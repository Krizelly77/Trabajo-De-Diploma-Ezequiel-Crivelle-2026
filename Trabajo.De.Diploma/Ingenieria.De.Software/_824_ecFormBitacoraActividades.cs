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
    public partial class _824_ecFormBitacoraActividades : Form
    {
        public _824_ecFormBitacoraActividades()
        {
            InitializeComponent();
        }
        private void _824_ecFormBitacoraActividades_Load(object sender, EventArgs e)
        {
            DTPfechaIni.ShowCheckBox = true;
            DTPfechaIni.Checked = false;
            DTPfechaFin.ShowCheckBox = true;
            DTPfechaFin.Checked = false;
            TXTidActividad.Enabled = true;
            TXTnombre.Enabled = true;

            DGVbitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVbitacora.MultiSelect = false;
            DGVbitacora.ReadOnly = true;
            DGVbitacora.AllowUserToAddRows = false;
            DGVbitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DGVbitacora.ScrollBars = ScrollBars.Both;
            CargarGrilla();
        }

        // grilla
        #region grilla
        private void CargarGrilla(int? id = null, string nombre = null, DateTime? fechaIni = null, DateTime? fechaFin = null)
        {
            try
            {
                List<_824_ecActividadCambio> lista = _824_ecActividadCambioBLL.Listar_824_ec(id, nombre, fechaIni, fechaFin);
                DGVbitacora.DataSource = null;
                DGVbitacora.DataSource = lista;
                FormatearColumnasGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la bitácora de cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatearColumnasGrilla()
        {
            if (DGVbitacora.Columns.Count == 0) return;

            // Ocultar IDs internos que no aportan a la vista
            if (DGVbitacora.Columns["IdHistorico_824_ec"] != null)
                DGVbitacora.Columns["IdHistorico_824_ec"].Visible = false;

            if (DGVbitacora.Columns["CategoriaId_824_ec"] != null)
                DGVbitacora.Columns["CategoriaId_824_ec"].Visible = false;

            if (DGVbitacora.Columns["OrganizadorId_824_ec"] != null)
                DGVbitacora.Columns["OrganizadorId_824_ec"].Visible = false;

            if (DGVbitacora.Columns["SolicitanteId_824_ec"] != null)
                DGVbitacora.Columns["SolicitanteId_824_ec"].Visible = false;

            // Configurar encabezados y anchos fijos en píxeles
            ConfigurarColumna("Id_824_ec", "Cod_Act", 75);
            ConfigurarColumna("ActividadActivo_824_ec", "Vigente", 65);
            ConfigurarColumna("Act_824_ec", "Act", 55);
            ConfigurarColumna("Nombre_824_ec", "Nombre", 180);
            ConfigurarColumna("Descripcion_824_ec", "Descripción", 260);
            ConfigurarColumna("Fecha_824_ec", "Fecha", 95, "dd/MM/yyyy");
            ConfigurarColumna("Hora_824_ec", "Hora", 75);
            ConfigurarColumna("FechaHora_824_ec", "Fecha Evento", 130, "dd/MM/yyyy HH:mm");
            ConfigurarColumna("FechaPublicacion_824_ec", "Publicación", 130, "dd/MM/yyyy HH:mm");
            ConfigurarColumna("FechaCaducidad_824_ec", "Caducidad", 130, "dd/MM/yyyy HH:mm");
            ConfigurarColumna("Ubicacion_824_ec", "Ubicación", 180);
            ConfigurarColumna("CantidadMinima_824_ec", "Cupo Mín", 80);
            ConfigurarColumna("CantidadMaxima_824_ec", "Cupo Máx", 80);
            ConfigurarColumna("NivelRequerido_824_ec", "Nivel", 100);
            ConfigurarColumna("Estado_824_ec", "Estado", 100);
        }
        private void ConfigurarColumna(string nombrePropiedad, string header, int ancho, string formato = null)
        {
            if (DGVbitacora.Columns[nombrePropiedad] != null)
            {
                DGVbitacora.Columns[nombrePropiedad].HeaderText = header;
                DGVbitacora.Columns[nombrePropiedad].Width = ancho;
                if (!string.IsNullOrEmpty(formato))
                {
                    DGVbitacora.Columns[nombrePropiedad].DefaultCellStyle.Format = formato;
                }
            }
        }
        #endregion grilla

        // botones
        #region botones
        private void BTNaplicar_Click(object sender, EventArgs e)
        {
            int? idFiltro = null;
            if (!string.IsNullOrWhiteSpace(TXTidActividad.Text))
            {
                if (int.TryParse(TXTidActividad.Text.Trim(), out int idParsed))
                {
                    idFiltro = idParsed;
                }
                else
                {
                    MessageBox.Show("El código de actividad debe ser un número entero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string nombreFiltro = string.IsNullOrWhiteSpace(TXTnombre.Text) ? null : TXTnombre.Text.Trim();
            DateTime? fechaIni = DTPfechaIni.Checked ? (DateTime?)DTPfechaIni.Value.Date : null;
            DateTime? fechaFin = DTPfechaFin.Checked ? (DateTime?)DTPfechaFin.Value.Date : null;

            CargarGrilla(idFiltro, nombreFiltro, fechaIni, fechaFin);
        }

        private void BTNlimpiar_Click(object sender, EventArgs e)
        {
            TXTidActividad.Clear();
            TXTnombre.Clear();
            DTPfechaIni.Checked = false;
            DTPfechaFin.Checked = false;
            CargarGrilla();
        }

        private void BTNactivar_Click(object sender, EventArgs e)
        {
            if (DGVbitacora.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro histórico de la grilla para activar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _824_ecActividadCambio seleccionado = (_824_ecActividadCambio)DGVbitacora.SelectedRows[0].DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Desea restaurar la actividad '{seleccionado.Nombre_824_ec}' (ID: {seleccionado.Id_824_ec}) al estado del {seleccionado.Fecha_824_ec:dd/MM/yyyy} {seleccionado.Hora_824_ec}?",
                "Confirmar Activación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                int resultado = _824_ecActividadCambioBLL.Activar_824_ec(seleccionado);
                if (resultado > 0)
                {
                    MessageBox.Show("Versión histórica activada y sincronizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BTNaplicar_Click(sender, e); // Refrescar manteniendo filtros actuales
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo activar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion botones

        private void DGVbitacora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Resaltar visualmente la fila que tiene Act = true (1)
            if (DGVbitacora.Rows[e.RowIndex].DataBoundItem is _824_ecActividadCambio item && item.Act_824_ec)
            {
                DGVbitacora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 248, 225);
                DGVbitacora.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(DGVbitacora.Font, FontStyle.Bold);
            }
        }

    }
}
