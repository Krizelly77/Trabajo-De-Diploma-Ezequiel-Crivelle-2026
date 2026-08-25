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
    public partial class FormHistorialUsuario : Form
    {
        private int usuarioId;
        private GestorDeAuditoria auditor = new GestorDeAuditoria();
        private UsuarioBLL usuarioBLL = new UsuarioBLL();
        public FormHistorialUsuario(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            LBLtitulo.Text = $"Historial de cambios: {usuarioNombre}";
            this.Load += FormHistorialUsuario_Load;
            BTNrevertir.Click += BTNrevertir_Click;
            BTNcerrar.Click += BTNcerrar_Click;
        }

        private void FormHistorialUsuario_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            List<RegistroCambio> historial = auditor.ObtenerHistorial(usuarioId);
            DGVhistorial.DataSource = null;
            DGVhistorial.DataSource = historial;
        }


        private void BTNrevertir_Click(object sender, EventArgs e)
        {
                    
            if (DGVhistorial.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un cambio para revertir.");
                return;
            }

            RegistroCambio cambio = (RegistroCambio)DGVhistorial.SelectedRows[0].DataBoundItem;

            if (cambio.ValorAnterior == null)
            {
                MessageBox.Show("Este cambio no se puede revertir (es un alta).");
                return;
            }

            try
            {
                Usuario usuario = UsuarioBLL.ObtenerPorId(usuarioId);

                switch (cambio.NombreCampo)
                {
                    case "NombreUsuario":
                        usuario.NombreUsuario = cambio.ValorAnterior;
                        break;
                    case "Activo":
                        usuario.Activo = bool.Parse(cambio.ValorAnterior);
                        break;
                    case "NivelPermisos":
                        usuario.NivelPermisos = int.Parse(cambio.ValorAnterior);
                        break;
                }

                usuarioBLL.Guardar(usuario);
                MessageBox.Show("Cambio revertido con éxito.");
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al revertir: {ex.Message}");
            }
        }

        private void BTNcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
