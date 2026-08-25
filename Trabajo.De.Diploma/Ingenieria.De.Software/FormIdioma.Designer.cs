namespace Ingenieria.De.Software
{
    partial class FormIdioma
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
            this.CMBidioma = new System.Windows.Forms.ComboBox();
            this.BTNaplicar = new System.Windows.Forms.Button();
            this.BTNcerrar = new System.Windows.Forms.Button();
            this.DGVetiquetas = new System.Windows.Forms.DataGridView();
            this.LBLnuevoIdioma = new System.Windows.Forms.Label();
            this.TXTnuevoIdioma = new System.Windows.Forms.TextBox();
            this.BTNagregarIdioma = new System.Windows.Forms.Button();
            this.BTNguardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVetiquetas)).BeginInit();
            this.SuspendLayout();
            // 
            // CMBidioma
            // 
            this.CMBidioma.FormattingEnabled = true;
            this.CMBidioma.Location = new System.Drawing.Point(12, 31);
            this.CMBidioma.Name = "CMBidioma";
            this.CMBidioma.Size = new System.Drawing.Size(135, 21);
            this.CMBidioma.TabIndex = 0;
            // 
            // BTNaplicar
            // 
            this.BTNaplicar.Location = new System.Drawing.Point(12, 58);
            this.BTNaplicar.Name = "BTNaplicar";
            this.BTNaplicar.Size = new System.Drawing.Size(135, 23);
            this.BTNaplicar.TabIndex = 1;
            this.BTNaplicar.Text = "Aplicar";
            this.BTNaplicar.UseVisualStyleBackColor = true;
            this.BTNaplicar.Click += new System.EventHandler(this.BTNaplicar_Click);
            // 
            // BTNcerrar
            // 
            this.BTNcerrar.Location = new System.Drawing.Point(15, 568);
            this.BTNcerrar.Name = "BTNcerrar";
            this.BTNcerrar.Size = new System.Drawing.Size(138, 23);
            this.BTNcerrar.TabIndex = 2;
            this.BTNcerrar.Text = "Cerrar";
            this.BTNcerrar.UseVisualStyleBackColor = true;
            this.BTNcerrar.Click += new System.EventHandler(this.BTNcerrar_Click);
            // 
            // DGVetiquetas
            // 
            this.DGVetiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVetiquetas.Location = new System.Drawing.Point(224, 31);
            this.DGVetiquetas.Name = "DGVetiquetas";
            this.DGVetiquetas.Size = new System.Drawing.Size(908, 560);
            this.DGVetiquetas.TabIndex = 3;
            // 
            // LBLnuevoIdioma
            // 
            this.LBLnuevoIdioma.AutoSize = true;
            this.LBLnuevoIdioma.Location = new System.Drawing.Point(12, 157);
            this.LBLnuevoIdioma.Name = "LBLnuevoIdioma";
            this.LBLnuevoIdioma.Size = new System.Drawing.Size(72, 13);
            this.LBLnuevoIdioma.TabIndex = 4;
            this.LBLnuevoIdioma.Text = "Nuevo idioma";
            // 
            // TXTnuevoIdioma
            // 
            this.TXTnuevoIdioma.Location = new System.Drawing.Point(15, 173);
            this.TXTnuevoIdioma.Name = "TXTnuevoIdioma";
            this.TXTnuevoIdioma.Size = new System.Drawing.Size(100, 20);
            this.TXTnuevoIdioma.TabIndex = 5;
            // 
            // BTNagregarIdioma
            // 
            this.BTNagregarIdioma.Location = new System.Drawing.Point(12, 199);
            this.BTNagregarIdioma.Name = "BTNagregarIdioma";
            this.BTNagregarIdioma.Size = new System.Drawing.Size(135, 23);
            this.BTNagregarIdioma.TabIndex = 6;
            this.BTNagregarIdioma.Text = "Agregar";
            this.BTNagregarIdioma.UseVisualStyleBackColor = true;
            this.BTNagregarIdioma.Click += new System.EventHandler(this.BTNagregarIdioma_Click);
            // 
            // BTNguardar
            // 
            this.BTNguardar.Location = new System.Drawing.Point(12, 237);
            this.BTNguardar.Name = "BTNguardar";
            this.BTNguardar.Size = new System.Drawing.Size(135, 23);
            this.BTNguardar.TabIndex = 7;
            this.BTNguardar.Text = "Guardar cambios";
            this.BTNguardar.UseVisualStyleBackColor = true;
            this.BTNguardar.Click += new System.EventHandler(this.BTNguardar_Click);
            // 
            // FormIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 603);
            this.Controls.Add(this.BTNguardar);
            this.Controls.Add(this.BTNagregarIdioma);
            this.Controls.Add(this.TXTnuevoIdioma);
            this.Controls.Add(this.LBLnuevoIdioma);
            this.Controls.Add(this.DGVetiquetas);
            this.Controls.Add(this.BTNcerrar);
            this.Controls.Add(this.BTNaplicar);
            this.Controls.Add(this.CMBidioma);
            this.Name = "FormIdioma";
            this.Text = "FormIdioma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormIdioma_FormClosed);
            this.Load += new System.EventHandler(this.FormIdioma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVetiquetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CMBidioma;
        private System.Windows.Forms.Button BTNaplicar;
        private System.Windows.Forms.Button BTNcerrar;
        private System.Windows.Forms.DataGridView DGVetiquetas;
        private System.Windows.Forms.Label LBLnuevoIdioma;
        private System.Windows.Forms.TextBox TXTnuevoIdioma;
        private System.Windows.Forms.Button BTNagregarIdioma;
        private System.Windows.Forms.Button BTNguardar;
    }
}