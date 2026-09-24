using Capa_de_Acceso_a_Datos_DAL_;
using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Capa_de_Aplicación_BLL_
{
    public class _824_ecPostulacionBLL
    {
        public static int RegistrarPostulacion_824_ec(_824_ecPostulacion postulacion_824_ec)
        {
            // Verificar que la actividad esté abierta
            if (postulacion_824_ec.Actividad_824_ec.Estado_824_ec != EstadoActividad_824_ec.Abierto)
                throw new Exception("No se pueden recibir postulaciones para una actividad que no se encuentra abierta.");

            // Validar que la fecha no haya caducado
            if (DateTime.Now > postulacion_824_ec.Actividad_824_ec.FechaCaducidad_824_ec)
            {
                _824_ecActividadBLL.VerificarCaducidad_824_ec(postulacion_824_ec.Actividad_824_ec);
                throw new Exception("La actividad ha caducado.");
            }

            // Validar duplicados
            List<_824_ecPostulacion> existentes_824_ec = _824_ecPostulacionDAL.ListarPorActividad_824_ec(postulacion_824_ec.Actividad_824_ec.Id_824_ec);
            if (existentes_824_ec.Any(p => p.Candidato_824_ec.Id == postulacion_824_ec.Candidato_824_ec.Id))
                throw new Exception("El usuario ya cuenta con una postulación registrada para esta actividad.");

            return _824_ecPostulacionDAL.Guardar_824_ec(postulacion_824_ec);
        }

        public static int EvaluarCandidato_824_ec(int postulacionId_824_ec, EstadoPostulacion_824_ec nuevoEstado_824_ec, _824_ecActividad actividad_824_ec)
        {
            int resultado_824_ec = _824_ecPostulacionDAL.ModificarEstado_824_ec(postulacionId_824_ec, nuevoEstado_824_ec);

            // Si se aceptó un candidato, verificamos el cupo del grupo
            if (nuevoEstado_824_ec == EstadoPostulacion_824_ec.Aceptado)
            {
                VerificarCupoYConformacion_824_ec(actividad_824_ec);
            }

            return resultado_824_ec;
        }

        public static void VerificarCupoYConformacion_824_ec(_824_ecActividad actividad_824_ec)
        {
            List<_824_ecPostulacion> postulaciones_824_ec = _824_ecPostulacionDAL.ListarPorActividad_824_ec(actividad_824_ec.Id_824_ec);
            int aceptados_824_ec = postulaciones_824_ec.Count(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado);

            // Si se alcanza el máximo de participantes, se cierra automáticamente la recepción
            if (aceptados_824_ec >= actividad_824_ec.CantidadMaxima_824_ec)
            {
                _824_ecActividadBLL.CambiarEstado_824_ec(actividad_824_ec.Id_824_ec, EstadoActividad_824_ec.Completado);
            }
        }

        public static List<_824_ecPostulacion> ListarCandidatosPorActividad_824_ec(int actividadId_824_ec)
        {
            return _824_ecPostulacionDAL.ListarPorActividad_824_ec(actividadId_824_ec);
        }
        public static List<_824_ecPostulacion> ListarActividadPorCandidato_824_ec(int idcandidato)
        {
            return _824_ecPostulacionDAL.ListarActividadPorCandidato_824_ec(idcandidato);
        }
    }
}
