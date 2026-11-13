using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingenieria.De.Software
{
    public partial class _824_ecNotificacionPersonalizada : Form
    {
        internal _824_ecActividad actividadNotificada;
        internal Usuario remitenteoNotifcado;
        internal int indiceActualMultiple = 0; // Ej: 1, 2, 3... (0 si no es múltiple)
        internal int totalMultiple = 0;        // Ej: total de postulaciones en el lote
        internal bool esGrupal = false;        // True solo cuando viene de RBTtipoPost3 (Grupal)

        internal List<_824_ecParticipante> Participante0s { get; set; } = new List<_824_ecParticipante>();

        private bool _notificacionEnviada = false;


        public _824_ecNotificacionPersonalizada()
        {
            InitializeComponent();
        }
        // carga inicial
        private void _824_ecNotificacionPersonalizada_Load(object sender, EventArgs e)
        {
            remitenteoNotifcado = SessionManager.TraerInstancia().usuarioINS;
            if (remitenteoNotifcado == null || actividadNotificada == null || actividadNotificada.Organizador_824_ec == null)
            {
                MessageBox.Show("El mensaje debe tener un remitente, una actividad y un destinatario válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LBLremiDesti.Text = $"De {remitenteoNotifcado.NombreUsuario} para {actividadNotificada.Organizador_824_ec.NombreUsuario}";

            if (totalMultiple > 1 && indiceActualMultiple > 0)
            {
                var partActual = Participante0s.FirstOrDefault();
                LBLpostMultiple.Visible = true;
                LBLpostMultiple.Text = $"Postulación {indiceActualMultiple} de {totalMultiple} ({partActual?.Apellido_824_ec})";
            }
            else if (esGrupal)
            {
                LBLpostMultiple.Visible = true;
                LBLpostMultiple.Text = $"Postulación Grupal ({Participante0s.Count} integrantes)";
            }
            else
            {
                LBLpostMultiple.Visible = false;
            }
        }

        // botones
        private void BTNenviarNotdef_Click(object sender, EventArgs e)
        {
            try
            {
                string mensajeAutomatico = ConstruirMensajePredeterminado_824_ec();
                RegistrarNotificacion_824_ec(mensajeAutomatico);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTNenviarNotper_Click(object sender, EventArgs e)
        {
            try
            {
                string mensajePersonalizado = TXBmensaje.Text.Trim();
                if (string.IsNullOrWhiteSpace(mensajePersonalizado))
                {
                    MessageBox.Show("Debe escribir un mensaje o presionar el botón de notificación predeterminada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RegistrarNotificacion_824_ec(mensajePersonalizado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // metodos de apoyo
        private string ConstruirMensajePredeterminado_824_ec()
        {
            if (esGrupal && Participante0s.Count > 1)
            {
                string integrantes = string.Join(", ", Participante0s.Select(p => $"{p.Apellido_824_ec} {p.Nombre_824_ec}"));
                return $"El gestor {remitenteoNotifcado.NombreUsuario} postuló a un grupo conformado por: {integrantes}, para la actividad {actividadNotificada.Nombre_824_ec} el día {actividadNotificada.FechaHora_824_ec}.";
            }
            else
            {
                var par = Participante0s.First();
                return $"El gestor {remitenteoNotifcado.NombreUsuario} postuló a {par.Nombre_824_ec} {par.Apellido_824_ec} (DNI: {par.Documento_824_ec}) para la actividad {actividadNotificada.Nombre_824_ec} el día {actividadNotificada.FechaHora_824_ec}.";
            }
        }
        private void RegistrarNotificacion_824_ec(string textoMensaje)
        {
            if (esGrupal && Participante0s.Count > 1)
            {
                _824_ecNotificacionBLL.Guardar_824_ec(
                    new _824_ecNotificacion(
                        "Nueva Postulación Grupal",
                        textoMensaje,
                        remitenteoNotifcado.Id,
                        actividadNotificada.Organizador_824_ec.Id,
                        participantesAgrupados: Participante0s
                    ));
            }
            else
            {
                _824_ecNotificacionBLL.Guardar_824_ec(
                    new _824_ecNotificacion(
                        "Nueva Postulación",
                        textoMensaje,
                        remitenteoNotifcado.Id,
                        actividadNotificada.Organizador_824_ec.Id,
                        participante: Participante0s.First()
                    ));
            }

            _notificacionEnviada = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // para evitar que si el usuario sale con x no se envie la norificacion
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_notificacionEnviada && remitenteoNotifcado != null && actividadNotificada?.Organizador_824_ec != null && Participante0s.Count > 0)
            {
                try
                {
                    RegistrarNotificacion_824_ec(ConstruirMensajePredeterminado_824_ec());
                }
                catch { /* Evitar bloqueo al cerrar */ }
            }
            base.OnFormClosing(e);
        }

    }
}
