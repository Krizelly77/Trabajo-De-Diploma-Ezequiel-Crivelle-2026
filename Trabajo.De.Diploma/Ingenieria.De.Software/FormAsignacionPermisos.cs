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
    public partial class FormAsignacionPermisos : Form
    {
        private UsuarioBLL Usuariobll = new UsuarioBLL();
        private PermisoBLL Permisobll = new PermisoBLL();
        private Usuario UsuarioSlec;
        public FormAsignacionPermisos()
        {
            InitializeComponent();
        }

        private void FormAsignacionPermisos_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarCatalogoPermisos();
        }
        private void CargarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = UsuarioBLL.Listar();
                CMBusuarios.DataSource = null;
                CMBusuarios.DataSource = usuarios;
                CMBusuarios.DisplayMember = "NombreUsuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}");
            }
        }

        private void CargarCatalogoPermisos()
        {
            try
            {
                List<ComponentePermiso> todoElCatalogo = Permisobll.ListarComponentesRaiz();

                List<ComponentePermiso> soloRoles = todoElCatalogo.Where(x => x is Rol).ToList();

                LBXrolesDisponibles.DataSource = null;
                LBXrolesDisponibles.DataSource = soloRoles;
                LBXrolesDisponibles.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el catálogo de roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CMBusuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBusuarios.SelectedItem is Usuario usuarioCombo)
            {
                UsuarioSlec = UsuarioBLL.ObtenerPorId(usuarioCombo.Id);
                MostrarPermisosActuales();
            }
        }
        #region metodosdesoporte
        private void MostrarPermisosActuales()
        {
            ArbolPermisosUsuario.Nodes.Clear();
            if (UsuarioSlec == null) return;

            foreach (var comp in UsuarioSlec.Permisos)
            {
                TreeNode nodoRaiz = new TreeNode(comp.Nombre)
                {
                    Tag = comp,
                    ForeColor = comp is Rol ? Color.Blue : Color.Black
                };

                ArbolPermisosUsuario.Nodes.Add(nodoRaiz);

                // Recorremos recursivamente las ramas internas si es un Rol contenedor
                LlenarRamasUsuarioRecursivo(comp, nodoRaiz);
            }

            ArbolPermisosUsuario.ExpandAll();
        }

        private void LlenarRamasUsuarioRecursivo(ComponentePermiso componentePadre, TreeNode nodoVisualPadre)
        {
            foreach (var hijo in componentePadre.Hijos)
            {
                TreeNode nodoVisualHijo = new TreeNode(hijo.Nombre)
                {
                    Tag = hijo,
                    ForeColor = hijo is Rol ? Color.Blue : Color.DarkSlateGray
                };

                nodoVisualPadre.Nodes.Add(nodoVisualHijo);

                if (hijo.Hijos.Count > 0)
                {
                    LlenarRamasUsuarioRecursivo(hijo, nodoVisualHijo);
                }
            }
        }
        #endregion metodosdesoporte

        #region botones


        private void BTNasignar_Click(object sender, EventArgs e)
        {
            if (UsuarioSlec == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (LBXrolesDisponibles.SelectedItem is ComponentePermiso componenteAAgregar)
            {
                // [NUEVA VALIDACIÓN] Bloqueo explícito si intentan meter algo que no sea un Rol
                if (!(componenteAAgregar is Rol))
                {
                    MessageBox.Show("Solo se permite asignar Roles completos a los usuarios. Las patentes deben agruparse dentro de un Rol.", "Operación Denegada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // Validación para no duplicar el componente DIRECTO
                if (UsuarioSlec.Permisos.Exists(x => x.Id == componenteAAgregar.Id))
                {
                    MessageBox.Show("El usuario ya tiene asignado este rol de manera directa.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Si es un rol (que ya sabemos que lo es), lo hidratamos
                componenteAAgregar = Permisobll.ObtenerRolCompleto(componenteAAgregar.Id);

                UsuarioSlec.Permisos.Add(componenteAAgregar);

                try
                {
                    Usuariobll.Guardar(UsuarioSlec);
                    MessageBox.Show($"Rol '{componenteAAgregar.Nombre}' asignado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarPermisosActuales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la asignación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTNrevocar_Click(object sender, EventArgs e)
        {
            if (UsuarioSlec == null || ArbolPermisosUsuario.SelectedNode == null) return;

            TreeNode nodoVisual = ArbolPermisosUsuario.SelectedNode;

            // REGLA DEL COMPOSITE: Sólo podemos remover permisos directos (nodos raíces del árbol del usuario)
            if (nodoVisual.Parent != null)
            {
                MessageBox.Show("No se puede revocar este permiso de forma individual porque el usuario lo hereda de un Rol superior. Debe revocar el Rol completo.", "Operación No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nodoVisual.Tag is ComponentePermiso componenteARemover)
            {
                UsuarioSlec.Permisos.RemoveAll(x => x.Id == componenteARemover.Id);

                try
                {
                    // Guardamos e impactamos cambios refrescando firmas digitales
                    Usuariobll.Guardar(UsuarioSlec);

                    MessageBox.Show($"Permiso '{componenteARemover.Nombre}' revocado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarPermisosActuales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar la baja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion botones

        private void BRNvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
