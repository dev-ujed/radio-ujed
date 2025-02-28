namespace RaduiUjedApp
{
    partial class RegistrarCategoria
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
            txtDesc = new TextBox();
            txtRuta = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dataGridViewCategoria = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            txtID = new TextBox();
            label4 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategoria).BeginInit();
            SuspendLayout();
            // 
            // txtDesc
            // 
            txtDesc.Anchor = AnchorStyles.Top;
            txtDesc.Location = new Point(187, 98);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(453, 23);
            txtDesc.TabIndex = 0;
            // 
            // txtRuta
            // 
            txtRuta.Anchor = AnchorStyles.Top;
            txtRuta.Location = new Point(187, 127);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(453, 23);
            txtRuta.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(112, 106);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Descripción";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(150, 135);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 3;
            label2.Text = "Ruta";
            // 
            // dataGridViewCategoria
            // 
            dataGridViewCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategoria.Location = new Point(50, 217);
            dataGridViewCategoria.Name = "dataGridViewCategoria";
            dataGridViewCategoria.RowTemplate.Height = 25;
            dataGridViewCategoria.Size = new Size(699, 150);
            dataGridViewCategoria.TabIndex = 4;
            dataGridViewCategoria.CellClick += dataGridViewCategoria_CellClick;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Location = new Point(200, 175);
            button1.Name = "button1";
            button1.Size = new Size(124, 23);
            button1.TabIndex = 5;
            button1.Text = "Registrar categoría";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Location = new Point(330, 175);
            button2.Name = "button2";
            button2.Size = new Size(154, 23);
            button2.TabIndex = 6;
            button2.Text = "Actualizar categoría";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(327, 25);
            label3.Name = "label3";
            label3.Size = new Size(106, 25);
            label3.TabIndex = 9;
            label3.Text = "Categorías";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.Enabled = false;
            txtID.Location = new Point(187, 69);
            txtID.Name = "txtID";
            txtID.Size = new Size(453, 23);
            txtID.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(163, 77);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 11;
            label4.Text = "ID";
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top;
            button5.Location = new Point(490, 175);
            button5.Name = "button5";
            button5.Size = new Size(128, 23);
            button5.TabIndex = 12;
            button5.Text = "Limpiar formulario";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // RegistrarCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 427);
            Controls.Add(button5);
            Controls.Add(label4);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewCategoria);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtRuta);
            Controls.Add(txtDesc);
            Name = "RegistrarCategoria";
            Text = "RegistrarCategoria";
            Load += RegistrarCategoria_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategoria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDesc;
        private TextBox txtRuta;
        private Label label1;
        private Label label2;
        private DataGridView dataGridViewCategoria;
        private Button button1;
        private Button button2;
        private Label label3;
        private TextBox txtID;
        private Label label4;
        private Button button5;
    }
}