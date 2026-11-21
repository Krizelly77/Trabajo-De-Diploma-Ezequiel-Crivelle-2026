using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Ingenieria.De.Software
{
    public partial class _824_ecABMnotificacion : Form
    {
        internal Constantes.TiposOperacion _824_ecTipoOperacion { get; set; }
        internal _824_ecNotificacion _824_ecNotificacionEditable { get; set; }
        private Usuario _824_ecRemitente;
        private Usuario __824_ecDestinatario;

        public _824_ecABMnotificacion()
        {
            InitializeComponent();
        }

        private void _824_ecABMnotificacion_Load(object sender, EventArgs e)
        {
            _824_ecRemitente = SessionManager.TraerInstancia().usuarioINS;
            if (_824_ecTipoOperacion == Constantes.TiposOperacion.Modificacion)
            {
                MessageBox.Show("No se puede modificar una Notificacion");
                this.Close();
            }
            TXTfecha.Enabled = false;
            CHKLeido.Enabled = false;
            _824_ecCargarABM();
        }

        // iniciar formulario en base al tipo de operacion
        #region cargar
        private void _824_ecCargarABM()
        {
            switch (_824_ecTipoOperacion)
            {
                case Constantes.TiposOperacion.Alta:
                    _824_ecLimpiarCampos();
                    CargarGrillaDestinatarios();
                    LBLnombree.Text = "Crear Nueva Notificacion";
                    break;

                case Constantes.TiposOperacion.Baja:
                    if (_824_ecNotificacionEditable == null)
                    {
                        MessageBox.Show("No se ha especificado la Notificacion a eliminar");
                        this.Close();
                        return;
                    }
                    _824_ecCargarCampos();
                    _824_eDeshabilitarCampos();
                    LBLnombree.Text = "NO RECOMENDABLE ";
                    panel1.BackColor = Color.Red;
                    BTNconfirmar.Text = "Eliminar";
                    BTNconfirmar.BackColor = Color.IndianRed;
                    BTNconfirmar.ForeColor = Color.White;
                    break;

                case Constantes.TiposOperacion.DeSesion:
                    if (_824_ecNotificacionEditable == null)
                    {
                        MessageBox.Show("No se ha especificado la Actividad para Ver");
                        this.Close();
                        return;
                    }
                    _824_ecCargarCampos();
                    _824_eDeshabilitarCampos();
                    LBLnombree.Text = "Vista de Notificacion ";
                    panel1.BackColor = Color.DimGray;
                    BTNcancelar.Text = "OK";
                    BTNcancelar.ForeColor = Color.OliveDrab;
                    BTNconfirmar.Enabled = false;
                    BTNconfirmar.Visible = false;
                    break;

                default:
                    MessageBox.Show("Tipo de operacion invalido");
                    this.Close();
                    break;
            }
        }
        private void _824_eDeshabilitarCampos()
        {
            TXTasunto.Enabled = false;
            TXBmensaje.Enabled = false;
            this.Size = new System.Drawing.Size(479, 482); 
            DGVdestinatarios.Visible = false;
            DGVdestinatarios.Enabled = false;
            LBLdestinatarios.Visible = false;

        }
        private void _824_ecCargarCampos()
        {
            TXTasunto.Text = _824_ecNotificacionEditable.Asunto_824_ec;
            TXBmensaje.Text = _824_ecNotificacionEditable.Mensaje_824_ec;
            CHKLeido.Checked = _824_ecNotificacionEditable.Leida_824_ec;
            TXTfecha.Text = _824_ecNotificacionEditable.Fecha_824_ec.ToString();

            Usuario remitente = UsuarioBLL.ObtenerPorId(_824_ecNotificacionEditable.IdRemitente_824_ec);

            Usuario destinatario = UsuarioBLL.ObtenerPorId(_824_ecNotificacionEditable.IdDestinatario_824_ec);

            string nombreRemitente = remitente?.NombreUsuario ?? "Usuario desconocido";
            string nombreDestinatario = destinatario?.NombreUsuario ?? "Usuario desconocido";

            LBLremiDesti.Text = $"De {nombreRemitente} para {nombreDestinatario}";
        }
        private void _824_ecLimpiarCampos()
        {
            TXTfecha.Visible = false;
            CHKLeido.Visible = false;
            TXTasunto.Text = "";
            TXBmensaje.Text = "Mensaje";
            LBLremiDesti.Text = $"Remitente: {_824_ecRemitente.NombreUsuario}";
            CHKLeido.Checked = false;
            LBLfecha.Visible = false;
        }
        #endregion cargar
        // Grilla
        #region grilla
        private void CargarGrillaDestinatarios()
        {
            DGVdestinatarios.Columns.Add("Id", "Id");
            DGVdestinatarios.Columns["Id"].Visible = false;

            DGVdestinatarios.Columns.Add("Nombre", "Nombre");
            DGVdestinatarios.Columns["Nombre"].Width = 200;

            DGVdestinatarios.AllowUserToAddRows = false;
            DGVdestinatarios.AllowUserToDeleteRows = false;
            DGVdestinatarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVdestinatarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVdestinatarios.MultiSelect = true;
            DGVdestinatarios.RowHeadersVisible = false;

            Actualizar();
        }
        private void Actualizar()
        {
            DGVdestinatarios.Rows.Clear();

            List<Usuario> usuarios = UsuarioBLL.Listar();

            if (usuarios == null)
                return;

            usuarios = usuarios.Where(u => u.Activo).ToList();

            PoblarGrilla(usuarios);
        }
        private void PoblarGrilla(List<Usuario> usuarios)
        {
            DGVdestinatarios.Rows.Clear();
            if (usuarios == null) return;

            foreach (var usu in usuarios)
            {
                DGVdestinatarios.Rows.Add(usu.Id, usu.NombreUsuario);
            }
        }
        #endregion grilla
        // Botones
        #region botones
        private void BTNconfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_824_ecTipoOperacion)
                {
                    case Constantes.TiposOperacion.Alta:

                        // Validar remitente
                        if (_824_ecRemitente == null)
                        {
                            MessageBox.Show("No se pudo identificar al remitente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Validar asunto
                        if (string.IsNullOrWhiteSpace(TXTasunto.Text))
                        {
                            MessageBox.Show("Debe ingresar un asunto para la notificación.");
                            TXTasunto.Focus();
                            return;
                        }

                        // Validar mensaje
                        if (string.IsNullOrWhiteSpace(TXBmensaje.Text))
                        {
                            MessageBox.Show("Debe ingresar el mensaje de la notificación.");
                            TXBmensaje.Focus();
                            return;
                        }

                        // Obtener destinatarios seleccionados
                        if (DGVdestinatarios.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Debe seleccionar al menos un destinatario.");
                            return;
                        }

                        List<int> destinatariosSeleccionados = DGVdestinatarios.SelectedRows.Cast<DataGridViewRow>()
                            .Select(f => Convert.ToInt32(f.Cells["Id"].Value)).Distinct().ToList();

                        // Confirmar envío múltiple
                        if (destinatariosSeleccionados.Count > 1)
                        {
                            DialogResult confirmacion = MessageBox.Show(
                                $"Ha seleccionado {destinatariosSeleccionados.Count} destinatarios.\n\n" +
                                "¿Desea enviar la notificación a múltiples usuarios?\n\n" +
                                "Seleccione 'No' para volver y elegir un único destinatario.",
                                "Confirmar envío múltiple",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question
                            );

                            if (confirmacion == DialogResult.No)
                                return;
                        }

                        // Crear y guardar una notificación por destinatario
                        int notificacionesEnviadas = 0;

                        foreach (int idDestinatario in destinatariosSeleccionados)
                        {
                            _824_ecNotificacion notificacion = new _824_ecNotificacion(TXTasunto.Text.Trim(), TXBmensaje.Text.Trim(), _824_ecRemitente.Id, idDestinatario);
                            _824_ecNotificacionBLL.Guardar_824_ec(notificacion);

                            notificacionesEnviadas++;
                        }

                        // Registrar actividad
                        SessionManager.TraerInstancia().RegistrarActividad("Envío de notificación a " + notificacionesEnviadas +(notificacionesEnviadas == 1 ? " usuario." : " usuarios."));

                        // Informar resultado
                        MessageBox.Show($"Se enviaron correctamente {notificacionesEnviadas} " +
                            (notificacionesEnviadas == 1 ? "notificación." : "notificaciones."), "Envío exitoso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information
                        );

                        this.Close();
                        break;


                    case Constantes.TiposOperacion.Baja:

                        DialogResult confirmacionBaja = MessageBox.Show(
                            "¿Está seguro de que desea eliminar esta notificación?",
                            "Confirmar eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (confirmacionBaja == DialogResult.No)
                            return;

                        _824_ecNotificacionBLL.Eliminar_824_ec(
                            _824_ecNotificacionEditable.Id_824_ec
                        );

                        SessionManager.TraerInstancia().RegistrarActividad(
                            "Eliminación de notificación ID: " +
                            _824_ecNotificacionEditable.Id_824_ec
                        );

                        MessageBox.Show(
                            "La notificación fue eliminada correctamente.",
                            "Eliminación exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        this.Close();
                        break;


                    case Constantes.TiposOperacion.DeSesion:
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTNcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion botones

    }
}
