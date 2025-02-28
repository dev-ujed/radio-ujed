namespace RaduiUjedApp
{
    partial class formMenu
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
            panel2 = new Panel();
            label2 = new Label();
            panel1 = new Panel();
            lb1 = new Label();
            lb2 = new Label();
            label3 = new Label();
            lb3 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(58, 65, 72);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(992, 49);
            panel2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(19, 11);
            label2.Name = "label2";
            label2.Size = new Size(298, 27);
            label2.TabIndex = 0;
            label2.Text = "RADIO UNIVERSIDAD 100.5";
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.BackColor = Color.FromArgb(186, 0, 0);
            panel1.Controls.Add(lb1);
            panel1.Controls.Add(lb2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lb3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 473);
            panel1.TabIndex = 9;
            // 
            // lb1
            // 
            lb1.BackColor = Color.FromArgb(186, 0, 0);
            lb1.BorderStyle = BorderStyle.FixedSingle;
            lb1.Dock = DockStyle.Top;
            lb1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb1.ForeColor = Color.WhiteSmoke;
            lb1.Location = new Point(0, 132);
            lb1.Name = "lb1";
            lb1.Size = new Size(200, 44);
            lb1.TabIndex = 9;
            lb1.Text = "Usuarios";
            lb1.TextAlign = ContentAlignment.MiddleCenter;
            lb1.Click += button1_Click;
            // 
            // lb2
            // 
            lb2.BackColor = Color.FromArgb(186, 0, 0);
            lb2.BorderStyle = BorderStyle.FixedSingle;
            lb2.Dock = DockStyle.Top;
            lb2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb2.ForeColor = Color.WhiteSmoke;
            lb2.Location = new Point(0, 88);
            lb2.Name = "lb2";
            lb2.Size = new Size(200, 44);
            lb2.TabIndex = 8;
            lb2.Text = "Categorías";
            lb2.TextAlign = ContentAlignment.MiddleCenter;
            lb2.Click += button5_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(186, 0, 0);
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(0, 44);
            label3.Name = "label3";
            label3.Size = new Size(200, 44);
            label3.TabIndex = 6;
            label3.Text = "Ver programación";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += button3_Click;
            // 
            // lb3
            // 
            lb3.BackColor = Color.FromArgb(186, 0, 0);
            lb3.BorderStyle = BorderStyle.FixedSingle;
            lb3.Dock = DockStyle.Top;
            lb3.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb3.ForeColor = Color.WhiteSmoke;
            lb3.Location = new Point(0, 0);
            lb3.Name = "lb3";
            lb3.Size = new Size(200, 44);
            lb3.TabIndex = 5;
            lb3.Text = "Cartas de programación";
            lb3.TextAlign = ContentAlignment.MiddleCenter;
            lb3.Click += button2_Click;
            // 
            // formMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 522);
            Controls.Add(panel1);
            Controls.Add(panel2);
            IsMdiContainer = true;
            Name = "formMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label label2;
        private Panel panel1;
        public Label lb1;
        private Label lb2;
        private Label label3;
        private Label lb3;
    }
}