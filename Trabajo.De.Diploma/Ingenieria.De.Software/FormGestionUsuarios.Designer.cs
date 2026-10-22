namespace Ingenieria.De.Software
{
    partial class FormGestionUsuarios
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
            this.DGVusuaios = new System.Windows.Forms.DataGridView();
            this.BTNcrearUsu = new System.Windows.Forms.Button();
            this.BTNmodUsu = new System.Windows.Forms.Button();
            this.BTNeliminarUsu = new System.Windows.Forms.Button();
            this.TXTnom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTcon = new System.Windows.Forms.TextBox();
            this.CHKactivo = new System.Windows.Forms.CheckBox();
            this.BTNvolver = new System.Windows.Forms.Button();
            this.BTNdesbloqueoDV = new System.Windows.Forms.Button();
            this.CHKbloqueado = new System.Windows.Forms.CheckBox();
            this.BTNhistorial = new System.Windows.Forms.Button();
            this.BTNasignarRol = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNserializar = new System.Windows.Forms.Button();
            this.BTNdeserializar = new System.Windows.Forms.Button();
            this.BTNlimpiar = new System.Windows.Forms.Button();
            this.BTNcargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVusuaios)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVusuaios
            // 
            this.DGVusuaios.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVusuaios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVusuaios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVusuaios.Location = new System.Drawing.Point(268, 58);
            this.DGVusuaios.Name = "DGVusuaios";
            this.DGVusuaios.Size = new System.Drawing.Size(646, 357);
            this.DGVusuaios.TabIndex = 0;
            this.DGVusuaios.SelectionChanged += new System.EventHandler(this.DGVusuaios_SelectionChanged);
            // 
            // BTNcrearUsu
            // 
            this.BTNcrearUsu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcrearUsu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNcrearUsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcrearUsu.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcrearUsu.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNcrearUsu.Location = new System.Drawing.Point(14, 235);
            this.BTNcrearUsu.Name = "BTNcrearUsu";
            this.BTNcrearUsu.Size = new System.Drawing.Size(121, 56);
            this.BTNcrearUsu.TabIndex = 1;
            this.BTNcrearUsu.Tag = "Permiso_Alta_Usuario";
            this.BTNcrearUsu.Text = "Crear Nuevo Usuario";
            this.BTNcrearUsu.UseVisualStyleBackColor = false;
            this.BTNcrearUsu.Click += new System.EventHandler(this.BTNcrearUsu_Click);
            // 
            // BTNmodUsu
            // 
            this.BTNmodUsu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNmodUsu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmodUsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmodUsu.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmodUsu.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmodUsu.Location = new System.Drawing.Point(141, 235);
            this.BTNmodUsu.Name = "BTNmodUsu";
            this.BTNmodUsu.Size = new System.Drawing.Size(121, 56);
            this.BTNmodUsu.TabIndex = 2;
            this.BTNmodUsu.Tag = "Permiso_Modificar_Usuario";
            this.BTNmodUsu.Text = "Modificar Usuario";
            this.BTNmodUsu.UseVisualStyleBackColor = false;
            this.BTNmodUsu.Click += new System.EventHandler(this.BTNmodUsu_Click);
            // 
            // BTNeliminarUsu
            // 
            this.BTNeliminarUsu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNeliminarUsu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNeliminarUsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNeliminarUsu.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNeliminarUsu.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNeliminarUsu.Location = new System.Drawing.Point(14, 359);
            this.BTNeliminarUsu.Name = "BTNeliminarUsu";
            this.BTNeliminarUsu.Size = new System.Drawing.Size(121, 56);
            this.BTNeliminarUsu.TabIndex = 4;
            this.BTNeliminarUsu.Tag = "Permiso_Baja_Usuario";
            this.BTNeliminarUsu.Text = "Eliminar Usuario";
            this.BTNeliminarUsu.UseVisualStyleBackColor = false;
            this.BTNeliminarUsu.Click += new System.EventHandler(this.BTNeliminarUsu_Click);
            // 
            // TXTnom
            // 
            this.TXTnom.BackColor = System.Drawing.SystemColors.Control;
            this.TXTnom.Enabled = false;
            this.TXTnom.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTnom.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTnom.Location = new System.Drawing.Point(14, 81);
            this.TXTnom.Name = "TXTnom";
            this.TXTnom.Size = new System.Drawing.Size(248, 29);
            this.TXTnom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(14, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(14, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Contraseña : ";
            // 
            // TXTcon
            // 
            this.TXTcon.BackColor = System.Drawing.SystemColors.Control;
            this.TXTcon.Enabled = false;
            this.TXTcon.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTcon.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTcon.Location = new System.Drawing.Point(14, 138);
            this.TXTcon.Name = "TXTcon";
            this.TXTcon.Size = new System.Drawing.Size(248, 29);
            this.TXTcon.TabIndex = 9;
            // 
            // CHKactivo
            // 
            this.CHKactivo.AutoSize = true;
            this.CHKactivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHKactivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CHKactivo.Enabled = false;
            this.CHKactivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHKactivo.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKactivo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CHKactivo.Location = new System.Drawing.Point(18, 175);
            this.CHKactivo.Name = "CHKactivo";
            this.CHKactivo.Size = new System.Drawing.Size(80, 24);
            this.CHKactivo.TabIndex = 11;
            this.CHKactivo.Text = "Activo :";
            this.CHKactivo.UseVisualStyleBackColor = true;
            // 
            // BTNvolver
            // 
            this.BTNvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNvolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolver.ForeColor = System.Drawing.Color.OliveDrab;
            this.BTNvolver.Location = new System.Drawing.Point(793, 421);
            this.BTNvolver.Name = "BTNvolver";
            this.BTNvolver.Size = new System.Drawing.Size(121, 56);
            this.BTNvolver.TabIndex = 12;
            this.BTNvolver.Text = "Volver al menu";
            this.BTNvolver.UseVisualStyleBackColor = false;
            this.BTNvolver.Click += new System.EventHandler(this.BTNvolver_Click);
            // 
            // BTNdesbloqueoDV
            // 
            this.BTNdesbloqueoDV.BackColor = System.Drawing.Color.IndianRed;
            this.BTNdesbloqueoDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNdesbloqueoDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNdesbloqueoDV.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNdesbloqueoDV.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNdesbloqueoDV.Location = new System.Drawing.Point(141, 359);
            this.BTNdesbloqueoDV.Name = "BTNdesbloqueoDV";
            this.BTNdesbloqueoDV.Size = new System.Drawing.Size(121, 56);
            this.BTNdesbloqueoDV.TabIndex = 13;
            this.BTNdesbloqueoDV.Tag = "Permiso_Recalcular_DV";
            this.BTNdesbloqueoDV.Text = "Desbloqueo Masivo de DV";
            this.BTNdesbloqueoDV.UseVisualStyleBackColor = false;
            this.BTNdesbloqueoDV.Click += new System.EventHandler(this.BTNdesbloqueoDV_Click);
            // 
            // CHKbloqueado
            // 
            this.CHKbloqueado.AutoSize = true;
            this.CHKbloqueado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHKbloqueado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CHKbloqueado.Enabled = false;
            this.CHKbloqueado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CHKbloqueado.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKbloqueado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CHKbloqueado.Location = new System.Drawing.Point(18, 205);
            this.CHKbloqueado.Name = "CHKbloqueado";
            this.CHKbloqueado.Size = new System.Drawing.Size(115, 24);
            this.CHKbloqueado.TabIndex = 14;
            this.CHKbloqueado.Text = "Bloqueado :";
            this.CHKbloqueado.UseVisualStyleBackColor = true;
            // 
            // BTNhistorial
            // 
            this.BTNhistorial.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNhistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNhistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNhistorial.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNhistorial.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNhistorial.Location = new System.Drawing.Point(141, 297);
            this.BTNhistorial.Name = "BTNhistorial";
            this.BTNhistorial.Size = new System.Drawing.Size(121, 56);
            this.BTNhistorial.TabIndex = 15;
            this.BTNhistorial.Text = "Ver Historial";
            this.BTNhistorial.UseVisualStyleBackColor = false;
            this.BTNhistorial.Click += new System.EventHandler(this.BTNhistorial_Click);
            // 
            // BTNasignarRol
            // 
            this.BTNasignarRol.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNasignarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNasignarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNasignarRol.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNasignarRol.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNasignarRol.Location = new System.Drawing.Point(14, 297);
            this.BTNasignarRol.Name = "BTNasignarRol";
            this.BTNasignarRol.Size = new System.Drawing.Size(121, 56);
            this.BTNasignarRol.TabIndex = 16;
            this.BTNasignarRol.Tag = "Permiso_Asignar_Roles";
            this.BTNasignarRol.Text = "Asignar Roles";
            this.BTNasignarRol.UseVisualStyleBackColor = false;
            this.BTNasignarRol.Click += new System.EventHandler(this.BTNasignarRol_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 52);
            this.panel1.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 36);
            this.label3.TabIndex = 18;
            this.label3.Text = "Gestion de Usuarios";
            // 
            // BTNserializar
            // 
            this.BTNserializar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNserializar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNserializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNserializar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNserializar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNserializar.Location = new System.Drawing.Point(268, 421);
            this.BTNserializar.Name = "BTNserializar";
            this.BTNserializar.Size = new System.Drawing.Size(121, 56);
            this.BTNserializar.TabIndex = 18;
            this.BTNserializar.Text = "Serializar";
            this.BTNserializar.UseVisualStyleBackColor = false;
            this.BTNserializar.Click += new System.EventHandler(this.BTNserializar_Click);
            // 
            // BTNdeserializar
            // 
            this.BTNdeserializar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNdeserializar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNdeserializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNdeserializar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNdeserializar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNdeserializar.Location = new System.Drawing.Point(395, 421);
            this.BTNdeserializar.Name = "BTNdeserializar";
            this.BTNdeserializar.Size = new System.Drawing.Size(121, 56);
            this.BTNdeserializar.TabIndex = 19;
            this.BTNdeserializar.Text = "Deserializar";
            this.BTNdeserializar.UseVisualStyleBackColor = false;
            this.BTNdeserializar.Click += new System.EventHandler(this.BTNdeserializar_Click);
            // 
            // BTNlimpiar
            // 
            this.BTNlimpiar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNlimpiar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNlimpiar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNlimpiar.Location = new System.Drawing.Point(522, 421);
            this.BTNlimpiar.Name = "BTNlimpiar";
            this.BTNlimpiar.Size = new System.Drawing.Size(121, 56);
            this.BTNlimpiar.TabIndex = 20;
            this.BTNlimpiar.Text = "Limpiar Grilla";
            this.BTNlimpiar.UseVisualStyleBackColor = false;
            this.BTNlimpiar.Click += new System.EventHandler(this.BTNlimpiar_Click);
            // 
            // BTNcargar
            // 
            this.BTNcargar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNcargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcargar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcargar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNcargar.Location = new System.Drawing.Point(649, 421);
            this.BTNcargar.Name = "BTNcargar";
            this.BTNcargar.Size = new System.Drawing.Size(121, 56);
            this.BTNcargar.TabIndex = 21;
            this.BTNcargar.Text = "Cargar Grilla";
            this.BTNcargar.UseVisualStyleBackColor = false;
            this.BTNcargar.Click += new System.EventHandler(this.BTNcargar_Click);
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 486);
            this.Controls.Add(this.BTNcargar);
            this.Controls.Add(this.BTNlimpiar);
            this.Controls.Add(this.BTNdeserializar);
            this.Controls.Add(this.BTNserializar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTNasignarRol);
            this.Controls.Add(this.BTNhistorial);
            this.Controls.Add(this.CHKbloqueado);
            this.Controls.Add(this.BTNdesbloqueoDV);
            this.Controls.Add(this.BTNvolver);
            this.Controls.Add(this.CHKactivo);
            this.Controls.Add(this.TXTcon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTnom);
            this.Controls.Add(this.BTNeliminarUsu);
            this.Controls.Add(this.BTNmodUsu);
            this.Controls.Add(this.BTNcrearUsu);
            this.Controls.Add(this.DGVusuaios);
            this.Name = "FormGestionUsuarios";
            this.Text = "FormGestionUsuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGestionUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.FormGestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVusuaios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVusuaios;
        private System.Windows.Forms.Button BTNcrearUsu;
        private System.Windows.Forms.Button BTNmodUsu;
        private System.Windows.Forms.Button BTNeliminarUsu;
        private System.Windows.Forms.TextBox TXTnom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTcon;
        private System.Windows.Forms.CheckBox CHKactivo;
        private System.Windows.Forms.Button BTNvolver;
        private System.Windows.Forms.Button BTNdesbloqueoDV;
        private System.Windows.Forms.CheckBox CHKbloqueado;
        private System.Windows.Forms.Button BTNhistorial;
        private System.Windows.Forms.Button BTNasignarRol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTNserializar;
        private System.Windows.Forms.Button BTNdeserializar;
        private System.Windows.Forms.Button BTNlimpiar;
        private System.Windows.Forms.Button BTNcargar;
    }
}