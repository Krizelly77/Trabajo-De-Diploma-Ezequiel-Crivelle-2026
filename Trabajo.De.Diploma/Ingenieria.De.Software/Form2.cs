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
    public partial class Form2 : Form, IObservadorDeIdioma
    {
        public Form PadreLogin { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            GestorDeIdioma.TraerInstancia().Suscribir(this);
            ActualizarIdioma(GestorDeIdioma.TraerInstancia().ObtenerTextos());

            var usuarioActivo = SessionManager.TraerInstancia().usuarioINS;
            LBLnombre.Text = usuarioActivo.NombreUsuario;
            AplicarPermisos(usuarioActivo);
        }

        public void ActualizarIdioma(Dictionary<string, string> textos)
        {
            var usuarioActivo = SessionManager.TraerInstancia().usuarioINS;
            this.Text             = $"{textos["menu_bienvenido"]}: {usuarioActivo?.NombreUsuario}";
            BTNgestUsuarios.Text  = textos["menu_usuarios"];
            BTNbitacora.Text      = textos["menu_bitacora"];
            BTNgestRolesPerm.Text = textos["menu_roles"];
            BTNcerrar.Text        = textos["menu_cerrar"];
            BTNidioma.Text        = textos["menu_idioma"];
        }

        private void AplicarPermisos(Usuario usuario)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.Tag != null)
                    c.Enabled = usuario.TienePermiso(c.Tag.ToString());
            }
        }
        //botones
        #region botones
        private void BTNcerrar_Click(object sender, EventArgs e)
        {
            try
            {
                SessionManager.TraerInstancia().Logout();

                if (PadreLogin != null)
                {
                    PadreLogin.Show();
                }
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion botones

        //eventos de formulario
        #region formularios
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorDeIdioma.TraerInstancia().Desuscribir(this);

            if (SessionManager.TraerInstancia().usuarioINS != null)
            {
                SessionManager.TraerInstancia().Logout();
            }

            if (this.PadreLogin != null)
            {
                this.PadreLogin.Show();
            }
        }
        private void BTNgestUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                FormGestionUsuarios Fgestusu = new FormGestionUsuarios();
                Fgestusu.PadredelPadreLogin = this;
                Fgestusu.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BTNbitacora_Click(object sender, EventArgs e)
        {
            try
            {
                FormBitacora fBitacora = new FormBitacora();
                fBitacora.ShowDialog(this);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BTNgestRolesPerm_Click(object sender, EventArgs e)
        {
            try
            {
                FormPermisosRoles Fperrol = new FormPermisosRoles();
                Fperrol.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BTNidioma_Click(object sender, EventArgs e)
        {
            try
            {
                FormIdioma fIdioma = new FormIdioma();
                fIdioma.ShowDialog(this);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion formularios
    }
}
