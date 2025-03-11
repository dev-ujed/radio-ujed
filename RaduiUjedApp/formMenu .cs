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
        private Form formularioActual;

        private void AbrirFormulario(Form nuevoFormulario)
        {
            if (formularioActual != null && !formularioActual.IsDisposed)
            {
                formularioActual.Close(); 
            }

            formularioActual = nuevoFormulario;
            formularioActual.MdiParent = this; 
            formularioActual.FormBorderStyle = FormBorderStyle.None;
            formularioActual.Dock = DockStyle.Fill;
            formularioActual.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Redirige a la pantalla de registrar y modificar usuario
            AbrirFormulario(new registroUsuario());
            CambiarLabel(sender);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            // Redirige a la pantalla de registrar programación
            AbrirFormulario(new RegistroProg());
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
            AbrirFormulario(new VerProg());
            CambiarLabel(sender);
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
            AbrirFormulario(new RegistrarCategoria());
            CambiarLabel(sender);
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
