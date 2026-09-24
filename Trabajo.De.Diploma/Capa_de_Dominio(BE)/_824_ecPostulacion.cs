using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Capa_de_Dominio_BE_
{
    public class _824_ecPostulacion
    { // clase eintermedia entre el candidato y la actividad 
        public int Id_824_ec { get; set; } 
        public _824_ecActividad Actividad_824_ec { get; set; } 
        public Usuario Candidato_824_ec { get; set; }
        public DateTime FechaPostulacion_824_ec { get; set; }
        public EstadoPostulacion_824_ec Estado_824_ec { get; set; }

        public _824_ecPostulacion()
        {
            FechaPostulacion_824_ec = DateTime.Now;
            Estado_824_ec = EstadoPostulacion_824_ec.Postulado;
        }
    }
}
