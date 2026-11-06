using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capa_de_Acceso_a_Datos_DAL_
{
    public static class _824_ecDatabaseInitializer
    {
        public static void EnsureDatabaseExists()
        {
            var connectionSetting = ConfigurationManager.ConnectionStrings["ConexionMaster"];
            if (connectionSetting == null || string.IsNullOrWhiteSpace(connectionSetting.ConnectionString))
            {
                throw new ConfigurationErrorsException("No se encontró la cadena de conexión 'ConexionMaster' en el archivo App.config.");
            }

            string cadenaMaster = connectionSetting.ConnectionString;
            string nombreBD = "DB_ingenieria_de_software";

            using (SqlConnection mCon = new SqlConnection(cadenaMaster))
            {
                mCon.Open();

                // 1. Verificar si la BD ya existe
                string checkDbQuery = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{nombreBD}'";
                using (SqlCommand cmdCheck = new SqlCommand(checkDbQuery, mCon))
                {
                    int dbCount = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (dbCount == 0)
                    {
                        // 2. Si no existe, crear la base de datos vacía en master
                        string createDbQuery = $"CREATE DATABASE [{nombreBD}]";
                        using (SqlCommand cmdCreate = new SqlCommand(createDbQuery, mCon))
                        {
                            cmdCreate.ExecuteNonQuery();
                        }

                        // 3. Cambiar el contexto a la base recién creada
                        mCon.ChangeDatabase(nombreBD);

                        // 4. Leer y ejecutar el script inicial de tablas y datos
                        string rutaScript = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "script_inicial.sql");

                        if (File.Exists(rutaScript))
                        {
                            string scriptSql = File.ReadAllText(rutaScript);
                            string[] comandos = Regex.Split(scriptSql, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                            foreach (var cmdText in comandos)
                            {
                                if (!string.IsNullOrWhiteSpace(cmdText))
                                {
                                    using (SqlCommand cmdScript = new SqlCommand(cmdText, mCon))
                                    {
                                        cmdScript.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new FileNotFoundException($"No se encontró el archivo 'script_inicial.sql' en la ruta: {rutaScript}");
                        }
                    }
                }
            }
        }
    }
}
