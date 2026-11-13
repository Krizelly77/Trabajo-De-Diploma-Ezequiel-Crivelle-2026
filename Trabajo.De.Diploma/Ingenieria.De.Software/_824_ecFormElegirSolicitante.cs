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
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Ingenieria.De.Software
{
    public partial class _824_ecFormElegirSolicitante : Form
    {
        private List<_824_ecSolicitante> SolicitantesRegistrados = new List<_824_ecSolicitante>();
        internal _824_ecSolicitante SolicitanteSeleccionado { get; private set; }

        public _824_ecFormElegirSolicitante()
        {
            InitializeComponent();
        }

        private void _824_ecFormElegirSolicitante_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            CargarGrillaSolicitantes_824_ec();
            LimpiarLabelsDetalle();
        }
        // carga inicial
        private void CargarFiltros()
        {
            CMBfiltroSolicitante.Items.Clear();
            CMBfiltroSolicitante.Items.Add("Sin filtro");
            CMBfiltroSolicitante.Items.Add("Nombre");
            CMBfiltroSolicitante.Items.Add("Apellido");
            CMBfiltroSolicitante.Items.Add("Documento");
            CMBfiltroSolicitante.SelectedIndex = 0;
            TXTfiltro.Text = "";
        }
        private void CargarGrillaSolicitantes_824_ec()
        {
            DGVSoliRegistrados.Columns.Clear();

            DGVSoliRegistrados.Columns.Add("Id", "Id");
            DGVSoliRegistrados.Columns["Id"].Visible = false;

            DataGridViewCheckBoxColumn columnaActivo = new DataGridViewCheckBoxColumn();
            columnaActivo.Name = "Activo";
            columnaActivo.HeaderText = "Activo";
            DGVSoliRegistrados.Columns.Add(columnaActivo);
            DGVSoliRegistrados.Columns["Activo"].Width = 55;

            DGVSoliRegistrados.Columns.Add("Nombre", "Nombre");
            DGVSoliRegistrados.Columns["Nombre"].Width = 110;

            DGVSoliRegistrados.Columns.Add("Apellido", "Apellido");
            DGVSoliRegistrados.Columns["Apellido"].Width = 110;

            DGVSoliRegistrados.Columns.Add("Documento", "Documento");
            DGVSoliRegistrados.Columns["Documento"].Width = 120;

            DGVSoliRegistrados.Columns.Add("Alta", "Fecha Alta");
            DGVSoliRegistrados.Columns["Alta"].Width = 110;

            DGVSoliRegistrados.AllowUserToAddRows = false;
            DGVSoliRegistrados.AllowUserToDeleteRows = false;
            DGVSoliRegistrados.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVSoliRegistrados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVSoliRegistrados.MultiSelect = false;
            DGVSoliRegistrados.RowHeadersVisible = false;

            ActualizarSolicitantes_824_ec();
        }

        private void ActualizarSolicitantes_824_ec()
        {
            SolicitantesRegistrados = _824_ecSolicitanteBLL.ListarTodos_824_ec();
            FiltrarSolicitantes_824_ec();
        }
        private void FiltrarSolicitantes_824_ec()
        {
            if (DGVSoliRegistrados.Columns.Count == 0) return;

            DGVSoliRegistrados.Rows.Clear();

            if (SolicitantesRegistrados != null)
            {
                var filtrados = SolicitantesRegistrados.AsEnumerable();

                string criterio = CMBfiltroSolicitante.SelectedItem?.ToString() ?? "Sin filtro";
                string texto = TXTfiltro.Text.Trim().ToLower();

                if (criterio != "Sin filtro" && !string.IsNullOrEmpty(texto))
                {
                    switch (criterio)
                    {
                        case "Nombre":
                            filtrados = filtrados.Where(s => s.Nombre_824_ec != null && s.Nombre_824_ec.ToLower().Contains(texto));
                            break;
                        case "Apellido":
                            filtrados = filtrados.Where(s => s.Apellido_824_ec != null && s.Apellido_824_ec.ToLower().Contains(texto));
                            break;
                        case "Documento":
                            filtrados = filtrados.Where(s => s.Documento_824_ec != null && s.Documento_824_ec.ToLower().Contains(texto));
                            break;
                    }
                }

                foreach (var sol in filtrados)
                {
                    DGVSoliRegistrados.Rows.Add(
                        sol.Id_824_ec,
                        sol.Activo_824_ec,
                        sol.Nombre_824_ec,
                        sol.Apellido_824_ec,
                        sol.Documento_824_ec,
                        sol.FechaDeAlta.ToShortDateString()
                    );
                }
            }

            if (DGVSoliRegistrados.Rows.Count == 0)
            {
                LimpiarLabelsDetalle();
            }
        }
        // botones
        #region botones
        private void BTNirABMsoli_Click(object sender, EventArgs e)
        {
            try
            {
                using (_824_ecFormABMmaestro fMaes_824_ec = new _824_ecFormABMmaestro())
                {
                    fMaes_824_ec._824_ecMaestroActual = MaestrosNegocia_824_ec.Solicitante;
                    fMaes_824_ec.ShowDialog(this);
                }

                ActualizarSolicitantes_824_ec();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BTNseleccionar_Click(object sender, EventArgs e)
        {
            if (DGVSoliRegistrados.CurrentRow == null || DGVSoliRegistrados.CurrentRow.Cells["Id"].Value == null)
            {
                MessageBox.Show("Debe seleccionar un solicitante de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSeleccionado = Convert.ToInt32(DGVSoliRegistrados.CurrentRow.Cells["Id"].Value);
            _824_ecSolicitante sol = SolicitantesRegistrados.FirstOrDefault(s => s.Id_824_ec == idSeleccionado);

            if (sol == null)
            {
                MessageBox.Show("No se pudo recuperar el solicitante seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!sol.Activo_824_ec)
            {
                MessageBox.Show("El solicitante seleccionado se encuentra inactivo. Active su registro o seleccione otro solicitante.", "Solicitante Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SolicitanteSeleccionado = sol;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion botones

        private void DGVSoliRegistrados_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChangeDeslocalizado();
        }

        private void SelectionChangeDeslocalizado()
        {
            if (DGVSoliRegistrados.CurrentRow != null && DGVSoliRegistrados.CurrentRow.Cells["Id"].Value != null)
            {
                if (int.TryParse(DGVSoliRegistrados.CurrentRow.Cells["Id"].Value.ToString(), out int idSol))
                {
                    _824_ecSolicitante sol = SolicitantesRegistrados?.FirstOrDefault(s => s.Id_824_ec == idSol);
                    if (sol != null)
                    {
                        LBLnomb.Text = sol.Nombre_824_ec;
                        LBLapell.Text = sol.Apellido_824_ec;
                        LBLdocu.Text = sol.Documento_824_ec;
                        return;
                    }
                }
            }

            LimpiarLabelsDetalle();
        }
        private void LimpiarLabelsDetalle()
        {
            LBLnomb.Text = "-";
            LBLapell.Text = "-";
            LBLdocu.Text = "-";
        }

        // eventos de otros controles
        private void TXTfiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarSolicitantes_824_ec();
        }

        private void CMBfiltroSolicitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarSolicitantes_824_ec();
        }
    }
}
