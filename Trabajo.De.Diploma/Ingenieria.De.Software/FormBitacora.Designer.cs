namespace Ingenieria.De.Software
{
    partial class FormBitacora
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
            this.DTPdesde = new System.Windows.Forms.DateTimePicker();
            this.DTPpasta = new System.Windows.Forms.DateTimePicker();
            this.TXTusuario = new System.Windows.Forms.TextBox();
            this.CMBactividad = new System.Windows.Forms.ComboBox();
            this.DGVbitacora = new System.Windows.Forms.DataGridView();
            this.BTNconsultar = new System.Windows.Forms.Button();
            this.BTNvolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVbitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // DTPdesde
            // 
            this.DTPdesde.Location = new System.Drawing.Point(64, 12);
            this.DTPdesde.Name = "DTPdesde";
            this.DTPdesde.Size = new System.Drawing.Size(167, 20);
            this.DTPdesde.TabIndex = 0;
            // 
            // DTPpasta
            // 
            this.DTPpasta.Location = new System.Drawing.Point(64, 38);
            this.DTPpasta.Name = "DTPpasta";
            this.DTPpasta.Size = new System.Drawing.Size(167, 20);
            this.DTPpasta.TabIndex = 1;
            // 
            // TXTusuario
            // 
            this.TXTusuario.Location = new System.Drawing.Point(111, 105);
            this.TXTusuario.Name = "TXTusuario";
            this.TXTusuario.Size = new System.Drawing.Size(120, 20);
            this.TXTusuario.TabIndex = 2;
            // 
            // CMBactividad
            // 
            this.CMBactividad.FormattingEnabled = true;
            this.CMBactividad.Location = new System.Drawing.Point(111, 149);
            this.CMBactividad.Name = "CMBactividad";
            this.CMBactividad.Size = new System.Drawing.Size(120, 21);
            this.CMBactividad.TabIndex = 3;
            // 
            // DGVbitacora
            // 
            this.DGVbitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVbitacora.Location = new System.Drawing.Point(264, 12);
            this.DGVbitacora.Name = "DGVbitacora";
            this.DGVbitacora.Size = new System.Drawing.Size(452, 259);
            this.DGVbitacora.TabIndex = 4;
            // 
            // BTNconsultar
            // 
            this.BTNconsultar.Location = new System.Drawing.Point(9, 248);
            this.BTNconsultar.Name = "BTNconsultar";
            this.BTNconsultar.Size = new System.Drawing.Size(96, 23);
            this.BTNconsultar.TabIndex = 5;
            this.BTNconsultar.Text = "Consultar";
            this.BTNconsultar.UseVisualStyleBackColor = true;
            this.BTNconsultar.Click += new System.EventHandler(this.BTNconsultar_Click);
            // 
            // BTNvolver
            // 
            this.BTNvolver.Location = new System.Drawing.Point(143, 248);
            this.BTNvolver.Name = "BTNvolver";
            this.BTNvolver.Size = new System.Drawing.Size(88, 23);
            this.BTNvolver.TabIndex = 6;
            this.BTNvolver.Text = "Volver";
            this.BTNvolver.UseVisualStyleBackColor = true;
            this.BTNvolver.Click += new System.EventHandler(this.BTNvolver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Filtrar por User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filtrar por actividad";
            // 
            // FormBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 307);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNvolver);
            this.Controls.Add(this.BTNconsultar);
            this.Controls.Add(this.DGVbitacora);
            this.Controls.Add(this.CMBactividad);
            this.Controls.Add(this.TXTusuario);
            this.Controls.Add(this.DTPpasta);
            this.Controls.Add(this.DTPdesde);
            this.Name = "FormBitacora";
            this.Text = "FormBitacora";
            this.Load += new System.EventHandler(this.FormBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVbitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPdesde;
        private System.Windows.Forms.DateTimePicker DTPpasta;
        private System.Windows.Forms.TextBox TXTusuario;
        private System.Windows.Forms.ComboBox CMBactividad;
        private System.Windows.Forms.DataGridView DGVbitacora;
        private System.Windows.Forms.Button BTNconsultar;
        private System.Windows.Forms.Button BTNvolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}