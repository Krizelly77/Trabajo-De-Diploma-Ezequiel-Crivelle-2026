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

            // Si es nueva, se establece el estado por defecto
            if (actividad_824_ec.Id_824_ec == 0)
            {
                actividad_824_ec.Estado_824_ec = EstadoActividad_824_ec.Abierto;
            }

            return _824_ecActividadDAL.Guardar_824_ec(actividad_824_ec);
        }

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

        public static bool VerificarCaducidad_824_ec(_824_ecActividad actividad_824_ec)
        { // de la forma lazy, cada que se pida la lista
            if (actividad_824_ec.Estado_824_ec == EstadoActividad_824_ec.Abierto &&
                DateTime.Now > actividad_824_ec.FechaCaducidad_824_ec)
            {
                actividad_824_ec.Estado_824_ec = EstadoActividad_824_ec.Caducado;
                _824_ecActividadDAL.ModificarEstado_824_ec(actividad_824_ec.Id_824_ec, EstadoActividad_824_ec.Caducado);
                return true;
            }
            return false;
        }

        public static int CambiarEstado_824_ec(int actividadId_824_ec, EstadoActividad_824_ec nuevoEstado_824_ec)
        {
            return _824_ecActividadDAL.ModificarEstado_824_ec(actividadId_824_ec, nuevoEstado_824_ec);
        }

        public static int Eliminar_824_ec(int actividadId_824_ec)
        {
            if (actividadId_824_ec <= 0)
                throw new Exception("Identificador de actividad inválido para eliminar.");

            return _824_ecActividadDAL.Eliminar_824_ec(actividadId_824_ec);
        }
    }
}
