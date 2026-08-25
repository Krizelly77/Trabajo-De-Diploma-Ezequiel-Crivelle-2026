using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria.De.Software
{
    internal class Constantes
    {
        public enum EstadosColeccion { SinCambio, Agregado, Modificado, Eliminado, Quitado };

        public enum TiposOperacion { Alta, Baja, Modificacion }
    }
}
