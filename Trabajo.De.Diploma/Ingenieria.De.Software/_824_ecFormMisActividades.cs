using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;
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
    public partial class _824_ecFormMisActividades : Form
    {
        private List<_824_ecActividad> MisAct_824_ec;
        public _824_ecFormMisActividades()
        {
            InitializeComponent();
        }

        private void _824_ecFormMisActividades_Load(object sender, EventArgs e)
        {
            ConfigurarFiltros_824_ec();
            CargarGrilla_824_ec();
        }

        private void ConfigurarFiltros_824_ec()
        {
            FiltroFecha.Value = DateTime.Now;

            CMBfiltroActividades.Items.Clear();
            CMBfiltroActividades.Items.Add("Todos");
            foreach (EstadoActividad_824_ec estado in Enum.GetValues(typeof(EstadoActividad_824_ec)))
            {
                CMBfiltroActividades.Items.Add(estado.ToString());
            }
            CMBfiltroActividades.SelectedIndex = 0;
        }

        private void CargarListaDesdeBD_824_ec()
        {
            Usuario usuarioActual = SessionManager.TraerInstancia().usuarioINS;
            if (usuarioActual != null)
            {
                MisAct_824_ec = _824_ecActividadBLL.ListarTodas_824_ec()
                    .Where(a => a.Organizador_824_ec != null && a.Organizador_824_ec.Id == usuarioActual.Id)
                    .ToList();
            }
            else
            {
                MisAct_824_ec = new List<_824_ecActividad>();
            }
        }

        // METODOS DE GRILLA
        #region grilla
        private void CargarGrilla_824_ec()
        {
            DGVmisactividades.Columns.Add("Id", "Id");
            DGVmisactividades.Columns["Id"].Visible = false;

            DGVmisactividades.Columns.Add("Nombre", "Nombre");
            DGVmisactividades.Columns["Nombre"].Width = 100;

            DGVmisactividades.Columns.Add("Estado", "Estado");
            DGVmisactividades.Columns["Estado"].Width = 70;

            DGVmisactividades.Columns.Add("Participantes", "Participantes");
            DGVmisactividades.Columns["Participantes"].Width = 60;

            DGVmisactividades.AllowUserToAddRows = false;
            DGVmisactividades.AllowUserToDeleteRows = false;
            DGVmisactividades.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVmisactividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVmisactividades.MultiSelect = false;

            Actualizar_824_ec();
        }

        private void Actualizar_824_ec()
        {
            CargarListaDesdeBD_824_ec();
            FiltrarGrilla_824_ec();
        }

        private void FiltrarGrilla_824_ec()
        {
            if (DGVmisactividades.Columns.Count == 0) return;

            DGVmisactividades.Rows.Clear();

            if (MisAct_824_ec != null)
            {
                var filtradas = MisAct_824_ec.AsEnumerable();

                // Filtro por Estado (si es distinto a "Todos")
                if (CMBfiltroActividades.SelectedItem != null && CMBfiltroActividades.SelectedItem.ToString() != "Todos")
                {
                    string estadoSeleccionado = CMBfiltroActividades.SelectedItem.ToString();
                    filtradas = filtradas.Where(a => a.Estado_824_ec.ToString() == estadoSeleccionado);
                }

                // Filtro por Fecha de Publicación (anteriores o iguales a la fecha seleccionada)
                DateTime fechaLimite = FiltroFecha.Value.Date;
                filtradas = filtradas.Where(a => a.FechaPublicacion_824_ec.Date <= fechaLimite);

                foreach (var act in filtradas)
                {
                    var postulaciones = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(act.Id_824_ec);
                    int cantParticipantes = postulaciones != null
                        ? postulaciones.Count(p => p.Estado_824_ec == _824_ecBE_Enums.EstadoPostulacion_824_ec.Aceptado)
                        : 0;

                    DGVmisactividades.Rows.Add(
                        act.Id_824_ec,
                        act.Nombre_824_ec,
                        act.Estado_824_ec.ToString(),
                        $"{cantParticipantes} / {act.CantidadMaxima_824_ec}"
                    );
                }
            }

            if (DGVmisactividades.Rows.Count == 0)
            {
                LimpiarDetalle_824_ec();
            }
        }

        private void CMBfiltroActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }

        private void FiltroFecha_ValueChanged(object sender, EventArgs e)
        {
            FiltrarGrilla_824_ec();
        }
        private void DGVmisactividades_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVmisactividades.CurrentRow != null && DGVmisactividades.CurrentRow.Cells["Id"].Value != null)
            {
                if (int.TryParse(DGVmisactividades.CurrentRow.Cells["Id"].Value.ToString(), out int actividadId))
                {
                    _824_ecActividad act = MisAct_824_ec?.FirstOrDefault(a => a.Id_824_ec == actividadId);
                    if (act != null)
                    {
                        if (act.Estado_824_ec == EstadoActividad_824_ec.Cancelado)
                        {
                            panel1.BackColor = Color.IndianRed;
                            BTNmodActividad.Enabled = false;
                        }
                        else
                        {
                            panel1.BackColor = Color.OliveDrab;
                            BTNmodActividad.Enabled = true;
                        }
                        CargarDetalleActividad_824_ec(act);
                        return;
                    }
                }
            }
            LimpiarDetalle_824_ec();
        }

        private void CargarDetalleActividad_824_ec(_824_ecActividad act)
        {
            LBLnombree.Text = act.Nombre_824_ec;
            TXTcategoria.Text = act.Categoria_824_ec != null ? act.Categoria_824_ec.Nombre_824_ec : "";
            TXTnivel.Text = act.NivelRequerido_824_ec.ToString();
            TXTestado.Text = act.Estado_824_ec.ToString();
            TXBdescripcion.Text = act.Descripcion_824_ec ?? "";
            TXTdia.Text = act.FechaHora_824_ec.ToString("dd/MM/yyyy");
            TXThora.Text = act.FechaHora_824_ec.ToString("HH:mm");
            TXTlugar.Text = act.Ubicacion_824_ec ?? "";

            var postulaciones = _824_ecPostulacionBLL.ListarCandidatosPorActividad_824_ec(act.Id_824_ec);
            int cantParticipantes = postulaciones != null
                ? postulaciones.Count(p => p.Estado_824_ec == _824_ecBE_Enums.EstadoPostulacion_824_ec.Aceptado)
                : 0;

            TXTmaxmin.Text = $"{act.CantidadMinima_824_ec} ≤ {cantParticipantes} ≤ {act.CantidadMaxima_824_ec}";
            TXTpublicacion.Text = act.FechaPublicacion_824_ec.ToString("dd/MM/yyyy");
            TXTcaducacion.Text = act.FechaCaducidad_824_ec.ToString("dd/MM/yyyy");
        }

        private void LimpiarDetalle_824_ec()
        {
            LBLnombree.Text = "Nombre de actividad";
            TXTcategoria.Text = "";
            TXTnivel.Text = "";
            TXTestado.Text = "";
            TXBdescripcion.Text = "";
            TXTdia.Text = "";
            TXThora.Text = "";
            TXTlugar.Text = "";
            TXTmaxmin.Text = "";
            TXTpublicacion.Text = "";
            TXTcaducacion.Text = "";
        }
        #endregion grilla

        // METODOS DE BOTONES
        #region botonesABM 
        private void BTNmodActividad_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Modificacion);
        }
        private void BTNnuevaActividad_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Alta);
        }
        private void BTNbajaActividad_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Baja);
        }
        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llamarAMB(Constantes.TiposOperacion oper)
        {
            if (oper == Constantes.TiposOperacion.Alta || DGVmisactividades.SelectedRows.Count > 0)
            {
                _824_ecFormABMactividad mForm_824_ec = new _824_ecFormABMactividad();
                mForm_824_ec.StartPosition = FormStartPosition.CenterParent;
                if (oper != Constantes.TiposOperacion.Alta)
                {
                    int mId = int.Parse(DGVmisactividades.SelectedRows[0].Cells[0].Value.ToString());
                    mForm_824_ec._824_ecActividadEditable = _824_ecActividadBLL.ObtenerPorId_824_ec(mId);
                }
                mForm_824_ec._824_ecTipoOperacion = oper;
                mForm_824_ec.ShowDialog(this);
                Actualizar_824_ec();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una de sus actividades para realizar esta operacion de " + oper.ToString());
            }
        }
        #endregion botonesABM
    }
}
