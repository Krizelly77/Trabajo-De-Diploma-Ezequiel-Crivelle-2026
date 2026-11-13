using Capa_de_Acceso_a_Datos_DAL_;
using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Aplicación_BLL_
{
    public class _824_ecSolicitanteBLL
    {
        public static int Guardar_824_ec(_824_ecSolicitante sol)
        {
            if (sol == null)
                throw new Exception("El solicitante no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(sol.Nombre_824_ec) || string.IsNullOrWhiteSpace(sol.Apellido_824_ec))
                throw new Exception("El nombre y apellido del solicitante son obligatorios.");

            int resultado = _824_ecSolicitanteDAL.Guardar_824_ec(sol);
            LlamarAlDigitoVerificador(resultado);

            return resultado;
        }

        public static int Eliminar_824_ec(_824_ecSolicitante sol)
        {
            int resultado = _824_ecSolicitanteDAL.Eliminar_824_ec(sol);
            LlamarAlDigitoVerificador(resultado);

            return resultado;
        }

        // solo lectura

        private static void LlamarAlDigitoVerificador(int resultado)
        {
            DigitoVerificadorBLL dvBLL = new DigitoVerificadorBLL();

            if (resultado > 0)
            {
                dvBLL.RecalcularIntegridadTabla("Solicitante", "Solicitante_Id", _824_ecSolicitanteDAL.ListarTodos_824_ec,
                    c => c.Id_824_ec, (c, dvh) => c.DVH_824_ec = dvh);
            }
        }

        public static _824_ecSolicitante ObtenerPorId_824_ec(int id_824_ec)
        {
            return _824_ecSolicitanteDAL.ObtenerPorId_824_ec(id_824_ec);
        }

        public static List<_824_ecSolicitante> ListarTodos_824_ec()
        {
            return _824_ecSolicitanteDAL.ListarTodos_824_ec();
        }
        // Carga diferida / explícita de postulaciones a pedido mediante un método
        public static _824_ecSolicitante ObtenerPorDocumento_824_ec(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                throw new Exception("Debe seleccionar un documento para buscar");

            List<_824_ecSolicitante> todos = ListarTodos_824_ec();
            return todos.FirstOrDefault(s => s.Documento_824_ec == documento && s.Activo_824_ec);
        }
        public static void CargarActividades_824_ec(_824_ecSolicitante sol)
        {
            _824_ecSolicitanteDAL.CargarActividades_824_ec(sol);
        }
        public static List<_824_ecActividad> ListarActividadesPorSolicitante_824_ec(int idSolicitante)
        {
            return _824_ecSolicitanteDAL.ListarActividadesPorSolicitante_824_ec(idSolicitante);
        }
    }
}
