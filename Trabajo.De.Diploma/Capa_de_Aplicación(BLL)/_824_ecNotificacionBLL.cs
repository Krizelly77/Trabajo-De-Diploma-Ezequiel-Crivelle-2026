using Capa_de_Acceso_a_Datos_DAL_;
using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Aplicación_BLL_
{
    public class _824_ecNotificacionBLL
    {
        public static int Guardar_824_ec(_824_ecNotificacion notificacion_824_ec)
        {
            ValidarNotificacion_824_ec(notificacion_824_ec);

            int resultado = _824_ecNotificacionDAL.Guardar_824_ec(notificacion_824_ec);
            LlamarAlDigitoVerificador_824_ec(resultado);

            return resultado;
        }

        public static void ValidarNotificacion_824_ec(_824_ecNotificacion notificacion_824_ec)
        {
            if (notificacion_824_ec == null)
                throw new Exception("La notificación provista no puede ser nula.");

            // 1. Validación de tamaño y formato del Asunto
            if (string.IsNullOrWhiteSpace(notificacion_824_ec.Asunto_824_ec))
                throw new Exception("El asunto de la notificación es obligatorio.");

            notificacion_824_ec.Asunto_824_ec = notificacion_824_ec.Asunto_824_ec.Trim();

            if (notificacion_824_ec.Asunto_824_ec.Length < 3)
                throw new Exception("El asunto de la notificación debe contener al menos 3 caracteres.");

            if (notificacion_824_ec.Asunto_824_ec.Length > 100)
                throw new Exception("El asunto de la notificación no puede superar los 100 caracteres.");

            // 2. Validación de tamaño y formato del Mensaje
            if (string.IsNullOrWhiteSpace(notificacion_824_ec.Mensaje_824_ec))
                throw new Exception("El mensaje de la notificación es obligatorio.");

            notificacion_824_ec.Mensaje_824_ec = notificacion_824_ec.Mensaje_824_ec.Trim();

            if (notificacion_824_ec.Mensaje_824_ec.Length < 3)
                throw new Exception("El mensaje de la notificación debe contener al menos 3 caracteres.");

            if (notificacion_824_ec.Mensaje_824_ec.Length > 500)
                throw new Exception("El mensaje de la notificación no puede superar los 500 caracteres.");

            // 3. Comprobación de existencia de usuarios por ID
            if (notificacion_824_ec.IdDestinatario_824_ec <= 0)
                throw new Exception("El ID de destinatario es inválido.");

            Usuario destinatario = UsuarioBLL.ObtenerPorId(notificacion_824_ec.IdDestinatario_824_ec);
            if (destinatario == null)
                throw new Exception($"El usuario destinatario con ID {notificacion_824_ec.IdDestinatario_824_ec} no existe en el sistema.");

            if (notificacion_824_ec.IdRemitente_824_ec <= 0)
                throw new Exception("El ID de remitente es inválido.");

            Usuario remitente = UsuarioBLL.ObtenerPorId(notificacion_824_ec.IdRemitente_824_ec);
            if (remitente == null)
                throw new Exception($"El usuario remitente con ID {notificacion_824_ec.IdRemitente_824_ec} no existe en el sistema.");
        }

        private static void LlamarAlDigitoVerificador_824_ec(int resultado)
        {
            DigitoVerificadorBLL dvBLL = new DigitoVerificadorBLL();

            if (resultado > 0)
            {
                dvBLL.RecalcularIntegridadTabla("Notificacion", "Notificacion_Id", _824_ecNotificacionDAL.Listar_824_ec,
                    n => n.Id_824_ec, (n, dvh) => n.DVH_824_ec = dvh);
            }
        }

        public static List<_824_ecNotificacion> Listar_824_ec()
        {
            return _824_ecNotificacionDAL.Listar_824_ec();
        }

        public static List<_824_ecNotificacion> ListarPorDestinatario_824_ec(int idDestinatario_824_ec)
        {
            if (idDestinatario_824_ec <= 0)
                throw new Exception("El ID de destinatario especificado es inválido.");

            return _824_ecNotificacionDAL.ListarPorDestinatario_824_ec(idDestinatario_824_ec);
        }

        public static _824_ecNotificacion ObtenerPorId_824_ec(int id_824_ec)
        {
            return _824_ecNotificacionDAL.ObtenerPorId_824_ec(id_824_ec);
        }

        public static int MarcarComoLeida_824_ec(int idNotificacion_824_ec)
        {
            int resultado = _824_ecNotificacionDAL.MarcarComoLeida_824_ec(idNotificacion_824_ec);
            LlamarAlDigitoVerificador_824_ec(resultado);
            return resultado;
        }

        public static int Eliminar_824_ec(int idNotificacion_824_ec)
        {
            int resultado = _824_ecNotificacionDAL.Eliminar_824_ec(idNotificacion_824_ec);
            LlamarAlDigitoVerificador_824_ec(resultado);
            return resultado;
        }

    }
}
