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
using Microsoft.VisualBasic;

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
            var usuarioActivo = SessionManager.TraerInstancia().usuarioINS;
            AplicarPermisos(usuarioActivo);
            CargarGrilla();
        }
        private void AplicarPermisos(Usuario usuario)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Tag != null)
                    c.Enabled = usuario.TienePermiso(c.Tag.ToString());
            }
        }

        public void ActualizarIdioma(Dictionary<string, string> textos)
        {
            this.Text          = textos["gestusu_titulo"];
            BTNcrearUsu.Text   = textos["gestusu_alta"];
            BTNmodUsu.Text     = textos["gestusu_modificar"];
            BTNeliminarUsu.Text = textos["gestusu_eliminar"];
            BTNvolver.Text     = textos["gestusu_volver"];
            BTNhistorial.Text  = textos["gestusu_historial"];

            if (textos.ContainsKey("gestusu_btn_serializar")) BTNserializar.Text = textos["gestusu_btn_serializar"];
            if (textos.ContainsKey("gestusu_btn_deserializar")) BTNdeserializar.Text = textos["gestusu_btn_deserializar"];
            if (textos.ContainsKey("gestusu_btn_limpiar")) BTNlimpiar.Text = textos["gestusu_btn_limpiar"];

            ToolTip toolTip = new ToolTip();
            if (textos.ContainsKey("gestusu_tt_limpiar")) toolTip.SetToolTip(BTNlimpiar, textos["gestusu_tt_limpiar"]);
            if (textos.ContainsKey("gestusu_tt_actualizar")) toolTip.SetToolTip(BTNcargar, textos["gestusu_tt_actualizar"]);

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
            PoblarGrilla(usuarios);
        }
        private void PoblarGrilla(List<Usuario> usuarios)
        {
            DGVusuaios.Rows.Clear();
            if (usuarios == null) return;

            foreach (var usu in usuarios)
            {
                DGVusuaios.Rows.Add(usu.Id, usu.NombreUsuario, usu.Contraseña, usu.Activo, usu.NivelPermisos, usu.BloqueoDV);
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

        // metodos de serializacion
        #region Serializacion XML

        private void BTNserializar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> listaUsuarios = UsuarioBLL.Listar();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos XML (*.xml)|*.xml";
                    saveFileDialog.Title = "Guardar archivo XML de Usuarios";
                    saveFileDialog.InitialDirectory = _824_ecDirectivosManejador.ObtenerRutaCarpetaDefault("ExportacionesXML");

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _824_ecSerializadorBLL.SerializarUsuariosXML(saveFileDialog.FileName, listaUsuarios);
                        MessageBox.Show("Datos serializados exitosamente en XML", "Todo OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al serializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNdeserializar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos XML (*.xml)|*.xml";
                    openFileDialog.Title = "Seleccionar archivo XML de Usuarios";
                    openFileDialog.InitialDirectory = _824_ecDirectivosManejador.ObtenerRutaCarpetaDefault("ExportacionesXML");

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        List<Usuario> listaDeserializada = _824_ecSerializadorBLL.DeserializarUsuariosXML(openFileDialog.FileName);
                        List<Usuario> listaFiltrada = SeleccionarCantidadFilasDeserializadas(listaDeserializada);
                        if (listaFiltrada != null && listaFiltrada.Count > 0)
                        {
                            PoblarGrilla(listaFiltrada);
                            MessageBox.Show($"Se cargaron {listaFiltrada.Count} usuario(s) en la grilla correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al deserializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<T> SeleccionarCantidadFilasDeserializadas<T>(List<T> listaDeserializada)
        {
            if (listaDeserializada == null || listaDeserializada.Count == 0)
            {
                MessageBox.Show("El archivo XML no contiene registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            DialogResult respuesta = MessageBox.Show(
                $"El archivo contiene {listaDeserializada.Count} registros.\n\n" +
                "¿Desea deserializar y cargar TODOS los registros?\n\n" +
                "- 'Sí': Cargar todos los registros.\n" +
                "- 'No': Especificar una cantidad determinada de filas.\n" +
                "- 'Cancelar': Anular la operación.",
                "Opciones de Deserialización",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                return listaDeserializada;
            }
            else if (respuesta == DialogResult.No)
            {
                string input = Interaction.InputBox(
                    $"Ingrese la cantidad de filas a cargar (entre 1 y {listaDeserializada.Count}):",
                    "Cantidad de filas a deserializar",
                    listaDeserializada.Count.ToString());

                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }

                if (int.TryParse(input.Trim(), out int cantidad) && cantidad > 0)
                {
                    if (cantidad > listaDeserializada.Count)
                    {
                        MessageBox.Show($"La cantidad ingresada ({cantidad}) supera el total disponible ({listaDeserializada.Count}). Se cargarán todos los registros disponibles.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cantidad = listaDeserializada.Count;
                    }
                    return listaDeserializada.Take(cantidad).ToList();
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es un número entero positivo válido. Operación cancelada.", "Valor Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }

            return null;
        }

        private void BTNlimpiar_Click(object sender, EventArgs e)
        {
            DGVusuaios.Rows.Clear();
            TXTnom.Clear();
            TXTcon.Clear();
            CHKactivo.Checked = false;
            CHKbloqueado.Checked = false;
        }

        private void BTNcargar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        #endregion Serializacion XML

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
            int mId = int.Parse(DGVusuaios.SelectedRows[0].Cells[0].Value.ToString());
            mFormPer.IdGestionUsuarios_824_ec = mId;
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
                            usuarioBll.Guardar(usu); //guardar la desactivacion del bloqueo
                        }
                        // Apagamos temporalmente el escáner para que nos deje recalculart
                        DigitoVerificadorBLL.ValidacionHabilitada = false;

                        // Ejecutamos la re-sincronización masiva de las tablas
                        DigitoVerificadorBLL dvBLL = new DigitoVerificadorBLL();
                        dvBLL.RecalcularIntegridadGlobal();

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
                finally
                {
                    DigitoVerificadorBLL.ValidacionHabilitada = true;
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
