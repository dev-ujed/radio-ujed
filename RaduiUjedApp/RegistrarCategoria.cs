﻿using Newtonsoft.Json;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RaduiUjedApp
{
    public partial class RegistrarCategoria : Form
    {
        private Categoria categoriaSeleccionado; // categoria seleccionado
        private List<Categoria> categorias; // Lista de categorias
        public RegistrarCategoria()
        {
            InitializeComponent();
            label4.Visible = false;
            label4.Visible = false;
        }
        private static RegistrarCategoria instance;
        public static RegistrarCategoria GetInstance(Form contendorPadre)
        {
            if (instance != null && !instance.IsDisposed)
            {
                instance.Close(); // Cierra la instancia previa si existe
            }

            instance = new RegistrarCategoria();
            instance.MdiParent = contendorPadre;
            instance.FormBorderStyle = FormBorderStyle.None;
            instance.Dock = DockStyle.Fill;

            return instance;
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

        private async void RegistrarCategoria_Load(object sender, EventArgs e)
        {
            // URL de la API
            string apiUrl = "http://192.168.10.176/categorias";

            // Obtener los datos de la API
            List<Categoria> categoria = await ObtenerCategoriaDesdeAPI(apiUrl);

            // Mostrar los datos en el DataGridView
            dataGridViewCategoria.DataSource = categoria;

            // Configurar el DataGridView
            ConfigurarDataGridView();

        }
        private void ConfigurarDataGridView()
        {

            // Cambiar los nombres de las columnas
            dataGridViewCategoria.Columns["id"].HeaderText = "ID";
            dataGridViewCategoria.Columns["usuariO_REG"].HeaderText = "Registrado por";
            dataGridViewCategoria.Columns["usuariO_MOD"].HeaderText = "Modificado por";
            dataGridViewCategoria.Columns["descripcion"].HeaderText = "Descripción";
            dataGridViewCategoria.Columns["ruta"].HeaderText = "Ruta";


            // Ocultar la columna de usuario (opcional)
            dataGridViewCategoria.Columns["id"].Visible = false;
            dataGridViewCategoria.Columns["usuariO_REG"].Visible = false;
            dataGridViewCategoria.Columns["usuariO_MOD"].Visible = false;
        }

        private async Task<List<Categoria>> ObtenerCategoriaDesdeAPI(string apiUrl)
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
                    categorias = JsonConvert.DeserializeObject<List<Categoria>>(json);

                    return categorias;
                }
                else
                {
                    MessageBox.Show("Error al cargar los datos de la API.");
                    return new List<Categoria>();
                }
            }
        }

        private void dataGridViewCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que se haya seleccionado una fila válida
            {
                // Obtener el usuario seleccionado
                categoriaSeleccionado = categorias[e.RowIndex];

                // Mostrar los datos en los controles de edición
                txtID.Text = categoriaSeleccionado.id.ToString();
                txtDesc.Text = categoriaSeleccionado.descripcion;
                txtRuta.Text = categoriaSeleccionado.ruta;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (categoriaSeleccionado != null)
            {
                // Actualizar los datos del usuario seleccionado
                categoriaSeleccionado.descripcion = txtDesc.Text;
                categoriaSeleccionado.ruta = txtRuta.Text;
                categoriaSeleccionado.usuariO_MOD = SesionUsuario.Usuario;

                if (string.IsNullOrWhiteSpace(txtDesc.Text) ||
                string.IsNullOrWhiteSpace(txtRuta.Text))
                {
                    MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                if (txtRuta.Text.Contains(":\\"))
                {


                    MessageBox.Show("Estás ingresando una ruta local. Por favor, usa rutas que comiencen con: 172.20.93.248 ", "Ruta inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    return;
                }
                // Enviar los datos actualizados a la API
                bool resultado = await ActualizarCategoriaEnAPI(categoriaSeleccionado);

                if (resultado)
                {
                    MessageBox.Show("Carpeta actualizada correctamente.");
                    await CargarCategorias(); // Recargar los datos en el DataGridView
                    await LimpiarForm();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el carpeta.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una carpeta para actualizar.");
            }
        }

        private async Task CargarCategorias()
        {
            string apiUrl = "http://192.168.10.176/categorias";
            categorias = await ObtenerCategoriaDesdeAPI(apiUrl);
            dataGridViewCategoria.DataSource = categorias;
        }

        private async Task LimpiarForm()
        {
            txtID.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtRuta.Text = string.Empty;

        }

        private async Task<bool> ActualizarCategoriaEnAPI(Categoria categoria)
        {
            try
            {
                // URL de la API para actualizar el usuario
                string apiUrl = $"http://192.168.10.176/actcategoria/{categoria.id}";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Serializar el objeto usuario a JSON
                    string json = JsonConvert.SerializeObject(categoria);
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
                        MessageBox.Show($"Error al actualizar carpeta: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el carpeta: {ex.Message}");
                return false;
            }
        }
        private async Task<bool> EliminarCategoriaEnAPI(int id)
        {
            try
            {
                // URL de la API para actualizar el usuario
                string apiUrl = $"http://192.168.10.176/borrarcat/{id}";

                using (HttpClient client = new HttpClient())
                {
                    var categoria = new Categoria();
                    string json = JsonConvert.SerializeObject(categoria);
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
                        MessageBox.Show($"Error al eliminar carpeta: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar  carpeta: {ex.Message}");
                return false;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtDesc.Text) ||
                string.IsNullOrWhiteSpace(txtRuta.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución del método
            }
            

            // Si contiene ":\", es una ruta local
            if (txtRuta.Text.Contains(":\\"))
            {
                
                
                MessageBox.Show("Estás ingresando una ruta local. Por favor, usa rutas que comiencen con: 172.20.93.248 ", "Ruta inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                return;
            }
            Categoria nuevoCategoria = new Categoria
            {
                // NO SE ENVÍA iD_USUARIO (se genera en la BD)
                descripcion = txtDesc.Text,
                ruta = txtRuta.Text,
                usuariO_REG = SesionUsuario.Usuario

            };

            if (await InsertarCategoriaEnAPI(nuevoCategoria))
            {
                await LimpiarForm(); // Limpiar formulario después de insertar
                await CargarCategorias(); // Recargar los datos en el DataGridView
            }
        }

        private async Task<bool> InsertarCategoriaEnAPI(Categoria categoria)
        {
            try
            {
                string apiUrl = "http://192.168.10.176/insertarcategoria";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Eliminar ID_USUARIO al serializar
                    string json = JsonConvert.SerializeObject(categoria, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore // Ignorar valores nulos
                    });

                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Carpeta insertada correctamente.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Error al insertar carpeta: {response.ReasonPhrase}");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el carpeta: {ex.Message}");
                return false;
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await LimpiarForm();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Categoria catSeleccionado = categorias.FirstOrDefault(c => c.id == 1);



            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecciona una carpeta";

                // Si la ruta no es null ni vacía, se usa; si no, se deja sin establecer
                if (!string.IsNullOrWhiteSpace(catSeleccionado?.ruta))
                {
                    folderDialog.SelectedPath = catSeleccionado.ruta;
                }

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = folderDialog.SelectedPath; // Guarda la carpeta seleccionada
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (categoriaSeleccionado == null || string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Selecciona una Categoria para eliminar.");
                return;
            }

           

            //se intenta eliminar el programa seleccionado
            bool resultado = await EliminarCategoriaEnAPI(categoriaSeleccionado.id);

            //si se eliminó correctamente:
            if (resultado)
            {
               
                MessageBox.Show("Categoria eliminada correctamente.");
                await CargarCategorias(); 
                await LimpiarForm();
            }
            else
            {
                MessageBox.Show("Error al eliminar  Categoria. Por favor intente más tarde.");
            }
        }
    }

    // Clase que representa una categoria
    public class Categoria
    {
        public int id { get; set; }       // Coincide con "id"
        public string usuariO_REG { get; set; }        // Coincide con "usuariO_REG"
        public string? usuariO_MOD { get; set; }       // Coincide con "usuariO_MOD"
        public string descripcion { get; set; }       // Coincide con "descripcion"
        public string ruta { get; set; }     // Coincide con "ruta"

    }
}
