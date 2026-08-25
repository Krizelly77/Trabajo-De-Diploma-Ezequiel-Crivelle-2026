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
using static Ingenieria.De.Software.Constantes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Ingenieria.De.Software
{
    public partial class Form1 : Form, IObservadorDeIdioma
    {
        private int intentos = 3;
        private bool bloqueo = false;
        private string _phUsuario = "USUARIO";
        private string _phContra = "CONTRASEÑA";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GestorDeIdioma.TraerInstancia().Suscribir(this);
            ActualizarIdioma(GestorDeIdioma.TraerInstancia().ObtenerTextos());
            LBLLoguin.Focus();
        }

        public void ActualizarIdioma(Dictionary<string, string> textos)
        {
            LBLLoguin.Text    = textos["login_titulo"];
            BTNingresar.Text  = textos["login_ingresar"];
            BTNcancel.Text    = textos["login_cancelar"];
            CHKcontra.Text    = textos["login_mostrar_contra"];

            if (TXTusua.Text  == _phUsuario) TXTusua.Text  = textos["login_usuario_placeholder"];
            if (TXTcontra.Text == _phContra)  TXTcontra.Text = textos["login_contra_placeholder"];
            _phUsuario = textos["login_usuario_placeholder"];
            _phContra  = textos["login_contra_placeholder"];
        }

        //controles
        #region eventos principales de los controles
        private void BTNingresar_Click(object sender, EventArgs e)
        {
            //para hacer pruebas Juan66, 123456 (admin); Maria01, miPerro ; Carlos22, contrasenia ; Ana77, reina2001 ; PedroX, elmascapo67 (admin)
            if (!bloqueo)
            {
                UsuarioBLL usabll = new UsuarioBLL();
                try
                {
                    ValidarItegridadDeLosDatos();
                    string devolucion = usabll.Login(TXTusua.Text, TXTcontra.Text);
                    switch (devolucion)
                    {
                        case "Exito":
                            Usuario usaLog = SessionManager.TraerInstancia().usuarioINS;
                            string fech = SessionManager.TraerInstancia().FechaDeInicio.ToString();
                            MessageBox.Show($"Ingreso Válido.\n\n bienvenido {usaLog.NombreUsuario}\n ");
                            SaltarAPantallaPrincipal(usabll);
                            break;
                        case "Contraseña invalida":
                            RestarIntento();
                            Mostrarexepcion(devolucion);
                            break;
                        case "El usuario no tiene una cuenta activa":
                            Mostrarexepcion(devolucion);
                            break;
                        case "El usuario esta bloqueado":
                            Mostrarexepcion(devolucion);
                            break;
                        default:
                            Mostrarexepcion("Error desconocido");
                            break;
                    }
                    
                }
                catch (Exception ex) { Mostrarexepcion(ex.Message); }
            }
            else { Mostrarexepcion("Espera a que termine el contador"); }
        }


        private void BTNcancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CHKcontra_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKcontra.Checked == false && TXTcontra.Text != _phContra)
                TXTcontra.UseSystemPasswordChar = true;
            else
                TXTcontra.UseSystemPasswordChar = false;
        }
        #endregion eventos principales de los controles

        //metodos de soporte
        #region metodos de soporte
        private void RestarIntento()
        {
            intentos--;
            LBLtimer.Text = $"le quedan {intentos} intentos";
            if (intentos <= 0)
                BloqueTemporaldelBoton();
        }
        private void BloqueTemporaldelBoton(int segundos = 30)
        {
            desabilitarboton();

            Timer timer = new Timer();
            timer.Interval = 1000;
            bloqueo = true;

            timer.Tick += (s, e) =>
            {
                segundos--;
                LBLtimer.Text = $"Esperá {segundos} segundos";

                if (segundos <= 0)
                {
                    timer.Stop();
                    reactivarbotones();
                    intentos = 3;
                    bloqueo = false;
                    LBLtimer.Text = "le quedan 3 intentos";
                }
            };
            timer.Start();
        }
        private void desabilitarboton()
        {
            BTNingresar.Enabled = false;
            BTNingresar.ForeColor = SystemColors.ActiveBorder;
            BTNingresar.BackColor = SystemColors.WindowFrame;
        }
        private void Mostrarexepcion(string exmen)
        {
            if(exmen.Length < 200)
                LBLerrores.Text = exmen;
            else
                MessageBox.Show(exmen);
            desabilitarboton();
        }
        private void reactivarbotones()
        {
            if (LBLerrores.Text != ". . .")
                LBLerrores.Text = ". . .";
            if (!BTNingresar.Enabled)
            {
                BTNingresar.Enabled = true;
                BTNingresar.ForeColor = SystemColors.WindowFrame;
                BTNingresar.BackColor = SystemColors.ActiveBorder;
            }
        }
        private void ValidarItegridadDeLosDatos()
        {
            DigitoVerificadorBLL integridadBll = new DigitoVerificadorBLL();
            string TodoIntegro = integridadBll.ValidarIntegridadDelSistema();

            if (TodoIntegro != "ok")
            {
                int cantidad = integridadBll.BloquearUsuariosPorFallaIntegridad();

                MessageBox.Show(
                    "La integridad de la base de datos fue comprometida. "+ cantidad + " han sido bloqueados. Por favor, llame a un administrador",
                    "ERROR CRÍTICO DE SEGURIDAD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
                Mostrarexepcion(TodoIntegro);
            }
        }
        #endregion metodos de soporte

        // metodos de formulario
        private void SaltarAPantallaPrincipal(UsuarioBLL musabll)
        {
            try
            {
                Form2 Fprinciapl = new Form2();
                Fprinciapl.PadreLogin = this;
                this.Hide();
                Fprinciapl.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // eventos de controles
        #region eventos para controles
        private void TXTusua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        private void TXTcontra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        #endregion eventos para controles

        //diseño de botones
        #region diseño de botones
        private void TXTusua_Enter(object sender, EventArgs e)
        {
            if (TXTusua.Text == _phUsuario)
            {
                TXTusua.Text = "";
                TXTusua.Font = new Font("Microsoft JhengHei", 12);
                TXTusua.Location = new Point(TXTusua.Location.X, TXTusua.Location.Y + 20);
            }
            reactivarbotones();
        }
        private void TXTusua_Leave(object sender, EventArgs e)
        {
            if (TXTusua.Text == "")
            {
                TXTusua.Text = _phUsuario;
                TXTusua.Font = new Font("Microsoft JhengHei", 22);
                TXTusua.Location = new Point(TXTusua.Location.X, TXTusua.Location.Y - 20);
            }
        }
        private void TXTcontra_Enter(object sender, EventArgs e)
        {
            if (TXTcontra.Text == _phContra)
            {
                TXTcontra.Text = "";
                if (!CHKcontra.Checked)
                {
                    TXTcontra.UseSystemPasswordChar = true;
                    TXTcontra.Font = new Font("Microsoft JhengHei", 12);
                }
                else { TXTcontra.Font = new Font("Microsoft JhengHei", 10); }
                TXTcontra.Location = new Point(TXTcontra.Location.X, TXTcontra.Location.Y + 20);
            }
            reactivarbotones();
        }
        private void TXTcontra_Leave(object sender, EventArgs e)
        {
            if (TXTcontra.Text == "")
            {
                TXTcontra.Text = _phContra;
                TXTcontra.UseSystemPasswordChar = false;
                TXTcontra.Font = new Font("Microsoft JhengHei", 22);
                TXTcontra.Location = new Point(TXTcontra.Location.X, TXTcontra.Location.Y - 20);
            }
        }

        #endregion diseño de botones

    }
}
