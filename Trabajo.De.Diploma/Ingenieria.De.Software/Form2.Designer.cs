namespace Ingenieria.De.Software
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.BTNcerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNopUsuario = new System.Windows.Forms.Button();
            this.BTNidioma = new System.Windows.Forms.Button();
            this.BTNgestRolesPerm = new System.Windows.Forms.Button();
            this.BTNbitacora = new System.Windows.Forms.Button();
            this.BTNgestUsuarios = new System.Windows.Forms.Button();
            this.BTNmisActividades = new System.Windows.Forms.Button();
            this.BTNverActividades = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario:";
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombre.Location = new System.Drawing.Point(169, 51);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(39, 33);
            this.LBLnombre.TabIndex = 1;
            this.LBLnombre.Text = "...";
            // 
            // BTNcerrar
            // 
            this.BTNcerrar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNcerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcerrar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcerrar.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNcerrar.Location = new System.Drawing.Point(15, 374);
            this.BTNcerrar.Name = "BTNcerrar";
            this.BTNcerrar.Size = new System.Drawing.Size(129, 46);
            this.BTNcerrar.TabIndex = 5;
            this.BTNcerrar.Text = "Cerrar sesion";
            this.BTNcerrar.UseVisualStyleBackColor = false;
            this.BTNcerrar.Click += new System.EventHandler(this.BTNcerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.BTNopUsuario);
            this.panel1.Controls.Add(this.BTNidioma);
            this.panel1.Controls.Add(this.BTNgestRolesPerm);
            this.panel1.Controls.Add(this.BTNbitacora);
            this.panel1.Controls.Add(this.BTNgestUsuarios);
            this.panel1.Controls.Add(this.BTNcerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 431);
            this.panel1.TabIndex = 0;
            // 
            // BTNopUsuario
            // 
            this.BTNopUsuario.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNopUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNopUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNopUsuario.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNopUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNopUsuario.Location = new System.Drawing.Point(15, 105);
            this.BTNopUsuario.Name = "BTNopUsuario";
            this.BTNopUsuario.Size = new System.Drawing.Size(129, 46);
            this.BTNopUsuario.TabIndex = 0;
            this.BTNopUsuario.Tag = "";
            this.BTNopUsuario.Text = "Opciones de Usuario";
            this.BTNopUsuario.UseVisualStyleBackColor = false;
            this.BTNopUsuario.Click += new System.EventHandler(this.BTNopUsuario_Click);
            // 
            // BTNidioma
            // 
            this.BTNidioma.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNidioma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNidioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNidioma.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNidioma.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNidioma.Location = new System.Drawing.Point(15, 313);
            this.BTNidioma.Name = "BTNidioma";
            this.BTNidioma.Size = new System.Drawing.Size(129, 46);
            this.BTNidioma.TabIndex = 4;
            this.BTNidioma.Tag = "Permiso_Asignar_Roles";
            this.BTNidioma.Text = "Idioma";
            this.BTNidioma.UseVisualStyleBackColor = false;
            this.BTNidioma.Click += new System.EventHandler(this.BTNidioma_Click);
            // 
            // BTNgestRolesPerm
            // 
            this.BTNgestRolesPerm.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNgestRolesPerm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNgestRolesPerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNgestRolesPerm.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNgestRolesPerm.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNgestRolesPerm.Location = new System.Drawing.Point(15, 209);
            this.BTNgestRolesPerm.Name = "BTNgestRolesPerm";
            this.BTNgestRolesPerm.Size = new System.Drawing.Size(129, 46);
            this.BTNgestRolesPerm.TabIndex = 2;
            this.BTNgestRolesPerm.Tag = "Permiso_Asignar_Roles";
            this.BTNgestRolesPerm.Text = "Gestionar Roles y Permisos";
            this.BTNgestRolesPerm.UseVisualStyleBackColor = false;
            this.BTNgestRolesPerm.Click += new System.EventHandler(this.BTNgestRolesPerm_Click);
            // 
            // BTNbitacora
            // 
            this.BTNbitacora.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNbitacora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNbitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNbitacora.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNbitacora.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNbitacora.Location = new System.Drawing.Point(15, 261);
            this.BTNbitacora.Name = "BTNbitacora";
            this.BTNbitacora.Size = new System.Drawing.Size(129, 46);
            this.BTNbitacora.TabIndex = 3;
            this.BTNbitacora.Tag = "Permiso_Ver_Bitacora";
            this.BTNbitacora.Text = "Bitácora";
            this.BTNbitacora.UseVisualStyleBackColor = false;
            this.BTNbitacora.Click += new System.EventHandler(this.BTNbitacora_Click);
            // 
            // BTNgestUsuarios
            // 
            this.BTNgestUsuarios.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNgestUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNgestUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNgestUsuarios.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNgestUsuarios.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNgestUsuarios.Location = new System.Drawing.Point(15, 157);
            this.BTNgestUsuarios.Name = "BTNgestUsuarios";
            this.BTNgestUsuarios.Size = new System.Drawing.Size(129, 46);
            this.BTNgestUsuarios.TabIndex = 1;
            this.BTNgestUsuarios.Tag = "Permiso_Ver_Usuarios";
            this.BTNgestUsuarios.Text = "Gestionar Usuarios";
            this.BTNgestUsuarios.UseVisualStyleBackColor = false;
            this.BTNgestUsuarios.Click += new System.EventHandler(this.BTNgestUsuarios_Click);
            // 
            // BTNmisActividades
            // 
            this.BTNmisActividades.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNmisActividades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmisActividades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmisActividades.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmisActividades.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmisActividades.Location = new System.Drawing.Point(212, 313);
            this.BTNmisActividades.Name = "BTNmisActividades";
            this.BTNmisActividades.Size = new System.Drawing.Size(300, 46);
            this.BTNmisActividades.TabIndex = 6;
            this.BTNmisActividades.Tag = "";
            this.BTNmisActividades.Text = "Mis Actividades";
            this.BTNmisActividades.UseVisualStyleBackColor = false;
            this.BTNmisActividades.Click += new System.EventHandler(this.BTNmisActividades_Click);
            // 
            // BTNverActividades
            // 
            this.BTNverActividades.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNverActividades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNverActividades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNverActividades.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNverActividades.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNverActividades.Location = new System.Drawing.Point(550, 313);
            this.BTNverActividades.Name = "BTNverActividades";
            this.BTNverActividades.Size = new System.Drawing.Size(300, 46);
            this.BTNverActividades.TabIndex = 7;
            this.BTNverActividades.Tag = "";
            this.BTNverActividades.Text = "Actividades Disponibles";
            this.BTNverActividades.UseVisualStyleBackColor = false;
            this.BTNverActividades.Click += new System.EventHandler(this.BTNverActividades_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::Ingenieria.De.Software.Properties.Resources.Insoft_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(400, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 191);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 431);
            this.Controls.Add(this.BTNverActividades);
            this.Controls.Add(this.BTNmisActividades);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBLnombre);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Button BTNcerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTNgestUsuarios;
        private System.Windows.Forms.Button BTNbitacora;
        private System.Windows.Forms.Button BTNgestRolesPerm;
        private System.Windows.Forms.Button BTNidioma;
        private System.Windows.Forms.Button BTNopUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTNmisActividades;
        private System.Windows.Forms.Button BTNverActividades;
    }
}