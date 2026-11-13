using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
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
    public partial class _824_ecFormNotificaciones : Form
    {
        private List<_824_ecNotificacion> Notis_824_ec;

        public Usuario UsuarioAnalizado;

        public _824_ecFormNotificaciones()
        {
            InitializeComponent();
        }
        // carga inicial
        private void _824_ecFormNotificaciones_Load(object sender, EventArgs e)
        {
            if (UsuarioAnalizado != null)
            {
                FiltroFecha.Value = DateTime.Now.Date;
                CargarGrilla_824_ec();
                cargarLista();
            }
            else
            {
                MessageBox.Show("No se encontró el usuario seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void cargarLista()
        {
            Notis_824_ec = _824_ecNotificacionBLL.ListarPorDestinatario_824_ec(UsuarioAnalizado.Id);
            CargarLabels();
            Actualizar_824_ec();
        }

        private void CargarLabels()
        {
            string seleccionPrevia = CMBfiltroUsuarios.SelectedItem?.ToString() ?? "Todos";

            CMBfiltroUsuarios.Items.Clear();
            CMBfiltroUsuarios.Items.Add("Todos");

            var remitentes = Notis_824_ec
               .Select(n => n.IdRemitente_824_ec)
               .Distinct()
               .Select(id => UsuarioBLL.ObtenerPorId(id))
               .Where(u => u != null)
               .OrderBy(u => u.NombreUsuario)
               .ToList();

            foreach (var usuario in remitentes)
            {
                CMBfiltroUsuarios.Items.Add(usuario.NombreUsuario);
            }

            if (CMBfiltroUsuarios.Items.Contains(seleccionPrevia))
                CMBfiltroUsuarios.SelectedItem = seleccionPrevia;
            else
                CMBfiltroUsuarios.SelectedIndex = 0;

            LBLcantidadNotis.Text = "Cantidad de notificaciones: " + Notis_824_ec.Count;
            LBLnotSinLeer.Text = "Sin Leer: " + Notis_824_ec.Count(u => !u.Leida_824_ec);
        }
        private void CargarGrilla_824_ec()
        {
            DGVNotificaciones.Columns.Clear();

            DGVNotificaciones.Columns.Add("Id", "Id");
            DGVNotificaciones.Columns["Id"].Visible = false;

            DataGridViewCheckBoxColumn columnaActivo = new DataGridViewCheckBoxColumn();
            columnaActivo.Name = "Leido";
            columnaActivo.HeaderText = "Leído";
            DGVNotificaciones.Columns.Add(columnaActivo);
            DGVNotificaciones.Columns["Leido"].Width = 60;

            DGVNotificaciones.Columns.Add("Remitente", "Gestor / Remitente");
            DGVNotificaciones.Columns["Remitente"].Width = 110;

            DGVNotificaciones.Columns.Add("Participante", "Participante / Grupo");
            DGVNotificaciones.Columns["Participante"].Width = 170;

            DGVNotificaciones.Columns.Add("Asunto", "Asunto");
            DGVNotificaciones.Columns["Asunto"].Width = 180;

            DGVNotificaciones.Columns.Add("Fecha", "Fecha");
            DGVNotificaciones.Columns["Fecha"].Width = 110;

            DGVNotificaciones.AllowUserToAddRows = false;
            DGVNotificaciones.AllowUserToDeleteRows = false;
            DGVNotificaciones.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVNotificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVNotificaciones.MultiSelect = false;
            DGVNotificaciones.RowHeadersVisible = false;
        }

        private void Actualizar_824_ec()
        {
            if (DGVNotificaciones.Columns.Count == 0 || Notis_824_ec == null) return;

            DGVNotificaciones.Rows.Clear();

            List<_824_ecNotificacion> not;

            if (CMBfiltroUsuarios.SelectedItem == null || CMBfiltroUsuarios.SelectedItem.ToString() == "Todos")
            {
                not = Notis_824_ec;
            }
            else
            {
                string nombreUsuario = CMBfiltroUsuarios.SelectedItem.ToString();

                Usuario remitente = Notis_824_ec
                    .Select(n => UsuarioBLL.ObtenerPorId(n.IdRemitente_824_ec))
                    .FirstOrDefault(u => u != null && u.NombreUsuario == nombreUsuario);

                not = remitente == null
                    ? new List<_824_ecNotificacion>()
                    : Notis_824_ec
                        .Where(n => n.IdRemitente_824_ec == remitente.Id)
                        .ToList();
            }

            if (not == null || not.Count == 0)
                return;

            DateTime fechaLimite = FiltroFecha.Value.Date;

            var filtradas = not.Where(n => n.Fecha_824_ec.Date >= fechaLimite);

            foreach (var nost in filtradas)
            {
                Usuario usuarioRemitente = UsuarioBLL.ObtenerPorId(nost.IdRemitente_824_ec);
                string infoParticipantes = ObtenerResumenParticipantes_824_ec(nost);

                DGVNotificaciones.Rows.Add(
                    nost.Id_824_ec,
                    nost.Leida_824_ec,
                    usuarioRemitente?.NombreUsuario ?? "Desconocido",
                    infoParticipantes,
                    nost.Asunto_824_ec,
                    nost.Fecha_824_ec
                );
            }
        }

        private string ObtenerResumenParticipantes_824_ec(_824_ecNotificacion notif)
        {
            if (notif.ParticipantesAgrupados != null && notif.ParticipantesAgrupados.Count > 0)
            {
                var apellidos = notif.ParticipantesAgrupados.Select(p => p.Apellido_824_ec);
                return $"Grupo ({notif.ParticipantesAgrupados.Count}): {string.Join(", ", apellidos)}";
            }
            if (notif.Participante_824_ec != null)
            {
                return $"{notif.Participante_824_ec.Apellido_824_ec}, {notif.Participante_824_ec.Nombre_824_ec} ({notif.Participante_824_ec.Documento_824_ec})";
            }
            return "Sistema / Interno";
        }

        // Eventos de otros controles
        private void FiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            Actualizar_824_ec();
        }

        private void CMBfiltroUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar_824_ec();
        }


        // Botones e interacciones
        #region Botones e interacciones
        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVNotificaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idNotificacion = Convert.ToInt32(DGVNotificaciones.Rows[e.RowIndex].Cells["Id"].Value);

            _824_ecNotificacion notificacion = Notis_824_ec.FirstOrDefault(n => n.Id_824_ec == idNotificacion);

            if (notificacion == null) return;

            // Construir detalle completo del mensaje + participantes involucrados
            string cuerpoCompleto = notificacion.Mensaje_824_ec;

            if (notificacion.ParticipantesAgrupados != null && notificacion.ParticipantesAgrupados.Count > 0)
            {
                cuerpoCompleto += "\n\n--- INTEGRANTES DEL GRUPO ---\n";
                foreach (var p in notificacion.ParticipantesAgrupados)
                {
                    cuerpoCompleto += $"• {p.Apellido_824_ec}, {p.Nombre_824_ec} (DNI: {p.Documento_824_ec})\n";
                }
            }
            else if (notificacion.Participante_824_ec != null)
            {
                cuerpoCompleto += $"\n\n--- PARTICIPANTE INVOLUCRADO ---\n" +
                                  $"• {notificacion.Participante_824_ec.Apellido_824_ec}, {notificacion.Participante_824_ec.Nombre_824_ec} (DNI: {notificacion.Participante_824_ec.Documento_824_ec})";
            }

            MessageBox.Show(
                cuerpoCompleto,
                notificacion.Asunto_824_ec,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (!notificacion.Leida_824_ec)
            {
                _824_ecNotificacionBLL.MarcarComoLeida_824_ec(idNotificacion);
                cargarLista();
            }
        }
        #endregion Botones e interacciones
    }
}
