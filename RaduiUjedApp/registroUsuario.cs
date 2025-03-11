using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // Asegúrate de instalar el paquete NuGet Newtonsoft.Json
using RaduiUjedApp.helpers;

namespace RaduiUjedApp
{
    public partial class registroUsuario : Form
    {
        private Usuario usuarioSeleccionado; // Usuario seleccionado
        private List<Usuario> usuarios; // Lista de usuarios
        public registroUsuario()
        {
            InitializeComponent();
        }
        
        private static registroUsuario instance;
        public static registroUsuario GetInstance(Form contendorPadre)
        {
            if (instance != null && !instance.IsDisposed)
            {
                instance.Close(); // Cierra la instancia previa si existe
            }

            instance = new registroUsuario();
            instance.MdiParent = contendorPadre;
            instance.FormBorderStyle = FormBorderStyle.None;
            instance.Dock = DockStyle.Fill;

            return instance;
        }
        private async void registroUsuario_Load(object sender, EventArgs e)
        {
            // URL de la API
            string apiUrl = "http://192.168.10.176/usuarios";

            // Obtener los datos de la API
            List<Usuario> usuarios = await ObtenerUsuariosDesdeAPI(apiUrl);

            // Mostrar los datos en el DataGridView
            dataGridViewUsuarios.DataSource = usuarios;

            // Configurar el DataGridView
            ConfigurarDataGridView();
            CargarRoles();
        }

        private void ConfigurarDataGridView()
        {
            // Cambiar los nombres de las columnas
            dataGridViewUsuarios.Columns["iD_USUARIO"].HeaderText = "ID";
            dataGridViewUsuarios.Columns["nombre"].HeaderText = "Nombre";
            dataGridViewUsuarios.Columns["paterno"].HeaderText = "Apellido paterno";
            dataGridViewUsuarios.Columns["materno"].HeaderText = "Apellido materno";
            dataGridViewUsuarios.Columns["roL_ID"].HeaderText = "Rol";
            dataGridViewUsuarios.Columns["u_USUARIO"].HeaderText = "Usuario";
            dataGridViewUsuarios.Columns["u_PASSWORD"].HeaderText = "Contraseña";

            // Ocultar la columna de contraseña (opcional)
            dataGridViewUsuarios.Columns["u_PASSWORD"].Visible = false;
        }

        private void CargarRoles()
        {
            // Lista de roles (puedes obtenerla desde una API)
            List<Rol> roles = new List<Rol>
                {
                    new Rol { Value = 0, Descripcion = "Seleccione un rol" },
                    new Rol { Value = 1, Descripcion = "Administrador" },
                    new Rol { Value = 2, Descripcion = "Operador" }
                };

            // Asignar la lista al ComboBox
            ComboRol.DataSource = roles;
            ComboRol.DisplayMember = "Descripcion"; // Texto visible
            ComboRol.ValueMember = "Value";         // Valor asociado
        }

        // Seleccionar el rol en el ComboBox
        private void SeleccionarRolEnComboBox(int rolID)
        {
            foreach (Rol rol in ComboRol.Items)
            {
                if (rol.Value == rolID)
                {
                    ComboRol.SelectedItem = rol;
                    break;
                }
            }
        }

        private async Task<List<Usuario>> ObtenerUsuariosDesdeAPI(string apiUrl)
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
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

                    return usuarios;
                }
                else
                {
                    MessageBox.Show("Error al cargar los datos de la API.");
                    return new List<Usuario>();
                }
            }
        }

        // Evento CellClick del DataGridView
        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que se haya seleccionado una fila válida
            {
                // Obtener el usuario seleccionado
                usuarioSeleccionado = usuarios[e.RowIndex];

                // Mostrar los datos en los controles de edición
                txtID.Text = usuarioSeleccionado.iD_USUARIO.ToString();
                txtNombre.Text = usuarioSeleccionado.nombre;
                txtPaterno.Text = usuarioSeleccionado.paterno;
                txtMaterno.Text = usuarioSeleccionado.materno;
                txtUsuario.Text = usuarioSeleccionado.u_USUARIO;
                txtPassword.Text = usuarioSeleccionado.u_PASSWORD;
                SeleccionarRolEnComboBox(usuarioSeleccionado.roL_ID);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var formMenu = new formMenu();
            formMenu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SesionUsuario.CerrarSesion();
            // Cierra la aplicación
            Application.Exit();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionado != null)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtPaterno.Text) ||
                    string.IsNullOrWhiteSpace(txtMaterno.Text) ||
                    string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                    // Actualizar los datos del usuario seleccionado
                usuarioSeleccionado.nombre = txtNombre.Text;
                usuarioSeleccionado.paterno = txtPaterno.Text;
                usuarioSeleccionado.materno = txtMaterno.Text;
                usuarioSeleccionado.u_USUARIO = txtUsuario.Text;
                usuarioSeleccionado.u_PASSWORD = txtPassword.Text;

                // Obtener el rol seleccionado en el ComboBox
                if (ComboRol.SelectedItem != null)
                {
                    Rol rolSeleccionado = (Rol)ComboRol.SelectedItem;
                    usuarioSeleccionado.roL_ID = rolSeleccionado.Value;
                }

                // Enviar los datos actualizados a la API
                bool resultado = await ActualizarUsuarioEnAPI(usuarioSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Usuario actualizado correctamente.");
                    await CargarUsuarios(); // Recargar los datos en el DataGridView
                    await LimpiarForm();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el usuario.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un usuario para actualizar.");
            }
        }

        private async Task CargarUsuarios()
        {
            string apiUrl = "http://192.168.10.176/usuarios";
            usuarios = await ObtenerUsuariosDesdeAPI(apiUrl);
            dataGridViewUsuarios.DataSource = usuarios;
        }

        private async Task LimpiarForm()
        {
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPaterno.Text = string.Empty;
            txtMaterno.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            // Seleccionar la primera opción del ComboBox
            ComboRol.SelectedIndex = 0;
        }

        private async Task<bool> InsertarUsuarioEnAPI(Usuario usuario)
        {
            try
            {
                string apiUrl = "http://192.168.10.176/insertarusuario";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Eliminar ID_USUARIO al serializar
                    string json = JsonConvert.SerializeObject(usuario, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore // Ignorar valores nulos
                    });

                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario insertado correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Error al insertar usuario: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el usuario: {ex.Message}");
                return false;
            }
        }


        private async Task<bool> ActualizarUsuarioEnAPI(Usuario usuario)
        {
            try
            {
                // URL de la API para actualizar el usuario
                string apiUrl = $"http://192.168.10.176/actusuarios/{usuario.iD_USUARIO}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Serializar el objeto usuario a JSON
                    string json = JsonConvert.SerializeObject(usuario);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Enviar solicitud PUT a la API
                    HttpResponseMessage response = await client.PatchAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {

                        return true; // Actualización exitosa

                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar usuario: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}");
                return false;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (
                 string.IsNullOrWhiteSpace(txtNombre.Text) ||
                 string.IsNullOrWhiteSpace(txtPaterno.Text) ||
                 string.IsNullOrWhiteSpace(txtMaterno.Text) ||
                 string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                 string.IsNullOrWhiteSpace(txtPassword.Text) ||
                 ComboRol.SelectedIndex == 0
                )
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución del método
            }

            Usuario nuevoUsuario = new Usuario
            {
                // NO SE ENVÍA iD_USUARIO (se genera en la BD)
                nombre = txtNombre.Text,
                paterno = txtPaterno.Text,
                materno = txtMaterno.Text,
                roL_ID = Convert.ToInt32(ComboRol.SelectedValue),
                u_USUARIO = txtUsuario.Text,
                u_PASSWORD = txtPassword.Text
            };

            if (await InsertarUsuarioEnAPI(nuevoUsuario))
            {
                await LimpiarForm(); // Limpiar formulario después de insertar
                await CargarUsuarios(); // Recargar los datos en el DataGridView
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await LimpiarForm(); // Limpiar formulario 
        }
    }

    // Clase que representa un usuario
    public class Usuario
    {
        public int iD_USUARIO { get; set; }       // Coincide con "iD_USUARIO"
        public string nombre { get; set; }        // Coincide con "nombre"
        public string paterno { get; set; }       // Coincide con "paterno"
        public string materno { get; set; }       // Coincide con "materno"
        public int roL_ID { get; set; }           // Coincide con "roL_ID"
        public string u_USUARIO { get; set; }     // Coincide con "u_USUARIO"
        public string u_PASSWORD { get; set; }    // Coincide con "u_PASSWORD"
    }

    public class Rol
    {
        public int Value { get; set; }          // Valor del rol (por ejemplo, 1, 2, 3)
        public string Descripcion { get; set; } // Descripción del rol (por ejemplo, "Admin", "Usuario")
    }
}
