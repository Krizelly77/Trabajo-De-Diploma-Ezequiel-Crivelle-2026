namespace Ingenieria.De.Software
{
    partial class FormAsignacionPermisos
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
            this.CMBusuarios = new System.Windows.Forms.ComboBox();
            this.ArbolPermisosUsuario = new System.Windows.Forms.TreeView();
            this.LBXrolesDisponibles = new System.Windows.Forms.ListBox();
            this.BTNasignar = new System.Windows.Forms.Button();
            this.BTNrevocar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BRNvolver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CMBusuarios
            // 
            this.CMBusuarios.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CMBusuarios.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBusuarios.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CMBusuarios.FormattingEnabled = true;
            this.CMBusuarios.Location = new System.Drawing.Point(616, 15);
            this.CMBusuarios.Name = "CMBusuarios";
            this.CMBusuarios.Size = new System.Drawing.Size(269, 28);
            this.CMBusuarios.TabIndex = 0;
            this.CMBusuarios.SelectedIndexChanged += new System.EventHandler(this.CMBusuarios_SelectedIndexChanged);
            // 
            // ArbolPermisosUsuario
            // 
            this.ArbolPermisosUsuario.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ArbolPermisosUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArbolPermisosUsuario.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArbolPermisosUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.ArbolPermisosUsuario.Location = new System.Drawing.Point(12, 93);
            this.ArbolPermisosUsuario.Name = "ArbolPermisosUsuario";
            this.ArbolPermisosUsuario.Size = new System.Drawing.Size(364, 208);
            this.ArbolPermisosUsuario.TabIndex = 1;
            // 
            // LBXrolesDisponibles
            // 
            this.LBXrolesDisponibles.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.LBXrolesDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LBXrolesDisponibles.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBXrolesDisponibles.FormattingEnabled = true;
            this.LBXrolesDisponibles.Location = new System.Drawing.Point(523, 93);
            this.LBXrolesDisponibles.Name = "LBXrolesDisponibles";
            this.LBXrolesDisponibles.Size = new System.Drawing.Size(364, 208);
            this.LBXrolesDisponibles.TabIndex = 2;
            // 
            // BTNasignar
            // 
            this.BTNasignar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNasignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNasignar.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNasignar.ForeColor = System.Drawing.Color.Green;
            this.BTNasignar.Location = new System.Drawing.Point(382, 93);
            this.BTNasignar.Name = "BTNasignar";
            this.BTNasignar.Size = new System.Drawing.Size(135, 54);
            this.BTNasignar.TabIndex = 3;
            this.BTNasignar.Text = ">>";
            this.BTNasignar.UseVisualStyleBackColor = false;
            this.BTNasignar.Click += new System.EventHandler(this.BTNasignar_Click);
            // 
            // BTNrevocar
            // 
            this.BTNrevocar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNrevocar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNrevocar.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNrevocar.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNrevocar.Location = new System.Drawing.Point(382, 177);
            this.BTNrevocar.Name = "BTNrevocar";
            this.BTNrevocar.Size = new System.Drawing.Size(135, 54);
            this.BTNrevocar.TabIndex = 4;
            this.BTNrevocar.Text = "<<";
            this.BTNrevocar.UseVisualStyleBackColor = false;
            this.BTNrevocar.Click += new System.EventHandler(this.BTNrevocar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(517, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Usuario :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(612, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Roles del usuario ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(101, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Roles disponibles ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(419, 34);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seleccione roles para un usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(391, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Asignar Rol";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label6.Location = new System.Drawing.Point(391, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Revocar Rol";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CMBusuarios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 53);
            this.panel1.TabIndex = 12;
            // 
            // BRNvolver
            // 
            this.BRNvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BRNvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRNvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRNvolver.ForeColor = System.Drawing.SystemColors.Control;
            this.BRNvolver.Location = new System.Drawing.Point(382, 247);
            this.BRNvolver.Name = "BRNvolver";
            this.BRNvolver.Size = new System.Drawing.Size(135, 54);
            this.BRNvolver.TabIndex = 13;
            this.BRNvolver.Text = "Volver al menu anterior";
            this.BRNvolver.UseVisualStyleBackColor = false;
            this.BRNvolver.Click += new System.EventHandler(this.BRNvolver_Click);
            // 
            // FormAsignacionPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 308);
            this.Controls.Add(this.BRNvolver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNrevocar);
            this.Controls.Add(this.BTNasignar);
            this.Controls.Add(this.LBXrolesDisponibles);
            this.Controls.Add(this.ArbolPermisosUsuario);
            this.Name = "FormAsignacionPermisos";
            this.Text = "FormAsignacionPermisos";
            this.Load += new System.EventHandler(this.FormAsignacionPermisos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CMBusuarios;
        private System.Windows.Forms.TreeView ArbolPermisosUsuario;
        private System.Windows.Forms.ListBox LBXrolesDisponibles;
        private System.Windows.Forms.Button BTNasignar;
        private System.Windows.Forms.Button BTNrevocar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BRNvolver;
    }
}