namespace Ingenieria.De.Software
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TXTusua = new System.Windows.Forms.TextBox();
            this.TXTcontra = new System.Windows.Forms.TextBox();
            this.BTNingresar = new System.Windows.Forms.Button();
            this.LBLtimer = new System.Windows.Forms.Label();
            this.CHKcontra = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTNcancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LBLLoguin = new System.Windows.Forms.Label();
            this.LBLerrores = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TXTusua
            // 
            this.TXTusua.BackColor = System.Drawing.SystemColors.Control;
            this.TXTusua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTusua.Font = new System.Drawing.Font("Microsoft JhengHei", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTusua.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTusua.Location = new System.Drawing.Point(216, 44);
            this.TXTusua.Name = "TXTusua";
            this.TXTusua.Size = new System.Drawing.Size(370, 39);
            this.TXTusua.TabIndex = 1;
            this.TXTusua.Text = "USUARIO";
            this.TXTusua.Enter += new System.EventHandler(this.TXTusua_Enter);
            this.TXTusua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTusua_KeyPress);
            this.TXTusua.Leave += new System.EventHandler(this.TXTusua_Leave);
            // 
            // TXTcontra
            // 
            this.TXTcontra.BackColor = System.Drawing.SystemColors.Control;
            this.TXTcontra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTcontra.Font = new System.Drawing.Font("Microsoft JhengHei", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTcontra.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTcontra.Location = new System.Drawing.Point(216, 140);
            this.TXTcontra.Name = "TXTcontra";
            this.TXTcontra.Size = new System.Drawing.Size(370, 39);
            this.TXTcontra.TabIndex = 2;
            this.TXTcontra.Text = "CONTRASEÑA";
            this.TXTcontra.Enter += new System.EventHandler(this.TXTcontra_Enter);
            this.TXTcontra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTcontra_KeyPress);
            this.TXTcontra.Leave += new System.EventHandler(this.TXTcontra_Leave);
            // 
            // BTNingresar
            // 
            this.BTNingresar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNingresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNingresar.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNingresar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.BTNingresar.Location = new System.Drawing.Point(216, 228);
            this.BTNingresar.Name = "BTNingresar";
            this.BTNingresar.Size = new System.Drawing.Size(188, 50);
            this.BTNingresar.TabIndex = 3;
            this.BTNingresar.Text = "Ingresar";
            this.BTNingresar.UseVisualStyleBackColor = false;
            this.BTNingresar.Click += new System.EventHandler(this.BTNingresar_Click);
            // 
            // LBLtimer
            // 
            this.LBLtimer.AutoSize = true;
            this.LBLtimer.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLtimer.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLtimer.Location = new System.Drawing.Point(226, 281);
            this.LBLtimer.Name = "LBLtimer";
            this.LBLtimer.Size = new System.Drawing.Size(131, 17);
            this.LBLtimer.TabIndex = 6;
            this.LBLtimer.Text = "le quedan 3 intentos";
            // 
            // CHKcontra
            // 
            this.CHKcontra.AutoSize = true;
            this.CHKcontra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHKcontra.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHKcontra.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CHKcontra.Location = new System.Drawing.Point(440, 201);
            this.CHKcontra.Name = "CHKcontra";
            this.CHKcontra.Size = new System.Drawing.Size(146, 21);
            this.CHKcontra.TabIndex = 0;
            this.CHKcontra.Text = "Mostrar contraseña";
            this.CHKcontra.UseVisualStyleBackColor = true;
            this.CHKcontra.CheckedChanged += new System.EventHandler(this.CHKcontra_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(216, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 10);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Location = new System.Drawing.Point(216, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 10);
            this.panel2.TabIndex = 10;
            // 
            // BTNcancel
            // 
            this.BTNcancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNcancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNcancel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNcancel.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNcancel.Location = new System.Drawing.Point(457, 228);
            this.BTNcancel.Name = "BTNcancel";
            this.BTNcancel.Size = new System.Drawing.Size(188, 50);
            this.BTNcancel.TabIndex = 4;
            this.BTNcancel.Text = "Cancelar";
            this.BTNcancel.UseVisualStyleBackColor = false;
            this.BTNcancel.Click += new System.EventHandler(this.BTNcancel_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.OliveDrab;
            this.panel3.Controls.Add(this.LBLLoguin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 313);
            this.panel3.TabIndex = 0;
            // 
            // LBLLoguin
            // 
            this.LBLLoguin.AutoSize = true;
            this.LBLLoguin.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLLoguin.ForeColor = System.Drawing.SystemColors.Control;
            this.LBLLoguin.Location = new System.Drawing.Point(3, 28);
            this.LBLLoguin.Name = "LBLLoguin";
            this.LBLLoguin.Size = new System.Drawing.Size(169, 55);
            this.LBLLoguin.TabIndex = 0;
            this.LBLLoguin.Text = "Loguin";
            // 
            // LBLerrores
            // 
            this.LBLerrores.AutoSize = true;
            this.LBLerrores.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLerrores.ForeColor = System.Drawing.Color.IndianRed;
            this.LBLerrores.Location = new System.Drawing.Point(226, 102);
            this.LBLerrores.Name = "LBLerrores";
            this.LBLerrores.Size = new System.Drawing.Size(23, 17);
            this.LBLerrores.TabIndex = 11;
            this.LBLerrores.Text = ". . .";
            this.LBLerrores.Click += new System.EventHandler(this.LBLerrores_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 313);
            this.Controls.Add(this.LBLerrores);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.BTNcancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CHKcontra);
            this.Controls.Add(this.LBLtimer);
            this.Controls.Add(this.BTNingresar);
            this.Controls.Add(this.TXTcontra);
            this.Controls.Add(this.TXTusua);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTusua;
        private System.Windows.Forms.TextBox TXTcontra;
        private System.Windows.Forms.Button BTNingresar;
        private System.Windows.Forms.Label LBLtimer;
        private System.Windows.Forms.CheckBox CHKcontra;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTNcancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LBLLoguin;
        private System.Windows.Forms.Label LBLerrores;
    }
}

