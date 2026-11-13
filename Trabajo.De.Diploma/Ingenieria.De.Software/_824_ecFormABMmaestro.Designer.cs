namespace Ingenieria.De.Software
{
    partial class _824_ecFormABMmaestro
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
            this.LBLnombre = new System.Windows.Forms.Label();
            this.BTNmaeSol = new System.Windows.Forms.Button();
            this.BTNmaePar = new System.Windows.Forms.Button();
            this.BTNmaeNot = new System.Windows.Forms.Button();
            this.BTNmaePos = new System.Windows.Forms.Button();
            this.BTNmaeCat = new System.Windows.Forms.Button();
            this.BTNmaeAct = new System.Windows.Forms.Button();
            this.BTNmodMae = new System.Windows.Forms.Button();
            this.BTNcrearMae = new System.Windows.Forms.Button();
            this.BTNeliminarMae = new System.Windows.Forms.Button();
            this.BTNvolver = new System.Windows.Forms.Button();
            this.BTNcargar = new System.Windows.Forms.Button();
            this.BTNlimpiar = new System.Windows.Forms.Button();
            this.BTNdeserializar = new System.Windows.Forms.Button();
            this.BTNserializar = new System.Windows.Forms.Button();
            this.BTNverMae = new System.Windows.Forms.Button();
            this.DGVmaestro = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVmaestro)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.LBLnombre);
            this.panel1.Controls.Add(this.BTNmaeSol);
            this.panel1.Controls.Add(this.BTNmaePar);
            this.panel1.Controls.Add(this.BTNmaeNot);
            this.panel1.Controls.Add(this.BTNmaePos);
            this.panel1.Controls.Add(this.BTNmaeCat);
            this.panel1.Controls.Add(this.BTNmaeAct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 45);
            this.panel1.TabIndex = 0;
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombre.ForeColor = System.Drawing.SystemColors.Control;
            this.LBLnombre.Location = new System.Drawing.Point(3, 7);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(191, 33);
            this.LBLnombre.TabIndex = 2;
            this.LBLnombre.Text = "AMB maestro";
            // 
            // BTNmaeSol
            // 
            this.BTNmaeSol.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNmaeSol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmaeSol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmaeSol.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmaeSol.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmaeSol.Location = new System.Drawing.Point(896, 3);
            this.BTNmaeSol.Name = "BTNmaeSol";
            this.BTNmaeSol.Size = new System.Drawing.Size(129, 37);
            this.BTNmaeSol.TabIndex = 9;
            this.BTNmaeSol.Tag = "";
            this.BTNmaeSol.Text = "Solicitante ";
            this.BTNmaeSol.UseVisualStyleBackColor = false;
            this.BTNmaeSol.Click += new System.EventHandler(this.BTNmaeSol_Click);
            // 
            // BTNmaePar
            // 
            this.BTNmaePar.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNmaePar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmaePar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmaePar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmaePar.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmaePar.Location = new System.Drawing.Point(761, 3);
            this.BTNmaePar.Name = "BTNmaePar";
            this.BTNmaePar.Size = new System.Drawing.Size(129, 37);
            this.BTNmaePar.TabIndex = 8;
            this.BTNmaePar.Tag = "";
            this.BTNmaePar.Text = "Participante";
            this.BTNmaePar.UseVisualStyleBackColor = false;
            this.BTNmaePar.Click += new System.EventHandler(this.BTNmaePar_Click);
            // 
            // BTNmaeNot
            // 
            this.BTNmaeNot.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNmaeNot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmaeNot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmaeNot.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmaeNot.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmaeNot.Location = new System.Drawing.Point(626, 3);
            this.BTNmaeNot.Name = "BTNmaeNot";
            this.BTNmaeNot.Size = new System.Drawing.Size(129, 37);
            this.BTNmaeNot.TabIndex = 7;
            this.BTNmaeNot.Tag = "";
            this.BTNmaeNot.Text = "Notificacion";
            this.BTNmaeNot.UseVisualStyleBackColor = false;
            this.BTNmaeNot.Click += new System.EventHandler(this.BTNmaeNot_Click);
            // 
            // BTNmaePos
            // 
            this.BTNmaePos.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNmaePos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmaePos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmaePos.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmaePos.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmaePos.Location = new System.Drawing.Point(491, 3);
            this.BTNmaePos.Name = "BTNmaePos";
            this.BTNmaePos.Size = new System.Drawing.Size(129, 37);
            this.BTNmaePos.TabIndex = 6;
            this.BTNmaePos.Tag = "";
            this.BTNmaePos.Text = "Postulacion";
            this.BTNmaePos.UseVisualStyleBackColor = false;
            this.BTNmaePos.Click += new System.EventHandler(this.BTNmaePos_Click);
            // 
            // BTNmaeCat
            // 
            this.BTNmaeCat.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNmaeCat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmaeCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmaeCat.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmaeCat.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmaeCat.Location = new System.Drawing.Point(356, 3);
            this.BTNmaeCat.Name = "BTNmaeCat";
            this.BTNmaeCat.Size = new System.Drawing.Size(129, 37);
            this.BTNmaeCat.TabIndex = 5;
            this.BTNmaeCat.Tag = "";
            this.BTNmaeCat.Text = "Categoria";
            this.BTNmaeCat.UseVisualStyleBackColor = false;
            this.BTNmaeCat.Click += new System.EventHandler(this.BTNmaeCat_Click);
            // 
            // BTNmaeAct
            // 
            this.BTNmaeAct.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNmaeAct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmaeAct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmaeAct.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmaeAct.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmaeAct.Location = new System.Drawing.Point(221, 3);
            this.BTNmaeAct.Name = "BTNmaeAct";
            this.BTNmaeAct.Size = new System.Drawing.Size(129, 37);
            this.BTNmaeAct.TabIndex = 4;
            this.BTNmaeAct.Tag = "";
            this.BTNmaeAct.Text = "Actividad";
            this.BTNmaeAct.UseVisualStyleBackColor = false;
            this.BTNmaeAct.Click += new System.EventHandler(this.BTNmaeAct_Click);
            // 
            // BTNmodMae
            // 
            this.BTNmodMae.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNmodMae.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNmodMae.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmodMae.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmodMae.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNmodMae.Location = new System.Drawing.Point(9, 170);
            this.BTNmodMae.Name = "BTNmodMae";
            this.BTNmodMae.Size = new System.Drawing.Size(172, 56);
            this.BTNmodMae.TabIndex = 4;
            this.BTNmodMae.Tag = "";
            this.BTNmodMae.Text = "Modificar Maestro";
            this.BTNmodMae.UseVisualStyleBackColor = false;
            this.BTNmodMae.Click += new System.EventHandler(this.BTNmodMae_Click);
            // 
            // BTNcrearMae
            // 
            this.BTNcrearMae.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcrearMae.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNcrearMae.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcrearMae.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcrearMae.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNcrearMae.Location = new System.Drawing.Point(9, 108);
            this.BTNcrearMae.Name = "BTNcrearMae";
            this.BTNcrearMae.Size = new System.Drawing.Size(172, 56);
            this.BTNcrearMae.TabIndex = 3;
            this.BTNcrearMae.Tag = "";
            this.BTNcrearMae.Text = "Crear Nuevo Maestro";
            this.BTNcrearMae.UseVisualStyleBackColor = false;
            this.BTNcrearMae.Click += new System.EventHandler(this.BTNcrearMae_Click);
            // 
            // BTNeliminarMae
            // 
            this.BTNeliminarMae.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNeliminarMae.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNeliminarMae.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNeliminarMae.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNeliminarMae.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNeliminarMae.Location = new System.Drawing.Point(9, 294);
            this.BTNeliminarMae.Name = "BTNeliminarMae";
            this.BTNeliminarMae.Size = new System.Drawing.Size(172, 56);
            this.BTNeliminarMae.TabIndex = 5;
            this.BTNeliminarMae.Tag = "Permiso_Baja_Usuario";
            this.BTNeliminarMae.Text = "Eliminar Maestro";
            this.BTNeliminarMae.UseVisualStyleBackColor = false;
            this.BTNeliminarMae.Click += new System.EventHandler(this.BTNeliminarMae_Click);
            // 
            // BTNvolver
            // 
            this.BTNvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNvolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolver.ForeColor = System.Drawing.Color.OliveDrab;
            this.BTNvolver.Location = new System.Drawing.Point(9, 410);
            this.BTNvolver.Name = "BTNvolver";
            this.BTNvolver.Size = new System.Drawing.Size(172, 56);
            this.BTNvolver.TabIndex = 13;
            this.BTNvolver.Text = "Volver al menu";
            this.BTNvolver.UseVisualStyleBackColor = false;
            this.BTNvolver.Click += new System.EventHandler(this.BTNvolver_Click);
            // 
            // BTNcargar
            // 
            this.BTNcargar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNcargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcargar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcargar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNcargar.Location = new System.Drawing.Point(859, 423);
            this.BTNcargar.Name = "BTNcargar";
            this.BTNcargar.Size = new System.Drawing.Size(166, 43);
            this.BTNcargar.TabIndex = 25;
            this.BTNcargar.Text = "Cargar Grilla";
            this.BTNcargar.UseVisualStyleBackColor = false;
            this.BTNcargar.Click += new System.EventHandler(this.BTNcargar_Click);
            // 
            // BTNlimpiar
            // 
            this.BTNlimpiar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNlimpiar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNlimpiar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNlimpiar.Location = new System.Drawing.Point(687, 423);
            this.BTNlimpiar.Name = "BTNlimpiar";
            this.BTNlimpiar.Size = new System.Drawing.Size(166, 43);
            this.BTNlimpiar.TabIndex = 24;
            this.BTNlimpiar.Text = "Limpiar Grilla";
            this.BTNlimpiar.UseVisualStyleBackColor = false;
            this.BTNlimpiar.Click += new System.EventHandler(this.BTNlimpiar_Click);
            // 
            // BTNdeserializar
            // 
            this.BTNdeserializar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNdeserializar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNdeserializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNdeserializar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNdeserializar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNdeserializar.Location = new System.Drawing.Point(515, 423);
            this.BTNdeserializar.Name = "BTNdeserializar";
            this.BTNdeserializar.Size = new System.Drawing.Size(166, 43);
            this.BTNdeserializar.TabIndex = 23;
            this.BTNdeserializar.Text = "Deserializar";
            this.BTNdeserializar.UseVisualStyleBackColor = false;
            this.BTNdeserializar.Click += new System.EventHandler(this.BTNdeserializar_Click);
            // 
            // BTNserializar
            // 
            this.BTNserializar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNserializar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNserializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNserializar.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNserializar.ForeColor = System.Drawing.Color.LightCyan;
            this.BTNserializar.Location = new System.Drawing.Point(343, 423);
            this.BTNserializar.Name = "BTNserializar";
            this.BTNserializar.Size = new System.Drawing.Size(166, 43);
            this.BTNserializar.TabIndex = 22;
            this.BTNserializar.Text = "Serializar";
            this.BTNserializar.UseVisualStyleBackColor = false;
            this.BTNserializar.Click += new System.EventHandler(this.BTNserializar_Click);
            // 
            // BTNverMae
            // 
            this.BTNverMae.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNverMae.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNverMae.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNverMae.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNverMae.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNverMae.Location = new System.Drawing.Point(9, 232);
            this.BTNverMae.Name = "BTNverMae";
            this.BTNverMae.Size = new System.Drawing.Size(172, 56);
            this.BTNverMae.TabIndex = 26;
            this.BTNverMae.Tag = "";
            this.BTNverMae.Text = "Ver Maestro";
            this.BTNverMae.UseVisualStyleBackColor = false;
            this.BTNverMae.Click += new System.EventHandler(this.BTNverMae_Click);
            // 
            // DGVmaestro
            // 
            this.DGVmaestro.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVmaestro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVmaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVmaestro.Location = new System.Drawing.Point(207, 60);
            this.DGVmaestro.Name = "DGVmaestro";
            this.DGVmaestro.Size = new System.Drawing.Size(818, 357);
            this.DGVmaestro.TabIndex = 27;
            // 
            // _824_ecFormABMmaestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 470);
            this.Controls.Add(this.DGVmaestro);
            this.Controls.Add(this.BTNverMae);
            this.Controls.Add(this.BTNcargar);
            this.Controls.Add(this.BTNlimpiar);
            this.Controls.Add(this.BTNdeserializar);
            this.Controls.Add(this.BTNserializar);
            this.Controls.Add(this.BTNvolver);
            this.Controls.Add(this.BTNeliminarMae);
            this.Controls.Add(this.BTNmodMae);
            this.Controls.Add(this.BTNcrearMae);
            this.Controls.Add(this.panel1);
            this.Name = "_824_ecFormABMmaestro";
            this.Text = "ABMmaestro";
            this.Load += new System.EventHandler(this.ABMmaestro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVmaestro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTNmaeAct;
        private System.Windows.Forms.Button BTNmaeSol;
        private System.Windows.Forms.Button BTNmaePar;
        private System.Windows.Forms.Button BTNmaeNot;
        private System.Windows.Forms.Button BTNmaePos;
        private System.Windows.Forms.Button BTNmaeCat;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Button BTNmodMae;
        private System.Windows.Forms.Button BTNcrearMae;
        private System.Windows.Forms.Button BTNeliminarMae;
        private System.Windows.Forms.Button BTNvolver;
        private System.Windows.Forms.Button BTNcargar;
        private System.Windows.Forms.Button BTNlimpiar;
        private System.Windows.Forms.Button BTNdeserializar;
        private System.Windows.Forms.Button BTNserializar;
        private System.Windows.Forms.Button BTNverMae;
        private System.Windows.Forms.DataGridView DGVmaestro;
    }
}