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

namespace Ingenieria.De.Software
{
    public partial class _824_ecABMparticipantesolicitante : Form
    {
        internal Constantes.TiposOperacion TipoOperacion { get; set; }
        internal _824_ecCliente ClienteEditable { get; set; }
        internal bool EsParticipante { get; set; }
        private string tipocliente = "";

        public _824_ecABMparticipantesolicitante()
        {
            InitializeComponent();
        }

        private void _824_ecABMparticipantesolicitante_Load(object sender, EventArgs e)
        {
            if (EsParticipante)
            {
                tipocliente = "Participante";
            }else
            {
                tipocliente = "Solicitante";

            }
            CargarABM();
        }

        // inicializar formulario
        #region cargar
        private void CargarABM()
        {
            if (!EsParticipante)
            {
                TXTclave.Enabled = false;
                TXTclave.Visible = false;
                LBLclave.Visible = false;
            }


            switch (TipoOperacion)
            {
                case Constantes.TiposOperacion.Alta:
                    LimpiarCampos();
                    LBLtitulo.Text = "Alta de "+ tipocliente;
                    TXTid.Visible = false;
                    DTFechaAlta.Visible = false;
                    LBLfecha.Visible = false;
                    LBLid.Visible = false;

                    break;

                case Constantes.TiposOperacion.Modificacion:
                    if (ClienteEditable == null)
                    {
                        MessageBox.Show("No se ha especificado el cliente a modificar");
                        this.Close();
                    }
                    CargarCampos(ClienteEditable);
                    LBLtitulo.Text = "Modificacion de " + tipocliente;
                    BTNrestablecerCampos.Visible = true;
                    BTNrestablecerCampos.Enabled = true;

                    break;

                case Constantes.TiposOperacion.Baja:
                    if (ClienteEditable == null)
                    {
                        MessageBox.Show("No se ha especificado el cliente a eliminar");
                        this.Close();
                    }
                    CargarCampos(ClienteEditable);
                    DeshabilitarCampos();
                    LBLtitulo.Text = "NO ES RECOMENDABLE";
                    PNLtitulo.BackColor = Color.Red;
                    BTNconfirmar.Text = "Eliminar";
                    break;

                case Constantes.TiposOperacion.DeSesion:
                    CargarCampos(ClienteEditable);
                    DeshabilitarCampos();
                    LBLtitulo.Text = "Ver " + tipocliente;
                    BTNconfirmar.Visible = false;
                    break;
            }
        }

        private void LimpiarCampos()
        {
            TXTnombre.Text = "";
            TXTapellido.Text = "";
            TXTdocumento.Text = "";
            TXTtelefono.Text = "";
            TXTcorreoele.Text = "";
            TXTclave.Text = "";
            CHKactivo.Checked = true;
            DTFechaAlta.Value = DateTime.Today;
            TXTid.Text = "0";
        }
        private void DeshabilitarCampos()
        {
            TXTnombre.Enabled = false;
            TXTapellido.Enabled = false;
            TXTdocumento.Enabled = false;
            TXTtelefono.Enabled = false;
            TXTcorreoele.Enabled = false;
            TXTclave.Enabled = false;
            CHKactivo.Enabled = false;
            DTFechaAlta.Enabled = false;
            TXTid.Enabled = false;
        }
        private void CargarCampos(_824_ecCliente clie)
        {
            if (clie == null) return;

            TXTnombre.Text = clie.Nombre_824_ec;
            TXTapellido.Text = clie.Apellido_824_ec;
            TXTdocumento.Text = clie.Documento_824_ec;
            TXTtelefono.Text = clie.NumeroDeTelefono_824_ec;
            TXTcorreoele.Text = clie.CorreoElectronico;
            CHKactivo.Checked = clie.Activo_824_ec;
            TXTid.Text = clie.Id_824_ec.ToString();

            if (EsParticipante && clie is _824_ecParticipante part)
            {
                DTFechaAlta.Value = part.FechaDeAlta != default(DateTime) ? part.FechaDeAlta : DateTime.Today;
                TXTclave.Text = part.PalabraClave_824_ec ?? "";
            }
            else if (!EsParticipante && clie is _824_ecSolicitante sol)
            {
                DTFechaAlta.Value = sol.FechaDeAlta != default(DateTime) ? sol.FechaDeAlta : DateTime.Today;
                TXTclave.Text = "";
            }

        }
        #endregion cargar

        //logica de botones
        #region botones
        private void ValorizarEntidad(_824_ecCliente clie)
        {
            clie.Nombre_824_ec = TXTnombre.Text.Trim();
            clie.Apellido_824_ec = TXTapellido.Text.Trim();
            clie.Documento_824_ec = TXTdocumento.Text.Trim();
            clie.NumeroDeTelefono_824_ec = TXTtelefono.Text.Trim();
            clie.CorreoElectronico = TXTcorreoele.Text.Trim();
            clie.Activo_824_ec = CHKactivo.Checked;

            if (EsParticipante && clie is _824_ecParticipante part)
            {
                part.PalabraClave_824_ec = TXTclave.Text.Trim();
                part.FechaDeAlta = DTFechaAlta.Value;
            }
            else if (!EsParticipante && clie is _824_ecSolicitante sol)
            {
                sol.FechaDeAlta = DTFechaAlta.Value;
            }

        }

        private void BTNconfirmar_Click_1(object sender, EventArgs e)
        {
            try
            {
                switch (TipoOperacion)
                {
                    case Constantes.TiposOperacion.Alta:
                        if (EsParticipante)
                            ClienteEditable = new _824_ecParticipante(0);
                        else
                            ClienteEditable = new _824_ecSolicitante(0);

                        ValorizarEntidad(ClienteEditable);

                        if (EsParticipante)
                            _824_ecParticipanteBLL.Guardar_824_ec((_824_ecParticipante)ClienteEditable);
                        else
                            _824_ecSolicitanteBLL.Guardar_824_ec((_824_ecSolicitante)ClienteEditable);

                        SessionManager.TraerInstancia().RegistrarActividad("Alta de " + tipocliente + ": " + ClienteEditable.Nombre_824_ec);
                        MessageBox.Show(tipocliente + " registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case Constantes.TiposOperacion.Modificacion:
                        ValorizarEntidad(ClienteEditable);

                        if (EsParticipante)
                            _824_ecParticipanteBLL.Guardar_824_ec((_824_ecParticipante)ClienteEditable);
                        else
                            _824_ecSolicitanteBLL.Guardar_824_ec((_824_ecSolicitante)ClienteEditable);

                        SessionManager.TraerInstancia().RegistrarActividad("Modificacion de " + tipocliente + ": " + ClienteEditable.Nombre_824_ec);
                        MessageBox.Show(tipocliente + " modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case Constantes.TiposOperacion.Baja:
                        if (EsParticipante)
                            _824_ecParticipanteBLL.Eliminar_824_ec((_824_ecParticipante)ClienteEditable);
                        else
                            _824_ecSolicitanteBLL.Eliminar_824_ec((_824_ecSolicitante)ClienteEditable);

                        SessionManager.TraerInstancia().RegistrarActividad("Baja de " + tipocliente + ": " + ClienteEditable.Nombre_824_ec);
                        MessageBox.Show(tipocliente + " eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNcancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void BTNrestablecerCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (ClienteEditable != null)
                CargarCampos(ClienteEditable);
        }
        #endregion botones

        // eventos de controles
        #region eventos para controles
        private void TXTnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTdocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTtelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TXTclave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CHKmostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKmostrar.Checked == false)
                TXTclave.UseSystemPasswordChar = true;
            else
                TXTclave.UseSystemPasswordChar = false;
        }
        #endregion eventos para controles

    }
}
