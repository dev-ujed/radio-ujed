using Newtonsoft.Json;
using RaduiUjedApp.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaduiUjedApp
{
    public partial class RegistroProg : Form
    {
        private Programacion prograSeleccionado; // programacion seleccionado
        private List<Programacion> programaciones; // Lista de programaciones
        public RegistroProg()
        {
            InitializeComponent();
        }
        private static RegistroProg instance;
        public static RegistroProg GetInstance(Form contendorPadre)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new RegistroProg();
                instance.MdiParent = contendorPadre;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form formMenu = this.MdiParent;
            RegistroProg registro = RegistroProg.GetInstance(formMenu);
            registro.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SesionUsuario.CerrarSesion();
            // Cierra la aplicación
            Application.Exit();
        }

        private async void RegistroProg_Load(object sender, EventArgs e)
        {
            // URL de la API
            string apiUrl = "http://192.168.10.176/programaciones";

            // Obtener los datos de la API
            List<Programacion> progra = await ObtenerProgramacionDesdeAPI(apiUrl);

            // Mostrar los datos en el DataGridView
            dataGridViewProgramacion.DataSource = progra;

            // Configurar DateTimePicker para solo capturar la hora
            txtHora.Format = DateTimePickerFormat.Time;
            txtHora.ShowUpDown = true;

            // Configurar el DataGridView
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewProgramacion.ReadOnly = true; // Hace todo el DataGridView de solo lectura

            // Crear la columna de botones
            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            btnCol.HeaderText = "";
            btnCol.Text = "Agregar programas";
            btnCol.UseColumnTextForButtonValue = true; // Mostrar "Detalles" en el botón
            btnCol.Name = "btnDetalles";



            // Cambiar los nombres de las columnas
            dataGridViewProgramacion.Columns["u_ID"].HeaderText = "ID";
            dataGridViewProgramacion.Columns["u_HORA"].HeaderText = "Hora";
            dataGridViewProgramacion.Columns["u_DESC"].HeaderText = "Descripción";
            dataGridViewProgramacion.Columns["u_OBSERVACION"].HeaderText = "Observaciones";
            dataGridViewProgramacion.Columns["u_FECHA"].HeaderText = "Fecha";


            // Formatear la columna de fecha para que muestre solo "dd/MM/yyyy"
            dataGridViewProgramacion.Columns["u_FECHA"].DefaultCellStyle.Format = "dd/MM/yyyy";
            // Formatear la columna "u_HORA" para que muestre solo la hora
            dataGridViewProgramacion.Columns["u_HORA"].DefaultCellStyle.Format = "HH:mm:ss";

            // Ocultar la columna de usuario (opcional)
            dataGridViewProgramacion.Columns["u_USUARIO"].Visible = false;
            // Agregar la columna de botón al DataGridView
            dataGridViewProgramacion.Columns.Add(btnCol);

            // Permitir solo la interacción con la columna de botón
            foreach (DataGridViewColumn col in dataGridViewProgramacion.Columns)
            {
                col.ReadOnly = !(col is DataGridViewButtonColumn);
            }

            //// Suscribir el evento de clic
            //dataGridViewProgramacion.CellContentClick += dataGridViewProgramacion_CellContentClick;

        }

        private async Task<List<Programacion>> ObtenerProgramacionDesdeAPI(string apiUrl)
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
                    programaciones = JsonConvert.DeserializeObject<List<Programacion>>(json);

                    return programaciones;
                }
                else
                {
                    MessageBox.Show("Error al cargar los datos de la API.");
                    return new List<Programacion>();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDesc.Text) ||
                string.IsNullOrWhiteSpace(txtObserv.Text) ||
                string.IsNullOrWhiteSpace(txtHora.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución del método
            }


            Programacion nuevoProg = new Programacion
            {
                // NO SE ENVÍA iD_USUARIO (se genera en la BD)
                u_DESC = txtDesc.Text,
                u_OBSERVACION = txtObserv.Text,
                u_HORA = txtHora.Value,
                u_USUARIO = SesionUsuario.Usuario,
                u_FECHA = txtFecha.Value

            };

            if (await InsertarProgramacionEnAPI(nuevoProg))
            {
                await LimpiarForm(); // Limpiar formulario después de insertar
                await CargarCategorias(); // Recargar los datos en el DataGridView
            }
        }

        private async Task CargarCategorias()
        {
            string apiUrl = "http://192.168.10.176/programaciones";
            programaciones = await ObtenerProgramacionDesdeAPI(apiUrl);
            dataGridViewProgramacion.DataSource = programaciones;
        }

        private async Task LimpiarForm()
        {
            txtID.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtObserv.Text = string.Empty;
            txtHora.Text = string.Empty;
            txtFecha.Value = DateTime.Now;

        }

        private async Task<bool> InsertarProgramacionEnAPI(Programacion progra)
        {
            try
            {
                string apiUrl = "http://192.168.10.176/insertarprogramacion";

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
                        MessageBox.Show("Carta de programación agregada correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Error al agregar programacion: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar  carta de programacion: {ex.Message}");
                return false;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (prograSeleccionado != null || txtID.Text != "")
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtDesc.Text) ||
                    string.IsNullOrWhiteSpace(txtObserv.Text) ||
                    string.IsNullOrWhiteSpace(txtHora.Text))
                {
                    MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detiene la ejecución del método
                }

                // Actualizar los datos del usuario seleccionado
                prograSeleccionado.u_ID = int.Parse(txtID.Text);
                prograSeleccionado.u_DESC = txtDesc.Text;
                prograSeleccionado.u_OBSERVACION = txtObserv.Text;
                prograSeleccionado.u_HORA = txtHora.Value;
                prograSeleccionado.u_FECHA = txtFecha.Value;


                // Enviar los datos actualizados a la API
                bool resultado = await ActualizarProgramacionEnAPI(prograSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Programación actualizada correctamente.");
                    await CargarCategorias(); // Recargar los datos en el DataGridView
                    await LimpiarForm();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el programación.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una carta de programación para actualizar.");
            }
        }

        private async Task<bool> ActualizarProgramacionEnAPI(Programacion progra)
        {
            try
            {
                // URL de la API para actualizar el usuario
                string apiUrl = $"http://192.168.10.176/actprogramacion/{progra.u_ID}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Serializar el objeto usuario a JSON
                    string json = JsonConvert.SerializeObject(progra);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar solicitud PUT a la API
                    HttpResponseMessage response = await client.PatchAsync(apiUrl, content);
                    //HttpResponseMessage response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {

                        return true; // Actualización exitosa

                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar programación: {response.ReasonPhrase}");
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


        private async Task<bool> EliminarProgramacionEnAPI(Programacion progra)
        {
            try
            {
                // URL de la API para actualizar el usuario
                string apiUrl = $"http://192.168.10.176/borrarprog/{progra.u_ID}";

                using (HttpClient client = new HttpClient())
                {
                    // Serializar el objeto usuario a JSON
                    string json = JsonConvert.SerializeObject(progra);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar solicitud Patch a la API
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

        private void dataGridViewProgramacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que se haya seleccionado una fila válida
            {
                // Obtener el usuario seleccionado
                prograSeleccionado = programaciones[e.RowIndex];

                // Mostrar los datos en los controles de edición
                txtID.Text = prograSeleccionado.u_ID.ToString();
                txtDesc.Text = prograSeleccionado.u_DESC;
                txtObserv.Text = prograSeleccionado.u_OBSERVACION;
                txtHora.Value = prograSeleccionado.u_HORA;
                txtFecha.Value = prograSeleccionado.u_FECHA;
            }

            // Verificar si se hizo clic en la columna del botón
            if (e.ColumnIndex == dataGridViewProgramacion.Columns["btnDetalles"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del registro seleccionado
                int idSeleccionado = Convert.ToInt32(dataGridViewProgramacion.Rows[e.RowIndex].Cells["u_ID"].Value);

                // Obtener el HORA del registro seleccionado
                // Obtener la hora como string
                string hora = dataGridViewProgramacion.Rows[e.RowIndex].Cells["u_HORA"].Value?.ToString();

                // Abrir el formulario de agregar detalles y pasarle el ID
                Form formMenu = this.MdiParent;
                RegDetProg registro = RegDetProg.GetInstance(formMenu, idSeleccionado, hora);
                registro.Show();
                this.Hide();
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (prograSeleccionado != null || txtID.Text != "")
            {
                //revisar si tiene programas no puede eliminar
                string apiUrl = $"http://192.168.10.176/detalleprog/{int.Parse(txtID.Text)}";
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET a la API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta como una cadena JSON
                        string json = await response.Content.ReadAsStringAsync();

                        // Deserializar el JSON en una lista de objetos (asegúrate de que el tipo sea correcto)
                        var datos = JsonConvert.DeserializeObject<List<object>>(json);

                        // Verificar si la lista tiene elementos
                        if (datos != null && datos.Count > 0)
                        {
                            MessageBox.Show("Esta carta de programación contiene programas registrados. Para proceder con su eliminación, es necesario eliminar los programas asociados previamente.");
                            return;
                        }
                        else
                        {
                            // Actualizar los datos del usuario seleccionado
                            prograSeleccionado.u_ID = int.Parse(txtID.Text);
                            prograSeleccionado.u_DESC = txtDesc.Text;
                            prograSeleccionado.u_OBSERVACION = txtObserv.Text;
                            prograSeleccionado.u_HORA = txtHora.Value;
                            prograSeleccionado.u_FECHA = txtFecha.Value;


                            // Enviar los datos actualizados a la API
                            bool resultado = await EliminarProgramacionEnAPI(prograSeleccionado);

                            if (resultado)
                            {
                                MessageBox.Show("Programación eliminada correctamente.");
                                await CargarCategorias(); // Recargar los datos en el DataGridView
                                await LimpiarForm();
                            }
                            else
                            {
                                MessageBox.Show("Error al eliminar  programación.");
                            }
                        }
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Actualizar los datos del usuario seleccionado
                        prograSeleccionado.u_ID = int.Parse(txtID.Text);
                        prograSeleccionado.u_DESC = txtDesc.Text;
                        prograSeleccionado.u_OBSERVACION = txtObserv.Text;
                        prograSeleccionado.u_HORA = txtHora.Value;
                        prograSeleccionado.u_FECHA = txtFecha.Value;


                        // Enviar los datos actualizados a la API
                        bool resultado = await EliminarProgramacionEnAPI(prograSeleccionado);

                        if (resultado)
                        {
                            MessageBox.Show("Programación eliminada correctamente.");
                            await CargarCategorias(); // Recargar los datos en el DataGridView
                            await LimpiarForm();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar  programación.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar los datos de la API. No fue posible eliminar la carta de programación.");
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Selecciona una carta de programación para actualizar.");
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await LimpiarForm();
        }
    }



    // Clase que representa una programacion
    public class Programacion
    {
        public int u_ID { get; set; }       // Coincide con "u_ID"
        public DateTime u_HORA { get; set; }   // Solo la hora (timestamp)
        //public string u_HORA { get; set; }        // Coincide con "u_HORA"
        public string u_DESC { get; set; }       // Coincide con "u_DESC"
        public string u_USUARIO { get; set; }       // Coincide con "u_USUARIO"
        public string? u_OBSERVACION { get; set; }       // Coincide con "u_OBSERVACION"
        public DateTime u_FECHA { get; set; }     // Coincide con "u_FECHA"

    }


}
