using RaduiUjedApp.helpers;
using RaduiUjedApp.models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace RaduiUjedApp
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient
            {   //http://192.168.10.176/categorias
                BaseAddress = new Uri("http://192.168.10.176") // URL de la API
            };     

        }


        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var request = new { NombreUsuario = txtUsuario.Text, Contraseña = txtContraseña.Text };
                var response = await _httpClient.PostAsJsonAsync("/login", request);

                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content.ReadFromJsonAsync<UsuarioModel>();

                    // Guardar los datos del usuario en la sesión
                    SesionUsuario.Id = usuario.Id;
                    SesionUsuario.Nombre = usuario.Nombre;
                    SesionUsuario.Paterno = usuario.Paterno;
                    SesionUsuario.Materno = usuario.Materno;
                    SesionUsuario.Rol = usuario.Rol;
                    SesionUsuario.Usuario = usuario.Usuario;

                    MessageBox.Show($"Bienvenido {SesionUsuario.Nombre}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide(); // Oculta el login en lugar de cerrarlo

                    Form siguienteForm;


                    if (usuario.Rol == 1)
                    {
                        siguienteForm = new formMenu();
                        siguienteForm.FormClosed += (s, args) => Application.Exit();
                    }
                    else
                    {
                        siguienteForm = new VerProg();
                        
                    }

                    siguienteForm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Si presiona Enter
            {
                e.SuppressKeyPress = true; // Evita el sonido de "beep"
                button1.PerformClick(); // Simula el clic en el botón de login
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            

            var verProgForm = new VerProg();

            this.Hide();

            // Verifica que está como invitado
            if (SesionUsuario.Nombre == null)
            {
                // Solo si es invitado, cerramos la app cuando se cierre VerProg
                verProgForm.FormClosed += (s, args) => Application.Exit();
            }

            verProgForm.Show();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = SystemColors.ControlText;

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = SystemColors.HotTrack;
        }
    }
}