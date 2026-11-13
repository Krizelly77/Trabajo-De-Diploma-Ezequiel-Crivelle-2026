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
            if (postulacion_824_ec == null)
                throw new Exception("La postulación no puede ser nula.");

            if (postulacion_824_ec.Actividad_824_ec == null)
                throw new Exception("Debe especificar una actividad válida.");

            if (postulacion_824_ec.GestorResponsable_824_ec == null)
                throw new Exception("Debe especificar el gestor responsable de la operación.");

            // Verificar que haya al menos un participante (individual o grupal)
            bool tieneIndividual = postulacion_824_ec.Participante_824_ec != null && postulacion_824_ec.Participante_824_ec.Id_824_ec > 0;
            bool tieneGrupo = postulacion_824_ec.ParticipantesAgrupados != null && postulacion_824_ec.ParticipantesAgrupados.Count > 0;

            if (!tieneIndividual && !tieneGrupo)
                throw new Exception("La postulación debe contener al menos un participante.");

            // Verificar que la actividad esté abierta
            if (postulacion_824_ec.Actividad_824_ec.Estado_824_ec != EstadoActividad_824_ec.Abierto)
                throw new Exception("No se pueden recibir postulaciones para una actividad que no se encuentra abierta.");

            // Validar que la fecha no haya caducado
            if (DateTime.Now > postulacion_824_ec.Actividad_824_ec.FechaCaducidad_824_ec)
            {
                _824_ecActividadBLL.VerificarCaducidad_824_ec(postulacion_824_ec.Actividad_824_ec);
                throw new Exception("La actividad ha caducado.");
            }

            // Validar que la cantidad a postular no supere los cupos disponibles
            List<_824_ecPostulacion> existentes_824_ec = _824_ecPostulacionDAL.ListarPorActividad_824_ec(postulacion_824_ec.Actividad_824_ec.Id_824_ec);
            int cuposOcupados = ContarParticipantesAceptados(existentes_824_ec);
            int nuevosIntegrantes = tieneGrupo ? postulacion_824_ec.ParticipantesAgrupados.Count : 1;

            if ((cuposOcupados + nuevosIntegrantes) > postulacion_824_ec.Actividad_824_ec.CantidadMaxima_824_ec)
                throw new Exception("La cantidad de participantes supera el cupo máximo disponible para esta actividad.");

            // Recopilar los IDs de los participantes involucrados en esta nueva solicitud
            List<int> idsNuevos = new List<int>();
            if (tieneIndividual)
                idsNuevos.Add(postulacion_824_ec.Participante_824_ec.Id_824_ec);
            if (tieneGrupo)
                idsNuevos.AddRange(postulacion_824_ec.ParticipantesAgrupados.Select(p => p.Id_824_ec));

            // Verificar si alguno de los participantes ya está postulado en esta actividad
            var existente = existentes_824_ec.FirstOrDefault(p =>
                (p.Participante_824_ec != null && idsNuevos.Contains(p.Participante_824_ec.Id_824_ec)) ||
                (p.ParticipantesAgrupados != null && p.ParticipantesAgrupados.Any(ag => idsNuevos.Contains(ag.Id_824_ec)))
            );

            if (existente != null)
            {
                switch (existente.Estado_824_ec)
                {
                    case EstadoPostulacion_824_ec.Postulado:
                    case EstadoPostulacion_824_ec.Aceptado:
                        throw new Exception("Uno o más participantes ya cuentan con una postulación activa para esta actividad.");

                    case EstadoPostulacion_824_ec.Rechazado:
                        throw new Exception("Uno o más participantes fueron rechazados previamente en esta actividad (el rechazo no es reversible).");

                    case EstadoPostulacion_824_ec.Retirado:
                        // Si es una postulación individual previa retirada, reutilizamos y reactivamos el registro
                        if (tieneIndividual && !tieneGrupo && existente.Participante_824_ec?.Id_824_ec == postulacion_824_ec.Participante_824_ec.Id_824_ec)
                        {
                            postulacion_824_ec.Id_824_ec = existente.Id_824_ec;
                            postulacion_824_ec.Estado_824_ec = EstadoPostulacion_824_ec.Postulado;
                            postulacion_824_ec.FechaPostulacion_824_ec = DateTime.Now;
                        }
                        else
                        {
                            // Si era parte de un grupo retirado y ahora viene distinto, se genera nueva postulación
                            postulacion_824_ec.Id_824_ec = 0;
                        }
                        break;
                }
            }

            int resultado = _824_ecPostulacionDAL.Guardar_824_ec(postulacion_824_ec);
            LlamarAlDigitoVerificador(resultado);
            return resultado;
        }


        public static bool EvaluarCandidatoAntesDeCambiarEstado_824_ec(int postulacionId_824_ec, EstadoPostulacion_824_ec viejoEstado_824_ec,  EstadoPostulacion_824_ec nuevoEstado_824_ec, _824_ecActividad actividad_824_ec)
        {
            bool aptoParaCompletar = false;

            if (viejoEstado_824_ec == nuevoEstado_824_ec)
                throw new Exception("La postulación ya se encuentra en estado: " + viejoEstado_824_ec.ToString());

            if (actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Completado)
                throw new Exception("No se pueden cambiar las postulaciones una vez que el grupo está completado.");

            if (viejoEstado_824_ec == EstadoPostulacion_824_ec.Rechazado && nuevoEstado_824_ec == EstadoPostulacion_824_ec.Retirado)
                throw new Exception("No se puede retirar una postulación que fue rechazada.");

            // Verificar cupos disponibles considerando postulaciones grupales
            List<_824_ecPostulacion> postulaciones_824_ec = _824_ecPostulacionDAL.ListarPorActividad_824_ec(actividad_824_ec.Id_824_ec);
            _824_ecPostulacion postulacionActual = postulaciones_824_ec.FirstOrDefault(p => p.Id_824_ec == postulacionId_824_ec);

            if (postulacionActual == null)
                throw new Exception("No se encontró la postulación especificada.");

            if (nuevoEstado_824_ec == EstadoPostulacion_824_ec.Aceptado)
            {
                int cuposOcupados = ContarParticipantesAceptados(postulaciones_824_ec);
                int integrantesEntrantes = (postulacionActual.ParticipantesAgrupados != null && postulacionActual.ParticipantesAgrupados.Count > 0)
                    ? postulacionActual.ParticipantesAgrupados.Count
                    : 1;

                if ((cuposOcupados + integrantesEntrantes) > actividad_824_ec.CantidadMaxima_824_ec)
                    throw new Exception($"No hay suficientes cupos disponibles. Cupos ocupados: {cuposOcupados}/{actividad_824_ec.CantidadMaxima_824_ec}, integrantes a aceptar: {integrantesEntrantes}.");
            }

            int resultado = _824_ecPostulacionDAL.ModificarEstado_824_ec(postulacionId_824_ec, nuevoEstado_824_ec);
            LlamarAlDigitoVerificador(resultado);

            if (nuevoEstado_824_ec == EstadoPostulacion_824_ec.Aceptado)
            {
                aptoParaCompletar = VerificarCupoYConformacion_824_ec(actividad_824_ec);
            }

            return aptoParaCompletar;
        }

        public static int RetirarPostulacionConValidacion_824_ec(int postulacionId, string documentoParticipante, string palabraClave)
        {
            // Método dedicado para retirar una postulación validando identidad mediante DNI y Palabra Clave
            if (!_824_ecParticipanteBLL.ValidarCredenciales_824_ec(documentoParticipante, palabraClave))
                throw new Exception("Credenciales inválidas: El documento o la palabra clave no coinciden.");

            _824_ecPostulacion pos = _824_ecPostulacionDAL.BuscarPorID_824_ec(postulacionId);
            if (pos == null)
                throw new Exception("No se encontró la postulación.");

            if (pos.Estado_824_ec == EstadoPostulacion_824_ec.Rechazado)
                throw new Exception("Una postulación rechazada no puede ser retirada.");

            if (pos.Estado_824_ec == EstadoPostulacion_824_ec.Retirado)
                throw new Exception("La postulación ya se encuentra retirada.");

            if (pos.Actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Completado)
                throw new Exception("No se puede retirar la postulación porque la actividad ya fue conformada.");

            int resultado = _824_ecPostulacionDAL.ModificarEstado_824_ec(postulacionId, EstadoPostulacion_824_ec.Retirado);
            LlamarAlDigitoVerificador(resultado);
            return resultado;
        }

        public static bool VerificarCupoYConformacion_824_ec(_824_ecActividad actividad_824_ec)
        {
            List<_824_ecPostulacion> postulaciones_824_ec = _824_ecPostulacionDAL.ListarPorActividad_824_ec(actividad_824_ec.Id_824_ec);
            int aceptados_824_ec = ContarParticipantesAceptados(postulaciones_824_ec);

            return aceptados_824_ec >= actividad_824_ec.CantidadMinima_824_ec;
        }
        private static int ContarParticipantesAceptados(List<_824_ecPostulacion> postulaciones)
        {
            // Calcula el total real de personas aceptadas (sumando 1 por individual y N por cada grupo)
            return postulaciones
                .Where(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado)
                .Sum(p => (p.ParticipantesAgrupados != null && p.ParticipantesAgrupados.Count > 0) ? p.ParticipantesAgrupados.Count: 1);
        }
        public static int Eliminar_824_ec(int idPostulacion)
        {
            int resultado = _824_ecPostulacionDAL.Eliminar_824_ec(idPostulacion);
            LlamarAlDigitoVerificador(resultado);
            return resultado;
        }

        private static void LlamarAlDigitoVerificador(int resultado)
        {
            DigitoVerificadorBLL dvBLL = new DigitoVerificadorBLL();
            if (resultado > 0)
            {
                dvBLL.RecalcularIntegridadTabla("Postulacion", "Postulacion_Id", _824_ecPostulacionDAL.ListarTodas_824_ec,
                    p => p.Id_824_ec,(p, dvh) => p.DVH_824_ec = dvh);
            }
        }

        // solo lectura
        public static List<_824_ecPostulacion> ListarActividadPorCandidato_824_ec(int idGestor)
        {
            return _824_ecPostulacionDAL.ListarActividadPorCandidato_824_ec(idGestor);
        }

        public static List<_824_ecPostulacion> ListarCandidatosPorActividad_824_ec(int actividadId_824_ec)
        {
            return _824_ecPostulacionDAL.ListarPorActividad_824_ec(actividadId_824_ec);
        }

        public static List<_824_ecPostulacion> ListarPorParticipante_824_ec(int idParticipante)
        {
            if (idParticipante <= 0)
                throw new Exception("El ID del participante especificado es inválido.");

            return _824_ecPostulacionDAL.ListarPorParticipante_824_ec(idParticipante);
        }

        public static List<_824_ecPostulacion> ListarTodas_824_ec()
        {
            return _824_ecPostulacionDAL.ListarTodas_824_ec();
        }

        public static _824_ecPostulacion BuscarPorID_824_ec(int idPostulacion)
        {
            return _824_ecPostulacionDAL.BuscarPorID_824_ec(idPostulacion);
        }

    }
}
