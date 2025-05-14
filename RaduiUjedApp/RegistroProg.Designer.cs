namespace RaduiUjedApp
{
    partial class RegistroProg
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
            txtObserv = new TextBox();
            txtFecha = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dataGridViewProgramacion = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            txtID = new TextBox();
            label6 = new Label();
            button5 = new Button();
            txtHora = new DateTimePicker();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProgramacion).BeginInit();
            SuspendLayout();
            // 
            // txtDesc
            // 
            txtDesc.Anchor = AnchorStyles.Top;
            txtDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtDesc.Location = new Point(278, 140);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(342, 58);
            txtDesc.TabIndex = 0;
            // 
            // txtObserv
            // 
            txtObserv.Anchor = AnchorStyles.Top;
            txtObserv.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtObserv.Location = new Point(278, 204);
            txtObserv.Multiline = true;
            txtObserv.Name = "txtObserv";
            txtObserv.Size = new Size(342, 67);
            txtObserv.TabIndex = 1;
            // 
            // txtFecha
            // 
            txtFecha.Anchor = AnchorStyles.Top;
            txtFecha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtFecha.Location = new Point(277, 70);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(342, 29);
            txtFecha.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(180, 182);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 4;
            label1.Text = "Descripción";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(159, 250);
            label2.Name = "label2";
            label2.Size = new Size(112, 21);
            label2.TabIndex = 5;
            label2.Text = "Observaciones";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(165, 111);
            label3.Name = "label3";
            label3.Size = new Size(106, 21);
            label3.TabIndex = 6;
            label3.Text = "Hora de inicio";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(221, 76);
            label4.Name = "label4";
            label4.Size = new Size(50, 21);
            label4.TabIndex = 7;
            label4.Text = "Fecha";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(277, 24);
            label5.Name = "label5";
            label5.Size = new Size(301, 25);
            label5.TabIndex = 8;
            label5.Text = "Registrar carta de programación";
            // 
            // dataGridViewProgramacion
            // 
            dataGridViewProgramacion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProgramacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProgramacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProgramacion.Location = new Point(-9, 348);
            dataGridViewProgramacion.Name = "dataGridViewProgramacion";
            dataGridViewProgramacion.RowTemplate.Height = 25;
            dataGridViewProgramacion.Size = new Size(810, 263);
            dataGridViewProgramacion.TabIndex = 9;
            dataGridViewProgramacion.CellClick += dataGridViewProgramacion_CellClick;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = SystemColors.Control;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(133, 297);
            button1.Name = "button1";
            button1.Size = new Size(138, 32);
            button1.TabIndex = 10;
            button1.Text = "Registrar carta";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.BackColor = SystemColors.Control;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(277, 297);
            button2.Name = "button2";
            button2.Size = new Size(125, 32);
            button2.TabIndex = 11;
            button2.Text = "Actualizar carta";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top;
            txtID.Enabled = false;
            txtID.Location = new Point(59, 70);
            txtID.Name = "txtID";
            txtID.Size = new Size(64, 23);
            txtID.TabIndex = 14;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(35, 73);
            label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 15;
            label6.Text = "ID";
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top;
            button5.BackColor = SystemColors.Control;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.ActiveCaptionText;
            button5.Location = new Point(408, 297);
            button5.Name = "button5";
            button5.Size = new Size(116, 32);
            button5.TabIndex = 16;
            button5.Text = "Eliminar carta";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // txtHora
            // 
            txtHora.Anchor = AnchorStyles.Top;
            txtHora.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtHora.Location = new Point(277, 105);
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(342, 29);
            txtHora.TabIndex = 17;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top;
            button6.BackColor = Color.FromArgb(233, 236, 239);
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(527, 297);
            button6.Name = "button6";
            button6.Size = new Size(150, 32);
            button6.TabIndex = 18;
            button6.Text = "Limpiar formulario";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // RegistroProg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 610);
            Controls.Add(button6);
            Controls.Add(txtHora);
            Controls.Add(button5);
            Controls.Add(label6);
            Controls.Add(txtID);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewProgramacion);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtFecha);
            Controls.Add(txtObserv);
            Controls.Add(txtDesc);
            Name = "RegistroProg";
            Text = "Carta de Programación";
            Load += RegistroProg_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProgramacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDesc;
        private TextBox txtObserv;
        private DateTimePicker txtFecha;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dataGridViewProgramacion;
        private Button button1;
        private Button button2;
        private TextBox txtID;
        private Label label6;
        private Button button5;
        private DateTimePicker txtHora;
        private Button button6;
    }
}