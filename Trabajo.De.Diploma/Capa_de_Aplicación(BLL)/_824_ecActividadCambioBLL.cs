using Capa_de_Acceso_a_Datos_DAL_;
using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Aplicación_BLL_
{
    public class _824_ecActividadCambioBLL
    {
        public static List<_824_ecActividadCambio> Listar_824_ec( int? actividadId_824_ec = null, string nombre_824_ec = null, DateTime? fechaIni_824_ec = null, DateTime? fechaFin_824_ec = null)
        {
            if (fechaIni_824_ec.HasValue && fechaFin_824_ec.HasValue && fechaIni_824_ec.Value.Date > fechaFin_824_ec.Value.Date)
                throw new Exception("La fecha de inicio no puede ser posterior a la fecha de fin.");

            return _824_ecActividadCambioDAL.Listar_824_ec(actividadId_824_ec, nombre_824_ec, fechaIni_824_ec, fechaFin_824_ec);
        }

        public static int Activar_824_ec(_824_ecActividadCambio cambio_824_ec)
        {
            if (cambio_824_ec == null || cambio_824_ec.IdHistorico_824_ec <= 0)
                throw new Exception("Debe seleccionar un registro válido de la bitácora.");

            if (cambio_824_ec.Act_824_ec)
                throw new Exception("El registro seleccionado ya se encuentra activo.");

            int resultado_824_ec = _824_ecActividadCambioDAL.Activar_824_ec(cambio_824_ec.IdHistorico_824_ec);

            if (resultado_824_ec > 0)
            {
                // Recalcular DVH de la tabla Actividad luego de que el trigger actualizó sus columnas
                DigitoVerificadorBLL dvBLL = new DigitoVerificadorBLL();
                dvBLL.RecalcularIntegridadTabla("Actividad", "Actividad_Id", _824_ecActividadDAL.ListarTodas_824_ec,
                    a => a.Id_824_ec, (a, dvh) => a.DVH_824_ec = dvh);
            }

            return resultado_824_ec;
        }
    }
}
