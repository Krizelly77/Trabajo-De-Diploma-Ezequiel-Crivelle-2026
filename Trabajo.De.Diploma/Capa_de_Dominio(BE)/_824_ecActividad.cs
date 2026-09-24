using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Capa_de_Dominio_BE_
{
    public class _824_ecActividad
    {
        public int Id_824_ec { get; set; }
        public string Nombre_824_ec { get; set; } // nombre personalizado por el organizador
        public string Descripcion_824_ec { get; set; } // descripcion personalizada por el organizador
        public _824_ecCategoria Categoria_824_ec { get; set; } // categoria a la que pertenece la actividad
        public DateTime FechaHora_824_ec { get; set; } // fecha hora donde se va a realizar la actividad
        public DateTime FechaPublicacion_824_ec { get; set; } // fecha y hora donde se publico la actividad
        public DateTime FechaCaducidad_824_ec { get; set; } // fecha hora donde no se permiten nuevas postulaciones
        public string Ubicacion_824_ec { get; set; } // lugar fisico donde se reuniran em fechahora
        public int CantidadMinima_824_ec { get; set; } // cantidad minima de participantes 
        public int CantidadMaxima_824_ec { get; set; } // cantidad maxia de participantes
        public NivelRequerido_824_ec NivelRequerido_824_ec { get; set; } // nivel de experiencia de la actividad
        public EstadoActividad_824_ec Estado_824_ec { get; set; } // estado en que se encuentra la actividad

        // usuario organizador que la creo
        public Usuario Organizador_824_ec { get; set; }

        // postulaciones recibidas
        public List<_824_ecPostulacion> Postulaciones_824_ec { get; set; }

        public _824_ecActividad()
        {
            Postulaciones_824_ec = new List<_824_ecPostulacion>();
            Estado_824_ec = EstadoActividad_824_ec.Cerrado;
            FechaPublicacion_824_ec = DateTime.Now;
        }
    }
}
