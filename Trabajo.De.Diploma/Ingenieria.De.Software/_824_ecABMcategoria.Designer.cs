namespace Ingenieria.De.Software
{
    partial class _824_ecABMcategoria
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
            this.BTNrestablecerCampos = new System.Windows.Forms.Button();
            this.LBLtitulo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TXTnombre = new System.Windows.Forms.TextBox();
            this.TXBdescripcion = new System.Windows.Forms.TextBox();
            this.BTNconfirmar = new System.Windows.Forms.Button();
            this.BTNcancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.BTNrestablecerCampos);
            this.panel1.Controls.Add(this.LBLtitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 50);
            this.panel1.TabIndex = 0;
            // 
            // BTNrestablecerCampos
            // 
            this.BTNrestablecerCampos.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNrestablecerCampos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNrestablecerCampos.Enabled = false;
            this.BTNrestablecerCampos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNrestablecerCampos.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNrestablecerCampos.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNrestablecerCampos.Location = new System.Drawing.Point(421, 5);
            this.BTNrestablecerCampos.Name = "BTNrestablecerCampos";
            this.BTNrestablecerCampos.Size = new System.Drawing.Size(109, 42);
            this.BTNrestablecerCampos.TabIndex = 82;
            this.BTNrestablecerCampos.Tag = "Permiso_Asignar_Roles";
            this.BTNrestablecerCampos.Text = "Restablecer";
            this.BTNrestablecerCampos.UseVisualStyleBackColor = false;
            this.BTNrestablecerCampos.Visible = false;
            this.BTNrestablecerCampos.Click += new System.EventHandler(this.BTNrestablecerCampos_Click);
            // 
            // LBLtitulo
            // 
            this.LBLtitulo.AutoSize = true;
            this.LBLtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLtitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.LBLtitulo.Location = new System.Drawing.Point(10, 9);
            this.LBLtitulo.Name = "LBLtitulo";
            this.LBLtitulo.Size = new System.Drawing.Size(265, 37);
            this.LBLtitulo.TabIndex = 28;
            this.LBLtitulo.Text = "Alta de Categoria";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Location = new System.Drawing.Point(12, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 29);
            this.label11.TabIndex = 41;
            this.label11.Text = "Nombre :";
            // 
            // TXTnombre
            // 
            this.TXTnombre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTnombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTnombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTnombre.Location = new System.Drawing.Point(131, 66);
            this.TXTnombre.Name = "TXTnombre";
            this.TXTnombre.Size = new System.Drawing.Size(401, 31);
            this.TXTnombre.TabIndex = 66;
            this.TXTnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTnombre_KeyPress);
            // 
            // TXBdescripcion
            // 
            this.TXBdescripcion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXBdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXBdescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXBdescripcion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXBdescripcion.Location = new System.Drawing.Point(17, 112);
            this.TXBdescripcion.Multiline = true;
            this.TXBdescripcion.Name = "TXBdescripcion";
            this.TXBdescripcion.Size = new System.Drawing.Size(513, 96);
            this.TXBdescripcion.TabIndex = 67;
            this.TXBdescripcion.Text = "Descripcion";
            // 
            // BTNconfirmar
            // 
            this.BTNconfirmar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNconfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNconfirmar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNconfirmar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.BTNconfirmar.Location = new System.Drawing.Point(214, 220);
            this.BTNconfirmar.Name = "BTNconfirmar";
            this.BTNconfirmar.Size = new System.Drawing.Size(155, 52);
            this.BTNconfirmar.TabIndex = 80;
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
            this.BTNcancelar.Location = new System.Drawing.Point(375, 220);
            this.BTNcancelar.Name = "BTNcancelar";
            this.BTNcancelar.Size = new System.Drawing.Size(155, 52);
            this.BTNcancelar.TabIndex = 81;
            this.BTNcancelar.Text = "Cancelar";
            this.BTNcancelar.UseVisualStyleBackColor = false;
            this.BTNcancelar.Click += new System.EventHandler(this.BTNcancelar_Click);
            // 
            // _824_ecABMcategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 284);
            this.Controls.Add(this.BTNcancelar);
            this.Controls.Add(this.BTNconfirmar);
            this.Controls.Add(this.TXBdescripcion);
            this.Controls.Add(this.TXTnombre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Name = "_824_ecABMcategoria";
            this.Text = "_824_ecABMcategoria";
            this.Load += new System.EventHandler(this._824_ecABMcategoria_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBLtitulo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TXTnombre;
        private System.Windows.Forms.TextBox TXBdescripcion;
        private System.Windows.Forms.Button BTNconfirmar;
        private System.Windows.Forms.Button BTNcancelar;
        private System.Windows.Forms.Button BTNrestablecerCampos;
    }
}