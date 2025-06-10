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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RaduiUjedApp
{
    public partial class VerProg : Form
    {
        private readonly string apiUrl = "http://192.168.10.176/programaciones";
        private readonly string apiUrlCat = "http://192.168.10.176/categorias";
        private List<detalles> programaciones; // Lista de programaciones
        private detalles detalleSeleccionado; // detalle seleccionado
        private List<Categoria> categorias; // Lista 

        public VerProg()
        {
            InitializeComponent();
            if (SesionUsuario.Nombre == null)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }
        private static VerProg instance;
        public static VerProg GetInstance(Form contendorPadre)
        {
            if (instance != null && !instance.IsDisposed)
            {
                instance.Close(); // Cierra la instancia previa si existe
            }

            instance = new VerProg();
            instance.MdiParent = contendorPadre;
            instance.FormBorderStyle = FormBorderStyle.None;
            instance.Dock = DockStyle.Fill;

            return instance;
        }
        private async void VerProg_Load(object sender, EventArgs e)
        {
            await CargarProgramaciones();
            await CargarCategorias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SesionUsuario.CerrarSesion();
            // Cierra la aplicación
            Application.Exit();
        }

        private async Task CargarProgramaciones()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<Programacion> prog = JsonConvert.DeserializeObject<List<Programacion>>(jsonResponse);

                        // Agregar la opción inicial
                        prog.Insert(0, new Programacion { u_ID = 0, u_DESC = "-- Seleccionar una opción --" });

                        // Llenar el ComboBox con las categorías
                        txtProg.DataSource = prog;
                        txtProg.DisplayMember = "u_FECHA";
                        txtProg.ValueMember = "u_ID";
                        txtProg.SelectedIndex = 0; // Establecer el ítem por defecto
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

        private async void txtProg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtProg.SelectedIndex > 0) // Evitar el ítem "Seleccionar una opción"
            {
                int selectedId = (int)txtProg.SelectedValue; // Obtener el ID seleccionado
                await CargarDatosEnDataGrid(selectedId); // Llamar API con el ID
            }
        }

        private async Task CargarDatosEnDataGrid(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"http://192.168.10.176/detalleprog/{id}"; // Suponiendo que la API usa ID en la URL
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<detalles> detalles = JsonConvert.DeserializeObject<List<detalles>>(jsonResponse);

                        // Llenar el DataGridView
                        dataGridView1.DataSource = detalles;

                        // Configurar el DataGridView
                        ConfigurarDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener los datos: " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);

            // Configurar DataGridView en modo de solo lectura
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false; // Evita filas vacías
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleccionar toda la fila

            // Verificar si la columna de botón ya existe para evitar duplicados
            if (dataGridView1.Columns["btnUbicacion"] == null)
            {
                // Crear la columna de botones
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
                {
                    HeaderText = "Acciones",
                    Text = "Abrir ubicación",
                    UseColumnTextForButtonValue = true,
                    Name = "btnUbicacion"
                };

                // Agregar la columna de botón al DataGridView
                dataGridView1.Columns.Add(btnCol);
            }

            // Configurar encabezados de columnas
            dataGridView1.Columns["hora"].HeaderText = "Hora de inicio";
            dataGridView1.Columns["u_DET_DES"].HeaderText = "Descripción de programación";
            dataGridView1.Columns["tiempo"].HeaderText = "Tiempo";

            // Formatear la columna "hora" para que muestre solo la hora
            dataGridView1.Columns["hora"].DefaultCellStyle.Format = "HH:mm:ss";

            // Ocultar columnas innecesarias
            dataGridView1.Columns["deT_ID"].Visible = false;
            dataGridView1.Columns["reG_ID"].Visible = false;
            dataGridView1.Columns["tipo_ID"].Visible = false;
            dataGridView1.Columns["tiempo"].Visible = false;
            dataGridView1.Columns["categoriaRuta"].Visible = false;
            dataGridView1.Columns["url"].Visible = false;

            //Habilita Saltos de Linea
            dataGridView1.Columns["u_DET_DES"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



            // Permitir que la columna de botones sea editable (clickeable)
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col is DataGridViewButtonColumn)
                {
                    col.ReadOnly = false;
                }
            }
            if (!dataGridView1.Columns.Contains("CategoriaDescripcion"))
            {
                DataGridViewTextBoxColumn categoriaCol = new DataGridViewTextBoxColumn
                {
                    Name = "CategoriaDescripcion",
                    HeaderText = "Categoría",
                    ReadOnly = true
                };

                dataGridView1.Columns.Add(categoriaCol);
            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["tipO_ID"].Value != null)
                {
                    int id = Convert.ToInt32(row.Cells["tipO_ID"].Value);
                    var categoria = this.categorias.FirstOrDefault(c => c.id == id);

                    if (categoria != null)
                    {
                        row.Cells["CategoriaDescripcion"].Value = categoria.descripcion;
                    }
                }
            }

            if (!dataGridView1.Columns.Contains("TiempoDescripcion"))
            {
                DataGridViewTextBoxColumn tiempoCol = new DataGridViewTextBoxColumn
                {
                    Name = "TiempoDescripcion",
                    HeaderText = "Tiempo '",
                    ReadOnly = true
                };

                dataGridView1.Columns.Add(tiempoCol);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
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



            if (dataGridView1.Columns.Contains("hora"))
            {
                dataGridView1.Columns["hora"].DisplayIndex = 0;
            }

            if (dataGridView1.Columns.Contains("tiempoDescripcion"))
            {
                dataGridView1.Columns["tiempoDescripcion"].DisplayIndex = 1;
            }
            if (dataGridView1.Columns.Contains("CategoriaDescripcion"))
            {
                dataGridView1.Columns["u_DET_DES"].DisplayIndex = 2;
            }
            if (dataGridView1.Columns.Contains("u_DET_DES"))
            {
                dataGridView1.Columns["CategoriaDescripcion"].DisplayIndex = 3;
            }
            dataGridView1.Columns["btnUbicacion"].DisplayIndex = dataGridView1.Columns.Count - 1;



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Validar que sea una celda válida
            {
                // Verificar si se hizo clic en la columna del botón
                if (dataGridView1.Columns[e.ColumnIndex].Name == "btnUbicacion")
                {
                    // Obtener la ruta de la celda correspondiente a la fila seleccionada
                    string ruta = dataGridView1.Rows[e.RowIndex].Cells["url"].Value?.ToString();

                    if (!string.IsNullOrEmpty(ruta)) // Verificar si la ruta no está vacía
                    {
                        try
                        {
                            // Abrir la ubicación con el explorador de Windows
                            System.Diagnostics.Process.Start("explorer.exe", ruta);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo abrir la ubicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La ruta no está definida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Alternar colores: filas impares de un color, filas pares de otro color
            if (e.RowIndex % 2 == 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(184, 224, 249); // Color para filas pares
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // Color para filas impares
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var formMenu = new formMenu();
            formMenu.Show();
            this.Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string contenido = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrEmpty(contenido))
                {
                    Clipboard.SetText(contenido);
                    MessageBox.Show("Contenido copiado: " + contenido, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La celda seleccionada está vacía.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var loginForm = new Form1();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
            this.Hide();
        }

        private async Task CargarCategorias()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrlCat);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        this.categorias = JsonConvert.DeserializeObject<List<Categoria>>(jsonResponse);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
