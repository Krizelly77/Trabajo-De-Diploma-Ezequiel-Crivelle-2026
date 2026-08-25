using Capa_de_Aplicación_BLL_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Ingenieria.De.Software
{
    public partial class FormIdioma : Form, IObservadorDeIdioma
    {
        public FormIdioma()
        {
            InitializeComponent();
        }

        private void FormIdioma_Load(object sender, EventArgs e)
        {
            GestorDeIdioma.TraerInstancia().Suscribir(this);
            CargarComboIdiomas();
            CargarGrilla();
            ActualizarIdioma(GestorDeIdioma.TraerInstancia().ObtenerTextos());
        }

        // Carga los idiomas disponibles en el combo leyendo las columnas de la tabla Etiqueta
        private void CargarComboIdiomas()
        {
            CMBidioma.Items.Clear();
            List<string> idiomas = GestorDeIdioma.TraerInstancia().ObtenerIdiomasDisponibles();
            foreach (string idioma in idiomas)
                CMBidioma.Items.Add(idioma);

            string actual = GestorDeIdioma.TraerInstancia().IdiomaActual;
            if (CMBidioma.Items.Contains(actual))
                CMBidioma.SelectedItem = actual;
        }

        // Carga la grilla con todas las etiquetas y sus traducciones
        private void CargarGrilla()
        {
            DataTable tabla = GestorDeIdioma.TraerInstancia().ObtenerTodasLasEtiquetas();
            DGVetiquetas.DataSource = tabla;

            if (DGVetiquetas.Columns["Clave"] != null)
                DGVetiquetas.Columns["Clave"].ReadOnly = true;

            DGVetiquetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVetiquetas.AllowUserToAddRows = false;
            DGVetiquetas.AllowUserToDeleteRows = false;
        }

        public void ActualizarIdioma(Dictionary<string, string> textos)
        {
            if (textos.ContainsKey("idioma_titulo"))    this.Text = textos["idioma_titulo"];
            if (textos.ContainsKey("idioma_aplicar"))   BTNaplicar.Text = textos["idioma_aplicar"];
            if (textos.ContainsKey("idioma_cerrar"))    BTNcerrar.Text = textos["idioma_cerrar"];
            if (textos.ContainsKey("idioma_nuevo_lbl")) LBLnuevoIdioma.Text = textos["idioma_nuevo_lbl"];
            if (textos.ContainsKey("idioma_agregar"))   BTNagregarIdioma.Text = textos["idioma_agregar"];
            if (textos.ContainsKey("idioma_guardar"))   BTNguardar.Text = textos["idioma_guardar"];
        }

        // Aplica el idioma seleccionado a toda la aplicacion
        private void BTNaplicar_Click(object sender, EventArgs e)
        {
            if (CMBidioma.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un idioma primero.");
                return;
            }
            GestorDeIdioma.TraerInstancia().CambiarIdioma(CMBidioma.SelectedItem.ToString());
        }

        // Agrega una nueva columna de idioma a la tabla Etiqueta
        private void BTNagregarIdioma_Click(object sender, EventArgs e)
        {
            string nuevoIdioma = TXTnuevoIdioma.Text.Trim();
            if (string.IsNullOrEmpty(nuevoIdioma))
            {
                MessageBox.Show("Ingrese el nombre del nuevo idioma.");
                return;
            }
            try
            {
                GestorDeIdioma.TraerInstancia().AgregarIdioma(nuevoIdioma);
                MessageBox.Show($"Idioma '{nuevoIdioma}' agregado. Complete las traducciones en la tabla.");
                TXTnuevoIdioma.Text = "";
                CargarComboIdiomas();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar idioma: " + ex.Message);
            }
        }

        // Guarda todas las traducciones editadas en la grilla
        private void BTNguardar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tabla = (DataTable)DGVetiquetas.DataSource;
                List<string> idiomas = GestorDeIdioma.TraerInstancia().ObtenerIdiomasDisponibles();

                foreach (DataRow fila in tabla.Rows)
                {
                    string clave = fila["Clave"].ToString();
                    foreach (string idioma in idiomas)
                    {
                        string texto = fila[idioma] == DBNull.Value ? "" : fila[idioma].ToString();
                        GestorDeIdioma.TraerInstancia().GuardarTraduccion(clave, idioma, texto);
                    }
                }
                MessageBox.Show("Traducciones guardadas correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void BTNcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormIdioma_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorDeIdioma.TraerInstancia().Desuscribir(this);
        }
    }
}
