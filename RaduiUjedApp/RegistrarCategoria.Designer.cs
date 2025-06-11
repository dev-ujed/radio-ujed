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
            button3 = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategoria).BeginInit();
            SuspendLayout();
            // 
            // txtDesc
            // 
            txtDesc.Anchor = AnchorStyles.Top;
            txtDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDesc.Location = new Point(240, 63);
            txtDesc.Margin = new Padding(4);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(581, 140);
            txtDesc.TabIndex = 0;
            // 
            // txtRuta
            // 
            txtRuta.Anchor = AnchorStyles.Top;
            txtRuta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRuta.Location = new Point(240, 213);
            txtRuta.Margin = new Padding(4);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(581, 29);
            txtRuta.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(144, 183);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 2;
            label1.Text = "Descripción";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(193, 224);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(42, 21);
            label2.TabIndex = 3;
            label2.Text = "Ruta";
            // 
            // dataGridViewCategoria
            // 
            dataGridViewCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategoria.Location = new Point(67, 339);
            dataGridViewCategoria.Margin = new Padding(4);
            dataGridViewCategoria.Name = "dataGridViewCategoria";
            dataGridViewCategoria.RowTemplate.Height = 25;
            dataGridViewCategoria.Size = new Size(899, 210);
            dataGridViewCategoria.TabIndex = 4;
            dataGridViewCategoria.CellClick += dataGridViewCategoria_CellClick;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(174, 270);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(159, 32);
            button1.TabIndex = 5;
            button1.Text = "Registrar carpetas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(347, 270);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(198, 32);
            button2.TabIndex = 6;
            button2.Text = "Actualizar carpetas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(485, 29);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 9;
            label3.Text = "Carpetas";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.Enabled = false;
            txtID.Location = new Point(240, 97);
            txtID.Margin = new Padding(4);
            txtID.Name = "txtID";
            txtID.Size = new Size(581, 29);
            txtID.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(210, 112);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(25, 21);
            label4.TabIndex = 11;
            label4.Text = "ID";
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(727, 270);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(165, 32);
            button5.TabIndex = 12;
            button5.Text = "Limpiar formulario";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(831, 203);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(96, 48);
            button3.TabIndex = 13;
            button3.Text = "Examinar...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Top;
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.Location = new Point(557, 270);
            btnEliminar.Margin = new Padding(4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(155, 32);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar carpeta";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // RegistrarCategoria
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 598);
            Controls.Add(txtDesc);
            Controls.Add(button3);
            Controls.Add(button5);
            Controls.Add(label4);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(btnEliminar);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewCategoria);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtRuta);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
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
        private Button button3;
        private Button btnEliminar;
    }
}