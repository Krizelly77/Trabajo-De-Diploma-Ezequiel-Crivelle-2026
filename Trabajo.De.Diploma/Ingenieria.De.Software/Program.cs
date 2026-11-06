using Capa_de_Aplicación_BLL_;
using Capa_de_Servicios_SL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingenieria.De.Software
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // 1. Conecta a master, verifica/crea la BD y ejecuta script_inicial.sql si no existe
                _824_ecDatabaseInitializerBLL.EnsureDatabaseExists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al inicializar la base de datos:\n\n{ex.Message}",
                    "Error de Inicialización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Detiene la ejecución para no abrir la UI sin base de datos
                return;
            }

            SessionManager.TraerInstancia().Suscribir(new BitacoraObserver());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
