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
            catch (Exception ex) { throw (ex); }
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
            catch (Exception ex) { throw (ex); }
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
            catch (Exception ex) { throw (ex); }
        }
    }
}
