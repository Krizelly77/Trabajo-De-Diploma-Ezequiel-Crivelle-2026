using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public class RegistroCambio
    {
        public int Id { get; set; }
        public string EntidadNombre { get; set; }
        public int EntidadId { get; set; }
        public string NombreCampo { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }
        public string Operador { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
