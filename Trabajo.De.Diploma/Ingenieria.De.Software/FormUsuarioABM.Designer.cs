namespace Ingenieria.De.Software
{
    partial class FormUsuarioABM
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
            this.LBLusuario = new System.Windows.Forms.Label();
            this.TXTnomusu = new System.Windows.Forms.TextBox();
            this.TXTnomcon = new System.Windows.Forms.TextBox();
            this.CHKactivo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PNLtitulo = new System.Windows.Forms.Panel();
            this.BTNconfirmar = new System.Windows.Forms.Button();
            this.BTNcancelar = new System.Windows.Forms.Button();
            this.CHKcontra = new System.Windows.Forms.CheckBox();
            this.CHKmostrar = new System.Windows.Forms.CheckBox();
            this.CMBpermisos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CHKbloqueoDV = new System.Windows.Forms.CheckBox();
            this.PNLtitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBLusuario
            // 
            this.LBLusuario.AutoSize = true;
            this.LBLusuario.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLusuario.ForeColor = System.Drawing.SystemColors.Control;
            this.LBLusuario.Location = new System.Drawing.Point(15, 9);
            this.LBLusuario.Name = "LBLusuario";
            this.LBLusuario.Size = new System.Drawing.Size(133, 40);
            this.LBLusuario.TabIndex = 0;
            this.LBLusuario.Text = "Usuario";
            // 
            // TXTnomusu
            // 
            this.TXTnomusu.BackColor = System.Drawing.SystemColors.Control;
            this.TXTnomusu.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTnomusu.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTnomusu.Location = new System.Drawing.Point(236, 83);
            this.TXTnomusu.Name = "TXTnomusu";
            this.TXTnomusu.Size = new System.Drawing.Size(391, 29);
            this.TXTnomusu.TabIndex = 1;
            this.TXTnomusu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTnomusu_KeyPress);
            // 
            // TXTnomcon
            // 
            this.TXTnomcon.BackColor = System.Drawing.SystemColors.Control;
            this.TXTnomcon.Enabled = false;
            this.TXTnomcon.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTnomcon.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTnomcon.Location = new System.Drawing.Point(235, 133);
            this.TXTnomcon.Name = "TXTnomcon";
            this.TXTnomcon.Size = new System.Drawing.Size(391, 29);
            this.TXTnomcon.TabIndex = 2;
            this.TXTnomcon.UseSystemPasswordChar = true;
            this.TXTnomcon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTnomcon_KeyPress);
            // 
            // CHKactivo
            // 
            this.CHKactivo.AutoSize = true;
            this.CHKactivo.BackColor = System.Drawing.SystemColors.Control;
            this.CHKactivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHKactivo.Checked = true;
            this.CHKactivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHKactivo.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKactivo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CHKactivo.Location = new System.Drawing.Point(22, 258);
            this.CHKactivo.Name = "CHKactivo";
            this.CHKactivo.Size = new System.Drawing.Size(103, 31);
            this.CHKactivo.TabIndex = 3;
            this.CHKactivo.Text = "Activo :";
            this.CHKactivo.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(17, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre de usuario:";
            // 
            // PNLtitulo
            // 
            this.PNLtitulo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PNLtitulo.Controls.Add(this.LBLusuario);
            this.PNLtitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNLtitulo.Location = new System.Drawing.Point(0, 0);
            this.PNLtitulo.Name = "PNLtitulo";
            this.PNLtitulo.Size = new System.Drawing.Size(639, 50);
            this.PNLtitulo.TabIndex = 6;
            // 
            // BTNconfirmar
            // 
            this.BTNconfirmar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNconfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNconfirmar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNconfirmar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.BTNconfirmar.Location = new System.Drawing.Point(284, 248);
            this.BTNconfirmar.Name = "BTNconfirmar";
            this.BTNconfirmar.Size = new System.Drawing.Size(155, 52);
            this.BTNconfirmar.TabIndex = 7;
            this.BTNconfirmar.Text = "Confirmar";
            this.BTNconfirmar.UseVisualStyleBackColor = false;
            this.BTNconfirmar.Click += new System.EventHandler(this.BTNconfirmar_Click);
            // 
            // BTNcancelar
            // 
            this.BTNcancelar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcancelar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcancelar.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNcancelar.Location = new System.Drawing.Point(472, 248);
            this.BTNcancelar.Name = "BTNcancelar";
            this.BTNcancelar.Size = new System.Drawing.Size(155, 52);
            this.BTNcancelar.TabIndex = 8;
            this.BTNcancelar.Text = "Cancelar";
            this.BTNcancelar.UseVisualStyleBackColor = false;
            this.BTNcancelar.Click += new System.EventHandler(this.BTNcancelar_Click);
            // 
            // CHKcontra
            // 
            this.CHKcontra.AutoSize = true;
            this.CHKcontra.BackColor = System.Drawing.SystemColors.Control;
            this.CHKcontra.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKcontra.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CHKcontra.Location = new System.Drawing.Point(22, 133);
            this.CHKcontra.Name = "CHKcontra";
            this.CHKcontra.Size = new System.Drawing.Size(156, 31);
            this.CHKcontra.TabIndex = 9;
            this.CHKcontra.Text = "Contraseña :";
            this.CHKcontra.UseVisualStyleBackColor = false;
            this.CHKcontra.CheckedChanged += new System.EventHandler(this.CHKcontra_CheckedChanged);
            // 
            // CHKmostrar
            // 
            this.CHKmostrar.AutoSize = true;
            this.CHKmostrar.BackColor = System.Drawing.SystemColors.Control;
            this.CHKmostrar.Enabled = false;
            this.CHKmostrar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKmostrar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CHKmostrar.Location = new System.Drawing.Point(471, 168);
            this.CHKmostrar.Name = "CHKmostrar";
            this.CHKmostrar.Size = new System.Drawing.Size(146, 21);
            this.CHKmostrar.TabIndex = 10;
            this.CHKmostrar.Text = "Mostrar contraseña";
            this.CHKmostrar.UseVisualStyleBackColor = false;
            this.CHKmostrar.Visible = false;
            this.CHKmostrar.CheckedChanged += new System.EventHandler(this.CHKmostrar_CheckedChanged);
            // 
            // CMBpermisos
            // 
            this.CMBpermisos.BackColor = System.Drawing.SystemColors.Control;
            this.CMBpermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBpermisos.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBpermisos.FormattingEnabled = true;
            this.CMBpermisos.Location = new System.Drawing.Point(236, 195);
            this.CMBpermisos.Name = "CMBpermisos";
            this.CMBpermisos.Size = new System.Drawing.Size(391, 28);
            this.CMBpermisos.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(17, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nivel de Permisos:";
            // 
            // CHKbloqueoDV
            // 
            this.CHKbloqueoDV.AutoSize = true;
            this.CHKbloqueoDV.BackColor = System.Drawing.SystemColors.Control;
            this.CHKbloqueoDV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHKbloqueoDV.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKbloqueoDV.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CHKbloqueoDV.Location = new System.Drawing.Point(131, 258);
            this.CHKbloqueoDV.Name = "CHKbloqueoDV";
            this.CHKbloqueoDV.Size = new System.Drawing.Size(123, 31);
            this.CHKbloqueoDV.TabIndex = 13;
            this.CHKbloqueoDV.Text = "Bloqueo :";
            this.CHKbloqueoDV.UseVisualStyleBackColor = false;
            // 
            // FormUsuarioABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 315);
            this.Controls.Add(this.CHKbloqueoDV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CMBpermisos);
            this.Controls.Add(this.CHKmostrar);
            this.Controls.Add(this.CHKcontra);
            this.Controls.Add(this.BTNcancelar);
            this.Controls.Add(this.BTNconfirmar);
            this.Controls.Add(this.PNLtitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CHKactivo);
            this.Controls.Add(this.TXTnomcon);
            this.Controls.Add(this.TXTnomusu);
            this.Name = "FormUsuarioABM";
            this.Text = "FormUsuarioABM";
            this.Load += new System.EventHandler(this.FormUsuarioABM_Load);
            this.PNLtitulo.ResumeLayout(false);
            this.PNLtitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBLusuario;
        private System.Windows.Forms.TextBox TXTnomusu;
        private System.Windows.Forms.TextBox TXTnomcon;
        private System.Windows.Forms.CheckBox CHKactivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PNLtitulo;
        private System.Windows.Forms.Button BTNconfirmar;
        private System.Windows.Forms.Button BTNcancelar;
        private System.Windows.Forms.CheckBox CHKcontra;
        private System.Windows.Forms.CheckBox CHKmostrar;
        private System.Windows.Forms.ComboBox CMBpermisos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CHKbloqueoDV;
    }
}