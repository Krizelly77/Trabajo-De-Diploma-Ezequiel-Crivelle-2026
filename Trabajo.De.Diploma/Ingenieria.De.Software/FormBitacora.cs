using Capa_de_Aplicación_BLL_;
using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ingenieria.De.Software
{
    public partial class FormBitacora : Form
    {
        public FormBitacora()
        {
            InitializeComponent();
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            DTPdesde.Value = DateTime.Today;
            DTPpasta.Value = DateTime.Today;

            CMBactividad.Items.Add("");
            CMBactividad.Items.Add("Login");
            CMBactividad.Items.Add("Logout");
            CMBactividad.Items.Add("Alta de usuario");
            CMBactividad.Items.Add("Modificacion de usuario");
            CMBactividad.Items.Add("Baja de usuario");
            CMBactividad.SelectedIndex = 0;

            ConfigurarGrilla();
        }

        private void ConfigurarGrilla()
        {
            DGVbitacora.Columns.Add("Id", "Id");
            DGVbitacora.Columns["Id"].Visible = false;

            DGVbitacora.Columns.Add("FechaHora", "Fecha y Hora");
            DGVbitacora.Columns["FechaHora"].Width = 150;

            DGVbitacora.Columns.Add("Usuario", "Usuario");
            DGVbitacora.Columns["Usuario"].Width = 150;

            DGVbitacora.Columns.Add("Actividad", "Actividad");
            DGVbitacora.Columns["Actividad"].Width = 300;

            DGVbitacora.AllowUserToAddRows = false;
            DGVbitacora.AllowUserToDeleteRows = false;
            DGVbitacora.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVbitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVbitacora.MultiSelect = false;
        }

        private void BTNconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                FiltrosBitacora filtros = new FiltrosBitacora
                {
                    FechaDesde = DTPdesde.Value.Date,
                    FechaHasta = DTPpasta.Value.Date,
                    Usuario    = TXTusuario.Text.Trim(),
                    Actividad  = CMBactividad.SelectedItem.ToString()
                };

                List<RegistroBitacora> registros = BitacoraBLL.ConsultarBitacora(filtros);

                DGVbitacora.Rows.Clear();
                foreach (var r in registros)
                {
                    DGVbitacora.Rows.Add(
                        r.Id,
                        r.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                        r.Usuario,
                        r.Actividad
                    );
                }

                if (registros.Count == 0)
                    MessageBox.Show("No se encontraron registros con los filtros seleccionados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
