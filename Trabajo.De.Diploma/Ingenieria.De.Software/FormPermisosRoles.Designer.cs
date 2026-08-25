namespace Ingenieria.De.Software
{
    partial class FormPermisosRoles
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
            this.ArbolPermisos = new System.Windows.Forms.TreeView();
            this.LBXcomponentes = new System.Windows.Forms.ListBox();
            this.BTNagregarAlRol = new System.Windows.Forms.Button();
            this.BTNquitarDelRol = new System.Windows.Forms.Button();
            this.BTNcrearRol = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TXTnomRol = new System.Windows.Forms.TextBox();
            this.BTNabrirrolusuario = new System.Windows.Forms.Button();
            this.BTNvolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNmodRol = new System.Windows.Forms.Button();
            this.BTNelimRol = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CMBroles = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArbolPermisos
            // 
            this.ArbolPermisos.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ArbolPermisos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArbolPermisos.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ArbolPermisos.Location = new System.Drawing.Point(560, 43);
            this.ArbolPermisos.Name = "ArbolPermisos";
            this.ArbolPermisos.Size = new System.Drawing.Size(353, 268);
            this.ArbolPermisos.TabIndex = 0;
            // 
            // LBXcomponentes
            // 
            this.LBXcomponentes.BackColor = System.Drawing.SystemColors.Control;
            this.LBXcomponentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LBXcomponentes.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBXcomponentes.FormattingEnabled = true;
            this.LBXcomponentes.Location = new System.Drawing.Point(29, 38);
            this.LBXcomponentes.Name = "LBXcomponentes";
            this.LBXcomponentes.Size = new System.Drawing.Size(351, 273);
            this.LBXcomponentes.TabIndex = 1;
            this.LBXcomponentes.SelectedIndexChanged += new System.EventHandler(this.LBXcomponentes_SelectedIndexChanged);
            this.LBXcomponentes.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LBXcomponentes_Format);
            // 
            // BTNagregarAlRol
            // 
            this.BTNagregarAlRol.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNagregarAlRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNagregarAlRol.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNagregarAlRol.ForeColor = System.Drawing.Color.Green;
            this.BTNagregarAlRol.Location = new System.Drawing.Point(414, 72);
            this.BTNagregarAlRol.Name = "BTNagregarAlRol";
            this.BTNagregarAlRol.Size = new System.Drawing.Size(140, 55);
            this.BTNagregarAlRol.TabIndex = 6;
            this.BTNagregarAlRol.Text = ">>";
            this.BTNagregarAlRol.UseVisualStyleBackColor = false;
            this.BTNagregarAlRol.Click += new System.EventHandler(this.BTNagregarAlRol_Click);
            // 
            // BTNquitarDelRol
            // 
            this.BTNquitarDelRol.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNquitarDelRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNquitarDelRol.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNquitarDelRol.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNquitarDelRol.Location = new System.Drawing.Point(414, 157);
            this.BTNquitarDelRol.Name = "BTNquitarDelRol";
            this.BTNquitarDelRol.Size = new System.Drawing.Size(140, 55);
            this.BTNquitarDelRol.TabIndex = 7;
            this.BTNquitarDelRol.Text = "<<";
            this.BTNquitarDelRol.UseVisualStyleBackColor = false;
            this.BTNquitarDelRol.Click += new System.EventHandler(this.BTNquitarDelRol_Click);
            // 
            // BTNcrearRol
            // 
            this.BTNcrearRol.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcrearRol.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcrearRol.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNcrearRol.Location = new System.Drawing.Point(488, 9);
            this.BTNcrearRol.Name = "BTNcrearRol";
            this.BTNcrearRol.Size = new System.Drawing.Size(136, 48);
            this.BTNcrearRol.TabIndex = 12;
            this.BTNcrearRol.Text = "Crear nuevo Rol con este nombre";
            this.BTNcrearRol.UseVisualStyleBackColor = false;
            this.BTNcrearRol.Click += new System.EventHandler(this.BTNcrearRol_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(484, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Rol Contenedor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(32, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(348, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Seleccione componente para Agregar";
            // 
            // TXTnomRol
            // 
            this.TXTnomRol.BackColor = System.Drawing.SystemColors.Control;
            this.TXTnomRol.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTnomRol.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTnomRol.Location = new System.Drawing.Point(157, 15);
            this.TXTnomRol.Name = "TXTnomRol";
            this.TXTnomRol.Size = new System.Drawing.Size(325, 35);
            this.TXTnomRol.TabIndex = 4;
            // 
            // BTNabrirrolusuario
            // 
            this.BTNabrirrolusuario.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNabrirrolusuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNabrirrolusuario.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNabrirrolusuario.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNabrirrolusuario.Location = new System.Drawing.Point(414, 218);
            this.BTNabrirrolusuario.Name = "BTNabrirrolusuario";
            this.BTNabrirrolusuario.Size = new System.Drawing.Size(140, 56);
            this.BTNabrirrolusuario.TabIndex = 15;
            this.BTNabrirrolusuario.Text = "Asignar Roles a un Usuario";
            this.BTNabrirrolusuario.UseVisualStyleBackColor = false;
            this.BTNabrirrolusuario.Click += new System.EventHandler(this.BTNabrirrolusuario_Click);
            // 
            // BTNvolver
            // 
            this.BTNvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolver.ForeColor = System.Drawing.Color.Green;
            this.BTNvolver.Location = new System.Drawing.Point(414, 280);
            this.BTNvolver.Name = "BTNvolver";
            this.BTNvolver.Size = new System.Drawing.Size(140, 54);
            this.BTNvolver.TabIndex = 16;
            this.BTNvolver.Text = "Volver al inicio";
            this.BTNvolver.UseVisualStyleBackColor = false;
            this.BTNvolver.Click += new System.EventHandler(this.BTNvolver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre del";
            // 
            // BTNmodRol
            // 
            this.BTNmodRol.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNmodRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmodRol.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmodRol.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmodRol.Location = new System.Drawing.Point(630, 9);
            this.BTNmodRol.Name = "BTNmodRol";
            this.BTNmodRol.Size = new System.Drawing.Size(136, 48);
            this.BTNmodRol.TabIndex = 18;
            this.BTNmodRol.Text = "Modificar Rol con este nombre";
            this.BTNmodRol.UseVisualStyleBackColor = false;
            this.BTNmodRol.Click += new System.EventHandler(this.BTNmodRol_Click);
            // 
            // BTNelimRol
            // 
            this.BTNelimRol.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNelimRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNelimRol.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNelimRol.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNelimRol.Location = new System.Drawing.Point(772, 9);
            this.BTNelimRol.Name = "BTNelimRol";
            this.BTNelimRol.Size = new System.Drawing.Size(136, 48);
            this.BTNelimRol.TabIndex = 19;
            this.BTNelimRol.Text = "Eliminar Rol con este nombre";
            this.BTNelimRol.UseVisualStyleBackColor = false;
            this.BTNelimRol.Click += new System.EventHandler(this.BTNelimRol_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(414, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Agregar al Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(414, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "Quitar del Rol";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Rol seleccionado:";
            // 
            // CMBroles
            // 
            this.CMBroles.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CMBroles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMBroles.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBroles.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CMBroles.FormattingEnabled = true;
            this.CMBroles.Location = new System.Drawing.Point(653, 9);
            this.CMBroles.Name = "CMBroles";
            this.CMBroles.Size = new System.Drawing.Size(260, 28);
            this.CMBroles.TabIndex = 23;
            this.CMBroles.SelectedIndexChanged += new System.EventHandler(this.CMBroles_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTNelimRol);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TXTnomRol);
            this.panel1.Controls.Add(this.BTNmodRol);
            this.panel1.Controls.Add(this.BTNcrearRol);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 65);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.LBXcomponentes);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 340);
            this.panel2.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(381, 30);
            this.label8.TabIndex = 15;
            this.label8.Text = "Crear y asiganar roles y permisos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label7.Location = new System.Drawing.Point(574, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(329, 24);
            this.label7.TabIndex = 26;
            this.label7.Text = "Seleccione componente para quitar";
            // 
            // FormPermisosRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 405);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CMBroles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNvolver);
            this.Controls.Add(this.BTNabrirrolusuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BTNquitarDelRol);
            this.Controls.Add(this.BTNagregarAlRol);
            this.Controls.Add(this.ArbolPermisos);
            this.Name = "FormPermisosRoles";
            this.Text = "FormPermisosRoles";
            this.Load += new System.EventHandler(this.FormPermisosRoles_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ArbolPermisos;
        private System.Windows.Forms.ListBox LBXcomponentes;
        private System.Windows.Forms.Button BTNagregarAlRol;
        private System.Windows.Forms.Button BTNquitarDelRol;
        private System.Windows.Forms.Button BTNcrearRol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TXTnomRol;
        private System.Windows.Forms.Button BTNabrirrolusuario;
        private System.Windows.Forms.Button BTNvolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNmodRol;
        private System.Windows.Forms.Button BTNelimRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CMBroles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}