using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using Ingenieria.De.Software;
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

namespace Capa_de_Aplicación_BLL_
{
    public partial class _824_ecConformarPostulacion : Form
    {
        internal _824_ecActividad _824_ecActividadActual;
        private List<_824_ecParticipante> ParticipantesRegistrados = new List<_824_ecParticipante>();
        private List<_824_ecParticipante> ParticipantesSeleccionados = new List<_824_ecParticipante>();
        internal List<_824_ecPostulacion> PostulacionesCreadas { get; private set; } = new List<_824_ecPostulacion>(); // para devolverle al form anterior
        public _824_ecConformarPostulacion()
        {
            InitializeComponent();
        }
        private void _824_ecConformarPostulacion_Load(object sender, EventArgs e)
        {
            if (_824_ecActividadActual == null)
            {
                MessageBox.Show("No se encontro la actividad seleccionada");
                this.Close();
            }
            CargarLabels();
            CargarFiltros();
            CargarGrillaParticipantes_824_ec();
            CargarGrillaParticipantesEnPosts_824_ec();


        }


        //Carga inicial
        #region Carga
        private void CargarLabels()
        {
            var postulaciones = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(_824_ecActividadActual.Id_824_ec);
            int cantParticipantes = postulaciones != null
                ? postulaciones
                    .Where(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado)
                    .Sum(p => (p.ParticipantesAgrupados != null && p.ParticipantesAgrupados.Count > 0)
                        ? p.ParticipantesAgrupados.Count
                        : 1)
                : 0;
            LBLacti.Text = _824_ecActividadActual.Nombre_824_ec;
            LBLmax.Text = _824_ecActividadActual.CantidadMaxima_824_ec.ToString();
            LBLmin.Text = cantParticipantes.ToString();
        }
        private void CargarFiltros()
        {
            CMBfiltroParticipante.Items.Clear();
            CMBfiltroParticipante.Items.Add("Sin filtro");
            CMBfiltroParticipante.Items.Add("Nombre");
            CMBfiltroParticipante.Items.Add("Apellido");
            CMBfiltroParticipante.Items.Add("Documento");
            CMBfiltroParticipante.SelectedIndex = 0;
        }
        private void CargarGrillaParticipantesEnPosts_824_ec()
        {
            DGVPartenPost.Columns.Add("Id", "Id");
            DGVPartenPost.Columns["Id"].Visible = false;

            DGVPartenPost.Columns.Add("Clave", "Clave");
            DGVPartenPost.Columns["Clave"].Visible = false;

            DGVPartenPost.Columns.Add("Apellido", "Apellido");
            DGVPartenPost.Columns["Apellido"].Width = 100;

            DGVPartenPost.Columns.Add("Documento", "Documento");
            DGVPartenPost.Columns["Documento"].Width = 150;

            DGVPartenPost.AllowUserToAddRows = false;
            DGVPartenPost.AllowUserToDeleteRows = false;
            DGVPartenPost.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVPartenPost.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVPartenPost.MultiSelect = false;
            DGVPartenPost.RowHeadersVisible = false;
        }
        #endregion Carga

        // cargar la grilla de los participantes
        #region grillaParticipantes
        private void CargarGrillaParticipantes_824_ec()
        {
            DGVPartRegistrados.Columns.Add("Id", "Id");
            DGVPartRegistrados.Columns["Id"].Visible = false;

            DGVPartRegistrados.Columns.Add("Clave", "Clave");
            DGVPartRegistrados.Columns["Clave"].Visible = false;

            DataGridViewCheckBoxColumn columnaActivo = new DataGridViewCheckBoxColumn();
            columnaActivo.Name = "Activo";
            columnaActivo.HeaderText = "Activo";
            DGVPartRegistrados.Columns.Add(columnaActivo);
            DGVPartRegistrados.Columns["Activo"].Width = 60;

            DGVPartRegistrados.Columns.Add("Nombre", "Nombre");
            DGVPartRegistrados.Columns["Nombre"].Width = 100;

            DGVPartRegistrados.Columns.Add("Apellido", "Apellido");
            DGVPartRegistrados.Columns["Apellido"].Width = 100;

            DGVPartRegistrados.Columns.Add("Documento", "Documento");
            DGVPartRegistrados.Columns["Documento"].Width = 150;

            DGVPartRegistrados.Columns.Add("Alta", "Alta");
            DGVPartRegistrados.Columns["Alta"].Width = 150;

            DGVPartRegistrados.AllowUserToAddRows = false;
            DGVPartRegistrados.AllowUserToDeleteRows = false;
            DGVPartRegistrados.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVPartRegistrados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVPartRegistrados.MultiSelect = false;
            DGVPartRegistrados.RowHeadersVisible = false;

            ActualizarPostulaciones_824_ec();
        }
        private void ActualizarPostulaciones_824_ec()
        {
            ParticipantesRegistrados = _824_ecParticipanteBLL.ListarTodos_824_ec();
            if (DGVPartRegistrados.Columns.Count == 0) return;
            DGVPartRegistrados.Rows.Clear();
            if (ParticipantesRegistrados != null)
            {
                foreach (var par in ParticipantesRegistrados)
                {
                    DGVPartRegistrados.Rows.Add(
                        par.Id_824_ec,
                        par.PalabraClave_824_ec,
                        par.Activo_824_ec,
                        par.Nombre_824_ec,
                        par.Apellido_824_ec,
                        par.Documento_824_ec,
                        par.FechaDeAlta
                    );
                }
            }

        }
        #endregion grillaParticipantes

        //Botones principales
        #region BotonesPrincipales
        private void BTNirABMparti_Click(object sender, EventArgs e)
        {
            try
            {
                _824_ecFormABMmaestro fMaes_824_ec = new _824_ecFormABMmaestro();
                fMaes_824_ec._824_ecMaestroActual = MaestrosNegocia_824_ec.Participante;
                fMaes_824_ec.ShowDialog(this);

                // Refrescar la lista de registrados por si se dio de alta un participante nuevo
                ActualizarPostulaciones_824_ec();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNverDetalle_Click(object sender, EventArgs e)
        {
            _824_ecFormABMactividad mForm_824_ec = new _824_ecFormABMactividad();
            mForm_824_ec.StartPosition = FormStartPosition.CenterParent;

            mForm_824_ec._824_ecActividadEditable = _824_ecActividadActual;

            mForm_824_ec._824_ecTipoOperacion = Constantes.TiposOperacion.DeSesion;
            mForm_824_ec.ShowDialog(this);
        }
        private void BTNenviarPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (ParticipantesSeleccionados.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos un participante para conformar la postulación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (RBTtipoPost3.Checked && ParticipantesSeleccionados.Count < 2)
                {
                    MessageBox.Show("Una postulación grupal requiere al menos 2 participantes.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Usuario gestorActual = SessionManager.TraerInstancia().usuarioINS;
                PostulacionesCreadas.Clear();

                // Reegistrar según el modo elegido
                if (RBTtipoPost1.Checked || RBTtipoPost2.Checked)
                {
                    foreach (var part in ParticipantesSeleccionados)
                    {
                        _824_ecPostulacion nuevaPost = new _824_ecPostulacion
                        {
                            Actividad_824_ec = _824_ecActividadActual,
                            GestorResponsable_824_ec = gestorActual,
                            Participante_824_ec = part,
                            FechaPostulacion_824_ec = DateTime.Now,
                            Estado_824_ec = EstadoPostulacion_824_ec.Postulado
                        };

                        _824_ecPostulacionBLL.RegistrarPostulacion_824_ec(nuevaPost);
                        PostulacionesCreadas.Add(nuevaPost);
                    }

                    string detalleBitacora = RBTtipoPost1.Checked
                        ? $"Postulacion individual de {PostulacionesCreadas[0].Participante_824_ec.Apellido_824_ec} en {_824_ecActividadActual.Nombre_824_ec}"
                        : $"Postulacion multiple ({PostulacionesCreadas.Count} candidatos) en {_824_ecActividadActual.Nombre_824_ec}";

                    SessionManager.TraerInstancia().RegistrarActividad(detalleBitacora);
                }
                else if (RBTtipoPost3.Checked)
                {
                    _824_ecPostulacion postGrupal = new _824_ecPostulacion
                    {
                        Actividad_824_ec = _824_ecActividadActual,
                        GestorResponsable_824_ec = gestorActual,
                        Participante_824_ec = null,
                        ParticipantesAgrupados = new List<_824_ecParticipante>(ParticipantesSeleccionados),
                        FechaPostulacion_824_ec = DateTime.Now,
                        Estado_824_ec = EstadoPostulacion_824_ec.Postulado
                    };

                    _824_ecPostulacionBLL.RegistrarPostulacion_824_ec(postGrupal);
                    PostulacionesCreadas.Add(postGrupal);
                    SessionManager.TraerInstancia().RegistrarActividad($"Postulacion grupal ({ParticipantesSeleccionados.Count} integrantes) en {_824_ecActividadActual.Nombre_824_ec}");
                }

                // envío de notificaciones 
                for (int i = 0; i < PostulacionesCreadas.Count; i++)
                {
                    var post = PostulacionesCreadas[i];
                    bool esGrupal = post.ParticipantesAgrupados != null && post.ParticipantesAgrupados.Count > 0;

                    using (_824_ecNotificacionPersonalizada fNotif = new _824_ecNotificacionPersonalizada())
                    {
                        fNotif.actividadNotificada = _824_ecActividadActual;
                        fNotif.esGrupal = esGrupal;
                        fNotif.indiceActualMultiple = PostulacionesCreadas.Count > 1 ? i + 1 : 0;
                        fNotif.totalMultiple = PostulacionesCreadas.Count;
                        fNotif.Participante0s = esGrupal
                            ? new List<_824_ecParticipante>(post.ParticipantesAgrupados)
                            : new List<_824_ecParticipante> { post.Participante_824_ec };
                        fNotif.StartPosition = this.StartPosition;
                        fNotif.ShowDialog(this);
                    }
                }

                MessageBox.Show("Postulación registrada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar postulación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion BotonesPrincipales


        // Cambiar de tipo de postulacion con radiobutons
        #region RadioButtons
        private void RBTtipoPost1_CheckedChanged(object sender, EventArgs e)
        {
            AdaptarFormulario();
        }
        private void RBTtipoPost2_CheckedChanged(object sender, EventArgs e)
        {
            AdaptarFormulario();
        }
        private void RBTtipoPost3_CheckedChanged(object sender, EventArgs e)
        {
            AdaptarFormulario();
        }
        private void AdaptarFormulario()
        {
            if (RBTtipoPost1.Checked)
            {
                LBLparti.Text = "Postulacion de:";
                LBLparti.Location = new Point(231, 62);
                DGVPartenPost.Size = new System.Drawing.Size(189, 75);
                DGVPartenPost.Location = new Point(236, 94);
                LBLagregar.Text = "Elegir";
                if (ParticipantesSeleccionados.Count > 1)
                {
                    var primero = ParticipantesSeleccionados.First();
                    ParticipantesSeleccionados.Clear();
                    ParticipantesSeleccionados.Add(primero);
                    RefrescarGrillaSeleccionados_824_ec();
                }
            }
            else if (RBTtipoPost2.Checked)
            {
                LBLparti.Text = "Postulaciones de:";
                LBLparti.Location = new Point(231, 0);
                DGVPartenPost.Size = new System.Drawing.Size(189, 254);
                DGVPartenPost.Location = new Point(236, 32);
                LBLagregar.Text = "Agregar";
            }
            else if (RBTtipoPost3.Checked)
            {
                LBLparti.Text = "Postulacion grupal:";
                LBLparti.Location = new Point(231, 0);
                DGVPartenPost.Size = new System.Drawing.Size(189, 254);
                DGVPartenPost.Location = new Point(236, 32);
                LBLagregar.Text = "Agregar";
            }
        }
        #endregion RadioButtons

        // region de los botones ue agregan y quitan al participante de la postulacion que se esta creando segun el modo 
        #region BotonParaAgregarQuitarParticipante
        private void BTNagregarAPost_Click(object sender, EventArgs e)
        {
            if (DGVPartRegistrados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un participante de la lista de registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(DGVPartRegistrados.CurrentRow.Cells["Id"].Value);
            _824_ecParticipante participante = ParticipantesRegistrados.FirstOrDefault(p => p.Id_824_ec == idSeleccionado);

            if (participante == null) return;

            if (!participante.Activo_824_ec)
            {
                MessageBox.Show("No se puede postular a un participante inactivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // en postulacion individual solo puedo haber uno 
            if (RBTtipoPost1.Checked)
            {
                ParticipantesSeleccionados.Clear();
                ParticipantesSeleccionados.Add(participante);
            }
            // en los otros modos acumula evitando repetidos
            else
            {
                if (ParticipantesSeleccionados.Any(p => p.Id_824_ec == participante.Id_824_ec))
                {
                    MessageBox.Show("El participante ya fue agregado a esta postulación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ParticipantesSeleccionados.Add(participante);
            }

            RefrescarGrillaSeleccionados_824_ec();
        }

        private void BTNquitarDePost_Click(object sender, EventArgs e)
        {
            if (DGVPartenPost.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un participante de la postulación para quitarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idQuitar = Convert.ToInt32(DGVPartenPost.CurrentRow.Cells["Id"].Value);
            _824_ecParticipante aQuitar = ParticipantesSeleccionados.FirstOrDefault(p => p.Id_824_ec == idQuitar);

            if (aQuitar != null)
            {
                ParticipantesSeleccionados.Remove(aQuitar);
                RefrescarGrillaSeleccionados_824_ec();
            }
        }
        private void RefrescarGrillaSeleccionados_824_ec()
        {
            DGVPartenPost.Rows.Clear();
            foreach (var par in ParticipantesSeleccionados)
            {
                DGVPartenPost.Rows.Add(
                    par.Id_824_ec,
                    par.PalabraClave_824_ec,
                    par.Apellido_824_ec,
                    par.Documento_824_ec
                );
            }
        }
        #endregion BotonParaAgregarQuitarParticipante


        private void CMBfiltroParticipante_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXTfiltro.Text = "";
            if (CMBfiltroParticipante.SelectedIndex == 0)
                TXTfiltro.Enabled = false;
            else
                TXTfiltro.Enabled = true;
        }

        private void TXTfiltro_TextChanged(object sender, EventArgs e)
        {
            if (ParticipantesRegistrados == null) return;

            string texto = TXTfiltro.Text.Trim().ToLower();
            IEnumerable<_824_ecParticipante> filtrados = ParticipantesRegistrados;

            if (!string.IsNullOrEmpty(texto) && CMBfiltroParticipante.SelectedIndex > 0)
            {
                switch (CMBfiltroParticipante.SelectedItem.ToString())
                {
                    case "Nombre":
                        filtrados = ParticipantesRegistrados.Where(p => p.Nombre_824_ec != null && p.Nombre_824_ec.ToLower().Contains(texto));
                        break;
                    case "Apellido":
                        filtrados = ParticipantesRegistrados.Where(p => p.Apellido_824_ec != null && p.Apellido_824_ec.ToLower().Contains(texto));
                        break;
                    case "Documento":
                        filtrados = ParticipantesRegistrados.Where(p => p.Documento_824_ec != null && p.Documento_824_ec.ToLower().Contains(texto));
                        break;
                }
            }

            DGVPartRegistrados.Rows.Clear();
            foreach (var par in filtrados)
            {
                DGVPartRegistrados.Rows.Add(
                    par.Id_824_ec,
                    par.PalabraClave_824_ec,
                    par.Activo_824_ec,
                    par.Nombre_824_ec,
                    par.Apellido_824_ec,
                    par.Documento_824_ec,
                    par.FechaDeAlta
                );
            }
        }

    }
}
