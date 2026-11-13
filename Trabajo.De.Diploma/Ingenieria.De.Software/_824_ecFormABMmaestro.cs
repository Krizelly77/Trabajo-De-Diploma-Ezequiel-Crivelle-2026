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
using Microsoft.VisualBasic;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Ingenieria.De.Software
{
    public partial class _824_ecFormABMmaestro : Form
    {
        internal MaestrosNegocia_824_ec _824_ecMaestroActual { get; set; }
        private List<_824_ecActividad> ActividadesMae;
        private List<_824_ecCategoria> CategoriasMae;
        private List<_824_ecPostulacion> PostulacionMae;
        private List<_824_ecNotificacion> NotificacionMae;
        private List<_824_ecParticipante> ParticipanteMae;
        private List<_824_ecSolicitante> SolicitanteMae;

        public _824_ecFormABMmaestro()
        {
            InitializeComponent();
        }

        private void ABMmaestro_Load(object sender, EventArgs e)
        {
            if (_824_ecMaestroActual == 0)
            {
                _824_ecCambiarDataSourse();
            }
            DGVmaestro.AllowUserToAddRows = false;
            DGVmaestro.AllowUserToDeleteRows = false;
            DGVmaestro.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVmaestro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVmaestro.MultiSelect = false;
        }
        private void _824_ecCambiarDataSourse()
        {
            switch (_824_ecMaestroActual)
            {
                case MaestrosNegocia_824_ec.Activida:
                    DGVmaestro.DataSource = ActividadesMae;
                    break;
                case MaestrosNegocia_824_ec.Categoria:
                    DGVmaestro.DataSource = CategoriasMae;
                    break;
                case MaestrosNegocia_824_ec.Postulacion:
                    DGVmaestro.DataSource = PostulacionMae;
                    break;
                case MaestrosNegocia_824_ec.Notificacion:
                    DGVmaestro.DataSource = NotificacionMae;
                    break;
                case MaestrosNegocia_824_ec.Participante:
                    DGVmaestro.DataSource = ParticipanteMae;
                    break;
                case MaestrosNegocia_824_ec.Solicitante:
                    DGVmaestro.DataSource = SolicitanteMae;
                    break;
            }
        }


        // Botones de cambio de maestro
        #region BotonesMaestros
        private void BTNmaeAct_Click(object sender, EventArgs e)
        {
            if (ActividadesMae == null)
                ActividadesMae = new List<_824_ecActividad>();

            ActividadesMae = _824_ecActividadBLL.ListarTodas_824_ec();
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Activida;
            _824_ecCambiarDataSourse();
        }

        private void BTNmaeCat_Click(object sender, EventArgs e)
        {
            if (CategoriasMae == null)
                CategoriasMae = new List<_824_ecCategoria>();

            CategoriasMae = _824_ecCategoriaBLL.Listar_824_ec();
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Categoria;
            _824_ecCambiarDataSourse();
        }

        private void BTNmaePos_Click(object sender, EventArgs e)
        {
            if (PostulacionMae == null)
                PostulacionMae = new List<_824_ecPostulacion>();

            PostulacionMae = _824_ecPostulacionBLL.ListarTodas_824_ec();
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Postulacion;
            _824_ecCambiarDataSourse();
        }

        private void BTNmaeNot_Click(object sender, EventArgs e)
        {
            if (NotificacionMae == null)
                NotificacionMae = new List<_824_ecNotificacion>();

            NotificacionMae = _824_ecNotificacionBLL.Listar_824_ec();
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Notificacion;
            _824_ecCambiarDataSourse();
        }

        private void BTNmaePar_Click(object sender, EventArgs e)
        {
            if (ParticipanteMae == null)
                ParticipanteMae = new List<_824_ecParticipante>();

            ParticipanteMae = _824_ecParticipanteBLL.ListarTodos_824_ec();
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Participante;
            _824_ecCambiarDataSourse();
        }

        private void BTNmaeSol_Click(object sender, EventArgs e)
        {
            if (SolicitanteMae == null)
                SolicitanteMae = new List<_824_ecSolicitante>();

            SolicitanteMae = _824_ecSolicitanteBLL.ListarTodos_824_ec();
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Solicitante;
            _824_ecCambiarDataSourse();
        }
        #endregion BotonesMaestros

        // Botones de operaciones ABM
        #region BotonesABM
        private void BTNcrearMae_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_824_ecMaestroActual)
                {
                    case MaestrosNegocia_824_ec.Participante:
                        CrearParticipanteSolicitante();
                        break;

                    case MaestrosNegocia_824_ec.Solicitante:
                        CrearParticipanteSolicitante();
                        break;

                    default:
                        MessageBox.Show("Seleccione un maestro para operar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNmodMae_Click(object sender, EventArgs e)
        {
            if (DGVmaestro.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                switch (_824_ecMaestroActual)
                {
                    case MaestrosNegocia_824_ec.Participante:
                        ModParticipanteSolicitante();
                        break;

                    case MaestrosNegocia_824_ec.Solicitante:
                        ModParticipanteSolicitante();
                        break;

                    default:
                        MessageBox.Show("Seleccione un maestro para operar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNverMae_Click(object sender, EventArgs e)
        {
            if (DGVmaestro.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para ver en detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                switch (_824_ecMaestroActual)
                {
                    case MaestrosNegocia_824_ec.Participante:
                        VerParticipanteSolicictante();
                        break;

                    case MaestrosNegocia_824_ec.Solicitante:
                        VerParticipanteSolicictante();
                        break;

                    default:
                        MessageBox.Show("Seleccione un maestro para operar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNeliminarMae_Click(object sender, EventArgs e)
        {
            if (DGVmaestro.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                switch (_824_ecMaestroActual)
                {
                    case MaestrosNegocia_824_ec.Participante:
                        EliParticipanteSolicitante();
                        break;

                    case MaestrosNegocia_824_ec.Solicitante:
                        EliParticipanteSolicitante();
                        break;

                    default:
                        MessageBox.Show("Seleccione un maestro para operar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // abm participante
        #region ParticipanteSolicitanteABM
        private void CrearParticipanteSolicitante()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante || _824_ecMaestroActual == MaestrosNegocia_824_ec.Solicitante)
            {
                using (_824_ecABMparticipantesolicitante frmABM = new _824_ecABMparticipantesolicitante())
                {
                    frmABM.TipoOperacion = Constantes.TiposOperacion.Alta;
                    frmABM.EsParticipante = (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante);

                    if (frmABM.ShowDialog() == DialogResult.OK)
                    {
                        RefrescarGrillaParticipanteSolicitante();
                    }
                }
            }
        }
        private void ModParticipanteSolicitante()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante || _824_ecMaestroActual == MaestrosNegocia_824_ec.Solicitante)
            {
                using (_824_ecABMparticipantesolicitante frmABM = new _824_ecABMparticipantesolicitante())
                {
                    frmABM.TipoOperacion = Constantes.TiposOperacion.Modificacion;
                    frmABM.EsParticipante = (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante);

                    frmABM.ClienteEditable = (_824_ecCliente)DGVmaestro.CurrentRow.DataBoundItem;

                    if (frmABM.ShowDialog() == DialogResult.OK)
                    {
                        RefrescarGrillaParticipanteSolicitante();
                    }
                }
            }
        }
        private void VerParticipanteSolicictante()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante || _824_ecMaestroActual == MaestrosNegocia_824_ec.Solicitante)
            {
                using (_824_ecABMparticipantesolicitante frmABM = new _824_ecABMparticipantesolicitante())
                {
                    frmABM.TipoOperacion = Constantes.TiposOperacion.DeSesion; // Modo lectura 
                    frmABM.EsParticipante = (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante);
                    frmABM.ClienteEditable = (_824_ecCliente)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog();
                }
            }
        }
        private void EliParticipanteSolicitante()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante || _824_ecMaestroActual == MaestrosNegocia_824_ec.Solicitante)
            {
                using (_824_ecABMparticipantesolicitante frmABM = new _824_ecABMparticipantesolicitante())
                {
                    frmABM.TipoOperacion = Constantes.TiposOperacion.Baja;
                    frmABM.EsParticipante = (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante);
                    frmABM.ClienteEditable = (_824_ecCliente)DGVmaestro.CurrentRow.DataBoundItem;

                    if (frmABM.ShowDialog() == DialogResult.OK)
                    {
                        RefrescarGrillaParticipanteSolicitante();
                    }
                }
            }
        }
        private void RefrescarGrillaParticipanteSolicitante()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante)
            {
                ParticipanteMae = _824_ecParticipanteBLL.ListarTodos_824_ec();
                _824_ecCambiarDataSourse();
            }
            else if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Solicitante)
            {
                SolicitanteMae = _824_ecSolicitanteBLL.ListarTodos_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        #endregion ParticipanteSolicitanteABM

        #endregion BotonesABM

        // Botones de serializacion
        #region BotonSerializador
        private void BTNserializar_Click(object sender, EventArgs e)
        {

        }

        private void BTNdeserializar_Click(object sender, EventArgs e)
        {

        }

        private void BTNlimpiar_Click(object sender, EventArgs e)
        {

        }

        private void BTNcargar_Click(object sender, EventArgs e)
        {

        }

        #endregion BotonesABM

        // Botones y otros controles
        #region Botones
        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Botones
        
    }
}