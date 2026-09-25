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
    public class _824_ecActividadBLL
    {
        

        public static int Guardar_824_ec(_824_ecActividad actividad_824_ec)
        {
            ValidacionGuardarModificar(actividad_824_ec);

            // Si es nueva, se establece el estado por defecto
            if (actividad_824_ec.Id_824_ec == 0)
            {
                actividad_824_ec.Estado_824_ec = EstadoActividad_824_ec.Abierto;
            }
            else
                throw new Exception("Algo salio mal, Para crear una nueva actividad esta tine que tener en un principo id = 0");


            int resultado = _824_ecActividadDAL.Guardar_824_ec(actividad_824_ec);
            LlamaraAlDigitoVerificador(resultado);

            return resultado;
        }
        public static int Modificar_824_ec(_824_ecActividad actividad_824_ec, EstadoActividad_824_ec estadoAnterior_824_ec)
        {
            ValidacionGuardarModificar(actividad_824_ec);

            if (estadoAnterior_824_ec == EstadoActividad_824_ec.Completado || estadoAnterior_824_ec == EstadoActividad_824_ec.Caducado || estadoAnterior_824_ec == EstadoActividad_824_ec.Cancelado)
                throw new Exception("No se puede modificar una actividad ya "+estadoAnterior_824_ec.ToString());

            // para comprobar que se alcanzo la cantidad minima para confirmar 
            List<_824_ecPostulacion> postulaciones_824_ec = _824_ecPostulacionDAL.ListarPorActividad_824_ec(actividad_824_ec.Id_824_ec);
            int Cupos_824_ec = postulaciones_824_ec.Count(p => p.Estado_824_ec == EstadoPostulacion_824_ec.Aceptado);
            if (Cupos_824_ec < actividad_824_ec.CantidadMinima_824_ec && actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Completado)
                throw new Exception("Cupo minimo no alcanzado");


            int resultado = _824_ecActividadDAL.Guardar_824_ec(actividad_824_ec);
            LlamaraAlDigitoVerificador(resultado);

            return resultado;
        }


        private static void ValidacionGuardarModificar(_824_ecActividad actividad_824_ec)
        {
            if (string.IsNullOrWhiteSpace(actividad_824_ec.Nombre_824_ec)) // validar nombre
                throw new Exception("El nombre de la actividad es obligatorio");

            if (actividad_824_ec.Nombre_824_ec.Length > 30) // validar nombre
                throw new Exception("Maximo 30 caracteres");

            if (actividad_824_ec.Categoria_824_ec == null || actividad_824_ec.Categoria_824_ec.Id_824_ec == 0)
                throw new Exception("Debe seleccionar una categoria valida");

            if (actividad_824_ec.CantidadMinima_824_ec <= 0)
                throw new Exception("La cantidad minima de participantes debe ser mayor a cero");

            if (actividad_824_ec.CantidadMaxima_824_ec <= actividad_824_ec.CantidadMinima_824_ec)
                throw new Exception("La cantidad maxima no puede ser inferior ni igual a la cantidad minima");

            if (string.IsNullOrWhiteSpace(actividad_824_ec.Ubicacion_824_ec))
                throw new Exception("Es obligatorio establecer un lugar de reunion");

            if (actividad_824_ec.FechaCaducidad_824_ec <= DateTime.Now)
                throw new Exception("La fecha de caducidad debe ser posterior a la fecha actual");

            if (actividad_824_ec.FechaHora_824_ec <= actividad_824_ec.FechaCaducidad_824_ec)
                throw new Exception("La fecha de realización debe ser posterior o igual a la fecha de caducidad");

            if (actividad_824_ec.Organizador_824_ec == null || actividad_824_ec.Organizador_824_ec.Id == 0)
                throw new Exception("La actividad debe tener un organizador asignado.");
        }

        private static void LlamaraAlDigitoVerificador(int resultado, bool post = false)
        {
            DigitoVerificadorBLL dvBLL = new DigitoVerificadorBLL();
            if (resultado > 0)
            {
                dvBLL.RecalcularIntegridadTabla("Actividad", "Actividad_Id", _824_ecActividadDAL.ListarTodas_824_ec,
                    a => a.Id_824_ec, (a, dvh) => a.DVH_824_ec = dvh);
            }
            if (post)
            {
                dvBLL.RecalcularIntegridadTabla("Postulacion", "Postulacion_Id", _824_ecPostulacionDAL.ListarTodas_824_ec,
                    p => p.Id_824_ec, (p, dvh) => p.DVH_824_ec = dvh);
            }
        }


        public static bool VerificarCaducidad_824_ec(_824_ecActividad actividad_824_ec)
        { // de la forma lazy, cada que se pida la lista
            if (actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Abierto &&
                DateTime.Now > actividad_824_ec.FechaCaducidad_824_ec)
            {
                actividad_824_ec.Estado_824_ec = EstadoActividad_824_ec.Caducado;
                int resultado = _824_ecActividadDAL.ModificarEstado_824_ec(actividad_824_ec.Id_824_ec, EstadoActividad_824_ec.Caducado);
                LlamaraAlDigitoVerificador(resultado);
            }
            return false;
        }

        public static int CambiarEstado_824_ec(int actividadId_824_ec, EstadoActividad_824_ec nuevoEstado_824_ec)
        {
            int resultado = _824_ecActividadDAL.ModificarEstado_824_ec(actividadId_824_ec, nuevoEstado_824_ec);
            LlamaraAlDigitoVerificador(resultado);
            return resultado;
        }

        public static int Eliminar_824_ec(int actividadId_824_ec)
        {
            if (actividadId_824_ec <= 0)
                throw new Exception("Identificador de actividad inválido para eliminar.");

            int resultado = _824_ecActividadDAL.Eliminar_824_ec(actividadId_824_ec);
            LlamaraAlDigitoVerificador(resultado, true);

            return resultado;
        }

        // buscar
        public static List<_824_ecActividad> ListarTodas_824_ec()
        {
            List<_824_ecActividad> lista_824_ec = _824_ecActividadDAL.ListarTodas_824_ec();

            // Verificación automática de caducidad al listar
            foreach (var act_824_ec in lista_824_ec)
            {
                VerificarCaducidad_824_ec(act_824_ec);
            }

            return lista_824_ec;
        }
        public static _824_ecActividad ObtenerPorId_824_ec(int _824_ecID)
        {
            return _824_ecActividadDAL.ObtenerPorId_824_ec(_824_ecID);
        }
    }
}
