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
        private _824_ecActividad ActividadSeleccionada { get; set; }

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
            DGVmaestro.AllowUserToAddRows = false;
            DGVmaestro.AllowUserToDeleteRows = false;
            DGVmaestro.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVmaestro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVmaestro.MultiSelect = false;

            // Solo inicializa la grilla si se cargó desde otro formulario con un maestro asignado
            if (_824_ecMaestroActual != 0)
            {
                CargarDatosMaestroActual_824_ec();
            }
            else
            {
                ActivarSerializacion(false);
            }
        }

        private void CargarDatosMaestroActual_824_ec()
        {
            switch (_824_ecMaestroActual)
            {
                case MaestrosNegocia_824_ec.Activida:
                    ActividadesMae = _824_ecActividadBLL.ListarTodas_824_ec();
                    break;
                case MaestrosNegocia_824_ec.Categoria:
                    CategoriasMae = _824_ecCategoriaBLL.Listar_824_ec();
                    break;
                case MaestrosNegocia_824_ec.Postulacion:
                    PostulacionMae = _824_ecPostulacionBLL.ListarTodas_824_ec();
                    break;
                case MaestrosNegocia_824_ec.Notificacion:
                    NotificacionMae = _824_ecNotificacionBLL.Listar_824_ec();
                    break;
                case MaestrosNegocia_824_ec.Participante:
                    ParticipanteMae = _824_ecParticipanteBLL.ListarTodos_824_ec();
                    break;
                case MaestrosNegocia_824_ec.Solicitante:
                    SolicitanteMae = _824_ecSolicitanteBLL.ListarTodos_824_ec();
                    break;
                default:
                    return;
            }

            _824_ecCambiarDataSourse();
        }

        private void _824_ecCambiarDataSourse()
        {
            DGVmaestro.DataSource = null;
            switch (_824_ecMaestroActual)
            {
                case MaestrosNegocia_824_ec.Activida:
                    DGVmaestro.DataSource = ActividadesMae;
                    NoverActividad(true);
                    ActivarModificar(true);
                    ActivarSerializacion(false);
                    ActivarBitacora(true);
                    CambiarBotones("Actividad");
                    break;
                case MaestrosNegocia_824_ec.Categoria:
                    DGVmaestro.DataSource = CategoriasMae;
                    NoverActividad(false);
                    ActivarModificar(true);
                    ActivarSerializacion(false);
                    ActivarBitacora(false);
                    CambiarBotones("Categoria");
                    break;
                case MaestrosNegocia_824_ec.Postulacion:
                    DGVmaestro.DataSource = PostulacionMae;
                    NoverActividad(true);
                    CambiarBotones("Postulacion");
                    ActivarSerializacion(false);
                    ActivarModificar(false);
                    ActivarBitacora(false);
                    break;
                case MaestrosNegocia_824_ec.Notificacion:
                    DGVmaestro.DataSource = NotificacionMae;
                    NoverActividad(false);
                    ActivarModificar(false);
                    ActivarSerializacion(false);
                    ActivarBitacora(false);
                    CambiarBotones("Notificacion");
                    break;
                case MaestrosNegocia_824_ec.Participante:
                    DGVmaestro.DataSource = ParticipanteMae;
                    NoverActividad(false);
                    ActivarSerializacion(true);
                    ActivarModificar(true);
                    ActivarBitacora(false);
                    CambiarBotones("Participante");
                    break;
                case MaestrosNegocia_824_ec.Solicitante:
                    DGVmaestro.DataSource = SolicitanteMae;
                    NoverActividad(false);
                    ActivarSerializacion(true);
                    ActivarModificar(true);
                    ActivarBitacora(false);
                    CambiarBotones("Solicitante");
                    break;
            }
            OcultarColumnasNoDeseadas();
        }
        private void CambiarBotones(string v)
        {
            BTNcrearMae.Text = "Crea nuevo " + v;
            BTNmodMae.Text = "Modificar " + v;
            BTNeliminarMae.Text = "Eliminar " + v;
            BTNverMae.Text = "Ver " + v;
        }
        private void NoverActividad(bool mostrar)
        {
            if (mostrar)
            {
                BTNactividadnull.Visible = true;
                BTNactividadnull.Enabled = true;
                LBLactividadSelec.Visible = true;
                LBLactividadSelec.Enabled = true;
                TXTactividadselec.Visible = true;
                TXTactividadselec.Enabled = true;
            }else
            {
                BTNactividadnull.Visible = false;
                BTNactividadnull.Enabled = false;
                LBLactividadSelec.Visible = false;
                LBLactividadSelec.Enabled = false;
                TXTactividadselec.Visible = false;
                TXTactividadselec.Enabled = false;
            }
        }
        private void ActivarModificar(bool mostrar)
        {
            if (mostrar)
            {
                BTNmodMae.Visible = true;
                BTNmodMae.Enabled = true;
            }
            else
            {
                BTNmodMae.Visible = false;
                BTNmodMae.Enabled = false;
            }
        }
        private void ActivarBitacora(bool mostrar)
        {
            if (mostrar)
            {
                BTNbitacora.Visible = true;
                BTNbitacora.Enabled = true;
            }
            else
            {
                BTNbitacora.Visible = false;
                BTNbitacora.Enabled = false;
            }
        }
        private void ActivarSerializacion(bool mostrar)
        {
            if (mostrar)
            {
                BTNserializar.Visible = true;
                BTNserializar.Enabled = true;
                BTNdeserializar.Visible = true;
                BTNdeserializar.Enabled = true;
            }
            else
            {
                BTNserializar.Visible = false;
                BTNserializar.Enabled = false;
                BTNdeserializar.Visible = false;
                BTNdeserializar.Enabled = false;
            }
        }
        private void OcultarColumnasNoDeseadas()
        {
            string[] columnasAOcultar = { "DVH", "Id", "Id_824_ec", "Clave", "Contraseña", "DVH_824_ec"};
            foreach (string col in columnasAOcultar)
            {
                if (DGVmaestro.Columns.Contains(col))
                {
                    DGVmaestro.Columns[col].Visible = false;
                }
            }
        }

        // Botones de cambio de maestro
        #region BotonesMaestros
        private void BTNmaeAct_Click(object sender, EventArgs e)
        {
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Activida;
            CargarDatosMaestroActual_824_ec();
        }
        private void BTNmaeCat_Click(object sender, EventArgs e)
        {
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Categoria;
            CargarDatosMaestroActual_824_ec();
        }
        private void BTNmaePos_Click(object sender, EventArgs e)
        {
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Postulacion;
            CargarDatosMaestroActual_824_ec();
        }
        private void BTNmaeNot_Click(object sender, EventArgs e)
        {
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Notificacion;
            CargarDatosMaestroActual_824_ec();
        }
        private void BTNmaePar_Click(object sender, EventArgs e)
        {
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Participante;
            CargarDatosMaestroActual_824_ec();
        }
        private void BTNmaeSol_Click(object sender, EventArgs e)
        {
            _824_ecMaestroActual = MaestrosNegocia_824_ec.Solicitante;
            CargarDatosMaestroActual_824_ec();
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

                    case MaestrosNegocia_824_ec.Activida:
                        CrearActividad();
                        break;

                    case MaestrosNegocia_824_ec.Categoria:
                        CrearCategoria();
                        break;

                    case MaestrosNegocia_824_ec.Postulacion:
                        CrearPostulacion();
                        break;

                    case MaestrosNegocia_824_ec.Notificacion:
                        CrearNotificacion();
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

                    case MaestrosNegocia_824_ec.Activida:
                        ModActividad();
                        break;

                    case MaestrosNegocia_824_ec.Categoria:
                        ModCategoria();
                        break;

                    default:
                        MessageBox.Show("Seleccione un maestro para operar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        VerParticipanteSolicitante();
                        break;

                    case MaestrosNegocia_824_ec.Solicitante:
                        VerParticipanteSolicitante();
                        break;

                    case MaestrosNegocia_824_ec.Activida:
                        VerActividad();
                        break;

                    case MaestrosNegocia_824_ec.Categoria:
                        VerCategoria();
                        break;

                    case MaestrosNegocia_824_ec.Postulacion:
                        VerPostulacion();
                        break;

                    case MaestrosNegocia_824_ec.Notificacion:
                        VerNotificacion();
                        break;

                    default:
                        MessageBox.Show("Seleccione un maestro para operar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ver el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    case MaestrosNegocia_824_ec.Activida:
                        EliActividad();
                        break;

                    case MaestrosNegocia_824_ec.Categoria:
                        EliCategoria();
                        break;

                    case MaestrosNegocia_824_ec.Postulacion:
                        EliPostulacion();
                        break;

                    case MaestrosNegocia_824_ec.Notificacion:
                        EliNotificacion();
                        break;

                    default:
                        MessageBox.Show("Seleccione un maestro para operar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void VerParticipanteSolicitante()
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

        // abm actividad
        #region actividadABM
        private void CrearActividad()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Activida)
            {
                using (_824_ecFormABMactividad frmABM = new _824_ecFormABMactividad())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Alta;

                    frmABM.ShowDialog(this);
                }
                ActividadesMae = _824_ecActividadBLL.ListarTodas_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        private void ModActividad()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Activida)
            {
                using (_824_ecFormABMactividad frmABM = new _824_ecFormABMactividad())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Modificacion; // Modo lectura 
                    frmABM._824_ecActividadEditable = (_824_ecActividad)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
                ActividadesMae = _824_ecActividadBLL.ListarTodas_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        private void VerActividad()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Activida)
            {
                using (_824_ecFormABMactividad frmABM = new _824_ecFormABMactividad())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.DeSesion; // Modo lectura 
                    frmABM._824_ecActividadEditable = (_824_ecActividad)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
            }
        }
        private void EliActividad()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Activida)
            {
                using (_824_ecFormABMactividad frmABM = new _824_ecFormABMactividad())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Baja; // Modo lectura 
                    frmABM._824_ecActividadEditable = (_824_ecActividad)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
                ActividadesMae = _824_ecActividadBLL.ListarTodas_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        #endregion actividadABM

        // abm Categoria
        #region categoriaABM
        private void CrearCategoria()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Categoria)
            {
                using (_824_ecABMcategoria frmABM = new _824_ecABMcategoria())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Alta;

                    frmABM.ShowDialog(this);
                }
                CategoriasMae = _824_ecCategoriaBLL.Listar_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        private void ModCategoria()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Categoria)
            {
                using (_824_ecABMcategoria frmABM = new _824_ecABMcategoria())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Modificacion; 
                    frmABM._824_ecCategoriaEditable = (_824_ecCategoria)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
                CategoriasMae = _824_ecCategoriaBLL.Listar_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        private void VerCategoria()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Categoria)
            {
                using (_824_ecABMcategoria frmABM = new _824_ecABMcategoria())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.DeSesion;
                    frmABM._824_ecCategoriaEditable = (_824_ecCategoria)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
            }
        }
        private void EliCategoria()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Categoria)
            {
                using (_824_ecABMcategoria frmABM = new _824_ecABMcategoria())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Baja; 
                    frmABM._824_ecCategoriaEditable = (_824_ecCategoria)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
                CategoriasMae = _824_ecCategoriaBLL.Listar_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        #endregion categoriaABM

        // abm Postulacion
        #region postulacionABM
        private void CrearPostulacion()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Postulacion)
            {
                if (ActividadSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar una Actividad desde eL ABM de actividades para crearle una postulacion");
                }else
                {
                    using (_824_ecConformarPostulacion frmABM = new _824_ecConformarPostulacion())
                    {
                        frmABM.StartPosition = FormStartPosition.CenterParent;
                        frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Alta;
                        frmABM._824_ecDesdeMaestro = true;
                        frmABM._824_ecActividadActual = ActividadSeleccionada;


                        frmABM.ShowDialog(this);
                    }
                    PostulacionMae = _824_ecPostulacionBLL.ListarTodas_824_ec();
                    _824_ecCambiarDataSourse();
                }
            }
        }
        private void VerPostulacion()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Postulacion)
            {
                using (_824_ecConformarPostulacion frmABM = new _824_ecConformarPostulacion())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.DeSesion;
                    frmABM._824_ecPostulacionActual = (_824_ecPostulacion)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
            }
        }
        private void EliPostulacion()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Postulacion)
            {
                using (_824_ecConformarPostulacion frmABM = new _824_ecConformarPostulacion())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Baja;
                    frmABM._824_ecPostulacionActual = (_824_ecPostulacion)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
                PostulacionMae = _824_ecPostulacionBLL.ListarTodas_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        #endregion postulacionABM

        // abm Notificacion
        #region notificacionabm
        private void CrearNotificacion()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Notificacion)
            {
                using (_824_ecABMnotificacion frmABM = new _824_ecABMnotificacion())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Alta;

                    frmABM.ShowDialog(this);
                }
                NotificacionMae = _824_ecNotificacionBLL.Listar_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        private void VerNotificacion()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Notificacion)
            {
                using (_824_ecABMnotificacion frmABM = new _824_ecABMnotificacion())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.DeSesion;
                    frmABM._824_ecNotificacionEditable = (_824_ecNotificacion)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
            }
        }
        private void EliNotificacion()
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Notificacion)
            {
                using (_824_ecABMnotificacion frmABM = new _824_ecABMnotificacion())
                {
                    frmABM.StartPosition = FormStartPosition.CenterParent;
                    frmABM._824_ecTipoOperacion = Constantes.TiposOperacion.Baja;
                    frmABM._824_ecNotificacionEditable = (_824_ecNotificacion)DGVmaestro.CurrentRow.DataBoundItem;

                    frmABM.ShowDialog(this);
                }
                NotificacionMae = _824_ecNotificacionBLL.Listar_824_ec();
                _824_ecCambiarDataSourse();
            }
        }
        #endregion notificacionabm

        #endregion BotonesABM

        // Botones de serializacion
        #region BotonSerializador
        private void BTNserializar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_824_ecMaestroActual != MaestrosNegocia_824_ec.Participante && _824_ecMaestroActual != MaestrosNegocia_824_ec.Solicitante)
                {
                    MessageBox.Show("La serialización XML solo se encuentra disponible para Participantes y Solicitantes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos XML (*.xml)|*.xml";
                    saveFileDialog.InitialDirectory = _824_ecDirectivosManejador.ObtenerRutaCarpetaDefault("ExportacionesXML");

                    if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante)
                    {
                        saveFileDialog.Title = "Guardar archivo XML de Participantes";
                        saveFileDialog.FileName = "Participantes.xml";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            List<_824_ecParticipante> listaParticipantes = _824_ecParticipanteBLL.ListarTodos_824_ec();
                            _824_ecSerializadorBLL.SerializarParticipantesXML(saveFileDialog.FileName, listaParticipantes);
                            MessageBox.Show("Participantes serializados exitosamente en XML.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Solicitante)
                    {
                        saveFileDialog.Title = "Guardar archivo XML de Solicitantes";
                        saveFileDialog.FileName = "Solicitantes.xml";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            List<_824_ecSolicitante> listaSolicitantes = _824_ecSolicitanteBLL.ListarTodos_824_ec();
                            _824_ecSerializadorBLL.SerializarSolicitantesXML(saveFileDialog.FileName, listaSolicitantes);
                            MessageBox.Show("Solicitantes serializados exitosamente en XML.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al serializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTNdeserializar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_824_ecMaestroActual != MaestrosNegocia_824_ec.Participante && _824_ecMaestroActual != MaestrosNegocia_824_ec.Solicitante)
                {
                    MessageBox.Show("La deserialización XML solo se encuentra disponible para Participantes y Solicitantes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos XML (*.xml)|*.xml";
                    openFileDialog.InitialDirectory = _824_ecDirectivosManejador.ObtenerRutaCarpetaDefault("ExportacionesXML");

                    if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Participante)
                    {
                        openFileDialog.Title = "Seleccionar archivo XML de Participantes";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            List<_824_ecParticipante> listaDeserializada = _824_ecSerializadorBLL.DeserializarParticipantesXML(openFileDialog.FileName);
                            List<_824_ecParticipante> listaFiltrada = SeleccionarCantidadFilasDeserializadas(listaDeserializada);
                            if (listaFiltrada != null && listaFiltrada.Count > 0)
                            {
                                ParticipanteMae = listaFiltrada;
                                DGVmaestro.DataSource = null;
                                DGVmaestro.DataSource = ParticipanteMae;
                                MessageBox.Show($"Se cargaron {listaFiltrada.Count} participante(s) en la grilla correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Solicitante)
                    {
                        openFileDialog.Title = "Seleccionar archivo XML de Solicitantes";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            List<_824_ecSolicitante> listaDeserializada = _824_ecSerializadorBLL.DeserializarSolicitantesXML(openFileDialog.FileName);
                            List<_824_ecSolicitante> listaFiltrada = SeleccionarCantidadFilasDeserializadas(listaDeserializada);
                            if (listaFiltrada != null && listaFiltrada.Count > 0)
                            {
                                SolicitanteMae = listaFiltrada;
                                DGVmaestro.DataSource = null;
                                DGVmaestro.DataSource = SolicitanteMae;
                                MessageBox.Show($"Se cargaron {listaFiltrada.Count} solicitante(s) en la grilla correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al deserializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<T> SeleccionarCantidadFilasDeserializadas<T>(List<T> listaDeserializada)
        {
            if (listaDeserializada == null || listaDeserializada.Count == 0)
            {
                MessageBox.Show("El archivo XML no contiene registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            DialogResult respuesta = MessageBox.Show(
                $"El archivo contiene {listaDeserializada.Count} registros.\n\n" +
                "¿Desea deserializar y cargar TODOS los registros?\n\n" +
                "- 'Sí': Cargar todos los registros.\n" +
                "- 'No': Especificar una cantidad determinada de filas.\n" +
                "- 'Cancelar': Anular la operación.",
                "Opciones de Deserialización",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                return listaDeserializada;
            }
            else if (respuesta == DialogResult.No)
            {
                string input = Interaction.InputBox(
                    $"Ingrese la cantidad de filas a cargar (entre 1 y {listaDeserializada.Count}):",
                    "Cantidad de filas a deserializar",
                    listaDeserializada.Count.ToString());

                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }

                if (int.TryParse(input.Trim(), out int cantidad) && cantidad > 0)
                {
                    if (cantidad > listaDeserializada.Count)
                    {
                        MessageBox.Show($"La cantidad ingresada ({cantidad}) supera el total disponible ({listaDeserializada.Count}). Se cargarán todos los registros disponibles.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cantidad = listaDeserializada.Count;
                    }
                    return listaDeserializada.Take(cantidad).ToList();
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es un número entero positivo válido. Operación cancelada.", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }

            return null;
        }
        private void BTNlimpiar_Click(object sender, EventArgs e)
        {
            DGVmaestro.DataSource = null;
            DGVmaestro.Rows.Clear();
        }
        private void BTNcargar_Click(object sender, EventArgs e)
        {
            if (_824_ecMaestroActual != 0)
            {
                CargarDatosMaestroActual_824_ec();
            }
            else
            {
                MessageBox.Show("Seleccione un maestro para cargar los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion BotonesABM

        // Botones y otros controles
        #region Botones
        private void BTNbitacora_Click(object sender, EventArgs e)
        {
            _824_ecFormBitacoraActividades frmBitacora = new _824_ecFormBitacoraActividades();
            frmBitacora.ShowDialog();
        }
        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DGVmaestro_SelectionChanged(object sender, EventArgs e)
        {
            if (_824_ecMaestroActual == MaestrosNegocia_824_ec.Activida)
            {
                if (DGVmaestro.CurrentRow != null)
                {
                    if (DGVmaestro.CurrentRow.DataBoundItem is _824_ecActividad actividad)
                    {
                        ActividadSeleccionada = (_824_ecActividad)DGVmaestro.CurrentRow.DataBoundItem;
                        TXTactividadselec.Text = ActividadSeleccionada.Nombre_824_ec;
                    }
                }
            }
        }
        private void BTNactividadnull_Click(object sender, EventArgs e)
        {
            ActividadSeleccionada = null;
            TXTactividadselec.Text = "";
        }
        #endregion Botones

    }
}