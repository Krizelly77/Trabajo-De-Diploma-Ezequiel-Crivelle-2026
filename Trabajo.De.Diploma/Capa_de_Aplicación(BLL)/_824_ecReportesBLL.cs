using Capa_de_Acceso_a_Datos_DAL_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;

namespace Capa_de_Aplicación_BLL_
{
    public class _824_ecReportesBLL
    {
        public static PrintDocument PrepararReporte_824_ec(string contenido)
        {
            if (string.IsNullOrWhiteSpace(contenido))
                throw new Exception(
                    "No se puede generar un reporte sin contenido.");

            _824_ecGestorPdf gestor = new _824_ecGestorPdf();

            gestor.ConfigurarReporte_824_ec(contenido);

            return gestor.ObtenerDocumento_824_ec();
        }
    }
}
