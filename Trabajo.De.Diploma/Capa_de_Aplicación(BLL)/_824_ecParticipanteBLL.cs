using Capa_de_Acceso_a_Datos_DAL_;
using Capa_de_Dominio_BE_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Aplicación_BLL_
{
    public class _824_ecParticipanteBLL
    {
        public static int Guardar_824_ec(_824_ecParticipante participante_824_ec)
        {
            if (string.IsNullOrWhiteSpace(participante_824_ec.Nombre_824_ec) || string.IsNullOrWhiteSpace(participante_824_ec.Apellido_824_ec))
                throw new Exception("El nombre y apellido del participante es obligatorio.");

            if (string.IsNullOrWhiteSpace(participante_824_ec.PalabraClave_824_ec))
                throw new Exception("La palabra clave de seguridad es obligatoria.");

            CryptoManager crypto = new CryptoManager();

            // Si es un nuevo participante o se ingresó una clave en texto plano, la hasheamos antes de persistir
            if (participante_824_ec.Id_824_ec == 0 || !EsHashSHA256(participante_824_ec.PalabraClave_824_ec))
            {
                participante_824_ec.PalabraClave_824_ec = crypto.Hash(participante_824_ec.PalabraClave_824_ec);
            }

            int resultado = _824_ecParticipanteDAL.Guardar_824_ec(participante_824_ec);
            LlamarAlDigitoVerificador(resultado);

            return resultado;
        }

        public static int Eliminar_824_ec(_824_ecParticipante participante_824_ec)
        {
            int resultado = _824_ecParticipanteDAL.Eliminar_824_ec(participante_824_ec);

            return resultado;
        }


        //solo lectura
        private static void LlamarAlDigitoVerificador(int resultado)
        {
            DigitoVerificadorBLL dvBLL = new DigitoVerificadorBLL();

            if (resultado > 0)
            {
                dvBLL.RecalcularIntegridadTabla("Participante", "Participante_Id", _824_ecParticipanteDAL.ListarTodos_824_ec,
                    c => c.Id_824_ec, (c, dvh) => c.DVH_824_ec = dvh);
            }
        }

        public static List<_824_ecParticipante> ListarTodos_824_ec()
        {
            return _824_ecParticipanteDAL.ListarTodos_824_ec();
        }

        public static _824_ecParticipante ObtenerPorId_824_ec(int id_824_ec)
        {
            return _824_ecParticipanteDAL.ObtenerPorId_824_ec(id_824_ec);
        }
        // Carga diferida / explícita de postulaciones a pedido mediante un método
        public static void CargarPostulaciones_824_ec(_824_ecParticipante parti)
        {
            _824_ecParticipanteDAL.CargarPostulaciones_824_ec(parti);
        }
        public static List<_824_ecPostulacion> ListarPostulacionesPorParticipante_824_ec(int idParticipante)
        {
            return _824_ecParticipanteDAL.ListarPostulacionesPorParticipante_824_ec(idParticipante);
        }

        // metodos auxiliares
        #region auxiliares
        public static bool ValidarCredenciales_824_ec(string documento, string palabraClaveIngresada)
        {
            if (string.IsNullOrWhiteSpace(documento) || string.IsNullOrWhiteSpace(palabraClaveIngresada))
                return false;

            List<_824_ecParticipante> todos = ListarTodos_824_ec();
            _824_ecParticipante participante = todos.FirstOrDefault(p => p.Documento_824_ec == documento && p.Activo_824_ec);

            if (participante == null || string.IsNullOrEmpty(participante.PalabraClave_824_ec))
                return false;

            CryptoManager crypto = new CryptoManager();
            return crypto.Compare(palabraClaveIngresada, participante.PalabraClave_824_ec);
        }
        private static bool EsHashSHA256(string texto)
        {
            if (string.IsNullOrEmpty(texto) || texto.Length != 64)
                return false;

            return texto.All(c => (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));
        }
        #endregion auxiliares

    }
}
