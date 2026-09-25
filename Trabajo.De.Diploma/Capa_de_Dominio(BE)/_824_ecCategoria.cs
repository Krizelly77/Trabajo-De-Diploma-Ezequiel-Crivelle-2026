using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public class _824_ecCategoria : IVerificable
    { //categoria para las actividades, podria necesitar un abm
        public int Id_824_ec { get; set; }
        public string Nombre_824_ec { get; set; }
        public string Descripcion_824_ec { get; set; }

        public string DVH_824_ec { get; set; } // digito verificador
        public List<string> ObtenerCamposParaDV()
        {

            return new List<string>
            {
                this.Id_824_ec.ToString(),
                this.Nombre_824_ec ?? string.Empty,
                this.Descripcion_824_ec
            };
        }
    }
}
