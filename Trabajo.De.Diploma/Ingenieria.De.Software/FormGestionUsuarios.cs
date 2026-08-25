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

namespace Ingenieria.De.Software
{
    public partial class FormGestionUsuarios : Form, IObservadorDeIdioma
    {
        public Form PadredelPadreLogin { get; set; }
        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            GestorDeIdioma.TraerInstancia().Suscribir(this);
            ActualizarIdioma(GestorDeIdioma.TraerInstancia().ObtenerTextos());
            CargarGrilla();
        }

        public void ActualizarIdioma(Dictionary<string, string> textos)
        {
            this.Text          = textos["gestusu_titulo"];
            BTNcrearUsu.Text   = textos["gestusu_alta"];
            BTNmodUsu.Text     = textos["gestusu_modificar"];
            BTNeliminarUsu.Text = textos["gestusu_eliminar"];
            BTNvolver.Text     = textos["gestusu_volver"];
            BTNhistorial.Text  = textos["gestusu_historial"];

            if (DGVusuaios.Columns["Nombre"] != null)
                DGVusuaios.Columns["Nombre"].HeaderText = textos["gestusu_col_nombre"];
            if (DGVusuaios.Columns["Contraseña"] != null)
                DGVusuaios.Columns["Contraseña"].HeaderText = textos["gestusu_col_contra"];
            if (DGVusuaios.Columns["Activo"] != null)
                DGVusuaios.Columns["Activo"].HeaderText = textos["gestusu_col_activo"];
        }


        // metodos de la grilla
        #region grilla
        private void CargarGrilla()
        {
            DGVusuaios.Columns.Add("Id", "Id");
            DGVusuaios.Columns["Id"].Visible = false;

            DGVusuaios.Columns.Add("Nombre", "Nombre");
            DGVusuaios.Columns["Nombre"].Width = 150;

            DGVusuaios.Columns.Add("Contraseña", "Contraseña");
            DGVusuaios.Columns["Contraseña"].Width = 150;

            DataGridViewCheckBoxColumn columnaActivo = new DataGridViewCheckBoxColumn();
            columnaActivo.Name = "Activo";
            columnaActivo.HeaderText = "Activo";
            DGVusuaios.Columns.Add(columnaActivo);
            DGVusuaios.Columns["Activo"].Width = 100;

            DGVusuaios.Columns.Add("NivelPermisos", "NivelPermisos");
            DGVusuaios.Columns["NivelPermisos"].Width = 100;

            DataGridViewCheckBoxColumn columnaBloqueado = new DataGridViewCheckBoxColumn();
            columnaBloqueado.Name = "BloqueoDV";
            columnaBloqueado.HeaderText = "BloqueoDV";
            DGVusuaios.Columns.Add(columnaBloqueado);
            DGVusuaios.Columns["BloqueoDV"].Width = 100;

            DGVusuaios.AllowUserToAddRows = false;
            DGVusuaios.AllowUserToDeleteRows = false;
            DGVusuaios.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGVusuaios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVusuaios.MultiSelect = false;

            Actualizar();
        }
        private void Actualizar()
        {
            DGVusuaios.Rows.Clear();

            List<Usuario> usuarios = UsuarioBLL.Listar();

            foreach (var usu in usuarios)
            {
                DGVusuaios.Rows.Add(usu.Id, usu.NombreUsuario, usu.Contraseña, usu.Activo.ToString(), usu.NivelPermisos.ToString(), usu.BloqueoDV.ToString());
            }
        }
        private void DGVusuaios_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVusuaios.CurrentRow != null)
            {
                TXTnom.Text = DGVusuaios.CurrentRow.Cells["Nombre"].Value.ToString();
                TXTcon.Text = DGVusuaios.CurrentRow.Cells["Contraseña"].Value.ToString();
                CHKactivo.Checked = Convert.ToBoolean(DGVusuaios.CurrentRow.Cells["Activo"].Value);
                CHKbloqueado.Checked = Convert.ToBoolean(DGVusuaios.CurrentRow.Cells["BloqueoDV"].Value);
            }
        }
        #endregion grilla

        // abrir y cerrar formularios
        #region formularios
        private void FormGestionUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorDeIdioma.TraerInstancia().Desuscribir(this);

            if (this.PadredelPadreLogin != null)
            {
                this.PadredelPadreLogin.Show();
            }
        }
        private void llamarAMB(Constantes.TiposOperacion oper)
        {

            if (DGVusuaios.SelectedRows.Count > 0)
            {
                FormUsuarioABM mForm = new FormUsuarioABM();
                mForm.StartPosition = FormStartPosition.CenterParent;
                if(oper != Constantes.TiposOperacion.Alta)
                {
                    int mId = int.Parse(DGVusuaios.SelectedRows[0].Cells[0].Value.ToString());
                    mForm.UsuarioEditable = UsuarioBLL.ObtenerPorId(mId);
                }
                mForm.TipoOperacion = oper;
                mForm.ShowDialog(this);
                Actualizar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario para realizar esta operacion de " + oper.ToString());
            }
        }
        private void BTNasignarRol_Click(object sender, EventArgs e)
        {
            FormAsignacionPermisos mFormPer = new FormAsignacionPermisos();
            mFormPer.StartPosition = FormStartPosition.CenterParent;
            mFormPer.ShowDialog(this);
        }
        #endregion formularios

        // botones
        #region botones
        private void BTNcrearUsu_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Alta);
        }

        private void BTNmodUsu_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Modificacion);
        }

        private void BTNeliminarUsu_Click(object sender, EventArgs e)
        {
            llamarAMB(Constantes.TiposOperacion.Baja);
        }
        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion botones

        private void BTNdesbloqueoDV_Click(object sender, EventArgs e)
        {
            // Cartel de confirmacion de accion
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea normalizar el sistema?\n\nEsto removerá el flag de BloqueoDV de todos los usuarios y volverá a generar las firmas de integridad (DVH y DVV) basadas en los datos actuales",
                "Confirmar Restablecimiento del Sistema",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    DigitoVerificadorBLL dvBll = new DigitoVerificadorBLL();
                    UsuarioBLL usuarioBll = new UsuarioBLL();

                    List<Usuario> listaUsuarios = UsuarioBLL.Listar();
                    if (listaUsuarios != null)
                    {
                        foreach (Usuario usu in listaUsuarios)
                        {
                            usu.BloqueoDV = false; //desbloqueo
                            usuarioBll.Guardar(usu); //guardar actualiza las dvs 
                        }

                        MessageBox.Show(
                            "El sistema se ha normalizado con exito, Se desbloquearon todos los accesos y las firmas digitales de la base de datos se encuentran actualizadas",
                            "Operación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        Actualizar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ocurrio un error inesperado al intentar normalizar las firmas: {ex.Message}",
                        "Error de Operación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void BTNhistorial_Click(object sender, EventArgs e)
        {
            if (DGVusuaios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario para ver su historial.");
                return;
            }

            int id = int.Parse(DGVusuaios.SelectedRows[0].Cells["Id"].Value.ToString());
            string nombre = DGVusuaios.SelectedRows[0].Cells["Nombre"].Value.ToString();

            FormHistorialUsuario fHistorial = new FormHistorialUsuario(id, nombre);
            fHistorial.ShowDialog(this);
        }

    }
}
