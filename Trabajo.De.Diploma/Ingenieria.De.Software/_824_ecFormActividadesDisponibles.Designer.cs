namespace Ingenieria.De.Software
{
    partial class _824_ecFormActividadesDisponibles
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
            this.BTNretirar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVpostulaciones = new System.Windows.Forms.DataGridView();
            this.BTNcvolver = new System.Windows.Forms.Button();
            this.BTNverDetalle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CMBfiltroActividades = new System.Windows.Forms.ComboBox();
            this.DGVactividades = new System.Windows.Forms.DataGridView();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.FiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.BTNpostular = new System.Windows.Forms.Button();
            this.CMDdirecciondeFecha = new System.Windows.Forms.ComboBox();
            this.TXTfiltroPostDocumento = new System.Windows.Forms.TextBox();
            this.TXTfiltroPostActividad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpostulaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVactividades)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TXTfiltroPostActividad);
            this.panel1.Controls.Add(this.TXTfiltroPostDocumento);
            this.panel1.Controls.Add(this.BTNretirar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DGVpostulaciones);
            this.panel1.Controls.Add(this.BTNcvolver);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 435);
            this.panel1.TabIndex = 0;
            // 
            // BTNretirar
            // 
            this.BTNretirar.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNretirar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNretirar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNretirar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNretirar.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNretirar.Location = new System.Drawing.Point(176, 381);
            this.BTNretirar.Name = "BTNretirar";
            this.BTNretirar.Size = new System.Drawing.Size(159, 42);
            this.BTNretirar.TabIndex = 28;
            this.BTNretirar.Tag = "";
            this.BTNretirar.Text = "Retirar esta Postulacion";
            this.BTNretirar.UseVisualStyleBackColor = false;
            this.BTNretirar.Click += new System.EventHandler(this.BTNretirar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 55);
            this.label2.TabIndex = 28;
            this.label2.Text = "Postulaciones";
            // 
            // DGVpostulaciones
            // 
            this.DGVpostulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVpostulaciones.Location = new System.Drawing.Point(12, 129);
            this.DGVpostulaciones.Name = "DGVpostulaciones";
            this.DGVpostulaciones.Size = new System.Drawing.Size(422, 246);
            this.DGVpostulaciones.TabIndex = 28;
            this.DGVpostulaciones.SelectionChanged += new System.EventHandler(this.DGVpostulaciones_SelectionChanged);
            // 
            // BTNcvolver
            // 
            this.BTNcvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcvolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNcvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcvolver.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNcvolver.Location = new System.Drawing.Point(11, 381);
            this.BTNcvolver.Name = "BTNcvolver";
            this.BTNcvolver.Size = new System.Drawing.Size(159, 42);
            this.BTNcvolver.TabIndex = 6;
            this.BTNcvolver.Text = "Volver atras";
            this.BTNcvolver.UseVisualStyleBackColor = false;
            this.BTNcvolver.Click += new System.EventHandler(this.BTNcvolver_Click);
            // 
            // BTNverDetalle
            // 
            this.BTNverDetalle.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNverDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNverDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNverDetalle.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNverDetalle.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNverDetalle.Location = new System.Drawing.Point(676, 381);
            this.BTNverDetalle.Name = "BTNverDetalle";
            this.BTNverDetalle.Size = new System.Drawing.Size(179, 42);
            this.BTNverDetalle.TabIndex = 3;
            this.BTNverDetalle.Tag = "";
            this.BTNverDetalle.Text = "Ver Actividad en detalle";
            this.BTNverDetalle.UseVisualStyleBackColor = false;
            this.BTNverDetalle.Click += new System.EventHandler(this.BTNverDetalle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(455, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mostrar :";
            // 
            // CMBfiltroActividades
            // 
            this.CMBfiltroActividades.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CMBfiltroActividades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBfiltroActividades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMBfiltroActividades.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBfiltroActividades.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CMBfiltroActividades.FormattingEnabled = true;
            this.CMBfiltroActividades.Location = new System.Drawing.Point(554, 80);
            this.CMBfiltroActividades.Name = "CMBfiltroActividades";
            this.CMBfiltroActividades.Size = new System.Drawing.Size(149, 28);
            this.CMBfiltroActividades.TabIndex = 24;
            this.CMBfiltroActividades.SelectedIndexChanged += new System.EventHandler(this.CMBfiltroActividades_SelectedIndexChanged);
            // 
            // DGVactividades
            // 
            this.DGVactividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVactividades.Location = new System.Drawing.Point(460, 118);
            this.DGVactividades.Name = "DGVactividades";
            this.DGVactividades.Size = new System.Drawing.Size(580, 257);
            this.DGVactividades.TabIndex = 1;
            this.DGVactividades.SelectionChanged += new System.EventHandler(this.DGVactividades_SelectionChanged);
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombre.Location = new System.Drawing.Point(455, 9);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(530, 55);
            this.LBLnombre.TabIndex = 2;
            this.LBLnombre.Text = "Actividades Disponibles";
            // 
            // FiltroFecha
            // 
            this.FiltroFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroFecha.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.FiltroFecha.CalendarTitleBackColor = System.Drawing.Color.OliveDrab;
            this.FiltroFecha.CalendarTrailingForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FiltroFecha.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroFecha.Location = new System.Drawing.Point(824, 84);
            this.FiltroFecha.Name = "FiltroFecha";
            this.FiltroFecha.Size = new System.Drawing.Size(216, 25);
            this.FiltroFecha.TabIndex = 27;
            this.FiltroFecha.ValueChanged += new System.EventHandler(this.FiltroFecha_ValueChanged);
            // 
            // BTNpostular
            // 
            this.BTNpostular.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNpostular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNpostular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNpostular.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNpostular.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNpostular.Location = new System.Drawing.Point(861, 381);
            this.BTNpostular.Name = "BTNpostular";
            this.BTNpostular.Size = new System.Drawing.Size(179, 42);
            this.BTNpostular.TabIndex = 4;
            this.BTNpostular.Tag = "";
            this.BTNpostular.Text = "Postular Participantes";
            this.BTNpostular.UseVisualStyleBackColor = false;
            this.BTNpostular.Click += new System.EventHandler(this.BTNpostular_Click);
            // 
            // CMDdirecciondeFecha
            // 
            this.CMDdirecciondeFecha.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CMDdirecciondeFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMDdirecciondeFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMDdirecciondeFecha.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMDdirecciondeFecha.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CMDdirecciondeFecha.FormattingEnabled = true;
            this.CMDdirecciondeFecha.Location = new System.Drawing.Point(709, 80);
            this.CMDdirecciondeFecha.Name = "CMDdirecciondeFecha";
            this.CMDdirecciondeFecha.Size = new System.Drawing.Size(109, 28);
            this.CMDdirecciondeFecha.TabIndex = 29;
            this.CMDdirecciondeFecha.SelectedIndexChanged += new System.EventHandler(this.CMDdirecciondeFecha_SelectedIndexChanged);
            // 
            // TXTfiltroPostDocumento
            // 
            this.TXTfiltroPostDocumento.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TXTfiltroPostDocumento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTfiltroPostDocumento.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTfiltroPostDocumento.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTfiltroPostDocumento.Location = new System.Drawing.Point(254, 101);
            this.TXTfiltroPostDocumento.Name = "TXTfiltroPostDocumento";
            this.TXTfiltroPostDocumento.Size = new System.Drawing.Size(180, 22);
            this.TXTfiltroPostDocumento.TabIndex = 30;
            this.TXTfiltroPostDocumento.TextChanged += new System.EventHandler(this.TXTfiltroPostDocumento_TextChanged);
            // 
            // TXTfiltroPostActividad
            // 
            this.TXTfiltroPostActividad.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TXTfiltroPostActividad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTfiltroPostActividad.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTfiltroPostActividad.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTfiltroPostActividad.Location = new System.Drawing.Point(220, 73);
            this.TXTfiltroPostActividad.Name = "TXTfiltroPostActividad";
            this.TXTfiltroPostActividad.Size = new System.Drawing.Size(214, 22);
            this.TXTfiltroPostActividad.TabIndex = 31;
            this.TXTfiltroPostActividad.TextChanged += new System.EventHandler(this.TXTfiltroPostActividad_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.OliveDrab;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(17, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 24);
            this.label3.TabIndex = 30;
            this.label3.Text = "Nombre de Actividad :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.OliveDrab;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(17, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 24);
            this.label4.TabIndex = 32;
            this.label4.Text = "Documento del postulado:";
            // 
            // _824_ecFormActividadesDisponibles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 435);
            this.Controls.Add(this.CMDdirecciondeFecha);
            this.Controls.Add(this.BTNpostular);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNverDetalle);
            this.Controls.Add(this.FiltroFecha);
            this.Controls.Add(this.LBLnombre);
            this.Controls.Add(this.DGVactividades);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CMBfiltroActividades);
            this.Name = "_824_ecFormActividadesDisponibles";
            this.Text = "_824_ecFormActividadesDisponibles";
            this.Load += new System.EventHandler(this._824_ecFormActividadesDisponibles_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpostulaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVactividades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DGVactividades;
        private System.Windows.Forms.Button BTNverDetalle;
        private System.Windows.Forms.Button BTNcvolver;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMBfiltroActividades;
        private System.Windows.Forms.DateTimePicker FiltroFecha;
        private System.Windows.Forms.DataGridView DGVpostulaciones;
        private System.Windows.Forms.Button BTNpostular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNretirar;
        private System.Windows.Forms.ComboBox CMDdirecciondeFecha;
        private System.Windows.Forms.TextBox TXTfiltroPostActividad;
        private System.Windows.Forms.TextBox TXTfiltroPostDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}