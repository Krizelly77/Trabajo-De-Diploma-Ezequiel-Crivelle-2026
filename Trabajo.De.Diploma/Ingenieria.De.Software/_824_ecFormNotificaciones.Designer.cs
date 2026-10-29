namespace Ingenieria.De.Software
{
    partial class _824_ecFormNotificaciones
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
            this.LBLnombree = new System.Windows.Forms.Label();
            this.FiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.CMBfiltroUsuarios = new System.Windows.Forms.ComboBox();
            this.DGVNotificaciones = new System.Windows.Forms.DataGridView();
            this.LBLcantidadNotis = new System.Windows.Forms.Label();
            this.BTNvolver = new System.Windows.Forms.Button();
            this.LBLnotSinLeer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNotificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // LBLnombree
            // 
            this.LBLnombree.AutoSize = true;
            this.LBLnombree.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombree.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombree.Location = new System.Drawing.Point(12, 0);
            this.LBLnombree.Name = "LBLnombree";
            this.LBLnombree.Size = new System.Drawing.Size(235, 39);
            this.LBLnombree.TabIndex = 29;
            this.LBLnombree.Text = "Notificaciones";
            // 
            // FiltroFecha
            // 
            this.FiltroFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroFecha.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.FiltroFecha.CalendarTitleBackColor = System.Drawing.Color.OliveDrab;
            this.FiltroFecha.CalendarTrailingForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FiltroFecha.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroFecha.Location = new System.Drawing.Point(12, 42);
            this.FiltroFecha.Name = "FiltroFecha";
            this.FiltroFecha.Size = new System.Drawing.Size(274, 29);
            this.FiltroFecha.TabIndex = 30;
            this.FiltroFecha.ValueChanged += new System.EventHandler(this.FiltroFecha_ValueChanged);
            // 
            // CMBfiltroUsuarios
            // 
            this.CMBfiltroUsuarios.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CMBfiltroUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBfiltroUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMBfiltroUsuarios.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBfiltroUsuarios.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CMBfiltroUsuarios.FormattingEnabled = true;
            this.CMBfiltroUsuarios.Location = new System.Drawing.Point(292, 45);
            this.CMBfiltroUsuarios.Name = "CMBfiltroUsuarios";
            this.CMBfiltroUsuarios.Size = new System.Drawing.Size(204, 28);
            this.CMBfiltroUsuarios.TabIndex = 33;
            this.CMBfiltroUsuarios.SelectedIndexChanged += new System.EventHandler(this.CMBfiltroUsuarios_SelectedIndexChanged);
            // 
            // DGVNotificaciones
            // 
            this.DGVNotificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNotificaciones.Location = new System.Drawing.Point(12, 77);
            this.DGVNotificaciones.Name = "DGVNotificaciones";
            this.DGVNotificaciones.Size = new System.Drawing.Size(484, 202);
            this.DGVNotificaciones.TabIndex = 34;
            this.DGVNotificaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVNotificaciones_CellClick);
            // 
            // LBLcantidadNotis
            // 
            this.LBLcantidadNotis.AutoSize = true;
            this.LBLcantidadNotis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLcantidadNotis.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLcantidadNotis.Location = new System.Drawing.Point(12, 291);
            this.LBLcantidadNotis.Name = "LBLcantidadNotis";
            this.LBLcantidadNotis.Size = new System.Drawing.Size(270, 24);
            this.LBLcantidadNotis.TabIndex = 35;
            this.LBLcantidadNotis.Text = "Cantidad de notificaciones: xxx";
            // 
            // BTNvolver
            // 
            this.BTNvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolver.ForeColor = System.Drawing.Color.OliveDrab;
            this.BTNvolver.Location = new System.Drawing.Point(368, 285);
            this.BTNvolver.Name = "BTNvolver";
            this.BTNvolver.Size = new System.Drawing.Size(128, 40);
            this.BTNvolver.TabIndex = 36;
            this.BTNvolver.Text = "OK";
            this.BTNvolver.UseVisualStyleBackColor = false;
            this.BTNvolver.Click += new System.EventHandler(this.BTNvolver_Click);
            // 
            // LBLnotSinLeer
            // 
            this.LBLnotSinLeer.AutoSize = true;
            this.LBLnotSinLeer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnotSinLeer.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnotSinLeer.Location = new System.Drawing.Point(253, 9);
            this.LBLnotSinLeer.Name = "LBLnotSinLeer";
            this.LBLnotSinLeer.Size = new System.Drawing.Size(120, 24);
            this.LBLnotSinLeer.TabIndex = 37;
            this.LBLnotSinLeer.Text = "Sin Leer: xxx";
            // 
            // _824_ecFormNotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 331);
            this.Controls.Add(this.LBLnotSinLeer);
            this.Controls.Add(this.BTNvolver);
            this.Controls.Add(this.LBLcantidadNotis);
            this.Controls.Add(this.DGVNotificaciones);
            this.Controls.Add(this.CMBfiltroUsuarios);
            this.Controls.Add(this.FiltroFecha);
            this.Controls.Add(this.LBLnombree);
            this.Name = "_824_ecFormNotificaciones";
            this.Text = "_824_ecFormNotificaciones";
            this.Load += new System.EventHandler(this._824_ecFormNotificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVNotificaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBLnombree;
        private System.Windows.Forms.DateTimePicker FiltroFecha;
        private System.Windows.Forms.ComboBox CMBfiltroUsuarios;
        private System.Windows.Forms.DataGridView DGVNotificaciones;
        private System.Windows.Forms.Label LBLcantidadNotis;
        private System.Windows.Forms.Button BTNvolver;
        private System.Windows.Forms.Label LBLnotSinLeer;
    }
}