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
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Ingenieria.De.Software
{
    public partial class _824_ecFormMostarListaActividades : Form
    {
        private List<_824_ecPostulacion> Posts_824_ec;
        private List<_824_ecPostulacion> Posts_824_ecSinFiltro;
        internal Usuario UsuarioAnalizado;
        internal _824_ecParticipante ParticipanteAnalizado;

        public _824_ecFormMostarListaActividades()
        {
            InitializeComponent();
        }

        private void _824_ecFormMostarListaActividades_Load(object sender, EventArgs e)
        {
            if (ParticipanteAnalizado != null)
            {
                Posts_824_ecSinFiltro = _824_ecPostulacionBLL.ListarPorParticipante_824_ec(ParticipanteAnalizado.Id_824_ec)
                    ?? new List<_824_ecPostulacion>();

                // Filtrar las completadas 
                Posts_824_ec = Posts_824_ecSinFiltro
                    .Where(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado &&
                                p.Actividad_824_ec != null &&
                                p.Actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Completado)
                    .ToList();

                LBLnombre.Text = $"{ParticipanteAnalizado.Apellido_824_ec}, {ParticipanteAnalizado.Nombre_824_ec}";

                ConfigurarControlesIniciales_824_ec();
                CargarRatio();
                CargarGrilla_824_ec();
            }
            else if (UsuarioAnalizado != null)
            {
                Posts_824_ecSinFiltro = _824_ecPostulacionBLL.ListarActividadPorCandidato_824_ec(UsuarioAnalizado.Id)
                    ?? new List<_824_ecPostulacion>();

                Posts_824_ec = UsuarioAnalizado.HistorialParticipaciones ?? new List<_824_ecPostulacion>();

                LBLnombre.Text = UsuarioAnalizado.NombreUsuario;

                ConfigurarControlesIniciales_824_ec();
                CargarRatio();
                CargarGrilla_824_ec();
            }
            else
            {
                MessageBox.Show("No se encontró el participante o usuario seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        // carga inicial
        private void ConfigurarControlesIniciales_824_ec()
        {
            // Arrancar desde la fecha más antigua del historial para mostrar toda la experiencia previa
            if (Posts_824_ecSinFiltro != null && Posts_824_ecSinFiltro.Any(p => p.Actividad_824_ec != null))
            {
                DateTime fechaMinima = Posts_824_ecSinFiltro
                    .Where(p => p.Actividad_824_ec != null)
                    .Min(p => p.Actividad_824_ec.FechaHora_824_ec.Date);

                FiltroFecha.Value = fechaMinima < FiltroFecha.MinDate ? FiltroFecha.MinDate : fechaMinima;
            }
            else
            {
                FiltroFecha.Value = DateTime.Now.AddYears(-1).Date;
            }

            CMBfiltroActividades.Items.Clear();
            CMBfiltroActividades.Items.Add("Completados");
            CMBfiltroActividades.Items.Add("Todos");
            CMBfiltroActividades.SelectedIndex = 0;
        }

        private void CargarRatio()
        {
            int completados = Posts_824_ec?.Count ?? 0;
            int totales = Posts_824_ecSinFiltro?.Count ?? 0;
            LBLratio.Text = $"Completó: {completados} de {totales} Postulaciones";
        }

        private void CargarGrilla_824_ec()
        {
            DGVactividades.Columns.Clear();

            DGVactividades.Columns.Add("Id", "Id");
            DGVactividades.Columns["Id"].Visible = false;

            DGVactividades.Columns.Add("Nombre", "Actividad");
            DGVactividades.Columns["Nombre"].Width = 130;

            DGVactividades.Columns.Add("Estado", "Estado Act.");
            DGVactividades.Columns["Estado"].Width = 90;

            DGVactividades.Columns.Add("Nivel", "Nivel");
            DGVactividades.Columns["Nivel"].Width = 85;

            DGVactividades.Columns.Add("EstadoPost", "Estado Post.");
            DGVactividades.Columns["EstadoPost"].Width = 90;

            DGVactividades.Columns.Add("Postulacion", "Fecha Post.");
            DGVactividades.Columns["Postulacion"].Width = 100;

            DGVactividades.Columns.Add("Realizacion", "Realización");
            DGVactividades.Columns["Realizacion"].Width = 100;

            DGVactividades.AllowUserToAddRows = false;
            DGVactividades.AllowUserToDeleteRows = false;
            DGVactividades.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVactividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVactividades.MultiSelect = false;
            DGVactividades.RowHeadersVisible = false;

            Actualizar_824_ec();
        }

        private void Actualizar_824_ec()
        {
            if (DGVactividades.Columns.Count == 0 || CMBfiltroActividades.SelectedItem == null) return;

            DGVactividades.Rows.Clear();

            List<_824_ecPostulacion> pos = CMBfiltroActividades.SelectedItem.ToString() == "Todos"
                ? Posts_824_ecSinFiltro
                : Posts_824_ec;

            if (pos == null || pos.Count == 0) return;

            DateTime fechaLimite = FiltroFecha.Value.Date;

            var filtradas = pos.Where(p => p.Actividad_824_ec != null && p.Actividad_824_ec.FechaHora_824_ec.Date >= fechaLimite);

            foreach (var post in filtradas)
            {
                DGVactividades.Rows.Add(
                    post.Id_824_ec,
                    post.Actividad_824_ec.Nombre_824_ec,
                    post.Actividad_824_ec.Estado_824_ec.ToString(),
                    post.Actividad_824_ec.NivelRequerido_824_ec.ToString(),
                    post.Estado_824_ec.ToString(),
                    post.FechaPostulacion_824_ec.ToShortDateString(),
                    post.Actividad_824_ec.FechaHora_824_ec.ToShortDateString()
                );
            }
        }

        private void CMBfiltroActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar_824_ec();
        }

        private void FiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            Actualizar_824_ec();
        }

        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
