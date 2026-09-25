namespace Ingenieria.De.Software
{
    partial class _824_ecFormMostarListaActividades
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
            this.DGVactividades = new System.Windows.Forms.DataGridView();
            this.FiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.LBLnombree = new System.Windows.Forms.Label();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.LBLratio = new System.Windows.Forms.Label();
            this.BTNvolver = new System.Windows.Forms.Button();
            this.CMBfiltroActividades = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVactividades)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVactividades
            // 
            this.DGVactividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVactividades.Location = new System.Drawing.Point(12, 78);
            this.DGVactividades.Name = "DGVactividades";
            this.DGVactividades.Size = new System.Drawing.Size(484, 202);
            this.DGVactividades.TabIndex = 0;
            // 
            // FiltroFecha
            // 
            this.FiltroFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroFecha.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.FiltroFecha.CalendarTitleBackColor = System.Drawing.Color.OliveDrab;
            this.FiltroFecha.CalendarTrailingForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FiltroFecha.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroFecha.Location = new System.Drawing.Point(12, 43);
            this.FiltroFecha.Name = "FiltroFecha";
            this.FiltroFecha.Size = new System.Drawing.Size(274, 29);
            this.FiltroFecha.TabIndex = 27;
            this.FiltroFecha.ValueChanged += new System.EventHandler(this.FiltroFecha_ValueChanged);
            // 
            // LBLnombree
            // 
            this.LBLnombree.AutoSize = true;
            this.LBLnombree.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombree.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombree.Location = new System.Drawing.Point(12, 1);
            this.LBLnombree.Name = "LBLnombree";
            this.LBLnombree.Size = new System.Drawing.Size(252, 39);
            this.LBLnombree.TabIndex = 28;
            this.LBLnombree.Text = "Actividades de ";
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombre.Location = new System.Drawing.Point(254, 1);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(141, 39);
            this.LBLnombre.TabIndex = 29;
            this.LBLnombre.Text = "Nombre";
            // 
            // LBLratio
            // 
            this.LBLratio.AutoSize = true;
            this.LBLratio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLratio.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLratio.Location = new System.Drawing.Point(15, 293);
            this.LBLratio.Name = "LBLratio";
            this.LBLratio.Size = new System.Drawing.Size(315, 24);
            this.LBLratio.TabIndex = 30;
            this.LBLratio.Text = "Completo: xxx de xxx Postulaciones";
            // 
            // BTNvolver
            // 
            this.BTNvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolver.ForeColor = System.Drawing.Color.OliveDrab;
            this.BTNvolver.Location = new System.Drawing.Point(368, 286);
            this.BTNvolver.Name = "BTNvolver";
            this.BTNvolver.Size = new System.Drawing.Size(128, 40);
            this.BTNvolver.TabIndex = 31;
            this.BTNvolver.Text = "OK";
            this.BTNvolver.UseVisualStyleBackColor = false;
            this.BTNvolver.Click += new System.EventHandler(this.BTNvolver_Click);
            // 
            // CMBfiltroActividades
            // 
            this.CMBfiltroActividades.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CMBfiltroActividades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBfiltroActividades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMBfiltroActividades.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBfiltroActividades.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CMBfiltroActividades.FormattingEnabled = true;
            this.CMBfiltroActividades.Location = new System.Drawing.Point(292, 43);
            this.CMBfiltroActividades.Name = "CMBfiltroActividades";
            this.CMBfiltroActividades.Size = new System.Drawing.Size(204, 28);
            this.CMBfiltroActividades.TabIndex = 32;
            this.CMBfiltroActividades.SelectedIndexChanged += new System.EventHandler(this.CMBfiltroActividades_SelectedIndexChanged);
            // 
            // _824_ecFormMostarListaActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 331);
            this.Controls.Add(this.CMBfiltroActividades);
            this.Controls.Add(this.BTNvolver);
            this.Controls.Add(this.LBLratio);
            this.Controls.Add(this.LBLnombre);
            this.Controls.Add(this.LBLnombree);
            this.Controls.Add(this.FiltroFecha);
            this.Controls.Add(this.DGVactividades);
            this.Name = "_824_ecFormMostarListaActividades";
            this.Text = "_824_ecFormMostarListaActividades";
            this.Load += new System.EventHandler(this._824_ecFormMostarListaActividades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVactividades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVactividades;
        private System.Windows.Forms.DateTimePicker FiltroFecha;
        private System.Windows.Forms.Label LBLnombree;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Label LBLratio;
        private System.Windows.Forms.Button BTNvolver;
        private System.Windows.Forms.ComboBox CMBfiltroActividades;
    }
}