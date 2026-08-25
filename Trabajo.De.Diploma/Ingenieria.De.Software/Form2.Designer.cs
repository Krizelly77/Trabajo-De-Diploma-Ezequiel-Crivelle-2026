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
            this.BTNidioma = new System.Windows.Forms.Button();
            this.BTNgestRolesPerm = new System.Windows.Forms.Button();
            this.BTNbitacora = new System.Windows.Forms.Button();
            this.BTNgestUsuarios = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.LBLnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombre.Location = new System.Drawing.Point(169, 51);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(31, 29);
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
            this.BTNcerrar.Location = new System.Drawing.Point(19, 346);
            this.BTNcerrar.Name = "BTNcerrar";
            this.BTNcerrar.Size = new System.Drawing.Size(113, 46);
            this.BTNcerrar.TabIndex = 1;
            this.BTNcerrar.Text = "Cerrar sesion";
            this.BTNcerrar.UseVisualStyleBackColor = false;
            this.BTNcerrar.Click += new System.EventHandler(this.BTNcerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.BTNidioma);
            this.panel1.Controls.Add(this.BTNgestRolesPerm);
            this.panel1.Controls.Add(this.BTNbitacora);
            this.panel1.Controls.Add(this.BTNgestUsuarios);
            this.panel1.Controls.Add(this.BTNcerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 404);
            this.panel1.TabIndex = 0;
            // 
            // BTNidioma
            // 
            this.BTNidioma.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNidioma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNidioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNidioma.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNidioma.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNidioma.Location = new System.Drawing.Point(19, 285);
            this.BTNidioma.Name = "BTNidioma";
            this.BTNidioma.Size = new System.Drawing.Size(113, 46);
            this.BTNidioma.TabIndex = 5;
            this.BTNidioma.Tag = "Permiso_Asignar_Roles";
            this.BTNidioma.Text = "Idioma";
            this.BTNidioma.UseVisualStyleBackColor = false;
            this.BTNidioma.Click += new System.EventHandler(this.BTNidioma_Click);
            // 
            // BTNgestRolesPerm
            // 
            this.BTNgestRolesPerm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNgestRolesPerm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNgestRolesPerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNgestRolesPerm.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNgestRolesPerm.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNgestRolesPerm.Location = new System.Drawing.Point(19, 181);
            this.BTNgestRolesPerm.Name = "BTNgestRolesPerm";
            this.BTNgestRolesPerm.Size = new System.Drawing.Size(113, 46);
            this.BTNgestRolesPerm.TabIndex = 4;
            this.BTNgestRolesPerm.Tag = "Permiso_Asignar_Roles";
            this.BTNgestRolesPerm.Text = "Gestionar Roles y Permisos";
            this.BTNgestRolesPerm.UseVisualStyleBackColor = false;
            this.BTNgestRolesPerm.Click += new System.EventHandler(this.BTNgestRolesPerm_Click);
            // 
            // BTNbitacora
            // 
            this.BTNbitacora.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNbitacora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNbitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNbitacora.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNbitacora.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNbitacora.Location = new System.Drawing.Point(19, 233);
            this.BTNbitacora.Name = "BTNbitacora";
            this.BTNbitacora.Size = new System.Drawing.Size(113, 46);
            this.BTNbitacora.TabIndex = 3;
            this.BTNbitacora.Tag = "Permiso_Ver_Bitacora";
            this.BTNbitacora.Text = "Bitácora";
            this.BTNbitacora.UseVisualStyleBackColor = false;
            this.BTNbitacora.Click += new System.EventHandler(this.BTNbitacora_Click);
            // 
            // BTNgestUsuarios
            // 
            this.BTNgestUsuarios.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNgestUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNgestUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNgestUsuarios.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNgestUsuarios.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNgestUsuarios.Location = new System.Drawing.Point(19, 129);
            this.BTNgestUsuarios.Name = "BTNgestUsuarios";
            this.BTNgestUsuarios.Size = new System.Drawing.Size(113, 46);
            this.BTNgestUsuarios.TabIndex = 0;
            this.BTNgestUsuarios.Tag = "Permiso_Ver_Usuarios";
            this.BTNgestUsuarios.Text = "Gestionar Usuarios";
            this.BTNgestUsuarios.UseVisualStyleBackColor = false;
            this.BTNgestUsuarios.Click += new System.EventHandler(this.BTNgestUsuarios_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBLnombre);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}