using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria.De.Software
{
    internal interface IColeccionable
    {
        Constantes.EstadosColeccion EstadoColeccion { get; set; }
        int IndiceColeccion { get; set; }
    }
}
