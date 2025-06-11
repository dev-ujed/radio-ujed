using Newtonsoft.Json;
using RaduiUjedApp.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RaduiUjedApp
{
    public partial class RegDetProg : Form
    {
        private int idRegistro;
        private TimeSpan hora; // Se usa TimeSpan para manejar hora
        private readonly string apiUrl = "http://192.168.10.176/categorias";
        private readonly string apiUrlNew = "http://192.168.10.176/cat";
        private List<detalles> programaciones; // Lista de programaciones
        private List<Categoria> categorias; // Lista 
        private List<NewCategoria> newcategorias; // Lista 

        private TimeSpan ultimaHora;
        private int ultimaDuracion = 0;

        private detalles detalleSeleccionado; // detalle seleccionado


        private string nuevafecha;
        public RegDetProg(int id, string horaRecibida)
        {
            InitializeComponent();
            idRegistro = id;
            nuevafecha = horaRecibida;
            txtID.Visible = false;
            label4.Visible = false;

            try
            {
                if (!string.IsNullOrWhiteSpace(horaRecibida)) // Verificar si la cadena no está vacía
                {
                    // Mostrar en un MessageBox la cadena que estamos recibiendo
                    //MessageBox.Show("Fecha recibida: " + horaRecibida, "Debug");

                    // Extraer la parte de la hora (por ejemplo, "07:00:00 PM" o "23:00:00")
                    string horaString = ExtractHora(horaRecibida);

                    // Intentar convertir la hora a TimeSpan
                    if (TimeSpan.TryParse(horaString, out TimeSpan horaExtraida))
                    {
                        this.hora = horaExtraida; // Guardar la hora como TimeSpan
                    }
                    else
                    {
                        MessageBox.Show("Error al convertir la hora: Formato incorrecto.\nHora extraída: " + horaString);
                        this.hora = TimeSpan.Zero; // Valor por defecto si no se pudo convertir
                    }
                }
                else
                {
                    MessageBox.Show("Error: La fecha/hora está vacía.");
                    this.hora = TimeSpan.Zero;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al procesar la hora: " + ex.Message);
                this.hora = TimeSpan.Zero;
            }

            // Mostrar los datos en los controles
            //lblID.Text = "ID: " + idRegistro.ToString();
            lblHora.Text = "Hora: " + this.hora.ToString(@"hh\:mm\:ss");
            // Cargar datos de las categorias
            CargarNewCategorias();
            CargarCategorias();
        }
        private static RegDetProg instance;

        public static RegDetProg GetInstance(Form contenedorPadre, int id, string fechaHoraString)
        {
            if (instance != null && !instance.IsDisposed)
            {
                instance.Close(); // Cierra el formulario si ya existe
            }

            instance = new RegDetProg(id, fechaHoraString);
            instance.MdiParent = contenedorPadre;
            instance.FormBorderStyle = FormBorderStyle.None;
            instance.Dock = DockStyle.Fill;

            return instance;
        }

        // Método para extraer la hora de la cadena recibida
        private string ExtractHora(string fechaHoraString)
        {
            try
            {
                // Si la fecha y hora está en formato "dd/MM/yyyy hh:mm:ss tt", extraemos solo la hora
                var fechaHora = DateTime.Parse(fechaHoraString);
                return fechaHora.ToString("HH:mm:ss"); // Solo devuelve la parte de la hora (formato 24h)
            }
            catch (FormatException)
            {
                // Si el formato no es correcto, manejar el error
                MessageBox.Show("Formato de fecha no válido: " + fechaHoraString);
                return string.Empty;
            }
        }

        private async Task CargarNewCategorias()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrlNew);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        this.newcategorias = JsonConvert.DeserializeObject<List<NewCategoria>>(jsonResponse);

                        // Llenar el ComboBox con las categorías
                        comboBoxCat.DataSource = newcategorias;
                        comboBoxCat.DisplayMember = "descripcion";
                        comboBoxCat.ValueMember = "id_categoria";
                        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                        foreach (var categoria in this.newcategorias)
                        {
                            collection.Add(categoria.descripcion); // si descripcion es una propiedad pública
                        }

                        comboBoxCat.AutoCompleteCustomSource = collection;
                        comboBoxCat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBoxCat.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener las categorías: " + response.ReasonPhrase);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async Task CargarCategorias()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        this.categorias = JsonConvert.DeserializeObject<List<Categoria>>(jsonResponse);

                        // Llenar el ComboBox con las categorías
                        txtCategoria.DataSource = categorias;
                        txtCategoria.DisplayMember = "descripcion";
                        txtCategoria.ValueMember = "id";
                        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                        foreach (var categoria in this.categorias)
                        {
                            collection.Add(categoria.descripcion); // si descripcion es una propiedad pública
                        }

                        txtCategoria.AutoCompleteCustomSource = collection;
                        txtCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtCategoria.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener las categorías: " + response.ReasonPhrase);
                    }
                }

                if (this.ultimaHora != TimeSpan.Zero)
                {
                    lblHora.Text = "Hora: " + this.ultimaHora.ToString(@"hh\:mm\:ss");
                }
                else
                {
                    lblHora.Text = "Hora: " + this.hora.ToString(@"hh\:mm\:ss");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void RegDetProg_Load(object sender, EventArgs e)
        {
            await CargarCategorias();
            await CargarNewCategorias();    
            // URL de la API
            string apiUrl = $"http://192.168.10.176/detalleprog/{idRegistro}";
            // Obtener los datos de la API
            List<detalles> progra = await ObtenerDetProgramacionDesdeAPI(apiUrl);

            // Mostrar los datos en el DataGridView
            dataGridViewDet.DataSource = progra;

            // Configurar el DataGridView
            ConfigurarDataGridView();

        }

        private void ConfigurarDataGridView()
        {
            dataGridViewDet.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridViewDet.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12);


            // 🔹 Si no hay columnas, agregarlas manualmente para evitar errores
            if (dataGridViewDet.Columns.Count == 0)
            {
                dataGridViewDet.Columns.Add("hora", "Hora");
                dataGridViewDet.Columns.Add("u_DET_DES", "Descripción de programación");
                dataGridViewDet.Columns.Add("tiempo", "Tiempo");
            }

            // Configurar propiedades generales del DataGridView
            dataGridViewDet.ReadOnly = true;
            dataGridViewDet.AllowUserToAddRows = false;
            dataGridViewDet.AllowUserToDeleteRows = false;
            dataGridViewDet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 🔹 Agregar columna de botón si no existe
            if (!dataGridViewDet.Columns.Contains("btnUbicacion"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
                {
                    HeaderText = "Acciones",
                    Text = "Abrir ubicación",
                    UseColumnTextForButtonValue = true,
                    Name = "btnUbicacion"
                };

                dataGridViewDet.Columns.Add(btnCol);
            }

            // 🔹 Verificar que las columnas existen antes de configurarlas
            if (dataGridViewDet.Columns.Contains("hora"))
            {
                dataGridViewDet.Columns["hora"].HeaderText = "Hora de inicio";
                dataGridViewDet.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";
            }

            if (dataGridViewDet.Columns.Contains("u_DET_DES"))
            {
                dataGridViewDet.Columns["u_DET_DES"].HeaderText = "Descripción de programación";
                dataGridViewDet.Columns["u_DET_DES"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            if (dataGridViewDet.Columns.Contains("tiempo"))
            {
                dataGridViewDet.Columns["tiempo"].HeaderText = "Tiempo ' ";
            }


            if (!dataGridViewDet.Columns.Contains("CategoriaDescripcion"))
            {
                DataGridViewTextBoxColumn categoriaCol = new DataGridViewTextBoxColumn
                {
                    Name = "CategoriaDescripcion",
                    HeaderText = "Categoría",
                    ReadOnly = true
                };

                dataGridViewDet.Columns.Add(categoriaCol);
            }

            if (!dataGridViewDet.Columns.Contains("TiempoDescripcion"))
            {
                DataGridViewTextBoxColumn tiempoCol = new DataGridViewTextBoxColumn
                {
                    Name = "TiempoDescripcion",
                    HeaderText = "Tiempo '",
                    ReadOnly = true
                };

                dataGridViewDet.Columns.Add(tiempoCol);
            }


            //foreach (DataGridViewRow row in dataGridViewDet.Rows)
            //{
            //    if (row.Cells["tipO_ID"].Value != null)
            //    {
            //        int id = Convert.ToInt32(row.Cells["tipO_ID"].Value);
            //        var categoria = this.categorias.FirstOrDefault(c => c.id == id);
                    

            //        if (categoria != null)
            //        {
            //            row.Cells["CategoriaDescripcion"].Value = categoria.descripcion;
            //        }
            //    }
            //}


            foreach (DataGridViewRow row in dataGridViewDet.Rows)
            {
                if (row.Cells["newCategoria"].Value != null)
                {
                    row.Cells["CategoriaDescripcion"].Value = row.Cells["newCategoria"].Value;
                }
            }
            
            foreach (DataGridViewRow row in dataGridViewDet.Rows)
            {
                if (row.Cells["tiempo"].Value != null && int.TryParse(row.Cells["tiempo"].Value.ToString(), out int tiempoSegundos))
                {
                    var tiempoTotal = "";
                    int minutos = tiempoSegundos / 60;
                    int segundos = tiempoSegundos % 60;

                    if (minutos > 0)
                    {
                        tiempoTotal += $"{minutos}min";
                    }
                    if (segundos > 0)
                    {
                        tiempoTotal += $"{segundos}seg";
                    }

                    row.Cells["TiempoDescripcion"].Value = tiempoTotal;
                }
            }


            // 🔹 Ocultar columnas innecesarias si existen
            string[] columnasOcultar = { "deT_ID", "reG_ID", "categoriaRuta", "url", "tipO_ID", "tiempo", "cat_id", "newCategoria" };
            foreach (string columna in columnasOcultar)
            {
                if (dataGridViewDet.Columns.Contains(columna))
                {
                    dataGridViewDet.Columns[columna].Visible = false;
                }
            }

            // 🔹 Ajustar tamaño de las filas automáticamente
            dataGridViewDet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 🔹 Habilitar edición en la columna de botones
            foreach (DataGridViewColumn col in dataGridViewDet.Columns)
            {
                if (col is DataGridViewButtonColumn)
                {
                    col.ReadOnly = false;
                }
            }
            if (dataGridViewDet.Columns.Contains("u_DET_DES"))
            {
                dataGridViewDet.Columns["u_DET_DES"].DisplayIndex = 2;
            }

            if (dataGridViewDet.Columns.Contains("CategoriaDescripcion"))
            {
                dataGridViewDet.Columns["CategoriaDescripcion"].DisplayIndex = 3;
            }
            if (dataGridViewDet.Columns.Contains("tiempoDescripcion"))
            {
                dataGridViewDet.Columns["tiempoDescripcion"].DisplayIndex = 1;
            }
            if (dataGridViewDet.Columns.Contains("hora"))
            {
                dataGridViewDet.Columns["hora"].DisplayIndex = 0;
            }
            // 🔹 Mover la columna "Acciones" al final
            if (dataGridViewDet.Columns.Contains("btnUbicacion"))
            {
                dataGridViewDet.Columns["btnUbicacion"].DisplayIndex = dataGridViewDet.Columns.Count - 1;
            }
        }

        private async Task<List<detalles>> ObtenerDetProgramacionDesdeAPI(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                // Hacer la solicitud GET a la API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta como una cadena JSON
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserializar el JSON en una lista de objetos Usuario
                    programaciones = JsonConvert.DeserializeObject<List<detalles>>(json);
                    var ultimoPrograma = programaciones.OrderByDescending(p => p.hora).FirstOrDefault();

                    if (ultimoPrograma != null)
                    {
                        this.ultimaDuracion = ultimoPrograma.tiempo;
                        TimeSpan horaUltimoPrograma = ultimoPrograma.hora.TimeOfDay.Add(TimeSpan.FromSeconds(ultimaDuracion));
                        this.ultimaHora = horaUltimoPrograma;
                        lblHora.Text = "Hora: " + horaUltimoPrograma.ToString(@"hh\:mm\:ss");
                    }

                    return programaciones;
                }
                else
                {
                    //MessageBox.Show("Error al cargar los datos de la API.");
                    return new List<detalles>();
                }
            }
        }

        private async Task RefrescarDesdeAPI(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    programaciones = JsonConvert.DeserializeObject<List<detalles>>(json) ?? new List<detalles>();

                    dataGridViewDet.DataSource = null; // Limpia el DataGridView

                    if (programaciones.Count > 0)
                    {
                        dataGridViewDet.DataSource = programaciones;
                    }

                    ConfigurarDataGridView(); // 🔹 Configurar siempre después de asignar datos

                    dataGridViewDet.Refresh();
                }
                else
                {
                    dataGridViewDet.DataSource = null;
                    ConfigurarDataGridView();
                    dataGridViewDet.Refresh();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SesionUsuario.CerrarSesion();
            // Cierra la aplicación
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formMenu = this.MdiParent;
            RegistroProg registro = RegistroProg.GetInstance(formMenu);
            registro.Show();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (
                    string.IsNullOrWhiteSpace(txtDescrip.Text) ||
                    txtCategoria.SelectedIndex == null || string.IsNullOrWhiteSpace(txtRuta.Text)
                    )
                {
                    MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detiene la ejecución del método
                }

                //definir la hora de inicio del programa, si hay ultimaHora se usa esa, si no se usa la recibida al cargar el componente
                TimeSpan fechaInicioPrograma = (this.ultimaHora != TimeSpan.Zero && this.ultimaDuracion > 0)
                ? this.ultimaHora
                : this.hora;

                //obtener duración a guardar
                int minutos = int.Parse(txtBxTiempo.Text.Split('m')[0]);
                int segundos = int.Parse(txtBxTiempo.Text.Split('m')[1].Split('s')[0]);

                int tiempoTotal = minutos * 60 + segundos;
                int duracionPrograma = Convert.ToInt32(tiempoTotal);
                //calcular la hora de finalización
                this.ultimaHora = fechaInicioPrograma.Add(TimeSpan.FromSeconds(duracionPrograma));
                //se asigna la fecha de finalización al label de hora 
                lblHora.Text = "Hora: " + this.ultimaHora.ToString(@"hh\:mm\:ss");

                string fechaHoraString = nuevafecha; // La fecha recibida al construir el formulario
                                                     // Reemplazar "p. m." y "a. m." por "PM" y "AM"
                fechaHoraString = fechaHoraString.Replace(" p. m.", " PM").Replace(" a. m.", " AM");
                // Intentar convertir la fechaHoraString a DateTime en formato de 24 horas
                DateTime fechaHoraOriginal;
                if (DateTime.TryParseExact(fechaHoraString, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaHoraOriginal))
                {
                    // Sumamos la nueva hora (this.hora) a la fecha original
                    DateTime nuevaFechaHora = fechaHoraOriginal.Date.Add(fechaInicioPrograma);
                    //// Guardar la nueva fecha y hora en la base de datos
                    //GuardarFechaHoraEnBaseDeDatos(nuevaFechaHora);
                    //MessageBox.Show("Fecha y hora actualizada correctamente: " + nuevaFechaHora.ToString());
                    // Validar que los campos no estén vacíos
                    if (txtCategoria.SelectedIndex == -1)
                    {
                        MessageBox.Show("Por favor, seleccione una opción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (string.IsNullOrWhiteSpace(txtDescrip.Text))
                    {
                        MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Detiene la ejecución del método
                    }
                    if (string.IsNullOrWhiteSpace(comboBoxCat.Text))
                    {
                        MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Detiene la ejecución del método
                    }
                    DetProgra nuevoProg = new DetProgra
                    {
                        // NO SE ENVÍA iD_USUARIO (se genera en la BD)
                        reG_ID = idRegistro,
                        u_DET_DES = txtDescrip.Text,
                        tipO_ID = Convert.ToInt32(txtCategoria.SelectedValue),
                        tiempo = duracionPrograma,
                        hora = nuevaFechaHora,
                        usuariO_REG = SesionUsuario.Usuario,
                        fechA_REG = DateTime.Now,
                        url = txtRuta.Text,
                        caT_ID = Convert.ToInt32(comboBoxCat.SelectedValue),


                    };
                    if (await InsertarDetProgramacionEnAPI(nuevoProg))
                    {   // URL de la API
                        string apiUrl = $"http://192.168.10.176/detalleprog/{idRegistro}";
                        this.ultimaDuracion = duracionPrograma;

                        await LimpiarForm(); // Limpiar formulario después de insertar
                        await CargarCategorias(); // Recargar los datos en el DataGridView
                        await CargarNewCategorias();
                        await RefrescarDesdeAPI(apiUrl);
                        ConfigurarDataGridView();
                    }
                }
                else
                {
                    MessageBox.Show("Error al convertir la fecha. Formato incorrecto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private async Task<bool> InsertarDetProgramacionEnAPI(DetProgra progra)
        {
            try
            {
                string apiUrl = "http://192.168.10.176/insertardetprogramacion";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Eliminar ID_USUARIO al serializar
                    string json = JsonConvert.SerializeObject(progra, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore // Ignorar valores nulos
                    });

                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Programa agregado correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Error al agregar programa: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar  programa: {ex.Message}");
                return false;
            }
        }

        private async Task LimpiarForm()
        {
            txtID.Text = string.Empty;
            txtDescrip.Text = string.Empty;
            txtBxTiempo.Text = "0m0s";
            txtRuta.Text = string.Empty;
            // Seleccionar la primera opción del ComboBox
            txtCategoria.SelectedIndex = 0;
        }

        private void dataGridViewDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic no sea en el encabezado
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < dataGridViewDet.Columns.Count)
            {
                // Verifica que la fila esté dentro del rango de programaciones
                if (e.RowIndex < programaciones.Count)
                {
                    // Verifica si se hizo clic en la columna del botón
                    if (dataGridViewDet.Columns[e.ColumnIndex].Name == "btnUbicacion")
                    {
                        //string ruta = programaciones[e.RowIndex].categoriaRuta;
                        string ruta = programaciones[e.RowIndex].url;

                        if (!string.IsNullOrEmpty(ruta))
                        {
                            try
                            {
                                System.Diagnostics.Process.Start("explorer.exe", ruta);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al abrir la ubicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay una ruta válida para esta categoría.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        // Obtener el detalle seleccionado
                        detalleSeleccionado = programaciones[e.RowIndex];
                        // Mostrar los datos en los controles de edición
                        txtID.Text = detalleSeleccionado.deT_ID.ToString();
                        txtDescrip.Text = detalleSeleccionado.u_DET_DES;
                        var tiempoMostrar = int.Parse(detalleSeleccionado.tiempo.ToString());
                        int minutos = tiempoMostrar / 60;
                        int segundos = tiempoMostrar % 60;
                        txtBxTiempo.Text = $"{minutos}m{segundos}s";
                        SeleccionarCategoriaEnComboBox(detalleSeleccionado.tipO_ID);
                        SeleccionarNewCategoriaEnComboBox(detalleSeleccionado.newCategoria);
                        txtRuta.Text = detalleSeleccionado.url;
                    }
                }
            }
        }

        // Seleccionar el rol en el ComboBox
        private void SeleccionarCategoriaEnComboBox(int catID)
        {
            foreach (Categoria cat in txtCategoria.Items)
            {
                if (cat.id == catID)
                {
                    txtCategoria.SelectedItem = cat;
                    break;
                }
            }

        }
        private void SeleccionarNewCategoriaEnComboBox(string cateID)
        {
            foreach (NewCategoria cat in comboBoxCat.Items)
            {    
                if (cat.descripcion == cateID)
                {
                    comboBoxCat.SelectedItem = cat;
                    break;
                }
            }

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDescrip.Text) || txtCategoria.SelectedIndex == 0)
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que detalleSeleccionado no sea nulo
            if (detalleSeleccionado == null)
            {
                MessageBox.Show("Selecciona un programa para actualizar.");
                return;
            }

            // Obtener categoria seleccionada en el ComboBox
            if (txtCategoria.SelectedItem != null)
            {
                Categoria catSeleccionado = (Categoria)txtCategoria.SelectedItem;
                detalleSeleccionado.tipO_ID = catSeleccionado.id;
            }
            if (comboBoxCat.SelectedItem != null)
            {
                NewCategoria catSelec = (NewCategoria)comboBoxCat.SelectedItem;
                detalleSeleccionado.cat_id = catSelec.id_categoria;
            }


            var nuevaDescripción = txtDescrip.Text;
            int minutos = int.Parse(txtBxTiempo.Text.Split('m')[0]);
            int segundos = int.Parse(txtBxTiempo.Text.Split('m')[1].Split('s')[0]);

            int tiempoTotal = minutos * 60 + segundos;
            var nuevoTiempo = Convert.ToInt32(tiempoTotal);
            var nuevaRuta = txtRuta.Text;

            // Buscar el programa original
            var programaOriginal = programaciones.FirstOrDefault(p => p.deT_ID == detalleSeleccionado.deT_ID);

            // Validar que se haya encontrado un programa original
            if (programaOriginal == null)
            {
                MessageBox.Show("No se encontró el programa original.");
                return;
            }

            // Actualizar siempre sin revisar si el tiempo se modificó
            var programacionesDespues = programaciones.Where(p => p.hora > programaOriginal.hora).ToList();

            string fechaHoraString = nuevafecha; // La fecha recibida al construir el formulario

            // Reemplazar "p. m." y "a. m." por "PM" y "AM"
            fechaHoraString = fechaHoraString.Replace(" p. m.", " PM").Replace(" a. m.", " AM");

            // Intentar convertir la fechaHoraString a DateTime en formato de 24 horas
            DateTime fechaHoraOriginal;

            if (DateTime.TryParseExact(fechaHoraString, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaHoraOriginal))
            {
                DetProgra detProg = new DetProgra
                {
                    deT_ID = detalleSeleccionado.deT_ID,
                    reG_ID = detalleSeleccionado.reG_ID,
                    u_DET_DES = nuevaDescripción,
                    tipO_ID = detalleSeleccionado.tipO_ID,
                    tiempo = nuevoTiempo,
                    hora = detalleSeleccionado.hora,
                    usuariO_MOD = SesionUsuario.Usuario,
                    fechA_MOD = DateTime.Now,
                    url = nuevaRuta,
                    caT_ID = Convert.ToInt32(comboBoxCat.SelectedValue),

                };

                // Enviar los datos actualizados a la API
                bool resultado = await ActualizarDetEnAPI(detProg);

                if (resultado)
                {
                    TimeSpan horaFinalPrograma = detalleSeleccionado.hora.TimeOfDay.Add(TimeSpan.FromSeconds(nuevoTiempo));

                    for (int i = 0; i < programacionesDespues.Count; i++)
                    {
                        if (i == 0)
                        {
                            await actualizarProgramasDespues(programacionesDespues[i], horaFinalPrograma);
                        }
                        else
                        {
                            horaFinalPrograma = horaFinalPrograma.Add(TimeSpan.FromSeconds(programacionesDespues[i - 1].tiempo));
                            await actualizarProgramasDespues(programacionesDespues[i], horaFinalPrograma);
                        }
                    }

                    // Actualizar el formulario
                    await ActualizarFormulario();

                    var ultimoPrograma = programaciones.OrderByDescending(p => p.hora).FirstOrDefault();
                    this.ultimaHora = ultimoPrograma.hora.TimeOfDay.Add(TimeSpan.FromSeconds(ultimoPrograma.tiempo));
                    this.ultimaDuracion = ultimoPrograma.tiempo;
                    lblHora.Text = "Hora: " + this.ultimaHora.ToString(@"hh\:mm\:ss");

                    MessageBox.Show("Programa actualizado correctamente.");

                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro.");
                }
            }
        }

        private async Task ActualizarFormulario()
        {
            string apiUrl = $"http://192.168.10.176/detalleprog/{detalleSeleccionado.reG_ID}";
            await LimpiarForm(); // Limpiar formulario después de insertar
            await CargarCategorias(); // Recargar los datos en el DataGridView
            await CargarNewCategorias();
            await RefrescarDesdeAPI(apiUrl);
            ConfigurarDataGridView();

        }

        private async Task<bool> ActualizarDetEnAPI(DetProgra det)
        {
            try
            {
                // URL de la API para actualizar el usuario
                string apiUrl = $"http://192.168.10.176/actdet/{det.deT_ID}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Serializar el objeto usuario a JSON
                    string json = JsonConvert.SerializeObject(det);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar solicitud PUT a la API
                    HttpResponseMessage response = await client.PatchAsync(apiUrl, content);
                    //HttpResponseMessage response = await client.PutAsync(apiUrl, content);
                    Console.WriteLine(response.Content);
                    if (response.IsSuccessStatusCode)
                    {

                        return true; // Actualización exitosa

                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        dynamic errorDetails = JsonConvert.DeserializeObject(errorResponse);
                        MessageBox.Show($"Error: {errorDetails.title}\nDetalles: {errorDetails.errors}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar  programación: {ex.Message}");
                return false;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (detalleSeleccionado == null || string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Selecciona un programa para eliminar.");
                return;
            }

            // Buscar el programa anterior 
            var programaAnterior = programaciones
                .Where(p => p.hora < detalleSeleccionado.hora)
                .OrderByDescending(p => p.hora)
                .FirstOrDefault();

            // Buscar si hay programas después ordenados por hora
            var programacionesDespues = programaciones
                .Where(p => p.hora > detalleSeleccionado.hora)
                .OrderBy(p => p.hora)
                .ToList();

            //se intenta eliminar el programa seleccionado
            bool resultado = await EliminarDetProgramacionEnAPI(detalleSeleccionado.deT_ID);

            //si se eliminó correctamente:
            if (resultado)
            {
                //remover prorgrama eliminardo de la lista local
                programaciones.Remove(detalleSeleccionado);

                TimeSpan horaFinalPrograma = this.hora;
                //si hay programa anterior se usa este como hora final
                if (programaAnterior != null)
                {
                    horaFinalPrograma = programaAnterior.hora.TimeOfDay.Add(TimeSpan.FromSeconds(programaAnterior.tiempo));
                }

                // Reajustar horas de los programas siguientes
                for (int i = 0; i < programacionesDespues.Count; i++)
                {
                    if (i > 0)
                        horaFinalPrograma = horaFinalPrograma.Add(TimeSpan.FromSeconds(programacionesDespues[i - 1].tiempo));

                    await actualizarProgramasDespues(programacionesDespues[i], horaFinalPrograma);
                }

                await ActualizarFormulario();
                MessageBox.Show("Programación eliminada correctamente.");
                var ultimoPrograma = programaciones.OrderByDescending(p => p.hora).FirstOrDefault();

                if (ultimoPrograma != null)
                {
                    this.ultimaHora = ultimoPrograma.hora.TimeOfDay.Add(TimeSpan.FromSeconds(ultimoPrograma.tiempo));
                    this.ultimaDuracion = ultimoPrograma.tiempo;
                    lblHora.Text = $"Hora: {this.ultimaHora:hh\\:mm\\:ss}";
                }
                else
                {
                    this.ultimaHora = TimeSpan.Zero;
                    this.ultimaDuracion = 0;
                    lblHora.Text = $"Hora: {this.hora:hh\\:mm\\:ss}";
                }
            }
            else
            {
                MessageBox.Show("Error al eliminar  programación. Por favor intente más tarde.");
            }
        }

        private async Task<bool> EliminarDetProgramacionEnAPI(int id)
        {
            try
            {
                // URL de la API para actualizar el usuario
                string apiUrl = $"http://192.168.10.176/borrardetprog/{id}";

                using (HttpClient client = new HttpClient())
                {
                    var progra = new DetProgra();
                    string json = JsonConvert.SerializeObject(progra);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar solicitud PUT a la API
                    HttpResponseMessage response = await client.PatchAsync(apiUrl, content);
                    //HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {

                        return true; // Eliminación exitosa

                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar programación: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar  programación: {ex.Message}");
                return false;
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await LimpiarForm(); // Limpiar formulario
        }

        private void dataGridViewDet_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Alternar colores: filas impares de un color, filas pares de otro color
            if (e.RowIndex % 2 == 0)
            {
                dataGridViewDet.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray; // Color para filas pares
            }
            else
            {
                dataGridViewDet.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // Color para filas impares
            }
        }

        private async Task actualizarProgramasDespues(detalles Programa, TimeSpan horaInicioPrograma)
        {

            string fechaHoraString = nuevafecha; // La fecha recibida al construir el formulario

            // Reemplazar "p. m." y "a. m." por "PM" y "AM"
            fechaHoraString = fechaHoraString.Replace(" p. m.", " PM").Replace(" a. m.", " AM");

            DateTime fechaHoraOriginal;

            if (DateTime.TryParseExact(fechaHoraString, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaHoraOriginal))
            {
                // Sumamos la nueva hora (this.horaInicio) a la fecha original
                DateTime nuevaFechaHora = fechaHoraOriginal.Date.Add(horaInicioPrograma);
                
                var idcat = newcategorias.FirstOrDefault(c => c.descripcion == Programa.newCategoria);

                DetProgra detProg = new DetProgra
                {
                    // NO SE ENVÍA iD_USUARIO (se genera en la BD)
                    deT_ID = Programa.deT_ID,
                    reG_ID = Programa.reG_ID,
                    u_DET_DES = Programa.u_DET_DES,
                    tipO_ID = Programa.tipO_ID,
                    tiempo = Programa.tiempo,
                    hora = nuevaFechaHora,
                    usuariO_MOD = SesionUsuario.Usuario,
                    fechA_MOD = DateTime.Now,
                    url = Programa.url,
                    caT_ID = int.Parse(idcat.id_categoria.ToString())


                };

                // Enviar los datos actualizados a la API
                bool resultado = await ActualizarDetEnAPI(detProg);

                if (resultado)
                {
                    string apiUrl = $"http://192.168.10.176/detalleprog/{Programa.reG_ID}";
                    await CargarCategorias();
                    await CargarNewCategorias();
                    await RefrescarDesdeAPI(apiUrl);
                    ConfigurarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro.");
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (txtCategoria.SelectedItem != null)
            {
                Categoria categoriaSeleccionada = (Categoria)txtCategoria.SelectedItem;
                string rutaSeleccionada = categoriaSeleccionada.ruta;
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    if (!string.IsNullOrEmpty(rutaSeleccionada) && Directory.Exists(rutaSeleccionada))
                    {
                        rutaSeleccionada += "\\";
                        folderDialog.SelectedPath = rutaSeleccionada; // Establece la carpeta inicial
                    }
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtRuta.Text = folderDialog.SelectedPath;
                    }
                }
            }
        }

        private void txtCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            Categoria categoriaSeleccionada = (Categoria)txtCategoria.SelectedItem;
            string rutaSeleccionada = categoriaSeleccionada.ruta;
            txtRuta.Text = rutaSeleccionada; // Establece la ruta de la categoría seleccionada
        }
    }


    public class DetProgra
    {
        public int deT_ID { get; set; }       // Coincide con "deT_ID"

        public int reG_ID { get; set; }       // Coincide con "deT_ID"
        public string u_DET_DES { get; set; }       // Coincide con "u_DET_DES"
        public int tipO_ID { get; set; }       // Coincide con "tipO_ID"
        public int tiempo { get; set; }       // Coincide con "tiempo"
        public DateTime hora { get; set; }   // Solo la hora (timestamp)
        public string? usuariO_REG { get; set; }       // Coincide con "usuariO_REG"
        public DateTime? fechA_REG { get; set; }     // Coincide con "fechA_REG"
        public string? usuariO_MOD { get; set; }       // Coincide con "usuariO_REG"
        public DateTime? fechA_MOD { get; set; }     // Coincide con "fechA_REG"

        public string url { get; set; }       // Coincide con "url"
        public int caT_ID { get; set; }
    }

    public class detalles
    {
        public int deT_ID { get; set; }
        public int reG_ID { get; set; }
        public string u_DET_DES { get; set; }
        public int tipO_ID { get; set; }
        public int tiempo { get; set; }
        public DateTime hora { get; set; }
        public string categoriaRuta { get; set; }

        public string url { get; set; }
        public int cat_id { get; set; }
        public string newCategoria { get; set; }


    }
    public class NewCategoria
    {
        public int id_categoria { get; set; }       // Coincide con "id"
        public string descripcion { get; set; }       // Coincide con "descripcion"
    }
}
