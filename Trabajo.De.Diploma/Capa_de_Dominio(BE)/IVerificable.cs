using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public interface IVerificable
    {  //vuelve a una tabla verificable por el validador de integridad
        string DVH_824_ec { get; set; }
        List<string> ObtenerCamposParaDV();
    }
}
