namespace Ingenieria.De.Software
{
    partial class FormHistorialUsuario
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
            this.LBLtitulo = new System.Windows.Forms.Label();
            this.DGVhistorial = new System.Windows.Forms.DataGridView();
            this.BTNrevertir = new System.Windows.Forms.Button();
            this.BTNcerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVhistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // LBLtitulo
            // 
            this.LBLtitulo.AutoSize = true;
            this.LBLtitulo.Location = new System.Drawing.Point(344, 21);
            this.LBLtitulo.Name = "LBLtitulo";
            this.LBLtitulo.Size = new System.Drawing.Size(101, 13);
            this.LBLtitulo.TabIndex = 0;
            this.LBLtitulo.Text = "Historial de cambios";
            // 
            // DGVhistorial
            // 
            this.DGVhistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVhistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVhistorial.Location = new System.Drawing.Point(12, 67);
            this.DGVhistorial.Name = "DGVhistorial";
            this.DGVhistorial.ReadOnly = true;
            this.DGVhistorial.Size = new System.Drawing.Size(776, 321);
            this.DGVhistorial.TabIndex = 1;
            // 
            // BTNrevertir
            // 
            this.BTNrevertir.Location = new System.Drawing.Point(12, 394);
            this.BTNrevertir.Name = "BTNrevertir";
            this.BTNrevertir.Size = new System.Drawing.Size(108, 23);
            this.BTNrevertir.TabIndex = 2;
            this.BTNrevertir.Text = "Revertir cambio";
            this.BTNrevertir.UseVisualStyleBackColor = true;
            this.BTNrevertir.Click += new System.EventHandler(this.BTNrevertir_Click);
            // 
            // BTNcerrar
            // 
            this.BTNcerrar.Location = new System.Drawing.Point(126, 394);
            this.BTNcerrar.Name = "BTNcerrar";
            this.BTNcerrar.Size = new System.Drawing.Size(108, 23);
            this.BTNcerrar.TabIndex = 3;
            this.BTNcerrar.Text = "Cerrar";
            this.BTNcerrar.UseVisualStyleBackColor = true;
            this.BTNcerrar.Click += new System.EventHandler(this.BTNcerrar_Click);
            // 
            // FormHistorialUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTNcerrar);
            this.Controls.Add(this.BTNrevertir);
            this.Controls.Add(this.DGVhistorial);
            this.Controls.Add(this.LBLtitulo);
            this.Name = "FormHistorialUsuario";
            this.Text = "FormHistorialUsuario";
            this.Load += new System.EventHandler(this.FormHistorialUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVhistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBLtitulo;
        private System.Windows.Forms.DataGridView DGVhistorial;
        private System.Windows.Forms.Button BTNrevertir;
        private System.Windows.Forms.Button BTNcerrar;
    }
}