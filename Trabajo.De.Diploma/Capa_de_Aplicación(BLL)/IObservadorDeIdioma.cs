using System.Collections.Generic;

namespace Capa_de_Aplicación_BLL_
{
    public interface IObservadorDeIdioma
    {
        void ActualizarIdioma(Dictionary<string, string> textos);
    }
}
