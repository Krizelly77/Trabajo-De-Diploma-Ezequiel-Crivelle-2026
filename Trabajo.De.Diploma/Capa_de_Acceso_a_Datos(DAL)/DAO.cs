using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Capa_de_Acceso_a_Datos_DAL_
{
    public class DAO
    {
        private readonly string cadenaConexion;
        public DAO()
        {
            var connectionSetting = ConfigurationManager.ConnectionStrings["MiConexionBiblioteca"];

            if (connectionSetting == null || string.IsNullOrWhiteSpace(connectionSetting.ConnectionString))
            {
                throw new ConfigurationErrorsException("No se encontró la cadena de conexión 'MiConexionBiblioteca' en el archivo App.config.");
            }

            cadenaConexion = connectionSetting.ConnectionString;
        }

        public DataSet ObtenerDataSet(string comando, List<SqlParameter> parametros = null)
        {
            try
            {

                using (SqlConnection mCon = new SqlConnection(cadenaConexion))
                {
                    SqlCommand coma = new SqlCommand(comando, mCon);
                    if (parametros != null) coma.Parameters.AddRange(parametros.ToArray());

                    SqlDataAdapter adaptador = new SqlDataAdapter(coma);
                    DataSet seta = new DataSet();
                    adaptador.Fill(seta);
                    coma.Parameters.Clear();
                    return seta;
                }
            }
            catch (Exception) { throw; }
        }
        public int EjecutarNonQuery(string comando, List<SqlParameter> parametros = null)
        {
            try
            {
                using (SqlConnection mCon = new SqlConnection(cadenaConexion))
                {
                    SqlCommand coma = new SqlCommand(comando, mCon);
                    if (parametros != null) coma.Parameters.AddRange(parametros.ToArray());

                    mCon.Open();
                    int filasAfectadas = coma.ExecuteNonQuery();
                    coma.Parameters.Clear();
                    return filasAfectadas;
                }
            }
            catch (Exception) { throw; }
        }
        public int ObtenerProximoId(string tabla)
        {
            try
            {
                using (SqlConnection mCon = new SqlConnection(cadenaConexion))
                {
                    SqlCommand coma = new SqlCommand($"SELECT ISNULL(MAX(" + tabla + "_Id),0) FROM " + tabla, mCon);
                    mCon.Open();
                    return int.Parse(coma.ExecuteScalar().ToString());
                }
            }
            catch (Exception) { throw; }
        }
        public int EjecutarTransaccion(List<(string comando, List<SqlParameter> parametros)> comandos)
        {
            using (SqlConnection mCon = new SqlConnection(cadenaConexion))
            {
                mCon.Open();
                using (SqlTransaction transaccion = mCon.BeginTransaction())
                {
                    try
                    {
                        int filasUltimoComando = 0;

                        foreach (var item in comandos)
                        {
                            using (SqlCommand coma = new SqlCommand(
                                item.comando,
                                mCon,
                                transaccion))
                            {
                                if (item.parametros != null)
                                    coma.Parameters.AddRange(item.parametros.ToArray());

                                filasUltimoComando = coma.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();

                        return filasUltimoComando;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
