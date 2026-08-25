using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Dominio_BE_;

namespace Capa_de_Servicios_SL_
{
    public class ValidadorDeIntegridad
    {
        private readonly CryptoManager encriptador = new CryptoManager();

        public string CalcularDVH(IVerificable entidad)
        {
            // calcula el digito verificador horizontal y lo hashea 
            List<string> atributos = entidad.ObtenerCamposParaDV();
            long sumaHasheable = 0;

            for (int i = 0; i < atributos.Count; i++)
            {
                int posicionAtributo = i + 1;
                string valorAtributo = atributos[i] ?? string.Empty;
                for (int j = 0; j < valorAtributo.Length; j++)
                {
                    int codigoASCII = (int)valorAtributo[j];
                    int posicionCaracter = j + 1;
                    sumaHasheable += (long)codigoASCII * posicionCaracter * posicionAtributo;
                }
            }
            return encriptador.Hash(sumaHasheable.ToString());
        }

        public string CalcularDVV(List<string> listaDVH)
        {
            // calcula el digito verificador vertical y lo hashea
            StringBuilder builder = new StringBuilder();
            foreach (var dvh in listaDVH)
            {
                builder.Append(dvh);
            }
            return encriptador.Hash(builder.ToString());
        }
    }
}
