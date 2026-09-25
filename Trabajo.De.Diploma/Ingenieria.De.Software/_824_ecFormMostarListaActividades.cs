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
        public Usuario UsuarioAnalizado;

        public _824_ecFormMostarListaActividades()
        {
            InitializeComponent();
        }

        private void _824_ecFormMostarListaActividades_Load(object sender, EventArgs e)
        {
            if (UsuarioAnalizado != null)
            {
                FiltroFecha.Value = DateTime.Now;
                CMBfiltroActividades.Items.Clear();
                CMBfiltroActividades.Items.Add("Completados");
                CMBfiltroActividades.Items.Add("Todos");
                CMBfiltroActividades.SelectedIndex = 0;
                LBLnombre.Text = UsuarioAnalizado.NombreUsuario;
                Posts_824_ec = UsuarioAnalizado.HistorialParticipaciones;
                CargarRatio();
                CargarGrilla_824_ec();
            }
            else
            {
                MessageBox.Show("No se encontro el usuario seleccionado");
                this.Close();
            }
        }

        private void CargarRatio()
        {
            Posts_824_ecSinFiltro = _824_ecPostulacionBLL.ListarActividadPorCandidato_824_ec(UsuarioAnalizado.Id);
            LBLratio.Text = $"Completo: {Posts_824_ec.Count} de {Posts_824_ecSinFiltro.Count} Postulaciones";
        }

        private void CargarGrilla_824_ec()
        {
            DGVactividades.Columns.Add("Id", "Id");
            DGVactividades.Columns["Id"].Visible = false;

            DGVactividades.Columns.Add("Nombre", "Nombre");
            DGVactividades.Columns["Nombre"].Width = 100;

            DGVactividades.Columns.Add("Estado", "Estado");
            DGVactividades.Columns["Estado"].Width = 100;

            DGVactividades.Columns.Add("Nivel", "Nivel");
            DGVactividades.Columns["Nivel"].Width = 100;

            DGVactividades.Columns.Add("Postulacion", "Postulacion");
            DGVactividades.Columns["Postulacion"].Width = 100;

            DGVactividades.Columns.Add("Realizacion", "Realizacion");
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
            if (DGVactividades.Columns.Count == 0) return;
            
            DGVactividades.Rows.Clear();

            List<_824_ecPostulacion> pos;
            if (CMBfiltroActividades.SelectedItem.ToString() == "Todos")
                pos = Posts_824_ecSinFiltro; 
            else
                pos = Posts_824_ec;

            if (pos == null || pos.Count == 0)
            {
                return;
            }

            DateTime fechaLimite = FiltroFecha.Value.Date;

            var filtradas = pos.Where(p =>
                p.Actividad_824_ec.FechaHora_824_ec.Date <= fechaLimite);

            foreach (var post in filtradas)
            {
                DGVactividades.Rows.Add(
                    post.Id_824_ec,
                    post.Actividad_824_ec.Nombre_824_ec,
                    post.Actividad_824_ec.Estado_824_ec,
                    post.Actividad_824_ec.NivelRequerido_824_ec,
                    post.FechaPostulacion_824_ec,
                    post.Actividad_824_ec.FechaHora_824_ec
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
