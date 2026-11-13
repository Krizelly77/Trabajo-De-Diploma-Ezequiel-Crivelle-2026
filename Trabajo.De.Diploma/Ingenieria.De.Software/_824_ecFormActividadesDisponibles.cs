using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Ingenieria.De.Software
{
    public partial class _824_ecFormActividadesDisponibles : Form
    {
        private List<_824_ecActividad> ActDis_824_ec;
        private List<_824_ecPostulacion> MisPost_824_ec;
        private Usuario UsuarioActual;
        private bool _ejecutandoLimpieza = false; // Variable para evitar bucles infinitos de eventos

        public _824_ecFormActividadesDisponibles()
        {
            InitializeComponent();
        }

        private void _824_ecFormActividadesDisponibles_Load(object sender, EventArgs e)
        {
            UsuarioActual = SessionManager.TraerInstancia().usuarioINS;
            if (UsuarioActual == null)
            {
                this.Close();
                throw new Exception("No se encontro un usuario logueado");
            }
            ConfigurarFiltros_824_ec();
            CargarGrillaPostulaciones_824_ec();
            CargarGrilla_824_ec();
        }

        private void ConfigurarFiltros_824_ec()
        {
            FiltroFecha.Value = DateTime.Now;

            CMBfiltroActividades.Items.Clear();
            CMBfiltroActividades.Items.Add("Todos");
            foreach (EstadoActividad_824_ec estado in Enum.GetValues(typeof(EstadoActividad_824_ec)))
            {
                CMBfiltroActividades.Items.Add(estado.ToString());
            }
            CMBfiltroActividades.SelectedIndex = 0;
            CMDdirecciondeFecha.Items.Clear();
            CMDdirecciondeFecha.Items.Add("Antes del:");
            CMDdirecciondeFecha.Items.Add("Despues del:");
            CMDdirecciondeFecha.SelectedIndex = 1;
        }

        // cargar la grillas de las postulaciones
        #region grillaPostulaciones
        private void CargarGrillaPostulaciones_824_ec()
        {
            DGVpostulaciones.Columns.Add("Id", "Id");
            DGVpostulaciones.Columns["Id"].Visible = false;

            DGVpostulaciones.Columns.Add("Actividad", "Actividad");
            DGVpostulaciones.Columns["Actividad"].Width = 140;

            DGVpostulaciones.Columns.Add("Participante", "Participante / Grupo");
            DGVpostulaciones.Columns["Participante"].Width = 180;

            DGVpostulaciones.Columns.Add("Postulacion", "Estado");
            DGVpostulaciones.Columns["Postulacion"].Width = 90;

            DGVpostulaciones.Columns.Add("Caduca", "Caduca");
            DGVpostulaciones.Columns["Caduca"].Width = 95;

            DGVpostulaciones.AllowUserToAddRows = false;
            DGVpostulaciones.AllowUserToDeleteRows = false;
            DGVpostulaciones.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVpostulaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVpostulaciones.MultiSelect = false;
            DGVpostulaciones.RowHeadersVisible = false;

            ActualizarPostulaciones_824_ec();
        }

        private void ActualizarPostulaciones_824_ec()
        {
            MisPost_824_ec = _824_ecPostulacionBLL.ListarActividadPorCandidato_824_ec(UsuarioActual.Id).ToList();
            FiltrarPostulaciones_824_ec();
        }

        private void FiltrarPostulaciones_824_ec()
        {
            if (DGVpostulaciones.Columns.Count == 0) return;

            DGVpostulaciones.Rows.Clear();

            if (MisPost_824_ec != null)
            {
                var filtradas = MisPost_824_ec.AsEnumerable();

                // 1. Filtro por Nombre de Actividad
                string filtroAct = TXTfiltroPostActividad.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(filtroAct))
                {
                    filtradas = filtradas.Where(p =>
                        p.Actividad_824_ec != null &&
                        p.Actividad_824_ec.Nombre_824_ec != null &&
                        p.Actividad_824_ec.Nombre_824_ec.ToLower().Contains(filtroAct));
                }

                // 2. Filtro por Documento del Participante (soporta Individual y Grupal)
                string filtroDoc = TXTfiltroPostDocumento.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(filtroDoc))
                {
                    filtradas = filtradas.Where(p =>
                        // Coincidencia en postulación individual
                        (p.Participante_824_ec != null &&
                         p.Participante_824_ec.Documento_824_ec != null &&
                         p.Participante_824_ec.Documento_824_ec.ToLower().Contains(filtroDoc))
                        ||
                        // Coincidencia en alguno de los integrantes de una postulación grupal
                        (p.ParticipantesAgrupados != null &&
                         p.ParticipantesAgrupados.Any(ag =>
                             ag.Documento_824_ec != null &&
                             ag.Documento_824_ec.ToLower().Contains(filtroDoc)))
                    );
                }

                foreach (var pos in filtradas)
                {
                    string infoParticipante = ObtenerDescripcionParticipantes_824_ec(pos);

                    DGVpostulaciones.Rows.Add(
                        pos.Id_824_ec,
                        pos.Actividad_824_ec.Nombre_824_ec,
                        infoParticipante,
                        pos.Estado_824_ec.ToString(),
                        pos.Actividad_824_ec.FechaCaducidad_824_ec.ToShortDateString()
                    );
                }
            }
        }

        private string ObtenerDescripcionParticipantes_824_ec(_824_ecPostulacion pos)
        {
            if (pos.ParticipantesAgrupados != null && pos.ParticipantesAgrupados.Count > 0)
            {
                var apellidos = pos.ParticipantesAgrupados.Select(p => p.Apellido_824_ec);
                return $"Grupo ({pos.ParticipantesAgrupados.Count}): {string.Join(", ", apellidos)}";
            }
            if (pos.Participante_824_ec != null)
            {
                return $"{pos.Participante_824_ec.Apellido_824_ec}, {pos.Participante_824_ec.Nombre_824_ec} ({pos.Participante_824_ec.Documento_824_ec})";
            }
            return "Sin participante asignado";
        }
        #endregion grillaPostulaciones

        // cargar la grillas de las actividades disponibles
        #region grilla
        private void CargarGrilla_824_ec()
        {
            DGVactividades.Columns.Add("Id", "Id");
            DGVactividades.Columns["Id"].Visible = false;

            DGVactividades.Columns.Add("Nombre", "Nombre");
            DGVactividades.Columns["Nombre"].Width = 100;

            DGVactividades.Columns.Add("Estado", "Estado");
            DGVactividades.Columns["Estado"].Width = 100;

            DGVactividades.Columns.Add("Categoria", "Categoria");
            DGVactividades.Columns["Categoria"].Width = 100;

            DGVactividades.Columns.Add("Nivel", "Nivel");
            DGVactividades.Columns["Nivel"].Width = 100;

            DGVactividades.Columns.Add("Fecha", "Fecha");
            DGVactividades.Columns["Fecha"].Width = 150;

            DGVactividades.Columns.Add("Lugar", "Lugar");
            DGVactividades.Columns["Lugar"].Width = 100;

            DGVactividades.Columns.Add("Vacantes", "Vacantes");
            DGVactividades.Columns["Vacantes"].Width = 50;


            DGVactividades.AllowUserToAddRows = false;
            DGVactividades.AllowUserToDeleteRows = false;
            DGVactividades.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVactividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVactividades.MultiSelect = false;
            DGVactividades.RowHeadersVisible = false;


            Actualizar_824_ec();
        }
        private void Actualizar_824_ec()
        {
            ActDis_824_ec = _824_ecActividadBLL.ListarTodas_824_ec().ToList();
            FiltrarGrilla_824_ec();
        }
        private void FiltrarGrilla_824_ec()
        {
            if (DGVactividades.Columns.Count == 0) return;

            DGVactividades.Rows.Clear();

            if (ActDis_824_ec != null)
            {
                var filtradas = ActDis_824_ec.AsEnumerable();

                // Filtro por Estado (si es distinto a "Todos")
                if (CMBfiltroActividades.SelectedItem != null && CMBfiltroActividades.SelectedItem.ToString() != "Todos")
                {
                    string estadoSeleccionado = CMBfiltroActividades.SelectedItem.ToString();
                    filtradas = filtradas.Where(a => a.Estado_824_ec.ToString() == estadoSeleccionado);
                }

                // Filtro por Fecha de Publicación (anteriores o iguales a la fecha seleccionada)
                DateTime fechaLimite = FiltroFecha.Value.Date;
                if (CMDdirecciondeFecha.SelectedIndex == 0)
                    filtradas = filtradas.Where(a => a.FechaHora_824_ec.Date <= fechaLimite);
                else if (CMDdirecciondeFecha.SelectedIndex == 1)
                    filtradas = filtradas.Where(a => a.FechaHora_824_ec.Date >= fechaLimite);

                foreach (var act in filtradas)
                {
                    var postulaciones = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(act.Id_824_ec);
                    int cantParticipantes = postulaciones != null ? postulaciones
                            .Where(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado)
                            .Sum(p => (p.ParticipantesAgrupados != null && p.ParticipantesAgrupados.Count > 0) ? p.ParticipantesAgrupados.Count
                                : 1): 0;

                    DGVactividades.Rows.Add(
                        act.Id_824_ec,
                        act.Nombre_824_ec,
                        act.Estado_824_ec.ToString(),
                        act.Categoria_824_ec.Nombre_824_ec,
                        act.NivelRequerido_824_ec,
                        act.FechaHora_824_ec,
                        act.Ubicacion_824_ec,
                        $"{cantParticipantes} / {act.CantidadMaxima_824_ec}" // solo se muestran aceptados y el maximo
                    );
                }
            }
        }
        #endregion grilla

        // botones
        #region Botones
        private void BTNcvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BTNverDetalle_Click(object sender, EventArgs e)
        {
            if (DGVactividades.SelectedRows.Count > 0)
            {
                _824_ecFormABMactividad mForm_824_ec = new _824_ecFormABMactividad();
                mForm_824_ec.StartPosition = FormStartPosition.CenterParent;

                int mId = int.Parse(DGVactividades.SelectedRows[0].Cells[0].Value.ToString());
                mForm_824_ec._824_ecActividadEditable = _824_ecActividadBLL.ObtenerPorId_824_ec(mId);
                
                mForm_824_ec._824_ecTipoOperacion = Constantes.TiposOperacion.DeSesion;
                mForm_824_ec.ShowDialog(this);
                Actualizar_824_ec();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una de sus actividades para realizar esta operacion");
            }
        }
        // podria convinar parte de estos dos botones para ahorrar lineas
        private void BTNpostular_Click(object sender, EventArgs e)
        {
            if (DGVactividades.SelectedRows.Count > 0)
            {
                try
                {
                    using (_824_ecConformarPostulacion fcon = new _824_ecConformarPostulacion())
                    {
                        int mId = int.Parse(DGVactividades.SelectedRows[0].Cells[0].Value.ToString());
                        fcon._824_ecActividadActual = _824_ecActividadBLL.ObtenerPorId_824_ec(mId);

                        if (fcon.ShowDialog(this) == DialogResult.OK)
                        {
                            ActualizarPostulaciones_824_ec();
                            Actualizar_824_ec();

                            if (fcon.PostulacionesCreadas.Count > 0)
                            {
                                GenerarComprobantePostulacion_824_ec(fcon.PostulacionesCreadas);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una actividad para conformar una postulación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BTNretirar_Click(object sender, EventArgs e)
        {
            if (DGVpostulaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una postulación para retirarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int mId = int.Parse(DGVpostulaciones.SelectedRows[0].Cells[0].Value.ToString());
                _824_ecPostulacion viejaPost = _824_ecPostulacionBLL.BuscarPorID_824_ec(mId);

                if (viejaPost == null) return;

                // Paso 18 PN2: Solicitar DNI y Palabra Clave del participante para autenticar el retiro
                if (!SolicitarCredencialesRetiro_824_ec(viejaPost, out string dniIngresado, out string claveIngresada))
                {
                    return; // El gestor canceló la ventana de validación
                }

                // Paso 19 PN2: Validar credenciales con CryptoManager y cambiar estado a Retirado
                _824_ecPostulacionBLL.RetirarPostulacionConValidacion_824_ec(viejaPost.Id_824_ec, dniIngresado, claveIngresada);

                string descParticipante = ObtenerDescripcionParticipantes_824_ec(viejaPost);

                // Notificar al Organizador de Actividades
                _824_ecNotificacionBLL.Guardar_824_ec(
                    new _824_ecNotificacion(
                        "Retiro de postulación",
                        $"El gestor {UsuarioActual.NombreUsuario} registró el retiro de postulación ({descParticipante}) para la actividad {viejaPost.Actividad_824_ec.Nombre_824_ec}.",
                        UsuarioActual.Id,
                        viejaPost.Actividad_824_ec.Organizador_824_ec.Id
                    ));

                SessionManager.TraerInstancia().RegistrarActividad($"Retiro de Postulacion ID {viejaPost.Id_824_ec} ({descParticipante}) en actividad {viejaPost.Actividad_824_ec.Nombre_824_ec}");
                MessageBox.Show("Postulación retirada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ActualizarPostulaciones_824_ec();
                Actualizar_824_ec();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en retiro de postulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool SolicitarCredencialesRetiro_824_ec(_824_ecPostulacion post, out string documento, out string palabraClave)
        {
            documento = string.Empty;
            palabraClave = string.Empty;

            using (Form prompt = new Form())
            {
                prompt.Width = 380;
                prompt.Height = 230;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Validación de Seguridad - Retiro";
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label lblInfo = new Label { Left = 20, Top = 15, Width = 330, Text = $"Actividad: {post.Actividad_824_ec.Nombre_824_ec}" };
                Label lblDni = new Label { Left = 20, Top = 45, Width = 120, Text = "DNI Participante:" };
                TextBox txtDni = new TextBox { Left = 150, Top = 42, Width = 190 };

                Label lblClave = new Label { Left = 20, Top = 85, Width = 120, Text = "Palabra Clave:" };
                TextBox txtClave = new TextBox { Left = 150, Top = 82, Width = 190, PasswordChar = '*' };

                Button btnOk = new Button { Text = "Validar y Retirar", Left = 130, Width = 110, Top = 135, DialogResult = DialogResult.OK };
                Button btnCancel = new Button { Text = "Cancelar", Left = 250, Width = 90, Top = 135, DialogResult = DialogResult.Cancel };

                prompt.Controls.AddRange(new Control[] { lblInfo, lblDni, txtDni, lblClave, txtClave, btnOk, btnCancel });
                prompt.AcceptButton = btnOk;
                prompt.CancelButton = btnCancel;

                if (prompt.ShowDialog(this) == DialogResult.OK)
                {
                    documento = txtDni.Text.Trim();
                    palabraClave = txtClave.Text.Trim();
                    return true;
                }
                return false;
            }
        }
        #endregion Botones

        // eventos de Controles
        #region Controles
        private void CMBfiltroActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }
        private void CMDdirecciondeFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }
        private void FiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }

        private void DGVactividades_SelectionChanged(object sender, EventArgs e)
        {
            if (_ejecutandoLimpieza) return;

            if (DGVactividades.SelectedRows.Count > 0 || DGVactividades.SelectedCells.Count > 0)
            {
                _ejecutandoLimpieza = true;
                DGVpostulaciones.ClearSelection();
                _ejecutandoLimpieza = false;
                BTNretirar.Enabled = false;
                BTNverDetalle.Enabled = true;
            }
            // deslocalisamos la logica por si el evento no se dispara al seleccionar desde la otra grilla
            ActualizarEstadoBotonPostular();
        }
        private void ActualizarEstadoBotonPostular()
        {
            if (DGVpostulaciones.SelectedRows.Count > 0 || DGVpostulaciones.SelectedCells.Count > 0)
            {
                BTNpostular.Enabled = false;
                return;
            }

            if (DGVactividades.CurrentRow == null || DGVactividades.SelectedRows.Count == 0)
            {
                BTNpostular.Enabled = false;
                return;
            }

            object valorId = DGVactividades.CurrentRow.Cells["Id"].Value;

            if (valorId == null || !int.TryParse(valorId.ToString(), out int actividadId))
            {
                BTNpostular.Enabled = false;
                return;
            }

            _824_ecActividad act = ActDis_824_ec?.FirstOrDefault(a => a.Id_824_ec == actividadId);

            if (act == null)
            {
                BTNpostular.Enabled = false;
                return;
            }

            BTNpostular.Enabled = act.Estado_824_ec == EstadoActividad_824_ec.Abierto ||
                act.Estado_824_ec == EstadoActividad_824_ec.Completado;
        }

        private void DGVpostulaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (_ejecutandoLimpieza) return;

            if (DGVpostulaciones.SelectedRows.Count > 0 || DGVpostulaciones.SelectedCells.Count > 0)
            {
                _ejecutandoLimpieza = true;
                DGVactividades.ClearSelection();
                _ejecutandoLimpieza = false;
                BTNretirar.Enabled = true;
                BTNverDetalle.Enabled = false;
                BTNpostular.Enabled = false;
            }

            if (DGVpostulaciones.CurrentRow != null && DGVpostulaciones.CurrentRow.Cells["Id"].Value != null)
            {
                if (int.TryParse(DGVpostulaciones.CurrentRow.Cells["Id"].Value.ToString(), out int PostulacionId))
                {
                    _824_ecPostulacion post = MisPost_824_ec?.FirstOrDefault(a => a.Id_824_ec == PostulacionId);
                    if (post != null)
                    {
                        // si el grupo esta completado, ya no puede retirar su postulacion
                        if (post.Actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Completado || post.Actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Caducado)
                            BTNretirar.Enabled = false;
                        else
                            BTNretirar.Enabled = true;
                        SeleccionarActividadEnLaGrilla(post.Actividad_824_ec.Id_824_ec);
                        return;
                    }
                }
            }
        }
        private void SeleccionarActividadEnLaGrilla(int idBuscado)
        {
            foreach (DataGridViewRow fila in DGVactividades.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["Id"].Value == null)
                    continue;

                if (!int.TryParse(fila.Cells["Id"].Value.ToString(), out int id))
                    continue;

                if (id == idBuscado)
                {
                    DGVactividades.CurrentCell = fila.Cells["Nombre"];

                    if (fila.Index >= 0)
                        DGVactividades.FirstDisplayedScrollingRowIndex = fila.Index;

                    // Nos aseguramos de actualizar la lógica aunque SelectionChanged no se dispare
                    ActualizarEstadoBotonPostular();

                    return;
                }
            }
        }
        private void TXTfiltroPostActividad_TextChanged(object sender, EventArgs e)
        {
            FiltrarPostulaciones_824_ec();
        }

        private void TXTfiltroPostDocumento_TextChanged(object sender, EventArgs e)
        {
            FiltrarPostulaciones_824_ec();
        }
        #endregion Controles

        private void GenerarComprobantePostulacion_824_ec(List<_824_ecPostulacion> postulaciones)
        {
            try
            {
                string carpetaDefault = _824_ecDirectivosManejador.ObtenerRutaCarpetaDefault("ReportesPDF");
                var primera = postulaciones.First();

                string detallePostulaciones = "";
                foreach (var post in postulaciones)
                {
                    detallePostulaciones += $"----------------------------------------\n" +
                                            $"N° Postulación: {post.Id_824_ec}\n";

                    if (post.ParticipantesAgrupados != null && post.ParticipantesAgrupados.Count > 0)
                    {
                        detallePostulaciones += $"Modalidad: Grupal ({post.ParticipantesAgrupados.Count} integrantes)\n";
                        foreach (var p in post.ParticipantesAgrupados)
                        {
                            detallePostulaciones += $"  - {p.Apellido_824_ec}, {p.Nombre_824_ec} (DNI: {p.Documento_824_ec})\n";
                        }
                    }
                    else if (post.Participante_824_ec != null)
                    {
                        detallePostulaciones += $"Modalidad: Individual\n" +
                                                $"Participante: {post.Participante_824_ec.Apellido_824_ec}, {post.Participante_824_ec.Nombre_824_ec} (DNI: {post.Participante_824_ec.Documento_824_ec})\n";
                    }
                }

                string contenido =
                    "COMPROBANTE DE POSTULACIÓN\n" +
                    "========================================\n\n" +
                    "Fecha de generación: " + DateTime.Now + "\n" +
                    "Gestor responsable: " + primera.GestorResponsable_824_ec.NombreUsuario + "\n\n" +
                    "DATOS DE LA ACTIVIDAD\n" +
                    "Actividad: " + primera.Actividad_824_ec.Nombre_824_ec + "\n" +
                    "Fecha y hora: " + primera.Actividad_824_ec.FechaHora_824_ec + "\n" +
                    "Lugar: " + primera.Actividad_824_ec.Ubicacion_824_ec + "\n" +
                    "Organizador: " + primera.Actividad_824_ec.Organizador_824_ec.NombreUsuario + "\n\n" +
                    "DETALLE DE POSTULACIONES REGISTRADAS (" + postulaciones.Count + ")\n" +
                    detallePostulaciones +
                    "========================================\n" +
                    "Las postulaciones fueron registradas correctamente.";

                DialogResult opcion = MessageBox.Show(
                    "Postulación registrada con éxito. ¿Desea obtener el comprobante?\n\n" +
                    "[Sí] - Guardar directo en carpeta predeterminada (AppData)\n" +
                    "[No] - Abrir Vista Previa (Elegir ubicación / Imprimir)\n" +
                    "[Cancelar] - No deseo generar un comprobante",
                    "Seleccionar modalidad de comprobante",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (opcion == DialogResult.Cancel) return;

                using (PrintDocument documento = _824_ecReportesBLL.PrepararReporte_824_ec(contenido))
                {
                    if (opcion == DialogResult.Yes)
                    {
                        string prefijo = postulaciones.Count > 1 ? "Comprobante_Postulaciones_Multiple" : $"Comprobante_Postulacion_{primera.Id_824_ec}";
                        string nombreArchivo = $"{prefijo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                        string rutaFinal = System.IO.Path.Combine(carpetaDefault, nombreArchivo);

                        documento.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                        documento.PrinterSettings.PrintToFile = true;
                        documento.PrinterSettings.PrintFileName = rutaFinal;
                        documento.PrintController = new System.Drawing.Printing.StandardPrintController();

                        documento.Print();

                        MessageBox.Show($"Comprobante guardado con éxito en:\n{rutaFinal}",
                            "Archivo generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (opcion == DialogResult.No)
                    {
                        using (PrintPreviewDialog vistaPrevia = new PrintPreviewDialog())
                        {
                            vistaPrevia.Document = documento;
                            vistaPrevia.Width = 900;
                            vistaPrevia.Height = 700;
                            vistaPrevia.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La postulación se registró correctamente, pero no se pudo generar el comprobante.\n\n" + ex.Message, "Error al generar comprobante",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
