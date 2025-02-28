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
            numericUpDown1 = new NumericUpDown();
            txtID = new TextBox();
            label4 = new Label();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDet
            // 
            dataGridViewDet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewDet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDet.Location = new Point(0, 284);
            dataGridViewDet.Name = "dataGridViewDet";
            dataGridViewDet.RowTemplate.Height = 25;
            dataGridViewDet.Size = new Size(798, 252);
            dataGridViewDet.TabIndex = 0;
            dataGridViewDet.CellClick += dataGridViewDet_CellClick;
            dataGridViewDet.RowPrePaint += dataGridViewDet_RowPrePaint;
            // 
            // txtDescrip
            // 
            txtDescrip.Anchor = AnchorStyles.Top;
            txtDescrip.Location = new Point(220, 82);
            txtDescrip.Multiline = true;
            txtDescrip.Name = "txtDescrip";
            txtDescrip.Size = new Size(375, 59);
            txtDescrip.TabIndex = 1;
            // 
            // txtCategoria
            // 
            txtCategoria.Anchor = AnchorStyles.Top;
            txtCategoria.FormattingEnabled = true;
            txtCategoria.Location = new Point(220, 147);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(375, 23);
            txtCategoria.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(145, 126);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 5;
            label1.Text = "Descripción";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(156, 155);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 6;
            label2.Text = "Categoría";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(104, 184);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 7;
            label3.Text = "Duración (minutos)";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Location = new Point(142, 243);
            button1.Name = "button1";
            button1.Size = new Size(141, 23);
            button1.TabIndex = 9;
            button1.Text = "Registrar programa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Location = new Point(289, 243);
            button2.Name = "button2";
            button2.Size = new Size(137, 23);
            button2.TabIndex = 10;
            button2.Text = "Actualizar programa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top;
            button3.Location = new Point(437, 243);
            button3.Name = "button3";
            button3.Size = new Size(120, 23);
            button3.TabIndex = 11;
            button3.Text = "Eliminar programa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top;
            button4.BackColor = Color.Orange;
            button4.Location = new Point(601, 52);
            button4.Name = "button4";
            button4.Size = new Size(143, 23);
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
            lblHora.Location = new Point(176, 209);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(38, 15);
            lblHora.TabIndex = 17;
            lblHora.Text = "label6";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top;
            numericUpDown1.Location = new Point(220, 176);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(375, 23);
            numericUpDown1.TabIndex = 18;
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.Enabled = false;
            txtID.Location = new Point(220, 53);
            txtID.Name = "txtID";
            txtID.Size = new Size(375, 23);
            txtID.TabIndex = 19;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(196, 61);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 20;
            label4.Text = "ID";
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top;
            button6.Location = new Point(564, 243);
            button6.Name = "button6";
            button6.Size = new Size(125, 23);
            button6.TabIndex = 21;
            button6.Text = "Limpiar formulario";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // RegDetProg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 533);
            Controls.Add(button6);
            Controls.Add(label4);
            Controls.Add(txtID);
            Controls.Add(numericUpDown1);
            Controls.Add(lblHora);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCategoria);
            Controls.Add(txtDescrip);
            Controls.Add(dataGridViewDet);
            Name = "RegDetProg";
            Text = "Programas";
            Load += RegDetProg_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDet).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private NumericUpDown numericUpDown1;
        private DataGridView dataGridViewDet;
        private TextBox txtID;
        private Label label4;
        private Button button6;
    }
}