using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Servicios_SL_
{
    public static class _824_ecDirectivosManejador
    {
        public static string ObtenerRutaCarpetaDefault(string subcarpeta = "")
        {
            // Apunta a: C:\Users\<Usuario>\AppData\Roaming\SistemaParaArmarParticiparActividades
            string rutaBase = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "SistemaParaArmarParticiparActividades"
            );

            if (!string.IsNullOrEmpty(subcarpeta))
            {
                rutaBase = Path.Combine(rutaBase, subcarpeta);
            }

            // Si la carpeta no existe, C# la crea automáticamente en el acto
            if (!Directory.Exists(rutaBase))
            {
                Directory.CreateDirectory(rutaBase);
            }

            return rutaBase;
        }
    }
}
