namespace Ingenieria.De.Software
{
    partial class _824_ecFormMisActividades
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
            this.BTNnuevaActividad = new System.Windows.Forms.Button();
            this.FiltroFecha = new System.Windows.Forms.DateTimePicker();
            this.CMBfiltroActividades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNvolver = new System.Windows.Forms.Button();
            this.DGVmisactividades = new System.Windows.Forms.DataGridView();
            this.DGVparticipantes = new System.Windows.Forms.DataGridView();
            this.LBLnombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVpostulaciones = new System.Windows.Forms.DataGridView();
            this.BTNaceptarsolicitud = new System.Windows.Forms.Button();
            this.BTNrevocarSolicitud = new System.Windows.Forms.Button();
            this.LBLaceptarsol = new System.Windows.Forms.Label();
            this.LBLrebocador = new System.Windows.Forms.Label();
            this.BTNverUsuario = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LBLnombree = new System.Windows.Forms.Label();
            this.TXBdescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LBLmaxmin = new System.Windows.Forms.Label();
            this.TXTdia = new System.Windows.Forms.TextBox();
            this.TXThora = new System.Windows.Forms.TextBox();
            this.TXTlugar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TXTpublicacion = new System.Windows.Forms.TextBox();
            this.TXTcaducacion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TXTcategoria = new System.Windows.Forms.TextBox();
            this.TXTmaxmin = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TXTnivel = new System.Windows.Forms.TextBox();
            this.TXTestado = new System.Windows.Forms.TextBox();
            this.BTNmodActividad = new System.Windows.Forms.Button();
            this.BTNbajaActividad = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVmisactividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVparticipantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpostulaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Controls.Add(this.BTNnuevaActividad);
            this.panel1.Controls.Add(this.FiltroFecha);
            this.panel1.Controls.Add(this.CMBfiltroActividades);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTNvolver);
            this.panel1.Controls.Add(this.DGVmisactividades);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 550);
            this.panel1.TabIndex = 0;
            // 
            // BTNnuevaActividad
            // 
            this.BTNnuevaActividad.BackColor = System.Drawing.Color.YellowGreen;
            this.BTNnuevaActividad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNnuevaActividad.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNnuevaActividad.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNnuevaActividad.Location = new System.Drawing.Point(146, 489);
            this.BTNnuevaActividad.Name = "BTNnuevaActividad";
            this.BTNnuevaActividad.Size = new System.Drawing.Size(140, 54);
            this.BTNnuevaActividad.TabIndex = 27;
            this.BTNnuevaActividad.Text = "Crear nueva Actividad";
            this.BTNnuevaActividad.UseVisualStyleBackColor = false;
            this.BTNnuevaActividad.Click += new System.EventHandler(this.BTNnuevaActividad_Click);
            // 
            // FiltroFecha
            // 
            this.FiltroFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroFecha.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.FiltroFecha.CalendarTitleBackColor = System.Drawing.Color.OliveDrab;
            this.FiltroFecha.CalendarTrailingForeColor = System.Drawing.SystemColors.WindowFrame;
            this.FiltroFecha.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltroFecha.Location = new System.Drawing.Point(12, 89);
            this.FiltroFecha.Name = "FiltroFecha";
            this.FiltroFecha.Size = new System.Drawing.Size(274, 29);
            this.FiltroFecha.TabIndex = 26;
            this.FiltroFecha.ValueChanged += new System.EventHandler(this.FiltroFecha_ValueChanged);
            // 
            // CMBfiltroActividades
            // 
            this.CMBfiltroActividades.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.CMBfiltroActividades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBfiltroActividades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CMBfiltroActividades.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBfiltroActividades.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.CMBfiltroActividades.FormattingEnabled = true;
            this.CMBfiltroActividades.Location = new System.Drawing.Point(12, 55);
            this.CMBfiltroActividades.Name = "CMBfiltroActividades";
            this.CMBfiltroActividades.Size = new System.Drawing.Size(274, 28);
            this.CMBfiltroActividades.TabIndex = 25;
            this.CMBfiltroActividades.SelectedIndexChanged += new System.EventHandler(this.CMBfiltroActividades_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mis Actividades ";
            // 
            // BTNvolver
            // 
            this.BTNvolver.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNvolver.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNvolver.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNvolver.Location = new System.Drawing.Point(12, 489);
            this.BTNvolver.Name = "BTNvolver";
            this.BTNvolver.Size = new System.Drawing.Size(128, 54);
            this.BTNvolver.TabIndex = 24;
            this.BTNvolver.Text = "Volver al inicio";
            this.BTNvolver.UseVisualStyleBackColor = false;
            this.BTNvolver.Click += new System.EventHandler(this.BTNvolver_Click);
            // 
            // DGVmisactividades
            // 
            this.DGVmisactividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVmisactividades.Location = new System.Drawing.Point(12, 124);
            this.DGVmisactividades.Name = "DGVmisactividades";
            this.DGVmisactividades.Size = new System.Drawing.Size(274, 359);
            this.DGVmisactividades.TabIndex = 0;
            this.DGVmisactividades.SelectionChanged += new System.EventHandler(this.DGVmisactividades_SelectionChanged);
            // 
            // DGVparticipantes
            // 
            this.DGVparticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVparticipantes.Location = new System.Drawing.Point(317, 197);
            this.DGVparticipantes.Name = "DGVparticipantes";
            this.DGVparticipantes.Size = new System.Drawing.Size(243, 286);
            this.DGVparticipantes.TabIndex = 1;
            this.DGVparticipantes.SelectionChanged += new System.EventHandler(this.DGVparticipantes_SelectionChanged);
            // 
            // LBLnombre
            // 
            this.LBLnombre.AutoSize = true;
            this.LBLnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombre.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombre.Location = new System.Drawing.Point(317, 165);
            this.LBLnombre.Name = "LBLnombre";
            this.LBLnombre.Size = new System.Drawing.Size(158, 29);
            this.LBLnombre.TabIndex = 3;
            this.LBLnombre.Text = "Participantes ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(709, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Postulaciones";
            // 
            // DGVpostulaciones
            // 
            this.DGVpostulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVpostulaciones.Location = new System.Drawing.Point(712, 197);
            this.DGVpostulaciones.Name = "DGVpostulaciones";
            this.DGVpostulaciones.Size = new System.Drawing.Size(243, 286);
            this.DGVpostulaciones.TabIndex = 5;
            this.DGVpostulaciones.SelectionChanged += new System.EventHandler(this.DGVpostulaciones_SelectionChanged);
            // 
            // BTNaceptarsolicitud
            // 
            this.BTNaceptarsolicitud.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNaceptarsolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNaceptarsolicitud.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNaceptarsolicitud.ForeColor = System.Drawing.Color.OliveDrab;
            this.BTNaceptarsolicitud.Location = new System.Drawing.Point(566, 269);
            this.BTNaceptarsolicitud.Name = "BTNaceptarsolicitud";
            this.BTNaceptarsolicitud.Size = new System.Drawing.Size(140, 55);
            this.BTNaceptarsolicitud.TabIndex = 7;
            this.BTNaceptarsolicitud.Text = "<<";
            this.BTNaceptarsolicitud.UseVisualStyleBackColor = false;
            this.BTNaceptarsolicitud.Click += new System.EventHandler(this.BTNaceptarsolicitud_Click);
            // 
            // BTNrevocarSolicitud
            // 
            this.BTNrevocarSolicitud.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNrevocarSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNrevocarSolicitud.Font = new System.Drawing.Font("Microsoft JhengHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNrevocarSolicitud.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNrevocarSolicitud.Location = new System.Drawing.Point(566, 356);
            this.BTNrevocarSolicitud.Name = "BTNrevocarSolicitud";
            this.BTNrevocarSolicitud.Size = new System.Drawing.Size(140, 55);
            this.BTNrevocarSolicitud.TabIndex = 8;
            this.BTNrevocarSolicitud.Text = ">>";
            this.BTNrevocarSolicitud.UseVisualStyleBackColor = false;
            this.BTNrevocarSolicitud.Click += new System.EventHandler(this.BTNrevocarSolicitud_Click);
            // 
            // LBLaceptarsol
            // 
            this.LBLaceptarsol.AutoSize = true;
            this.LBLaceptarsol.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLaceptarsol.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLaceptarsol.Location = new System.Drawing.Point(566, 246);
            this.LBLaceptarsol.Name = "LBLaceptarsol";
            this.LBLaceptarsol.Size = new System.Drawing.Size(137, 20);
            this.LBLaceptarsol.TabIndex = 21;
            this.LBLaceptarsol.Text = "Aceptar Solicitud";
            // 
            // LBLrebocador
            // 
            this.LBLrebocador.AutoSize = true;
            this.LBLrebocador.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLrebocador.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLrebocador.Location = new System.Drawing.Point(562, 333);
            this.LBLrebocador.Name = "LBLrebocador";
            this.LBLrebocador.Size = new System.Drawing.Size(148, 20);
            this.LBLrebocador.TabIndex = 22;
            this.LBLrebocador.Text = "Rebocar del grupo";
            // 
            // BTNverUsuario
            // 
            this.BTNverUsuario.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNverUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNverUsuario.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNverUsuario.ForeColor = System.Drawing.Color.OliveDrab;
            this.BTNverUsuario.Location = new System.Drawing.Point(566, 427);
            this.BTNverUsuario.Name = "BTNverUsuario";
            this.BTNverUsuario.Size = new System.Drawing.Size(140, 56);
            this.BTNverUsuario.TabIndex = 23;
            this.BTNverUsuario.Text = "Ver Usuario en Detalle ";
            this.BTNverUsuario.UseVisualStyleBackColor = false;
            this.BTNverUsuario.Click += new System.EventHandler(this.BTNverUsuario_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(715, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "El dia :";
            // 
            // LBLnombree
            // 
            this.LBLnombree.AutoSize = true;
            this.LBLnombree.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLnombree.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLnombree.Location = new System.Drawing.Point(310, 6);
            this.LBLnombree.Name = "LBLnombree";
            this.LBLnombree.Size = new System.Drawing.Size(335, 39);
            this.LBLnombree.TabIndex = 26;
            this.LBLnombree.Text = "Nombre de actividad";
            // 
            // TXBdescripcion
            // 
            this.TXBdescripcion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXBdescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXBdescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXBdescripcion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXBdescripcion.Location = new System.Drawing.Point(317, 89);
            this.TXBdescripcion.Multiline = true;
            this.TXBdescripcion.Name = "TXBdescripcion";
            this.TXBdescripcion.ReadOnly = true;
            this.TXBdescripcion.Size = new System.Drawing.Size(401, 76);
            this.TXBdescripcion.TabIndex = 27;
            this.TXBdescripcion.Text = "Descripcion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label7.Location = new System.Drawing.Point(717, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "En      :";
            // 
            // LBLmaxmin
            // 
            this.LBLmaxmin.AutoSize = true;
            this.LBLmaxmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLmaxmin.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.LBLmaxmin.Location = new System.Drawing.Point(562, 197);
            this.LBLmaxmin.Name = "LBLmaxmin";
            this.LBLmaxmin.Size = new System.Drawing.Size(149, 20);
            this.LBLmaxmin.TabIndex = 29;
            this.LBLmaxmin.Text = "MIN ≤ CANT ≤ MAX";
            // 
            // TXTdia
            // 
            this.TXTdia.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTdia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTdia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTdia.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTdia.Location = new System.Drawing.Point(774, 97);
            this.TXTdia.Name = "TXTdia";
            this.TXTdia.ReadOnly = true;
            this.TXTdia.Size = new System.Drawing.Size(184, 19);
            this.TXTdia.TabIndex = 30;
            // 
            // TXThora
            // 
            this.TXThora.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXThora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXThora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXThora.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXThora.Location = new System.Drawing.Point(774, 122);
            this.TXThora.Name = "TXThora";
            this.TXThora.ReadOnly = true;
            this.TXThora.Size = new System.Drawing.Size(184, 19);
            this.TXThora.TabIndex = 31;
            // 
            // TXTlugar
            // 
            this.TXTlugar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTlugar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTlugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTlugar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTlugar.Location = new System.Drawing.Point(774, 146);
            this.TXTlugar.Name = "TXTlugar";
            this.TXTlugar.ReadOnly = true;
            this.TXTlugar.Size = new System.Drawing.Size(184, 19);
            this.TXTlugar.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label8.Location = new System.Drawing.Point(718, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Hora  :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label9.Location = new System.Drawing.Point(313, 498);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "Se publico el   :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label10.Location = new System.Drawing.Point(318, 518);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "Caduca en     :";
            // 
            // TXTpublicacion
            // 
            this.TXTpublicacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTpublicacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTpublicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTpublicacion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTpublicacion.Location = new System.Drawing.Point(434, 496);
            this.TXTpublicacion.Name = "TXTpublicacion";
            this.TXTpublicacion.ReadOnly = true;
            this.TXTpublicacion.Size = new System.Drawing.Size(184, 19);
            this.TXTpublicacion.TabIndex = 36;
            // 
            // TXTcaducacion
            // 
            this.TXTcaducacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTcaducacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTcaducacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTcaducacion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTcaducacion.Location = new System.Drawing.Point(434, 521);
            this.TXTcaducacion.Name = "TXTcaducacion";
            this.TXTcaducacion.ReadOnly = true;
            this.TXTcaducacion.Size = new System.Drawing.Size(184, 19);
            this.TXTcaducacion.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Location = new System.Drawing.Point(313, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 24);
            this.label11.TabIndex = 38;
            this.label11.Text = "Categoria :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label12.Location = new System.Drawing.Point(751, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 24);
            this.label12.TabIndex = 39;
            this.label12.Text = "Estado :";
            // 
            // TXTcategoria
            // 
            this.TXTcategoria.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTcategoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTcategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTcategoria.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTcategoria.Location = new System.Drawing.Point(412, 61);
            this.TXTcategoria.Name = "TXTcategoria";
            this.TXTcategoria.ReadOnly = true;
            this.TXTcategoria.Size = new System.Drawing.Size(123, 22);
            this.TXTcategoria.TabIndex = 40;
            // 
            // TXTmaxmin
            // 
            this.TXTmaxmin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTmaxmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTmaxmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTmaxmin.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTmaxmin.Location = new System.Drawing.Point(566, 221);
            this.TXTmaxmin.Name = "TXTmaxmin";
            this.TXTmaxmin.ReadOnly = true;
            this.TXTmaxmin.Size = new System.Drawing.Size(140, 19);
            this.TXTmaxmin.TabIndex = 42;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label13.Location = new System.Drawing.Point(541, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 24);
            this.label13.TabIndex = 43;
            this.label13.Text = "Nivel  :";
            // 
            // TXTnivel
            // 
            this.TXTnivel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTnivel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTnivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTnivel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTnivel.Location = new System.Drawing.Point(622, 61);
            this.TXTnivel.Name = "TXTnivel";
            this.TXTnivel.ReadOnly = true;
            this.TXTnivel.Size = new System.Drawing.Size(123, 22);
            this.TXTnivel.TabIndex = 44;
            // 
            // TXTestado
            // 
            this.TXTestado.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TXTestado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXTestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTestado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TXTestado.Location = new System.Drawing.Point(832, 59);
            this.TXTestado.Name = "TXTestado";
            this.TXTestado.ReadOnly = true;
            this.TXTestado.Size = new System.Drawing.Size(123, 22);
            this.TXTestado.TabIndex = 45;
            // 
            // BTNmodActividad
            // 
            this.BTNmodActividad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNmodActividad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNmodActividad.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNmodActividad.ForeColor = System.Drawing.Color.OliveDrab;
            this.BTNmodActividad.Location = new System.Drawing.Point(669, 489);
            this.BTNmodActividad.Name = "BTNmodActividad";
            this.BTNmodActividad.Size = new System.Drawing.Size(140, 54);
            this.BTNmodActividad.TabIndex = 27;
            this.BTNmodActividad.Text = "Modificar Actividad";
            this.BTNmodActividad.UseVisualStyleBackColor = false;
            this.BTNmodActividad.Click += new System.EventHandler(this.BTNmodActividad_Click);
            // 
            // BTNbajaActividad
            // 
            this.BTNbajaActividad.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTNbajaActividad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNbajaActividad.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNbajaActividad.ForeColor = System.Drawing.Color.IndianRed;
            this.BTNbajaActividad.Location = new System.Drawing.Point(815, 489);
            this.BTNbajaActividad.Name = "BTNbajaActividad";
            this.BTNbajaActividad.Size = new System.Drawing.Size(140, 54);
            this.BTNbajaActividad.TabIndex = 46;
            this.BTNbajaActividad.Text = "Eliminar Actividad";
            this.BTNbajaActividad.UseVisualStyleBackColor = false;
            this.BTNbajaActividad.Click += new System.EventHandler(this.BTNbajaActividad_Click);
            // 
            // _824_ecFormMisActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 550);
            this.Controls.Add(this.BTNbajaActividad);
            this.Controls.Add(this.BTNmodActividad);
            this.Controls.Add(this.TXTestado);
            this.Controls.Add(this.TXTnivel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TXTmaxmin);
            this.Controls.Add(this.TXTcategoria);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TXTcaducacion);
            this.Controls.Add(this.TXTpublicacion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TXTlugar);
            this.Controls.Add(this.TXThora);
            this.Controls.Add(this.TXTdia);
            this.Controls.Add(this.LBLmaxmin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TXBdescripcion);
            this.Controls.Add(this.LBLnombree);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BTNverUsuario);
            this.Controls.Add(this.LBLrebocador);
            this.Controls.Add(this.LBLaceptarsol);
            this.Controls.Add(this.BTNrevocarSolicitud);
            this.Controls.Add(this.BTNaceptarsolicitud);
            this.Controls.Add(this.DGVpostulaciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBLnombre);
            this.Controls.Add(this.DGVparticipantes);
            this.Controls.Add(this.panel1);
            this.Name = "_824_ecFormMisActividades";
            this.Text = "_824_ecFormMisActividades";
            this.Load += new System.EventHandler(this._824_ecFormMisActividades_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVmisactividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVparticipantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVpostulaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DGVmisactividades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMBfiltroActividades;
        private System.Windows.Forms.DateTimePicker FiltroFecha;
        private System.Windows.Forms.DataGridView DGVparticipantes;
        private System.Windows.Forms.Label LBLnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVpostulaciones;
        private System.Windows.Forms.Button BTNaceptarsolicitud;
        private System.Windows.Forms.Button BTNrevocarSolicitud;
        private System.Windows.Forms.Label LBLaceptarsol;
        private System.Windows.Forms.Label LBLrebocador;
        private System.Windows.Forms.Button BTNverUsuario;
        private System.Windows.Forms.Button BTNvolver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LBLnombree;
        private System.Windows.Forms.TextBox TXBdescripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LBLmaxmin;
        private System.Windows.Forms.TextBox TXTdia;
        private System.Windows.Forms.TextBox TXThora;
        private System.Windows.Forms.TextBox TXTlugar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TXTpublicacion;
        private System.Windows.Forms.TextBox TXTcaducacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TXTcategoria;
        private System.Windows.Forms.TextBox TXTmaxmin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TXTnivel;
        private System.Windows.Forms.TextBox TXTestado;
        private System.Windows.Forms.Button BTNnuevaActividad;
        private System.Windows.Forms.Button BTNmodActividad;
        private System.Windows.Forms.Button BTNbajaActividad;
    }
}