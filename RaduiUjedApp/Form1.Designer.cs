﻿namespace RaduiUjedApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            bindingSource1 = new BindingSource(components);
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.Location = new Point(298, 127);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(212, 29);
            txtUsuario.TabIndex = 0;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtContraseña.Location = new Point(298, 193);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(212, 29);
            txtContraseña.TabIndex = 1;
            txtContraseña.UseSystemPasswordChar = true;
            txtContraseña.KeyDown += txtContraseña_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(298, 103);
            label1.Name = "label1";
            label1.Size = new Size(67, 21);
            label1.TabIndex = 2;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(298, 169);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 3;
            label2.Text = "Contraseña:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(298, 243);
            button1.Margin = new Padding(3, 3, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(212, 41);
            button1.TabIndex = 4;
            button1.Text = "Iniciar sesión";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_ClickAsync;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(232, 76, 61);
            label3.Location = new Point(247, 31);
            label3.Name = "label3";
            label3.Size = new Size(320, 54);
            label3.TabIndex = 5;
            label3.Text = "RADIO UNIVERSIDAD 100.5";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Location = new Point(247, 88);
            panel2.Name = "panel2";
            panel2.Size = new Size(320, 1);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Location = new Point(247, 338);
            panel3.Name = "panel3";
            panel3.Size = new Size(320, 1);
            panel3.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.logoru;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(225, 364);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(247, 303);
            label4.Name = "label4";
            label4.Size = new Size(320, 32);
            label4.TabIndex = 10;
            label4.Text = "Ver cartas de programación";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            label4.MouseEnter += label4_MouseEnter;
            label4.MouseLeave += label4_MouseLeave;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 364);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private BindingSource bindingSource1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label label4;
    }
}