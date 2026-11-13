using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Ingenieria.De.Software
{
    public partial class _824_ecFormMisActividades : Form
    {
        private List<_824_ecActividad> MisAct_824_ec;
        private _824_ecActividad ActividadActual;
        private List<_824_ecPostulacion> PostAct_824_ec;
        private List<_824_ecPostulacion> PartAct_824_ec;
        private bool _ejecutandoLimpieza = false;// Variable para evitar bucles infinitos de eventos
        private bool _actualizandoGrilla = false;// bandera para evitar que se dispare el evento inesperadamente
        private Usuario UsuariActual;

        public _824_ecFormMisActividades()
        {
            InitializeComponent();
        }

        private void _824_ecFormMisActividades_Load(object sender, EventArgs e)
        {
            UsuariActual = SessionManager.TraerInstancia().usuarioINS;
            if (UsuariActual == null)
            {
                this.Close();
                throw new Exception("No se encontro un usuario logueado");
            }
            ConfigurarFiltros_824_ec();
            CargarGrilla_824_ec();
            CargarGrillaPostulados_824_ec();
            CargarGrillaAceptados_824_ec();
        }
        // carga inicial
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
        private void CargarListaDesdeBD_824_ec()
        {
            if (UsuariActual != null)
            {
                MisAct_824_ec = _824_ecActividadBLL.ListarTodas_824_ec()
                    .Where(a => a.Organizador_824_ec != null && a.Organizador_824_ec.Id == UsuariActual.Id)
                    .ToList();
            }
            else
            {
                MisAct_824_ec = new List<_824_ecActividad>();
            }
        }
        private int ContarParticipantesAceptados_824_ec(List<_824_ecPostulacion> postulaciones)
        {
            if (postulaciones == null) return 0;

            return postulaciones
                .Where(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado)
                .Sum(p => (p.ParticipantesAgrupados != null && p.ParticipantesAgrupados.Count > 0)
                    ? p.ParticipantesAgrupados.Count: 1);
        }
        private string ObtenerDescripcionParticipante_824_ec(_824_ecPostulacion pos)
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
            return $"Gestor: {pos.GestorResponsable_824_ec?.NombreUsuario ?? "N/A"}";
        }

        // METODOS DE GRILLA
        #region grilla
        private void CargarGrilla_824_ec()
        {
            DGVmisactividades.Columns.Clear();

            DGVmisactividades.Columns.Add("Id", "Id");
            DGVmisactividades.Columns["Id"].Visible = false;

            DGVmisactividades.Columns.Add("Nombre", "Nombre");
            DGVmisactividades.Columns["Nombre"].Width = 100;

            DGVmisactividades.Columns.Add("Estado", "Estado");
            DGVmisactividades.Columns["Estado"].Width = 70;

            DGVmisactividades.Columns.Add("Cupos", "Cupos");
            DGVmisactividades.Columns["Cupos"].Width = 60;

            DGVmisactividades.AllowUserToAddRows = false;
            DGVmisactividades.AllowUserToDeleteRows = false;
            DGVmisactividades.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVmisactividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVmisactividades.MultiSelect = false;

            Actualizar_824_ec();
        }
        private void Actualizar_824_ec()
        {
            try
            {
                _actualizandoGrilla = true;
                CargarListaDesdeBD_824_ec();
                FiltrarGrilla_824_ec();
            }
            finally
            {
                _actualizandoGrilla = false;
            }
        }
        private void FiltrarGrilla_824_ec()
        {
            if (DGVmisactividades.Columns.Count == 0) return;

            DGVmisactividades.Rows.Clear();

            if (MisAct_824_ec != null)
            {
                var filtradas = MisAct_824_ec.AsEnumerable();

                if (CMBfiltroActividades.SelectedItem != null && CMBfiltroActividades.SelectedItem.ToString() != "Todos")
                {
                    string estadoSeleccionado = CMBfiltroActividades.SelectedItem.ToString();
                    filtradas = filtradas.Where(a => a.Estado_824_ec.ToString() == estadoSeleccionado);
                }

                DateTime fechaLimite = FiltroFecha.Value.Date;
                if (CMDdirecciondeFecha.SelectedIndex == 0)
                    filtradas = filtradas.Where(a => a.FechaHora_824_ec.Date <= fechaLimite);
                else if (CMDdirecciondeFecha.SelectedIndex == 1)
                    filtradas = filtradas.Where(a => a.FechaHora_824_ec.Date >= fechaLimite);

                foreach (var act in filtradas)
                {
                    var postulaciones = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(act.Id_824_ec);
                    int cantParticipantes = ContarParticipantesAceptados_824_ec(postulaciones);

                    DGVmisactividades.Rows.Add(
                        act.Id_824_ec,
                        act.Nombre_824_ec,
                        act.Estado_824_ec.ToString(),
                        $"{cantParticipantes} / {act.CantidadMaxima_824_ec}"
                    );
                }
            }

            if (DGVmisactividades.Rows.Count == 0)
            {
                LimpiarDetalle_824_ec();
            }
        }

        private void SeleccionarActual()
        {
            if (ActividadActual == null) return;

            int actividadId = ActividadActual.Id_824_ec;

            foreach (DataGridViewRow fila in DGVmisactividades.Rows)
            {
                if (fila.IsNewRow || fila.Cells["Id"].Value == null) continue;

                if (!int.TryParse(fila.Cells["Id"].Value.ToString(), out int id)) continue;

                if (id == actividadId)
                {
                    DGVmisactividades.CurrentCell = fila.Cells["Nombre"];

                    if (fila.Index >= 0)
                        DGVmisactividades.FirstDisplayedScrollingRowIndex = fila.Index;

                    SelectionChangeDeslocalizado();
                    return;
                }
            }
        }

        private void SelectionChangeDeslocalizado()
        {
            if (_actualizandoGrilla) return;

            if (DGVmisactividades.CurrentRow != null &&
                DGVmisactividades.CurrentRow.Cells["Id"].Value != null)
            {
                if (int.TryParse(DGVmisactividades.CurrentRow.Cells["Id"].Value.ToString(), out int actividadId))
                {
                    _824_ecActividad act = MisAct_824_ec?.FirstOrDefault(a => a.Id_824_ec == actividadId);

                    if (act != null)
                    {
                        if (act.Estado_824_ec == EstadoActividad_824_ec.Cancelado || act.Estado_824_ec == EstadoActividad_824_ec.Caducado)
                        {
                            panel1.BackColor = Color.IndianRed;
                            BTNmodActividad.Enabled = false;
                            BTNmodActividad.Visible = false;
                        }
                        else if (act.Estado_824_ec == EstadoActividad_824_ec.Completado)
                        {
                            panel1.BackColor = Color.Green;
                            BTNmodActividad.Enabled = false;
                            BTNmodActividad.Visible = false;
                        }
                        else
                        {
                            panel1.BackColor = Color.OliveDrab;
                            BTNmodActividad.Enabled = true;
                            BTNmodActividad.Visible = true;
                        }

                        ActividadActual = act;

                        CargarDetalleActividad_824_ec();
                        ActualizarPostulados_824_ec();
                        ActualizarCargarGrillaAceptados_824_ec();

                        return;
                    }
                }
            }

            LimpiarDetalle_824_ec();
        }

        private void DGVmisactividades_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChangeDeslocalizado();
        }

        #endregion grilla

        //Grilla de postulados
        #region grillaPostulados
        private void CargarGrillaPostulados_824_ec()
        {
            DGVpostulaciones.Columns.Clear();

            DGVpostulaciones.Columns.Add("Id", "Id");
            DGVpostulaciones.Columns["Id"].Visible = false;

            DGVpostulaciones.Columns.Add("Participante", "Participante / Grupo");
            DGVpostulaciones.Columns["Participante"].Width = 150;

            DGVpostulaciones.Columns.Add("Gestor", "Gestor");
            DGVpostulaciones.Columns["Gestor"].Width = 85;

            DGVpostulaciones.Columns.Add("Estado", "Estado");
            DGVpostulaciones.Columns["Estado"].Width = 80;

            DGVpostulaciones.AllowUserToAddRows = false;
            DGVpostulaciones.AllowUserToDeleteRows = false;
            DGVpostulaciones.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVpostulaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVpostulaciones.MultiSelect = false;
            DGVpostulaciones.RowHeadersVisible = false;

            ActualizarPostulados_824_ec();
        }
        private void ActualizarPostulados_824_ec()
        {
            if (ActividadActual != null)
            {
                PostAct_824_ec = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(ActividadActual.Id_824_ec)
                    .Where(p => p.Estado_824_ec != EstadoPostulacion_824_ec.Aceptado)
                    .ToList();

                if (DGVpostulaciones.Columns.Count == 0) return;
                DGVpostulaciones.Rows.Clear();

                if (PostAct_824_ec != null)
                {
                    foreach (var pos in PostAct_824_ec)
                    {
                        DGVpostulaciones.Rows.Add(
                            pos.Id_824_ec,
                            ObtenerDescripcionParticipante_824_ec(pos),
                            pos.GestorResponsable_824_ec?.NombreUsuario ?? "N/A",
                            pos.Estado_824_ec.ToString()
                        );
                    }
                }
            }
        }
        #endregion grillaPostulados

        //Grilla aceptados
        #region grillaAceptados
        private void CargarGrillaAceptados_824_ec()
        {
            DGVparticipantes.Columns.Clear();

            DGVparticipantes.Columns.Add("Id", "Id");
            DGVparticipantes.Columns["Id"].Visible = false;

            DGVparticipantes.Columns.Add("Participante", "Participante / Grupo");
            DGVparticipantes.Columns["Participante"].Width = 150;

            DGVparticipantes.Columns.Add("Gestor", "Gestor");
            DGVparticipantes.Columns["Gestor"].Width = 85;

            DGVparticipantes.Columns.Add("Estado", "Estado");
            DGVparticipantes.Columns["Estado"].Width = 80;

            DGVparticipantes.AllowUserToAddRows = false;
            DGVparticipantes.AllowUserToDeleteRows = false;
            DGVparticipantes.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVparticipantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVparticipantes.MultiSelect = false;
            DGVparticipantes.RowHeadersVisible = false;

            ActualizarCargarGrillaAceptados_824_ec();
        }
        private void ActualizarCargarGrillaAceptados_824_ec()
        {
            if (ActividadActual != null)
            {
                PartAct_824_ec = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(ActividadActual.Id_824_ec)
                    .Where(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado)
                    .ToList();

                if (DGVparticipantes.Columns.Count == 0) return;
                DGVparticipantes.Rows.Clear();

                if (PartAct_824_ec != null)
                {
                    foreach (var pos in PartAct_824_ec)
                    {
                        DGVparticipantes.Rows.Add(
                            pos.Id_824_ec,
                            ObtenerDescripcionParticipante_824_ec(pos),
                            pos.GestorResponsable_824_ec?.NombreUsuario ?? "N/A",
                            pos.Estado_824_ec.ToString()
                        );
                    }
                }
            }
        }
        #endregion grillaAceptados

        // Detalle de la actividad
        #region Detalle
        private void CargarDetalleActividad_824_ec()
        {
            LBLnombree.Text = ActividadActual.Nombre_824_ec;
            TXTcategoria.Text = ActividadActual.Categoria_824_ec != null ? ActividadActual.Categoria_824_ec.Nombre_824_ec : "";
            TXTnivel.Text = ActividadActual.NivelRequerido_824_ec.ToString();
            TXTestado.Text = ActividadActual.Estado_824_ec.ToString();
            TXBdescripcion.Text = ActividadActual.Descripcion_824_ec ?? "";
            TXTdia.Text = ActividadActual.FechaHora_824_ec.ToString("dd/MM/yyyy");
            TXThora.Text = ActividadActual.FechaHora_824_ec.ToString("HH:mm");
            TXTlugar.Text = ActividadActual.Ubicacion_824_ec ?? "";

            var postulaciones = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(ActividadActual.Id_824_ec);
            int cantParticipantes = ContarParticipantesAceptados_824_ec(postulaciones);

            TXTmaxmin.Text = $"{ActividadActual.CantidadMinima_824_ec} ≤ {cantParticipantes} ≤ {ActividadActual.CantidadMaxima_824_ec}";
            TXTpublicacion.Text = ActividadActual.FechaPublicacion_824_ec.ToString("dd/MM/yyyy");
            TXTcaducacion.Text = ActividadActual.FechaCaducidad_824_ec.ToString("dd/MM/yyyy");
        }
        private void LimpiarDetalle_824_ec()
        {
            LBLnombree.Text = "Nombre de actividad";
            TXTcategoria.Text = "";
            TXTnivel.Text = "";
            TXTestado.Text = "";
            TXBdescripcion.Text = "";
            TXTdia.Text = "";
            TXThora.Text = "";
            TXTlugar.Text = "";
            TXTmaxmin.Text = "";
            TXTpublicacion.Text = "";
            TXTcaducacion.Text = "";
        }
        #endregion Detalle


        // METODOS DE BOTONES
        #region botonesABM 
        private void BTNmodActividad_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Modificacion);
        }
        private void BTNnuevaActividad_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Alta);
        }
        private void BTNbajaActividad_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Baja);
        }
        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llamarAMB(Constantes.TiposOperacion oper)
        {
            if (oper == Constantes.TiposOperacion.Alta || DGVmisactividades.SelectedRows.Count > 0)
            {
                _824_ecFormABMactividad mForm_824_ec = new _824_ecFormABMactividad();
                mForm_824_ec.StartPosition = FormStartPosition.CenterParent;
                if (oper != Constantes.TiposOperacion.Alta)
                {
                    int mId = int.Parse(DGVmisactividades.SelectedRows[0].Cells[0].Value.ToString());
                    mForm_824_ec._824_ecActividadEditable = _824_ecActividadBLL.ObtenerPorId_824_ec(mId);
                }
                mForm_824_ec._824_ecTipoOperacion = oper;
                mForm_824_ec.ShowDialog(this);
                Actualizar_824_ec();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una de sus actividades para realizar esta operacion de " + oper.ToString());
            }
        }
        private void BTNverUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                int postulacionId = 0;
                if (DGVparticipantes.SelectedRows.Count > 0)
                {
                    postulacionId = int.Parse(DGVparticipantes.SelectedRows[0].Cells["Id"].Value.ToString());
                }
                else if (DGVpostulaciones.SelectedRows.Count > 0)
                {
                    postulacionId = int.Parse(DGVpostulaciones.SelectedRows[0].Cells["Id"].Value.ToString());
                }
                else
                {
                    MessageBox.Show("Para ver el historial y experiencia de un participante, primero debes seleccionarlo en la grilla de postulaciones o participantes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _824_ecPostulacion postSeleccionada = _824_ecPostulacionBLL.BuscarPorID_824_ec(postulacionId);
                if (postSeleccionada == null) return;

                // Si es grupal, mostrar lista de integrantes y abrir el historial del seleccionado (o directamente si es individual)
                List<_824_ecParticipante> candidatosAInspeccionar = new List<_824_ecParticipante>();
                if (postSeleccionada.ParticipantesAgrupados != null && postSeleccionada.ParticipantesAgrupados.Count > 0)
                {
                    candidatosAInspeccionar.AddRange(postSeleccionada.ParticipantesAgrupados);
                }
                else if (postSeleccionada.Participante_824_ec != null)
                {
                    candidatosAInspeccionar.Add(postSeleccionada.Participante_824_ec);
                }

                if (candidatosAInspeccionar.Count == 0)
                {
                    MessageBox.Show("Esta postulación no tiene participantes asociados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Abrir la ficha de historial por cada participante de la postulación (1 si es individual, o uno tras otro si es grupo)
                foreach (var participante in candidatosAInspeccionar)
                {
                    using (_824_ecFormMostarListaActividades fVerPart = new _824_ecFormMostarListaActividades())
                    {
                        fVerPart.ParticipanteAnalizado = participante;
                        fVerPart.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTNaceptarsolicitud_Click(object sender, EventArgs e)
        {
            if (DGVpostulaciones.SelectedRows.Count > 0)
            {
                try
                {
                    int mId = int.Parse(DGVpostulaciones.SelectedRows[0].Cells[0].Value.ToString());
                    _824_ecPostulacion viejaPost = _824_ecPostulacionBLL.BuscarPorID_824_ec(mId);

                    bool AptoParaCompletar = _824_ecPostulacionBLL.EvaluarCandidatoAntesDeCambiarEstado_824_ec(
                        viejaPost.Id_824_ec,
                        viejaPost.Estado_824_ec,
                        EstadoPostulacion_824_ec.Aceptado,
                        viejaPost.Actividad_824_ec);

                    string detallePostulado = ObtenerDescripcionParticipante_824_ec(viejaPost);

                    _824_ecNotificacionBLL.Guardar_824_ec(
                        new _824_ecNotificacion(
                            "Postulación Aceptada",
                            $"El organizador {UsuariActual.NombreUsuario} aceptó la postulación de [{detallePostulado}] para la actividad {viejaPost.Actividad_824_ec.Nombre_824_ec} del día {viejaPost.Actividad_824_ec.FechaHora_824_ec}.",
                            UsuariActual.Id,
                            viejaPost.GestorResponsable_824_ec.Id,
                            participante: viejaPost.Participante_824_ec,
                            participantesAgrupados: viejaPost.ParticipantesAgrupados
                        ));

                    MessageBox.Show("Postulación aceptada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (AptoParaCompletar)
                    {
                        MessageBox.Show("Se alcanzó el cupo mínimo, la actividad ya puede completarse.", "Cupo Mínimo Alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    string logAceptar = $"Postulacion ID:{viejaPost.Id_824_ec} (Act:{viejaPost.Actividad_824_ec.Id_824_ec}) -> Aceptado";
                    SessionManager.TraerInstancia().RegistrarActividad(logAceptar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Actualizar_824_ec();
                ActualizarPostulados_824_ec();
                ActualizarCargarGrillaAceptados_824_ec();
                SeleccionarActual();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una postulación de la grilla para aceptarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BTNrevocarSolicitud_Click(object sender, EventArgs e)
        {
            if (DGVparticipantes.SelectedRows.Count > 0)
            {
                try
                {
                    int mId = int.Parse(DGVparticipantes.SelectedRows[0].Cells[0].Value.ToString());
                    _824_ecPostulacion viejaPost = _824_ecPostulacionBLL.BuscarPorID_824_ec(mId);

                    _824_ecPostulacionBLL.EvaluarCandidatoAntesDeCambiarEstado_824_ec(
                        viejaPost.Id_824_ec,
                        viejaPost.Estado_824_ec,
                        EstadoPostulacion_824_ec.Postulado,
                        viejaPost.Actividad_824_ec);

                    string detallePostulado = ObtenerDescripcionParticipante_824_ec(viejaPost);

                    _824_ecNotificacionBLL.Guardar_824_ec(
                        new _824_ecNotificacion(
                            "Postulación Revocada",
                            $"El organizador {UsuariActual.NombreUsuario} revocó la aceptación de [{detallePostulado}] para la actividad {viejaPost.Actividad_824_ec.Nombre_824_ec} del día {viejaPost.Actividad_824_ec.FechaHora_824_ec}. La postulación volvió a estado Postulado.",
                            UsuariActual.Id,
                            viejaPost.GestorResponsable_824_ec.Id,
                            participante: viejaPost.Participante_824_ec,
                            participantesAgrupados: viejaPost.ParticipantesAgrupados
                        ));

                    MessageBox.Show("Postulación revocada del grupo con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string logRevocar = $"Postulacion ID:{viejaPost.Id_824_ec} (Act:{viejaPost.Actividad_824_ec.Id_824_ec}) -> Postulado";
                    SessionManager.TraerInstancia().RegistrarActividad(logRevocar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (DGVpostulaciones.SelectedRows.Count > 0)
            {
                try
                {
                    int mId2 = int.Parse(DGVpostulaciones.SelectedRows[0].Cells[0].Value.ToString());
                    _824_ecPostulacion viejaPost2 = _824_ecPostulacionBLL.BuscarPorID_824_ec(mId2);

                    _824_ecPostulacionBLL.EvaluarCandidatoAntesDeCambiarEstado_824_ec(
                        viejaPost2.Id_824_ec,
                        viejaPost2.Estado_824_ec,
                        EstadoPostulacion_824_ec.Rechazado,
                        viejaPost2.Actividad_824_ec);

                    string detallePostulado2 = ObtenerDescripcionParticipante_824_ec(viejaPost2);

                    _824_ecNotificacionBLL.Guardar_824_ec(
                        new _824_ecNotificacion(
                            "Postulación Rechazada",
                            $"El organizador {UsuariActual.NombreUsuario} rechazó definitivamente la postulación de [{detallePostulado2}] para la actividad {viejaPost2.Actividad_824_ec.Nombre_824_ec} del día {viejaPost2.Actividad_824_ec.FechaHora_824_ec}.",
                            UsuariActual.Id,
                            viejaPost2.GestorResponsable_824_ec.Id,
                            participante: viejaPost2.Participante_824_ec,
                            participantesAgrupados: viejaPost2.ParticipantesAgrupados
                        ));

                    MessageBox.Show("Postulación rechazada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string logRechazar = $"Postulacion ID:{viejaPost2.Id_824_ec} (Act:{viejaPost2.Actividad_824_ec.Id_824_ec}) -> Rechazado";
                    SessionManager.TraerInstancia().RegistrarActividad(logRechazar);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Para revocar una aceptación seleccione un participante aceptado, o para rechazar seleccione una solicitud de postulación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Actualizar_824_ec();
            ActualizarPostulados_824_ec();
            ActualizarCargarGrillaAceptados_824_ec();
            SeleccionarActual();
        }
        #endregion botonesABM

        // Eventos DE Controles
        #region controles
        private void CMBfiltroActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }
        private void FiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }
        private void CMDdirecciondeFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }
        private void DGVparticipantes_SelectionChanged(object sender, EventArgs e)
        {
            if (_ejecutandoLimpieza) return;

            if (DGVparticipantes.SelectedRows.Count > 0 || DGVparticipantes.SelectedCells.Count > 0)
            {
                _ejecutandoLimpieza = true;
                DGVpostulaciones.ClearSelection();
                LBLrebocador.Text = "Revocar del grupo";
                _ejecutandoLimpieza = false;
                BTNaceptarsolicitud.Enabled = false;
                BTNaceptarsolicitud.Visible = false;
                LBLaceptarsol.Visible = false;
            }
        }
        private void DGVpostulaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (_ejecutandoLimpieza) return;

            if (DGVpostulaciones.SelectedRows.Count > 0 || DGVpostulaciones.SelectedCells.Count > 0)
            {
                _ejecutandoLimpieza = true;
                DGVparticipantes.ClearSelection();
                LBLrebocador.Text = "Rechazar Solicitud";
                _ejecutandoLimpieza = false;
                BTNaceptarsolicitud.Enabled = true;
                BTNaceptarsolicitud.Visible = true;
                LBLaceptarsol.Visible = true;
            }
        }
        #endregion controles

    }
}
