namespace RaduiUjedApp
{
    partial class RegDetProg
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
            dataGridViewDet = new DataGridView();
            txtDescrip = new TextBox();
            txtCategoria = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label5 = new Label();
            lblHora = new Label();
            txtID = new TextBox();
            label4 = new Label();
            button6 = new Button();
            txtRuta = new TextBox();
            label6 = new Label();
            button5 = new Button();
            txtBxTiempo = new TextBoxTime();
            comboBoxCat = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDet).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDet
            // 
            dataGridViewDet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDet.Location = new Point(0, 337);
            dataGridViewDet.Name = "dataGridViewDet";
            dataGridViewDet.RowTemplate.Height = 25;
            dataGridViewDet.Size = new Size(798, 199);
            dataGridViewDet.TabIndex = 0;
            dataGridViewDet.CellClick += dataGridViewDet_CellClick;
            dataGridViewDet.RowPrePaint += dataGridViewDet_RowPrePaint;
            // 
            // txtDescrip
            // 
            txtDescrip.Anchor = AnchorStyles.Top;
            txtDescrip.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescrip.Location = new Point(182, 38);
            txtDescrip.Multiline = true;
            txtDescrip.Name = "txtDescrip";
            txtDescrip.Size = new Size(429, 59);
            txtDescrip.TabIndex = 1;
            // 
            // txtCategoria
            // 
            txtCategoria.Anchor = AnchorStyles.Top;
            txtCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCategoria.FormattingEnabled = true;
            txtCategoria.Location = new Point(182, 143);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(429, 29);
            txtCategoria.TabIndex = 2;
            txtCategoria.SelectedIndexChanged += txtCategoria_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(85, 76);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 5;
            label1.Text = "Descripción";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(99, 151);
            label2.Name = "label2";
            label2.Size = new Size(64, 21);
            label2.TabIndex = 6;
            label2.Text = "Carpeta";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(32, 215);
            label3.Name = "label3";
            label3.Size = new Size(144, 21);
            label3.TabIndex = 7;
            label3.Text = "Duración (minutos)";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(117, 287);
            button1.Name = "button1";
            button1.Size = new Size(141, 32);
            button1.TabIndex = 9;
            button1.Text = "Registrar programa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(264, 287);
            button2.Name = "button2";
            button2.Size = new Size(137, 32);
            button2.TabIndex = 10;
            button2.Text = "Actualizar programa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(412, 287);
            button3.Name = "button3";
            button3.Size = new Size(120, 32);
            button3.TabIndex = 11;
            button3.Text = "Eliminar programa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top;
            button4.BackColor = Color.Orange;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(630, 38);
            button4.Name = "button4";
            button4.Size = new Size(151, 36);
            button4.TabIndex = 12;
            button4.Text = "Volver a cartas";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(330, 9);
            label5.Name = "label5";
            label5.Size = new Size(109, 25);
            label5.TabIndex = 14;
            label5.Text = "Programas";
            // 
            // lblHora
            // 
            lblHora.Anchor = AnchorStyles.Top;
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblHora.Location = new Point(124, 255);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(52, 21);
            lblHora.TabIndex = 17;
            lblHora.Text = "label6";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.Enabled = false;
            txtID.Location = new Point(50, 38);
            txtID.Name = "txtID";
            txtID.Size = new Size(50, 23);
            txtID.TabIndex = 19;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(26, 46);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 20;
            label4.Text = "ID";
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top;
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(539, 287);
            button6.Name = "button6";
            button6.Size = new Size(153, 32);
            button6.TabIndex = 21;
            button6.Text = "Limpiar formulario";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // txtRuta
            // 
            txtRuta.Anchor = AnchorStyles.Top;
            txtRuta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRuta.Location = new Point(182, 178);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(429, 29);
            txtRuta.TabIndex = 22;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(137, 186);
            label6.Name = "label6";
            label6.Size = new Size(39, 21);
            label6.TabIndex = 6;
            label6.Text = "URL";
            label6.Click += label6_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(630, 143);
            button5.Name = "button5";
            button5.Size = new Size(100, 29);
            button5.TabIndex = 23;
            button5.Text = "Examinar...";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // txtBxTiempo
            // 
            txtBxTiempo.Anchor = AnchorStyles.Top;
            txtBxTiempo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBxTiempo.Location = new Point(182, 215);
            txtBxTiempo.Name = "txtBxTiempo";
            txtBxTiempo.Size = new Size(429, 29);
            txtBxTiempo.TabIndex = 24;
            txtBxTiempo.Text = "0m0s";
            // 
            // comboBoxCat
            // 
            comboBoxCat.Anchor = AnchorStyles.Top;
            comboBoxCat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxCat.FormattingEnabled = true;
            comboBoxCat.Location = new Point(182, 106);
            comboBoxCat.Name = "comboBoxCat";
            comboBoxCat.Size = new Size(429, 29);
            comboBoxCat.TabIndex = 2;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(99, 112);
            label7.Name = "label7";
            label7.Size = new Size(77, 21);
            label7.TabIndex = 6;
            label7.Text = "Categoría";
            // 
            // RegDetProg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 533);
            Controls.Add(txtBxTiempo);
            Controls.Add(button5);
            Controls.Add(txtRuta);
            Controls.Add(button6);
            Controls.Add(label4);
            Controls.Add(txtID);
            Controls.Add(lblHora);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxCat);
            Controls.Add(txtCategoria);
            Controls.Add(txtDescrip);
            Controls.Add(dataGridViewDet);
            Name = "RegDetProg";
            Text = "Programas";
            Load += RegDetProg_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtDescrip;
        private ComboBox txtCategoria;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label5;
        private Label lblHora;
        private DataGridView dataGridViewDet;
        private TextBox txtID;
        private Label label4;
        private Button button6;
        private TextBox txtRuta;
        private Label label6;
        private Button button5;
        private TextBoxTime txtBxTiempo;
        private ComboBox comboBoxCat;
        private Label label7;
    }
}