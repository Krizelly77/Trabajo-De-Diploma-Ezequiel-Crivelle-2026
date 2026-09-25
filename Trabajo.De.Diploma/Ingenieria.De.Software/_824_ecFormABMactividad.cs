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
using static Ingenieria.De.Software.Constantes;

namespace Ingenieria.De.Software
{
    public partial class _824_ecFormABMactividad : Form
    {
        internal Constantes.TiposOperacion _824_ecTipoOperacion { get; set; }
        internal _824_ecActividad _824_ecActividadEditable { get; set; }
        internal List<_824_ecCategoria> _824_ecCats;
        internal _824_ecBE_Enums.EstadoActividad_824_ec EstadoAnterior { get; set; }

        public _824_ecFormABMactividad()
        {
            InitializeComponent();
        }
        private void _824_ecFormABMactividad_Load(object sender, EventArgs e)
        {
            _824_ecCats = _824_ecCategoriaBLL.Listar_824_ec();
            CMBcategoria.Items.Clear(); 
            if (_824_ecCats != null)
            {
                foreach (var cat in _824_ecCats)
                {
                    CMBcategoria.Items.Add(cat.Nombre_824_ec);
                }
            }
            if(_824_ecTipoOperacion != TiposOperacion.Alta)
                EstadoAnterior = _824_ecActividadEditable.Estado_824_ec;
            CMBestado.DataSource = Enum.GetValues(typeof(EstadoActividad_824_ec));
            CMBnivel.DataSource = Enum.GetValues(typeof(NivelRequerido_824_ec));
            _824_ecCargarABM();
        }

        // iniciar formulario en base al tipo de operacion
        #region cargar
        private void _824_ecCargarABM()
        {
            switch (_824_ecTipoOperacion)
            {
                case Constantes.TiposOperacion.Alta:
                    _824_ecLimpiarCampos();
                    LBLnombree.Text = "Crear Nueva Actividad";
                    BTNrestablecerCampos.Enabled = false;
                    BTNrestablecerCampos.Visible = false;
                    CMBestado.Enabled = false;
                    CMBestado.Visible = false;
                    LBLestado.Visible = false;

                    break;

                case Constantes.TiposOperacion.Modificacion:
                    if (_824_ecActividadEditable == null)
                    {
                        MessageBox.Show("No se ha especificado la Actividad a modificar");
                        this.Close();
                        return;
                    }
                    _824_ecCargarCampos(_824_ecActividadEditable);
                    LBLnombree.Text = "Modificación de Actividad";
                    break;

                case Constantes.TiposOperacion.Baja:
                    if (_824_ecActividadEditable == null)
                    {
                        MessageBox.Show("No se ha especificado la Actividad a eliminar");
                        this.Close();
                        return;
                    }
                    _824_ecCargarCampos(_824_ecActividadEditable);
                    _824_eDeshabilitarCampos();
                    LBLnombree.Text = "NO RECOMENDABLE ELIMINAR ";
                    panel1.BackColor = Color.Red;
                    BTNconfirmar.Text = "Eliminar";
                    BTNconfirmar.BackColor = Color.IndianRed;
                    BTNconfirmar.ForeColor = Color.White;
                    BTNrestablecerCampos.Enabled = false;
                    BTNrestablecerCampos.Visible = false;
                    break;

                case Constantes.TiposOperacion.DeSesion:
                    if (_824_ecActividadEditable == null)
                    {
                        MessageBox.Show("No se ha especificado la Actividad para Ver");
                        this.Close();
                        return;
                    }
                    _824_ecCargarCampos(_824_ecActividadEditable);
                    _824_eDeshabilitarCampos();
                    LBLnombree.Text = "Vista de Actividad ";
                    panel1.BackColor = Color.DimGray;
                    BTNrestablecerCampos.Enabled = false;
                    BTNrestablecerCampos.Visible = false;
                    BTNconfirmar.Enabled = false;
                    BTNconfirmar.Visible = false;
                    break;

                default:
                    MessageBox.Show("Tipo de operacion invalido");
                    this.Close();
                    break;
            }
        }
        private void _824_eDeshabilitarCampos()
        {
            TXTnombre.Enabled = false;
            TXTlugar.Enabled = false;
            TXBdescripcion.Enabled = false;
            NUDmax.Enabled = false;
            NUDmin.Enabled = false;
            FechaActividad.Enabled = false;
            FechaCaducidad.Enabled = false;
            CMBcategoria.Enabled = false;
            CMBestado.Enabled = false;
            CMBnivel.Enabled = false;
        }
        private void _824_ecCargarCampos(_824_ecActividad _824_ecAct)
        {
            TXTnombre.Text = _824_ecAct.Nombre_824_ec;
            TXTlugar.Text = _824_ecAct.Ubicacion_824_ec;
            TXBdescripcion.Text = _824_ecAct.Descripcion_824_ec;
            NUDmax.Value = _824_ecAct.CantidadMaxima_824_ec;
            NUDmin.Value = _824_ecAct.CantidadMinima_824_ec;
            FechaActividad.Value = _824_ecAct.FechaHora_824_ec;
            FechaCaducidad.Value = _824_ecAct.FechaCaducidad_824_ec;
            if (_824_ecAct.Categoria_824_ec != null)
                CMBcategoria.SelectedItem = _824_ecAct.Categoria_824_ec.Nombre_824_ec;
            CMBestado.SelectedItem = _824_ecAct.Estado_824_ec;
            CMBnivel.SelectedItem = _824_ecAct.NivelRequerido_824_ec;
        }
        private void _824_ecLimpiarCampos()
        {
            TXTnombre.Text = "";
            TXTlugar.Text = "";
            TXBdescripcion.Clear();
            NUDmax.Value = 10;
            NUDmin.Value = 2;
            FechaCaducidad.Value = DateTime.Now.AddDays(3);
            FechaActividad.Value = DateTime.Now.AddDays(7);
            CMBcategoria.SelectedIndex = -1;
            CMBestado.SelectedItem = EstadoActividad_824_ec.Abierto;
            CMBestado.Enabled = false;
            CMBnivel.SelectedIndex = 0;
        }
        #endregion cargar

        #region botones
        private void ValorizarEntidad(_824_ecActividad act)
        {
            act.Nombre_824_ec = TXTnombre.Text.Trim();
            act.Ubicacion_824_ec = TXTlugar.Text.Trim();
            act.Descripcion_824_ec = TXBdescripcion.Text.Trim();

            // Categoria
            if (CMBcategoria.SelectedIndex >= 0 && _824_ecCats != null && CMBcategoria.SelectedIndex < _824_ecCats.Count)
            {
                act.Categoria_824_ec = _824_ecCats[CMBcategoria.SelectedIndex];
            }
            else
            {
                act.Categoria_824_ec = null;
            }

            // Nivel
            if (CMBnivel.SelectedItem != null)
            {
                act.NivelRequerido_824_ec = (NivelRequerido_824_ec)CMBnivel.SelectedItem;
            }

            // Estado
            if (_824_ecTipoOperacion == Constantes.TiposOperacion.Alta)
            {
                act.Estado_824_ec = EstadoActividad_824_ec.Abierto;
            }
            else if (CMBestado.SelectedItem != null)
            {
                if ((EstadoActividad_824_ec)CMBestado.SelectedItem != EstadoActividad_824_ec.Caducado)
                {
                    act.Estado_824_ec = (EstadoActividad_824_ec)CMBestado.SelectedItem;
                }
                else
                {
                    throw new Exception("Una actividad solo puede estar caducada si exede su fecha de caducidad");
                }
            }

            // Cupos
            act.CantidadMinima_824_ec = (int)NUDmin.Value;
            act.CantidadMaxima_824_ec = (int)NUDmax.Value;

            // Fechas
            act.FechaHora_824_ec = FechaActividad.Value;
            act.FechaCaducidad_824_ec = FechaCaducidad.Value;

            // Organizador
            if (act.Organizador_824_ec == null)
            {
                act.Organizador_824_ec = SessionManager.TraerInstancia().usuarioINS;
            }
        }
        private void BTNconfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_824_ecTipoOperacion)
                {
                    case Constantes.TiposOperacion.Alta:
                        if (_824_ecActividadEditable == null)
                            _824_ecActividadEditable = new _824_ecActividad();

                        ValorizarEntidad(_824_ecActividadEditable);

                        _824_ecActividadBLL.Guardar_824_ec(_824_ecActividadEditable);

                        SessionManager.TraerInstancia().RegistrarActividad("Alta de actividad: " + _824_ecActividadEditable.Nombre_824_ec);
                        MessageBox.Show("Actividad registrada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;

                    case Constantes.TiposOperacion.Modificacion:
                        bool confirmacion2 = true;
                        if (_824_ecActividadEditable == null)
                        {
                            MessageBox.Show("No se ha especificado la actividad a modificar.");
                            return;
                        }
                        if ((EstadoActividad_824_ec)CMBestado.SelectedItem == EstadoActividad_824_ec.Cancelado)
                        {
                            string mensaje2 = $"¿Está seguro de que desea Cancelar la actividad '{_824_ecActividadEditable.Nombre_824_ec}'?\n\nAdvertencia de seguridad: Una vez confirmada esta acción, esta actividad ya no se podra modificar.";
                            confirmacion2 = mostrarAdvertenciaDeConfirmacion(mensaje2);
                        }
                        if (confirmacion2)
                        {
                            ValorizarEntidad(_824_ecActividadEditable);
                            _824_ecActividadBLL.Modificar_824_ec(_824_ecActividadEditable, EstadoAnterior);

                            SessionManager.TraerInstancia().RegistrarActividad("Modificación de actividad: " + _824_ecActividadEditable.Nombre_824_ec);
                            MessageBox.Show("Actividad modificada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                        break;

                    case Constantes.TiposOperacion.Baja:
                        if (_824_ecActividadEditable == null)
                        {
                            MessageBox.Show("No se ha especificado la actividad a eliminar.");
                            return;
                        }
                        string mensaje = $"¿Está seguro de que desea eliminar permanentemente la actividad '{_824_ecActividadEditable.Nombre_824_ec}'?\n\nAdvertencia de seguridad: Una vez confirmada esta acción, no habrá marcha atrás.";
                        bool confirmacion = mostrarAdvertenciaDeConfirmacion(mensaje);
                        if (confirmacion)
                        {
                            _824_ecActividadBLL.Eliminar_824_ec(_824_ecActividadEditable.Id_824_ec);

                            SessionManager.TraerInstancia().RegistrarActividad("Baja permanente de actividad: " + _824_ecActividadEditable.Nombre_824_ec);
                            MessageBox.Show("Actividad eliminada permanentemente con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool mostrarAdvertenciaDeConfirmacion(string m)
        {
            DialogResult advertencia = MessageBox.Show(
                            m,
                            "Advertencia de Seguridad",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2
            );

            if (advertencia == DialogResult.Yes)
                return true;
            else
                return false;
        }
        private void BTNcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BTNrestablecerCampos_Click(object sender, EventArgs e)
        {
            _824_ecCargarCampos(_824_ecActividadEditable);
        }
        #endregion botones

    }
}
