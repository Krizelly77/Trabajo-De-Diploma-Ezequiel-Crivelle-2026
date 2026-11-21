namespace Ingenieria.De.Software
{
    partial class _824_ecFormBitacoraActividades
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DGVbitacora = new System.Windows.Forms.DataGridView();
            this.DTPfechaIni = new System.Windows.Forms.DateTimePicker();
            this.DTPfechaFin = new System.Windows.Forms.DateTimePicker();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNaplicar = new System.Windows.Forms.Button();
            this.BTNactivar = new System.Windows.Forms.Button();
            this.BTNlimpiar = new System.Windows.Forms.Button();
            this.BTNsalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.TXTidActividad = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVbitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 52);
            this.panel1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 36);
            this.label3.TabIndex = 18;
            this.label3.Text = "Bitacora de Actividades";
            // 
            // DGVbitacora
            // 
            this.DGVbitacora.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVbitacora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVbitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVbitacora.Location = new System.Drawing.Point(213, 90);
            this.DGVbitacora.Name = "DGVbitacora";
            this.DGVbitacora.Size = new System.Drawing.Size(692, 327);
            this.DGVbitacora.TabIndex = 19;
            this.DGVbitacora.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVbitacora_CellFormatting);
            // 
            // DTPfechaIni
            // 
            this.DTPfechaIni.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPfechaIni.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.DTPfechaIni.CalendarTitleBackColor = System.Drawing.Color.OliveDrab;
            this.DTPfechaIni.CalendarTrailingForeColor = System.Drawing.SystemColors.WindowFrame;
            this.DTPfechaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPfechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPfechaIni.Location = new System.Drawing.Point(12, 90);
            this.DTPfechaIni.Name = "DTPfechaIni";
            this.DTPfechaIni.Size = new System.Drawing.Size(195, 26);
            this.DTPfechaIni.TabIndex = 21;
            // 
            // DTPfechaFin
            // 
            this.DTPfechaFin.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPfechaFin.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.DTPfechaFin.CalendarTitleBackColor = System.Drawing.Color.OliveDrab;
            this.DTPfechaFin.CalendarTrailingForeColor = System.Drawing.SystemColors.WindowFrame;
            this.DTPfechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPfechaFin.Location = new System.Drawing.Point(12, 151);
            this.DTPfechaFin.Name = "DTPfechaFin";
            this.DTPfechaFin.Size = new System.Drawing.Size(195, 26);
            this.DTPfechaFin.TabIndex = 22;
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombre.Location = new System.Drawing.Point(7, 58);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(185, 29);
            this.LBLnombre.TabIndex = 23;
            this.LBLnombre.Text = "Desde la fecha :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(7, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 24;
            this.label1.Text = "Hasta la fecha :";
            // 
            // BTNaplicar
            // 
            this.BTNaplicar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNaplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNaplicar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNaplicar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNaplicar.Location = new System.Drawing.Point(12, 183);
            this.BTNaplicar.Name = "BTNaplicar";
            this.BTNaplicar.Size = new System.Drawing.Size(195, 54);
            this.BTNaplicar.TabIndex = 28;
            this.BTNaplicar.Text = "Aplicar filtros";
            this.BTNaplicar.UseVisualStyleBackColor = false;
            this.BTNaplicar.Click += new System.EventHandler(this.BTNaplicar_Click);
            // 
            // BTNactivar
            // 
            this.BTNactivar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNactivar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNactivar.ForeColor = System.Drawing.Color.OliveDrab;
            this.BTNactivar.Location = new System.Drawing.Point(12, 303);
            this.BTNactivar.Name = "BTNactivar";
            this.BTNactivar.Size = new System.Drawing.Size(195, 54);
            this.BTNactivar.TabIndex = 29;
            this.BTNactivar.Text = "Activar";
            this.BTNactivar.UseVisualStyleBackColor = false;
            this.BTNactivar.Click += new System.EventHandler(this.BTNactivar_Click);
            // 
            // BTNlimpiar
            // 
            this.BTNlimpiar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNlimpiar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNlimpiar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNlimpiar.Location = new System.Drawing.Point(12, 243);
            this.BTNlimpiar.Name = "BTNlimpiar";
            this.BTNlimpiar.Size = new System.Drawing.Size(195, 54);
            this.BTNlimpiar.TabIndex = 30;
            this.BTNlimpiar.Text = "Limpiar filtros";
            this.BTNlimpiar.UseVisualStyleBackColor = false;
            this.BTNlimpiar.Click += new System.EventHandler(this.BTNlimpiar_Click);
            // 
            // BTNsalir
            // 
            this.BTNsalir.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNsalir.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNsalir.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNsalir.Location = new System.Drawing.Point(12, 363);
            this.BTNsalir.Name = "BTNsalir";
            this.BTNsalir.Size = new System.Drawing.Size(195, 54);
            this.BTNsalir.TabIndex = 31;
            this.BTNsalir.Text = "Volver";
            this.BTNsalir.UseVisualStyleBackColor = false;
            this.BTNsalir.Click += new System.EventHandler(this.BTNsalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(208, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 32;
            this.label2.Text = "Nombre :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(542, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 29);
            this.label4.TabIndex = 33;
            this.label4.Text = "Identificador :";
            // 
            // TXTnombre
            // 
            this.TXTnombre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTnombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTnombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTnombre.Location = new System.Drawing.Point(327, 59);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(209, 22);
            this.TXTnombre.TabIndex = 41;
            // 
            // TXTidActividad
            // 
            this.TXTidActividad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTidActividad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTidActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTidActividad.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTidActividad.Location = new System.Drawing.Point(696, 59);
            this.TXTidActividad.Name = "TXTidActividad";
            this.TXTidActividad.Size = new System.Drawing.Size(209, 22);
            this.TXTidActividad.TabIndex = 42;
            // 
            // _824_ecFormBitacoraActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 424);
            this.Controls.Add(this.TXTidActividad);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNsalir);
            this.Controls.Add(this.BTNlimpiar);
            this.Controls.Add(this.BTNactivar);
            this.Controls.Add(this.BTNaplicar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBLnombre);
            this.Controls.Add(this.DTPfechaFin);
            this.Controls.Add(this.DTPfechaIni);
            this.Controls.Add(this.DGVbitacora);
            this.Controls.Add(this.panel1);
            this.Name = "_824_ecFormBitacoraActividades";
            this.Text = "_824_ecFormBitacoraActividades";
            this.Load += new System.EventHandler(this._824_ecFormBitacoraActividades_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVbitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGVbitacora;
        private System.Windows.Forms.DateTimePicker DTPfechaIni;
        private System.Windows.Forms.DateTimePicker DTPfechaFin;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNaplicar;
        private System.Windows.Forms.Button BTNactivar;
        private System.Windows.Forms.Button BTNlimpiar;
        private System.Windows.Forms.Button BTNsalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.TextBox TXTidActividad;
    }
}