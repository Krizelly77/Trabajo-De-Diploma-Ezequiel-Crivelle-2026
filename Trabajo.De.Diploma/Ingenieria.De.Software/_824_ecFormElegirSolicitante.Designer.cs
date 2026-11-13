namespace Ingenieria.De.Software
{
    partial class _824_ecFormElegirSolicitante
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
            this.DGVSoliRegistrados = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTfiltro = new System.Windows.Forms.TextBox();
            this.CMBfiltroSolicitante = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNseleccionar = new System.Windows.Forms.Button();
            this.LBLdocu = new System.Windows.Forms.Label();
            this.LBLapell = new System.Windows.Forms.Label();
            this.BTNirABMsoli = new System.Windows.Forms.Button();
            this.BTNvolver = new System.Windows.Forms.Button();
            this.LBLnomb = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSoliRegistrados)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVSoliRegistrados
            // 
            this.DGVSoliRegistrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSoliRegistrados.Location = new System.Drawing.Point(254, 89);
            this.DGVSoliRegistrados.Name = "DGVSoliRegistrados";
            this.DGVSoliRegistrados.Size = new System.Drawing.Size(534, 253);
            this.DGVSoliRegistrados.TabIndex = 1;
            this.DGVSoliRegistrados.SelectionChanged += new System.EventHandler(this.DGVSoliRegistrados_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(249, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 33);
            this.label2.TabIndex = 32;
            this.label2.Text = "Solicitantes registrados";
            // 
            // TXTfiltro
            // 
            this.TXTfiltro.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TXTfiltro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTfiltro.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTfiltro.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTfiltro.Location = new System.Drawing.Point(496, 58);
            this.TXTfiltro.Name = "TXTfiltro";
            this.TXTfiltro.Size = new System.Drawing.Size(292, 22);
            this.TXTfiltro.TabIndex = 31;
            this.TXTfiltro.TextChanged += new System.EventHandler(this.TXTfiltro_TextChanged);
            // 
            // CMBfiltroSolicitante
            // 
            this.CMBfiltroSolicitante.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CMBfiltroSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBfiltroSolicitante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMBfiltroSolicitante.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBfiltroSolicitante.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CMBfiltroSolicitante.FormattingEnabled = true;
            this.CMBfiltroSolicitante.Location = new System.Drawing.Point(371, 55);
            this.CMBfiltroSolicitante.Name = "CMBfiltroSolicitante";
            this.CMBfiltroSolicitante.Size = new System.Drawing.Size(119, 28);
            this.CMBfiltroSolicitante.TabIndex = 30;
            this.CMBfiltroSolicitante.SelectedIndexChanged += new System.EventHandler(this.CMBfiltroSolicitante_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(249, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Filtrar por :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.BTNseleccionar);
            this.panel1.Controls.Add(this.LBLdocu);
            this.panel1.Controls.Add(this.LBLapell);
            this.panel1.Controls.Add(this.BTNirABMsoli);
            this.panel1.Controls.Add(this.BTNvolver);
            this.panel1.Controls.Add(this.LBLnomb);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 354);
            this.panel1.TabIndex = 40;
            // 
            // BTNseleccionar
            // 
            this.BTNseleccionar.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNseleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNseleccionar.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNseleccionar.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNseleccionar.Location = new System.Drawing.Point(17, 177);
            this.BTNseleccionar.Name = "BTNseleccionar";
            this.BTNseleccionar.Size = new System.Drawing.Size(179, 51);
            this.BTNseleccionar.TabIndex = 50;
            this.BTNseleccionar.Text = "Seleccionar";
            this.BTNseleccionar.UseVisualStyleBackColor = false;
            this.BTNseleccionar.Click += new System.EventHandler(this.BTNseleccionar_Click);
            // 
            // LBLdocu
            // 
            this.LBLdocu.AutoSize = true;
            this.LBLdocu.BackColor = System.Drawing.Color.OliveDrab;
            this.LBLdocu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLdocu.ForeColor = System.Drawing.SystemColors.Control;
            this.LBLdocu.Location = new System.Drawing.Point(11, 121);
            this.LBLdocu.Name = "LBLdocu";
            this.LBLdocu.Size = new System.Drawing.Size(153, 31);
            this.LBLdocu.TabIndex = 49;
            this.LBLdocu.Text = "Documento";
            // 
            // LBLapell
            // 
            this.LBLapell.AutoSize = true;
            this.LBLapell.BackColor = System.Drawing.Color.OliveDrab;
            this.LBLapell.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLapell.ForeColor = System.Drawing.SystemColors.Control;
            this.LBLapell.Location = new System.Drawing.Point(12, 80);
            this.LBLapell.Name = "LBLapell";
            this.LBLapell.Size = new System.Drawing.Size(110, 31);
            this.LBLapell.TabIndex = 48;
            this.LBLapell.Text = "Apellido";
            // 
            // BTNirABMsoli
            // 
            this.BTNirABMsoli.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNirABMsoli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNirABMsoli.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNirABMsoli.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNirABMsoli.Location = new System.Drawing.Point(17, 234);
            this.BTNirABMsoli.Name = "BTNirABMsoli";
            this.BTNirABMsoli.Size = new System.Drawing.Size(179, 51);
            this.BTNirABMsoli.TabIndex = 40;
            this.BTNirABMsoli.Text = "Ir a ABM de Solicitantes";
            this.BTNirABMsoli.UseVisualStyleBackColor = false;
            this.BTNirABMsoli.Click += new System.EventHandler(this.BTNirABMsoli_Click);
            // 
            // BTNvolver
            // 
            this.BTNvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNvolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolver.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNvolver.Location = new System.Drawing.Point(18, 291);
            this.BTNvolver.Name = "BTNvolver";
            this.BTNvolver.Size = new System.Drawing.Size(179, 51);
            this.BTNvolver.TabIndex = 47;
            this.BTNvolver.Tag = "";
            this.BTNvolver.Text = "Volver Atras";
            this.BTNvolver.UseVisualStyleBackColor = false;
            this.BTNvolver.Click += new System.EventHandler(this.BTNvolver_Click);
            // 
            // LBLnomb
            // 
            this.LBLnomb.AutoSize = true;
            this.LBLnomb.BackColor = System.Drawing.Color.OliveDrab;
            this.LBLnomb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnomb.ForeColor = System.Drawing.SystemColors.Control;
            this.LBLnomb.Location = new System.Drawing.Point(12, 38);
            this.LBLnomb.Name = "LBLnomb";
            this.LBLnomb.Size = new System.Drawing.Size(110, 31);
            this.LBLnomb.TabIndex = 39;
            this.LBLnomb.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.OliveDrab;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(14, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Solicitante actual :";
            // 
            // _824_ecFormElegirSolicitante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 354);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TXTfiltro);
            this.Controls.Add(this.CMBfiltroSolicitante);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVSoliRegistrados);
            this.Name = "_824_ecFormElegirSolicitante";
            this.Text = "_824_ecFormElegirSolicitante";
            this.Load += new System.EventHandler(this._824_ecFormElegirSolicitante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSoliRegistrados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVSoliRegistrados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTfiltro;
        private System.Windows.Forms.ComboBox CMBfiltroSolicitante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTNirABMsoli;
        private System.Windows.Forms.Button BTNvolver;
        private System.Windows.Forms.Label LBLnomb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LBLdocu;
        private System.Windows.Forms.Label LBLapell;
        private System.Windows.Forms.Button BTNseleccionar;
    }
}