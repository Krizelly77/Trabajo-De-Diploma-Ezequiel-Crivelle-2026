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
    public partial class FormUsuarioABM : Form
    {
        internal Constantes.TiposOperacion TipoOperacion { get; set; }
        internal Usuario UsuarioEditable { get; set; }
        public FormUsuarioABM()
        {
            InitializeComponent();
        }

        private void FormUsuarioABM_Load(object sender, EventArgs e)
        {
            CMBpermisos.Items.Add("Administrador");
            CMBpermisos.Items.Add("Usuario Generico");
            CargarABM();
        }
        // inicializar formulario
        #region cargar
        private void CargarABM()
        {
            switch (TipoOperacion)
            {
                case Constantes.TiposOperacion.Alta:
                    LimpiarCampos();
                    LBLusuario.Text = "Crear Nuevo Usuario";
                    CHKcontra.Checked = true;
                    CHKcontra.Enabled = false;

                    break;
                case Constantes.TiposOperacion.Modificacion:
                    if (UsuarioEditable == null)
                    {
                        MessageBox.Show("No se ha especificado el Usuario a modificar");
                        this.Close();
                    }
                    CargarCampos(UsuarioEditable);
                    LBLusuario.Text = "Modificación de Usuario";
                    break;
                case Constantes.TiposOperacion.Baja:
                    if (UsuarioEditable == null)
                    {
                        MessageBox.Show("No se ha especificado el Usuario a eliminar");
                        this.Close();
                    }
                    CargarCampos(UsuarioEditable);
                    DeshabilitarCampos();
                    LBLusuario.Text = "NO ES RECOMENDABLE ELIMINAR ";
                    PNLtitulo.BackColor = Color.Red;
                    BTNconfirmar.Text = "Eliminar";
                    break;
            }
        }

        private void LimpiarCampos()
        {
            TXTnomcon.Text = "";
            TXTnomusu.Text = "";
        }

        private void DeshabilitarCampos()
        {
            TXTnomcon.Enabled = false;
            TXTnomusu.Enabled = false;
            CHKactivo.Enabled = false;
            CHKcontra.Enabled = false;
            CMBpermisos.Enabled = false;
            CHKbloqueoDV.Enabled = false;

        }

        private void CargarCampos(Usuario usua)
        {
            TXTnomusu.Text = usua.NombreUsuario;
            TXTnomcon.Text = "";
            CHKactivo.Checked = usua.Activo;

            // Mapeamos el estado del flag individual a la pantalla
            CHKbloqueoDV.Checked = usua.BloqueoDV;

            switch (usua.NivelPermisos)
            {
                case 1: CMBpermisos.SelectedItem = "Administrador"; break;
                case 2: CMBpermisos.SelectedItem = "Usuario Generico"; break;
            }
        }
        #endregion cargar

        //logica de botones
        #region botones
        private void ValorizarEntidad(Usuario usua)
        {
            usua.NombreUsuario = TXTnomusu.Text;
            if (CHKcontra.Checked == true)
                usua.Contraseña = TXTnomcon.Text;

            switch (CMBpermisos.SelectedIndex)
            {
                case 0: usua.NivelPermisos = 1; break;
                case 1: usua.NivelPermisos = 2; break;
                default: usua.NivelPermisos = 0; break;
            }

            usua.Activo = CHKactivo.Checked;
            usua.BloqueoDV = CHKbloqueoDV.Checked;
        }

        private void BTNconfirmar_Click(object sender, EventArgs e)
        {
            if (CMBpermisos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un nivel de permisos válido para el usuario");
                return;
            }
            try
            {
                UsuarioBLL persistidor = new UsuarioBLL();
                switch (TipoOperacion)
                {
                    case Constantes.TiposOperacion.Alta:
                        if (UsuarioEditable == null)
                            UsuarioEditable = new Usuario(0); //0 indica que debe ser creado
                        ValorizarEntidad(UsuarioEditable);
                        persistidor.Guardar(UsuarioEditable);
                        SessionManager.TraerInstancia().RegistrarActividad("Alta de usuario: " + UsuarioEditable.NombreUsuario);
                        this.Close();
                        break;
                    case Constantes.TiposOperacion.Modificacion:
                        ValorizarEntidad(UsuarioEditable);
                        persistidor.Guardar(UsuarioEditable);
                        SessionManager.TraerInstancia().RegistrarActividad("Modificacion de usuario: " + UsuarioEditable.NombreUsuario);
                        this.Close();
                        break;
                    case Constantes.TiposOperacion.Baja:
                        SessionManager sm = SessionManager.TraerInstancia();
                        if (sm.usuarioINS.Id != UsuarioEditable.Id)
                        {
                            persistidor.Eliminar(UsuarioEditable);
                            sm.RegistrarActividad("Baja de usuario: " + UsuarioEditable.NombreUsuario);
                            this.Close();
                        }
                        else
                            MessageBox.Show("No se puede eliminar permanentemente a uno mismo, pruebe desactivar su cuenta");
                        break;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTNcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion botones

        // eventos de controles
        #region eventos para controles
        private void TXTnomusu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TXTnomcon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void CHKcontra_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKcontra.Checked == false)
            {
                TXTnomcon.Enabled = false;
                CHKmostrar.Visible = false;
                CHKmostrar.Enabled = false;
            }
            else
            {
                TXTnomcon.Enabled = true;
                CHKmostrar.Visible = true;
                CHKmostrar.Enabled = true;
            }
        }
        private void CHKmostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKmostrar.Checked == false)
                TXTnomcon.UseSystemPasswordChar = true;
            else
                TXTnomcon.UseSystemPasswordChar = false;
        }
        #endregion eventos para controles

    }
}
