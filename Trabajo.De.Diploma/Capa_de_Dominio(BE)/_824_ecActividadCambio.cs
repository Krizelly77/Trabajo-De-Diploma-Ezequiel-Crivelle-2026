using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Capa_de_Dominio_BE_
{
    public class _824_ecActividadCambio
    {
        // WIP para bitacora

        public int Id_824_ec { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Nombre_824_ec { get; set; }
        public string Descripcion_824_ec { get; set; }
        public DateTime FechaHora_824_ec { get; set; }
        public string Ubicacion_824_ec { get; set; }
        public int CantidadMinima_824_ec { get; set; }
        public int CantidadMaxima_824_ec { get; set; }
        public EstadoActividad_824_ec Estado_824_ec { get; set; }
        public bool Act { get; set; }
    }
}
