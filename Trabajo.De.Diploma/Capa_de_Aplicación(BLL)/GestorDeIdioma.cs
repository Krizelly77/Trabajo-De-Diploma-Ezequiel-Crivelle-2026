using Capa_de_Acceso_a_Datos_DAL_;
using System.Collections.Generic;

namespace Capa_de_Aplicación_BLL_
{
    public class GestorDeIdioma
    {
        private static GestorDeIdioma instancia;
        private List<IObservadorDeIdioma> observadores = new List<IObservadorDeIdioma>();
        private string idiomaActual = "Español";
        private Dictionary<string, string> textosActuales;

        private GestorDeIdioma()
        {
            textosActuales = IdiomaDAL.ObtenerDiccionario(idiomaActual);
        }

        public static GestorDeIdioma TraerInstancia()
        {
            if (instancia == null)
                instancia = new GestorDeIdioma();
            return instancia;
        }

        public string IdiomaActual => idiomaActual;

        public void Suscribir(IObservadorDeIdioma obs)
        {
            if (!observadores.Contains(obs))
                observadores.Add(obs);
        }

        public void Desuscribir(IObservadorDeIdioma obs)
        {
            observadores.Remove(obs);
        }

        // Cambia el idioma activo y notifica a todos los formularios suscriptos
        public void CambiarIdioma(string idioma)
        {
            idiomaActual = idioma;
            textosActuales = IdiomaDAL.ObtenerDiccionario(idioma);
            Notificar();
        }

        public Dictionary<string, string> ObtenerTextos()
        {
            return textosActuales;
        }

        public List<string> ObtenerIdiomasDisponibles()
        {
            return IdiomaDAL.ObtenerIdiomas();
        }

        public System.Data.DataTable ObtenerTodasLasEtiquetas()
        {
            return IdiomaDAL.ObtenerTodasLasEtiquetas();
        }

        public void AgregarIdioma(string nombre)
        {
            IdiomaDAL.AgregarIdioma(nombre);
        }

        public void GuardarTraduccion(string clave, string idioma, string texto)
        {
            IdiomaDAL.ActualizarTraduccion(clave, idioma, texto);
        }

        private void Notificar()
        {
            foreach (var obs in observadores)
                obs.ActualizarIdioma(textosActuales);
        }
    }
}
