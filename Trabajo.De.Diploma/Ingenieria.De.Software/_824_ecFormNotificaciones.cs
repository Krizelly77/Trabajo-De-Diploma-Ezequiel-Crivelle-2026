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

        private void _824_ecFormNotificaciones_Load(object sender, EventArgs e)
        {
            if (UsuarioAnalizado != null)
            {
                FiltroFecha.Value = DateTime.Now;
                CMBfiltroUsuarios.Items.Clear();
                CMBfiltroUsuarios.Items.Add("Todos");
                CMBfiltroUsuarios.SelectedIndex = 0;
                cargarLista();
                CargarGrilla_824_ec();
            }
            else
            {
                MessageBox.Show("No se encontro el usuario seleccionado");
                this.Close();
            }
        }
        private void cargarLista()
        {
            Notis_824_ec = _824_ecNotificacionBLL.ListarPorDestinatario_824_ec(UsuarioAnalizado.Id);
            CargarLabels();
            Actualizar_824_ec();
        }

        private void CargarGrilla_824_ec()
        {
            DGVNotificaciones.Columns.Add("Id", "Id");
            DGVNotificaciones.Columns["Id"].Visible = false;

            DataGridViewCheckBoxColumn columnaActivo = new DataGridViewCheckBoxColumn();
            columnaActivo.Name = "Leido";
            columnaActivo.HeaderText = "Leido";
            DGVNotificaciones.Columns.Add(columnaActivo);
            DGVNotificaciones.Columns["Leido"].Width = 100;

            DGVNotificaciones.Columns.Add("Remitente", "Remitente");
            DGVNotificaciones.Columns["Remitente"].Width = 100;

            DGVNotificaciones.Columns.Add("Asunto", "Asunto");
            DGVNotificaciones.Columns["Asunto"].Width = 200;

            DGVNotificaciones.Columns.Add("Fecha", "Fecha");
            DGVNotificaciones.Columns["Fecha"].Width = 100;


            DGVNotificaciones.AllowUserToAddRows = false;
            DGVNotificaciones.AllowUserToDeleteRows = false;
            DGVNotificaciones.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVNotificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVNotificaciones.MultiSelect = false;
            DGVNotificaciones.RowHeadersVisible = false;

            Actualizar_824_ec();
        }

        private void Actualizar_824_ec()
        {
            if (DGVNotificaciones.Columns.Count == 0) return;

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

            var filtradas = not.Where(n => n.Fecha_824_ec >= fechaLimite);

            foreach (var nost in filtradas)
            {
                Usuario usuarioRemitente =
                    UsuarioBLL.ObtenerPorId(nost.IdRemitente_824_ec);

                DGVNotificaciones.Rows.Add(
                    nost.Id_824_ec,
                    nost.Leida_824_ec,
                    usuarioRemitente?.NombreUsuario ?? "Desconocido",
                    nost.Asunto_824_ec,
                    nost.Fecha_824_ec
                );
            }
        }

        private void CargarLabels()
        {
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

            LBLcantidadNotis.Text = "Cantidad de notificaciones: " + Notis_824_ec.Count();
            LBLnotSinLeer.Text = "Sin Leer: " + Notis_824_ec.Where(u  => !u.Leida_824_ec).Count();
        }

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

            int idNotificacion = Convert.ToInt32( DGVNotificaciones.Rows[e.RowIndex].Cells["Id"].Value);

            _824_ecNotificacion notificacion = Notis_824_ec.FirstOrDefault(n => n.Id_824_ec == idNotificacion);

            if (notificacion == null) return;

            MessageBox.Show(
                notificacion.Mensaje_824_ec,
                notificacion.Asunto_824_ec,
                MessageBoxButtons.OK
            );
            if(!notificacion.Leida_824_ec)
                _824_ecNotificacionBLL.MarcarComoLeida_824_ec(idNotificacion);
            cargarLista();
        }
        #endregion Botones e interacciones
    }
}
