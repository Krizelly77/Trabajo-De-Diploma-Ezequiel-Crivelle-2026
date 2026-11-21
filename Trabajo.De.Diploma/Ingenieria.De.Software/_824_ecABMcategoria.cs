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
    public partial class _824_ecABMcategoria : Form
    {
        public _824_ecABMcategoria()
        {
            InitializeComponent();
        }
        internal _824_ecCategoria _824_ecCategoriaEditable { get; set; }
        internal Constantes.TiposOperacion _824_ecTipoOperacion { get; set; }

        private void _824_ecABMcategoria_Load(object sender, EventArgs e)
        {
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
                    LBLtitulo.Text = "Crear Nueva Categoria";
                    break;

                case Constantes.TiposOperacion.Modificacion:
                    if (_824_ecCategoriaEditable == null)
                    {
                        MessageBox.Show("No se ha especificado la categoria a modificar");
                        this.Close();
                        return;
                    }
                    _824_ecCargarCampos(_824_ecCategoriaEditable);
                    LBLtitulo.Text = "Modificación de Categoria";
                    BTNrestablecerCampos.Enabled = true;
                    BTNrestablecerCampos.Visible = true;
                    break;

                case Constantes.TiposOperacion.Baja:
                    if (_824_ecCategoriaEditable == null)
                    {
                        MessageBox.Show("No se ha especificado la Categoria a eliminar");
                        this.Close();
                        return;
                    }
                    _824_ecCargarCampos(_824_ecCategoriaEditable);
                    _824_eDeshabilitarCampos();
                    LBLtitulo.Text = "NO RECOMENDABLE ELIMINAR ";
                    panel1.BackColor = Color.Red;
                    BTNconfirmar.Text = "Eliminar";
                    BTNconfirmar.BackColor = Color.IndianRed;
                    BTNconfirmar.ForeColor = Color.White;
                    break;

                case Constantes.TiposOperacion.DeSesion:
                    if (_824_ecCategoriaEditable == null)
                    {
                        MessageBox.Show("No se ha especificado la Categoria para Ver");
                        this.Close();
                        return;
                    }
                    _824_ecCargarCampos(_824_ecCategoriaEditable);
                    _824_eDeshabilitarCampos();
                    LBLtitulo.Text = "Vista de Categoria ";
                    panel1.BackColor = Color.DimGray;
                    BTNcancelar.Text = "OK";
                    BTNcancelar.ForeColor = Color.OliveDrab;
                    BTNconfirmar.Visible = false;
                    BTNconfirmar.Enabled = false;

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
            TXBdescripcion.Enabled = false;
        }
        private void _824_ecCargarCampos(_824_ecCategoria _824_ecAct)
        {
            TXTnombre.Text = _824_ecAct.Nombre_824_ec;
            TXBdescripcion.Text = _824_ecAct.Descripcion_824_ec;
        }
        private void _824_ecLimpiarCampos()
        {
            TXTnombre.Text = "";
            TXBdescripcion.Clear();
        }
        #endregion cargar

        //botones
        #region botones
        private void ValorizarEntidad(_824_ecCategoria act)
        {
            act.Nombre_824_ec = TXTnombre.Text.Trim();
            act.Descripcion_824_ec = TXBdescripcion.Text.Trim();
        }
        private void BTNconfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_824_ecTipoOperacion)
                {
                    case Constantes.TiposOperacion.Alta:
                        if (_824_ecCategoriaEditable == null)
                            _824_ecCategoriaEditable = new _824_ecCategoria(0); //0 indica que debe ser creado
                        ValorizarEntidad(_824_ecCategoriaEditable);
                        _824_ecCategoriaBLL.Guardar_824_ec(_824_ecCategoriaEditable);
                        SessionManager.TraerInstancia().RegistrarActividad("Alta de Categoria: " + _824_ecCategoriaEditable.Nombre_824_ec);
                        this.Close();
                        break;

                    case Constantes.TiposOperacion.Modificacion:
                        ValorizarEntidad(_824_ecCategoriaEditable);
                        _824_ecCategoriaBLL.Guardar_824_ec(_824_ecCategoriaEditable);
                        SessionManager.TraerInstancia().RegistrarActividad("Modificacion de Categoria: " + _824_ecCategoriaEditable.Nombre_824_ec);
                        this.Close();
                        break;

                    case Constantes.TiposOperacion.Baja:
                        _824_ecCategoriaBLL.Eliminar_824_ec(_824_ecCategoriaEditable);
                        SessionManager.TraerInstancia().RegistrarActividad("Baja de Categoria: " + _824_ecCategoriaEditable.Nombre_824_ec);
                        this.Close();
                        break;

                    case Constantes.TiposOperacion.DeSesion:
                        this.Close();
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BTNcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BTNrestablecerCampos_Click(object sender, EventArgs e)
        {
            _824_ecCargarCampos(_824_ecCategoriaEditable);
        }
        #endregion botones

        private void TXTnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TXBdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
