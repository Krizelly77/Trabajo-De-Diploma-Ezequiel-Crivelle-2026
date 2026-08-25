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
    public partial class FormPermisosRoles : Form
    {
        private PermisoBLL permisoBll = new PermisoBLL();
        private Rol rolseleccionado; // para abm integrado
        private ComponentePermiso componenteSeleccionado; // para añadir a un rol
        public FormPermisosRoles()
        {
            InitializeComponent();
        }

        private void FormPermisosRoles_Load(object sender, EventArgs e)
        {
            ActualizarControlesMaestros();
            LBXcomponentes.Format += LBXcomponentes_Format;
        }
        #region refrecar
        private void ActualizarControlesMaestros()
        { //sincronizar form con la bd
            try
            {
                List<ComponentePermiso> todo = permisoBll.ListarComponentesRaiz();
                LBXcomponentes.DataSource = null;
                LBXcomponentes.DataSource = todo;

                List<Rol> onlyRoles = new List<Rol>();
                foreach (var comp in todo)
                {
                    if (comp is Rol) onlyRoles.Add((Rol)comp);
                }

                CMBroles.DataSource = null;
                CMBroles.DataSource = onlyRoles;
                CMBroles.DisplayMember = "Nombre";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar componentes: {ex.Message}");
            }
        }
        private void CargarArbolPermisos(Rol rolRaiz)
        {
            ArbolPermisos.Nodes.Clear();
            if (rolRaiz == null) return;

            TreeNode nodoRaiz = new TreeNode(rolRaiz.Nombre)
            {
                Tag = rolRaiz,
                ForeColor = Color.DarkRed // Resaltamos la raiz del arbol actual
            };

            ArbolPermisos.Nodes.Add(nodoRaiz);
            LlenarNodosRecursivo(rolRaiz, nodoRaiz);
            ArbolPermisos.ExpandAll();
        }
        private void LlenarNodosRecursivo(ComponentePermiso componentePadre, TreeNode nodoVisualPadre)
        {
            foreach (var hijo in componentePadre.Hijos)
            {
                TreeNode nodoVisualHijo = new TreeNode(hijo.Nombre)
                {
                    Tag = hijo
                };

                if (hijo is Rol)
                {
                    nodoVisualHijo.ForeColor = Color.Blue; // Sub-roles organizacionales en Azul
                }

                nodoVisualPadre.Nodes.Add(nodoVisualHijo);

                if (hijo.Hijos.Count > 0)
                {
                    LlenarNodosRecursivo(hijo, nodoVisualHijo);
                }
            }
        }

        #endregion refrecar

        #region Botones
        private void BTNagregarAlRol_Click(object sender, EventArgs e)
        {
            if (rolseleccionado == null)
            {
                MessageBox.Show("Seleccione un rol en el combo");
                return;
            }

            if (componenteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un componente");
                return;
            }

            try
            {
                ComponentePermiso componente = componenteSeleccionado;

                if (componente is Rol)
                    componente = permisoBll.ObtenerRolCompleto(componente.Id);

                permisoBll.AgregarComponenteARol(rolseleccionado, componente);

                rolseleccionado = permisoBll.ObtenerRolCompleto(rolseleccionado.Id);
                CargarArbolPermisos(rolseleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BTNquitarDelRol_Click(object sender, EventArgs e)
        {
            if (rolseleccionado == null || ArbolPermisos.SelectedNode == null) return;

            TreeNode nodoSeleccionado = ArbolPermisos.SelectedNode;

            // Validamos que no intenten borrar el nodo raíz del TreeView
            if (nodoSeleccionado.Parent == null) return;

            if (nodoSeleccionado.Tag is ComponentePermiso componenteAQuitar)
            {
                // Obtenemos el componente padre directo de la estructura visual para saber de dónde removerlo en memoria
                ComponentePermiso componentePadre = (ComponentePermiso)nodoSeleccionado.Parent.Tag;

                if (componentePadre is Rol rolPadre)
                {
                    permisoBll.QuitarComponenteDeRol(rolPadre, componenteAQuitar);

                    // Volvemos a traer el rol de la BD para asegurar consistencia e integridad visual
                    rolseleccionado = permisoBll.ObtenerRolCompleto(rolseleccionado.Id);
                    CargarArbolPermisos(rolseleccionado);
                }
            }
        }
        private void BTNcrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                Rol nuevoRol = new Rol
                {
                    Nombre = TXTnomRol.Text,
                    NombreInterno = null
                };

                permisoBll.GuardarComponente(nuevoRol);
                MessageBox.Show("Rol contenedor creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TXTnomRol.Clear();

                // Guardamos el ID de lo que estábamos editando para no perderlo
                int idIdActual = rolseleccionado != null ? rolseleccionado.Id : 0;

                ActualizarControlesMaestros();

                if (idIdActual > 0)
                    ReseleccionarRolEnCombo(idIdActual);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BTNmodRol_Click(object sender, EventArgs e)
        {
            if (!(componenteSeleccionado is Rol rol))
            {
                MessageBox.Show("Seleccione un rol en la lista.");
                return;
            }

            rol.Nombre = TXTnomRol.Text.Trim();

            permisoBll.ModificarRol(rol);

            ActualizarControlesMaestros();
        }
        private void BTNelimRol_Click(object sender, EventArgs e)
        {
            if (!(componenteSeleccionado is Rol rol))
            {
                MessageBox.Show("Seleccione un rol en la lista.");
                return;
            }

            DialogResult r = MessageBox.Show($"¿Eliminar rol '{rol.Nombre}'?","Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r != DialogResult.Yes)
                return;

            permisoBll.EliminarRol(rol);

            TXTnomRol.Clear();
            componenteSeleccionado = null;

            ActualizarControlesMaestros();
        }
        #endregion Botones

        #region otroscontroles
        private void LBXcomponentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBXcomponentes.SelectedItem is ComponentePermiso comp)
            {
                componenteSeleccionado = comp;
                if (comp is Rol rol)
                {
                    TXTnomRol.Text = rol.Nombre;
                    BTNmodRol.Enabled = true;
                    BTNelimRol.Enabled = true;
                }
                else
                {
                    TXTnomRol.Text = "";
                    BTNmodRol.Enabled = false;
                    BTNelimRol.Enabled = false;
                }
            }
        }
        private void LBXcomponentes_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Rol rol)
                e.Value = $"[ROL] {rol.Nombre}";
            else if (e.ListItem is PermisoSimple permiso)
                e.Value = $"[PERMISO] {permiso.Nombre}";
        }
        private void CMBroles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBroles.SelectedItem is Rol rolParcial)
            {
                // Buscamos el rol completo desde la base de datos 
                rolseleccionado = permisoBll.ObtenerRolCompleto(rolParcial.Id);
                CargarArbolPermisos(rolseleccionado);
            }
        }
        private void ReseleccionarRolEnCombo(int idRol)
        {
            foreach (Rol item in CMBroles.Items)
            {
                if (item.Id == idRol)
                {
                    CMBroles.SelectedItem = item;
                    break;
                }
            }
        }
        #endregion otroscontroles

        #region formularios
        private void BTNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BTNabrirrolusuario_Click(object sender, EventArgs e)
        {
            try
            {
                FormAsignacionPermisos Fpermisos = new FormAsignacionPermisos();
                Fpermisos.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion formularios
    }
}
