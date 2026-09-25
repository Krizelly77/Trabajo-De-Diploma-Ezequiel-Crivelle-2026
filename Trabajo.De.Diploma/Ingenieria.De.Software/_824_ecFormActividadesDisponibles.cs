using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public _824_ecFormActividadesDisponibles()
        {
            InitializeComponent();
        }

        private void _824_ecFormActividadesDisponibles_Load(object sender, EventArgs e)
        {
            UsuarioActual = SessionManager.TraerInstancia().usuarioINS;

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
        }

        // cargar la grillas de las postulaciones
        #region grillaPostulaciones
        private void CargarGrillaPostulaciones_824_ec()
        {
            DGVpostulaciones.Columns.Add("Id", "Id");
            DGVpostulaciones.Columns["Id"].Visible = false;

            DGVpostulaciones.Columns.Add("Actividad", "Actividad");
            DGVpostulaciones.Columns["Actividad"].Width = 150;

            DGVpostulaciones.Columns.Add("Postulacion", "Postulacion");
            DGVpostulaciones.Columns["Postulacion"].Width = 100;

            DGVpostulaciones.Columns.Add("Caduca", "Caduca");
            DGVpostulaciones.Columns["Caduca"].Width = 100;

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
            if (DGVpostulaciones.Columns.Count == 0) return;
            DGVpostulaciones.Rows.Clear();
            if (MisPost_824_ec != null)
            {
                foreach (var pos in MisPost_824_ec)
                {
                    DGVpostulaciones.Rows.Add(
                        pos.Id_824_ec,
                        pos.Actividad_824_ec.Nombre_824_ec,
                        pos.Estado_824_ec.ToString(),
                        pos.Actividad_824_ec.FechaCaducidad_824_ec
                    );
                }
            }

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
                filtradas = filtradas.Where(a => a.FechaPublicacion_824_ec.Date <= fechaLimite);

                foreach (var act in filtradas)
                {
                    var postulaciones = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(act.Id_824_ec);
                    int cantParticipantes = postulaciones != null
                        ? postulaciones.Count(p => p.Estado_824_ec == _824_ecBE_Enums.EstadoPostulacion_824_ec.Aceptado)
                        : 0;

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
                    _824_ecPostulacion nuevaPost = new _824_ecPostulacion();

                    int mId = int.Parse(DGVactividades.SelectedRows[0].Cells[0].Value.ToString());

                    nuevaPost.Actividad_824_ec = _824_ecActividadBLL.ObtenerPorId_824_ec(mId);
                    nuevaPost.Candidato_824_ec = UsuarioActual;
                    _824_ecPostulacionBLL.RegistrarPostulacion_824_ec(nuevaPost, UsuarioActual.Id);

                    SessionManager.TraerInstancia().RegistrarActividad("Alta de Postulacion: en" + nuevaPost.Actividad_824_ec.Nombre_824_ec + " de id: " + nuevaPost.Id_824_ec);
                    MessageBox.Show("Postulacion registrada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {   MessageBox.Show(ex.Message);}

                ActualizarPostulaciones_824_ec();
                Actualizar_824_ec();
            }
            else
                MessageBox.Show("Debe seleccionar una actividad para postularte");
        }
        private void BTNretirar_Click(object sender, EventArgs e)
        {
            if (DGVpostulaciones.SelectedRows.Count > 0)
            {
                try
                {
                    int mId = int.Parse(DGVpostulaciones.SelectedRows[0].Cells[0].Value.ToString());
                    _824_ecPostulacion viejaPost = _824_ecPostulacionBLL.BuscarPorID_824_ec(mId);
                    _824_ecPostulacionBLL.EvaluarCandidatoAntesDeCambiarEstado_824_ec(viejaPost.Id_824_ec, viejaPost.Estado_824_ec, EstadoPostulacion_824_ec.Retirado, viejaPost.Actividad_824_ec);

                    SessionManager.TraerInstancia().RegistrarActividad($"Modificacion de Postulacion: la postulacion de {viejaPost.Candidato_824_ec.NombreUsuario}, en la actividad: {viejaPost.Actividad_824_ec.Nombre_824_ec}, del estado:{viejaPost.Estado_824_ec} a:Retirado");
                    MessageBox.Show("Postulacion retirada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex) 
                { MessageBox.Show(ex.Message); }

                ActualizarPostulaciones_824_ec();
                Actualizar_824_ec();
            }
            else
                MessageBox.Show("Debe seleccionar una postulacion para retirarla");
        }
        #endregion Botones

        // eventos de Controles
        #region Controles
        private void CMBfiltroActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }
        private void FiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }

        private void DGVactividades_SelectionChanged(object sender, EventArgs e)
        {
            // deslocalisamos la logica por si el evento no se dispara al seleccionar desde la otra grilla
            ActualizarEstadoBotonPostular();
        }
        private void ActualizarEstadoBotonPostular()
        {
            if (DGVactividades.CurrentRow == null)
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

            _824_ecActividad act = ActDis_824_ec?
                .FirstOrDefault(a => a.Id_824_ec == actividadId);

            if (act == null)
            {
                BTNpostular.Enabled = false;
                return;
            }

            BTNpostular.Enabled =
                act.Estado_824_ec == EstadoActividad_824_ec.Abierto ||
                act.Estado_824_ec == EstadoActividad_824_ec.Completado;
        }

        private void DGVpostulaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVpostulaciones.CurrentRow != null && DGVpostulaciones.CurrentRow.Cells["Id"].Value != null)
            {
                if (int.TryParse(DGVpostulaciones.CurrentRow.Cells["Id"].Value.ToString(), out int PostulacionId))
                {
                    _824_ecPostulacion post = MisPost_824_ec?.FirstOrDefault(a => a.Id_824_ec == PostulacionId);
                    if (post != null)
                    {
                        // si el grupo esta completado, ya no puede retirar su postulacion
                        if (post.Actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Completado)
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
        #endregion Controles

    }
}
