namespace RaduiUjedApp
{
    partial class registroUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewUsuarios = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            txtID = new TextBox();
            txtNombre = new TextBox();
            txtPaterno = new TextBox();
            txtMaterno = new TextBox();
            ComboRol = new ComboBox();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.AllowUserToDeleteRows = false;
            dataGridViewUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(81, 319);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.RowTemplate.Height = 25;
            dataGridViewUsuarios.Size = new Size(707, 207);
            dataGridViewUsuarios.TabIndex = 0;
            dataGridViewUsuarios.CellClick += dataGridViewUsuarios_CellClick;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Location = new Point(212, 290);
            button1.Name = "button1";
            button1.Size = new Size(152, 23);
            button1.TabIndex = 1;
            button1.Text = "Registrar usuario";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(389, 36);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 2;
            label1.Text = "Usuarios";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.Enabled = false;
            txtID.Location = new Point(270, 79);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(371, 23);
            txtID.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Top;
            txtNombre.Location = new Point(270, 108);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(371, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtPaterno
            // 
            txtPaterno.Anchor = AnchorStyles.Top;
            txtPaterno.Location = new Point(270, 137);
            txtPaterno.Name = "txtPaterno";
            txtPaterno.Size = new Size(371, 23);
            txtPaterno.TabIndex = 5;
            // 
            // txtMaterno
            // 
            txtMaterno.Anchor = AnchorStyles.Top;
            txtMaterno.Location = new Point(270, 166);
            txtMaterno.Name = "txtMaterno";
            txtMaterno.Size = new Size(371, 23);
            txtMaterno.TabIndex = 6;
            // 
            // ComboRol
            // 
            ComboRol.Anchor = AnchorStyles.Top;
            ComboRol.FormattingEnabled = true;
            ComboRol.Location = new Point(270, 195);
            ComboRol.Name = "ComboRol";
            ComboRol.Size = new Size(371, 23);
            ComboRol.TabIndex = 7;
            // 
            // txtUsuario
            // 
            txtUsuario.Anchor = AnchorStyles.Top;
            txtUsuario.Location = new Point(272, 223);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(369, 23);
            txtUsuario.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top;
            txtPassword.Location = new Point(271, 251);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(370, 23);
            txtPassword.TabIndex = 9;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Location = new Point(379, 290);
            button2.Name = "button2";
            button2.Size = new Size(159, 23);
            button2.TabIndex = 10;
            button2.Text = "Actualizar usuario";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(237, 82);
            label2.Name = "label2";
            label2.Size = new Size(21, 15);
            label2.TabIndex = 13;
            label2.Text = "ID:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(206, 116);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 14;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(209, 145);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 15;
            label4.Text = "Paterno:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(209, 174);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 16;
            label5.Text = "Materno:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(237, 203);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 17;
            label6.Text = "Rol:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(214, 231);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 18;
            label7.Text = "Usuario:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(195, 259);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 19;
            label8.Text = "Contraseña:";
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top;
            button5.Location = new Point(554, 290);
            button5.Name = "button5";
            button5.Size = new Size(126, 23);
            button5.TabIndex = 20;
            button5.Text = "Limpiar formulario";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // registroUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 540);
            Controls.Add(button5);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(ComboRol);
            Controls.Add(txtMaterno);
            Controls.Add(txtPaterno);
            Controls.Add(txtNombre);
            Controls.Add(txtID);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridViewUsuarios);
            Name = "registroUsuario";
            Text = "registroUsuario";
            Load += registroUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewUsuarios;
        private Button button1;
        private Label label1;
        private TextBox txtID;
        private TextBox txtNombre;
        private TextBox txtPaterno;
        private TextBox txtMaterno;
        private ComboBox ComboRol;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button button2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button5;
    }
}