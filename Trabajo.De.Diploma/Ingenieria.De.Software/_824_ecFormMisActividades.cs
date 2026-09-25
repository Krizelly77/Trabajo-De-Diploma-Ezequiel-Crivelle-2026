using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingenieria.De.Software
{
    public partial class _824_ecFormMisActividades : Form
    {
        private List<_824_ecActividad> MisAct_824_ec;
        private _824_ecActividad ActividadActual;
        private List<_824_ecPostulacion> PostAct_824_ec;
        private List<_824_ecPostulacion> PartAct_824_ec; 
        private bool _ejecutandoLimpieza = false; // Variable para evitar bucles infinitos de eventos
        private bool _actualizandoGrilla = false; // bandera para evitar que se dispare el evento inesperadamente

        public _824_ecFormMisActividades()
        {
            InitializeComponent();
        }

        private void _824_ecFormMisActividades_Load(object sender, EventArgs e)
        {
            ConfigurarFiltros_824_ec();
            CargarGrilla_824_ec();
            CargarGrillaPostulados_824_ec();
            CargarGrillaAceptados_824_ec();
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
        }
        private void CargarListaDesdeBD_824_ec()
        {
            Usuario usuarioActual = SessionManager.TraerInstancia().usuarioINS;
            if (usuarioActual != null)
            {
                MisAct_824_ec = _824_ecActividadBLL.ListarTodas_824_ec()
                    .Where(a => a.Organizador_824_ec != null && a.Organizador_824_ec.Id == usuarioActual.Id)
                    .ToList();
            }
            else
            {
                MisAct_824_ec = new List<_824_ecActividad>();
            }
        }

        // METODOS DE GRILLA
        #region grilla
        private void CargarGrilla_824_ec()
        {
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

                // Filtro por Estado (si es distinto a "Todos")
                if (CMBfiltroActividades.SelectedItem != null && CMBfiltroActividades.SelectedItem.ToString() != "Todos")
                {
                    string estadoSeleccionado = CMBfiltroActividades.SelectedItem.ToString();
                    filtradas = filtradas.Where(a => a.Estado_824_ec.ToString() == estadoSeleccionado);
                }

                // Filtro por Fecha de Publicación (anteriores o iguales a la fecha seleccionada)
                DateTime fechaLimite = FiltroFecha.Value.Date;
                filtradas = filtradas.Where(a => a.FechaPublicacion_824_ec.Date <= fechaLimite);

                foreach (var act in filtradas)
                {
                    var postulaciones = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(act.Id_824_ec);
                    int cantParticipantes = postulaciones != null
                        ? postulaciones.Count(p => p.Estado_824_ec == _824_ecBE_Enums.EstadoPostulacion_824_ec.Aceptado)
                        : 0;

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
            if (ActividadActual == null)
                return;

            int actividadId = ActividadActual.Id_824_ec;

            foreach (DataGridViewRow fila in DGVmisactividades.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                if (fila.Cells["Id"].Value == null)
                    continue;

                if (!int.TryParse(
                    fila.Cells["Id"].Value.ToString(),
                    out int id))
                    continue;

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
            if (_actualizandoGrilla)
                return;

            if (DGVmisactividades.CurrentRow != null &&
                DGVmisactividades.CurrentRow.Cells["Id"].Value != null)
            {
                if (int.TryParse(
                    DGVmisactividades.CurrentRow.Cells["Id"].Value.ToString(),
                    out int actividadId))
                {
                    _824_ecActividad act = MisAct_824_ec?
                        .FirstOrDefault(a => a.Id_824_ec == actividadId);

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
            DGVpostulaciones.Columns.Add("Id", "Id");
            DGVpostulaciones.Columns["Id"].Visible = false;

            DGVpostulaciones.Columns.Add("Nombre", "Nombre");
            DGVpostulaciones.Columns["Nombre"].Width = 100;

            DGVpostulaciones.Columns.Add("Estado", "Estado");
            DGVpostulaciones.Columns["Estado"].Width = 100;

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
                PostAct_824_ec = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(ActividadActual.Id_824_ec).Where(p => p.Estado_824_ec != EstadoPostulacion_824_ec.Aceptado).ToList();
                if (DGVpostulaciones.Columns.Count == 0) return;
                DGVpostulaciones.Rows.Clear();
                if (PostAct_824_ec != null)
                {
                    foreach (var pos in PostAct_824_ec)
                    {
                        DGVpostulaciones.Rows.Add(
                            pos.Id_824_ec,
                            pos.Candidato_824_ec.NombreUsuario,
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
            DGVparticipantes.Columns.Add("Id", "Id");
            DGVparticipantes.Columns["Id"].Visible = false;

            DGVparticipantes.Columns.Add("Nombre", "Nombre");
            DGVparticipantes.Columns["Nombre"].Width = 100;
                
            DGVparticipantes.Columns.Add("Estado", "Estado");
            DGVparticipantes.Columns["Estado"].Width = 100;

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
                PartAct_824_ec = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(ActividadActual.Id_824_ec).Where(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado).ToList();
                if (DGVparticipantes.Columns.Count == 0) return;
                DGVparticipantes.Rows.Clear();
                if (PartAct_824_ec != null)
                {
                    foreach (var pos in PartAct_824_ec)
                    {
                        DGVparticipantes.Rows.Add(
                            pos.Id_824_ec,
                            pos.Candidato_824_ec.NombreUsuario,
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
            int cantParticipantes = postulaciones != null
                ? postulaciones.Count(p => p.Estado_824_ec == _824_ecBE_Enums.EstadoPostulacion_824_ec.Aceptado)
                : 0;

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
            
        }
        private void BTNaceptarsolicitud_Click(object sender, EventArgs e)
        {
            if (DGVpostulaciones.SelectedRows.Count > 0)
            {
                try
                {
                    int mId = int.Parse(DGVpostulaciones.SelectedRows[0].Cells[0].Value.ToString());
                    _824_ecPostulacion viejaPost = _824_ecPostulacionBLL.BuscarPorID_824_ec(mId);
                    bool AptoParaCompletar = _824_ecPostulacionBLL.EvaluarCandidatoAntesDeCambiarEstado_824_ec(viejaPost.Id_824_ec, viejaPost.Estado_824_ec, EstadoPostulacion_824_ec.Aceptado, viejaPost.Actividad_824_ec);

                    SessionManager.TraerInstancia().RegistrarActividad($"Modificacion de Postulacion: la postulacion de {viejaPost.Candidato_824_ec.NombreUsuario}, en la actividad: {viejaPost.Actividad_824_ec.Nombre_824_ec}, del estado:{viejaPost.Estado_824_ec} a:Aceptado");
                    MessageBox.Show("Postulacion Aceptada con éxito");
                    if (AptoParaCompletar)
                    {
                        MessageBox.Show("Se alcanzo el cupo minimo, grupo ya puede completarce");
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }

                Actualizar_824_ec();
                ActualizarPostulados_824_ec();
                ActualizarCargarGrillaAceptados_824_ec();
                SeleccionarActual();
            }
            else
                MessageBox.Show("Debe seleccionar un usuario de la grilla de postulaciones para aceptarlo");
        }
        private void BTNrevocarSolicitud_Click(object sender, EventArgs e)
        {
            if (DGVparticipantes.SelectedRows.Count > 0)
            {
                try
                {
                    int mId = int.Parse(DGVparticipantes.SelectedRows[0].Cells[0].Value.ToString());
                    _824_ecPostulacion viejaPost = _824_ecPostulacionBLL.BuscarPorID_824_ec(mId);
                    _824_ecPostulacionBLL.EvaluarCandidatoAntesDeCambiarEstado_824_ec(viejaPost.Id_824_ec, viejaPost.Estado_824_ec, EstadoPostulacion_824_ec.Postulado, viejaPost.Actividad_824_ec);

                    SessionManager.TraerInstancia().RegistrarActividad($"Modificacion de Postulacion: la postulacion de {viejaPost.Candidato_824_ec.NombreUsuario}, en la actividad: {viejaPost.Actividad_824_ec.Nombre_824_ec}, del estado:{viejaPost.Estado_824_ec} a:Postulado");
                    MessageBox.Show("Postulación revocada del grupo con éxito");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }

            }
            else if(DGVpostulaciones.SelectedRows.Count > 0)
            {
                try
                {
                    int mId2 = int.Parse(DGVpostulaciones.SelectedRows[0].Cells[0].Value.ToString());
                    _824_ecPostulacion viejaPost2 = _824_ecPostulacionBLL.BuscarPorID_824_ec(mId2);
                    _824_ecPostulacionBLL.EvaluarCandidatoAntesDeCambiarEstado_824_ec(viejaPost2.Id_824_ec, viejaPost2.Estado_824_ec, EstadoPostulacion_824_ec.Rechazado, viejaPost2.Actividad_824_ec);

                    SessionManager.TraerInstancia().RegistrarActividad($"Modificacion de Postulacion: la postulacion de {viejaPost2.Candidato_824_ec.NombreUsuario}, en la actividad: {viejaPost2.Actividad_824_ec.Nombre_824_ec}, del estado:{viejaPost2.Estado_824_ec} a:Rechazado");
                    MessageBox.Show("Postulación rechazada con éxito");
                }
                catch (Exception ex2)
                { MessageBox.Show(ex2.Message); }
            }
            else { MessageBox.Show("Para quitar aceptado seleccione un usuario de participantes o para rechazarlo de postulaciones"); }

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
        private void DGVparticipantes_SelectionChanged(object sender, EventArgs e)
        {
            if (_ejecutandoLimpieza) return;

            if (DGVparticipantes.SelectedRows.Count > 0 || DGVparticipantes.SelectedCells.Count > 0)
            {
                _ejecutandoLimpieza = true;
                DGVpostulaciones.ClearSelection();
                LBLrebocador.Text = "Rebocar del grupo";
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
