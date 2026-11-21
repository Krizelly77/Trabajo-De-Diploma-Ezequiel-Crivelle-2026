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
        // WIP para bitacora(o verciones o lo que en realidad sea)

        public int IdHistorico_824_ec { get; set; }
        public int Id_824_ec { get; set; }
        public DateTime Fecha_824_ec { get; set; }
        public string Hora_824_ec { get; set; }
        public string Nombre_824_ec { get; set; }
        public string Descripcion_824_ec { get; set; }
        public int? CategoriaId_824_ec { get; set; }
        public DateTime FechaHora_824_ec { get; set; }
        public DateTime FechaPublicacion_824_ec { get; set; }
        public DateTime FechaCaducidad_824_ec { get; set; }
        public string Ubicacion_824_ec { get; set; }
        public int CantidadMinima_824_ec { get; set; }
        public int CantidadMaxima_824_ec { get; set; }
        public NivelRequerido_824_ec NivelRequerido_824_ec { get; set; }
        public EstadoActividad_824_ec Estado_824_ec { get; set; }
        public int? OrganizadorId_824_ec { get; set; }
        public int? SolicitanteId_824_ec { get; set; }
        public bool ActividadActivo_824_ec { get; set; }
        public bool Act_824_ec { get; set; }
    }
}
