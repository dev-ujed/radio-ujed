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
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
            CambiarLabel(lb3);
            MostrarRegistroPro();

        }
        private Label labelSelecionado;
        private void button1_Click(object sender, EventArgs e)
        {
            // Redirige a la pantalla de registrar y modificar usuario
            usuarios();
            CambiarLabel(sender);
        }
        public void usuarios()
        {
            registroUsuario user = registroUsuario.GetInstance(this);
            user.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Redirige a la pantalla de registrar programación
            MostrarRegistroPro();
            CambiarLabel(sender);
        }
        public void MostrarRegistroPro()
        {
            RegistroProg registro = RegistroProg.GetInstance(this);
            registro.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Redirige a la pantalla de ver programación
            verProgrmacion();
            CambiarLabel(sender);
        }
        public void verProgrmacion()
        {
            VerProg ver = VerProg.GetInstance(this);
            ver.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SesionUsuario.CerrarSesion();
            // Cierra la aplicación
            var form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Redirige a la pantalla de registro de categorias
            categorias();
            CambiarLabel(sender);
        }
        public void categorias()
        {
            RegistrarCategoria cat = RegistrarCategoria.GetInstance(this);
            cat.Show();
        }
        public void CambiarLabel(object label)
        {
            var lb = (Label)label;
            lb.BackColor = Color.FromArgb(168, 127, 63);
            lb.ForeColor = Color.White;

            if (labelSelecionado != null && labelSelecionado != lb)
            {
                labelSelecionado.BackColor = Color.FromArgb(186, 0, 0);
                labelSelecionado.ForeColor = Color.White;
            }
            labelSelecionado = lb;


        }
    }
}
