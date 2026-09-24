using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public class _824_ecBE_Enums
    {
        public enum NivelRequerido_824_ec // nivel de experiencia de la actividad
        {
            Indistinto = 0,
            Principiante = 1,
            Veterano = 2,
            Profesional = 3
        }

        public enum EstadoActividad_824_ec
        {
            Abierto = 1, // ABIERTO se recibern nuevas postulaciones
            Cerrado = 2, // CERRADO no se reciben nuevas postulaciones
            Caducado = 3, // CADUCADO se agoto el tiempo para completar el grupo
            Completado = 4, // COMPLETADO se conformo el grupo 
            Cancelado = 5 // CANCELADO el organizador cancelo la actividad
        }

        public enum EstadoPostulacion_824_ec
        {
            Postulado = 1, // el candidato envio una postulacion para participar 
            Aceptado = 2, // el organizador acepto la postulacion del candidato
            Rechazado = 3, // el organizador rechazo la postulacion del candidato
            Retirado = 4 // el candidato cancelo su postulacion 
        }
    }
}
