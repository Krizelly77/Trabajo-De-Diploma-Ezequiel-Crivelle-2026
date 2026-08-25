using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Acceso_a_Datos_DAL_
{
    public class DigitoVerificadorDAL
    {  //controla la tabla del digito verificador vertical en BD
        public static string ObtenerDVVPorTabla(string nombreTabla)
        {   
            string comando = "SELECT DVV_Hash FROM DigitoVerificadorVertical WHERE DVV_Tabla = @tabla";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@tabla", nombreTabla) };
            DAO dao = new DAO();
            DataSet seta = dao.ObtenerDataSet(comando, parametros);

            if (seta.Tables.Count > 0 && seta.Tables[0].Rows.Count > 0)
            {
                return seta.Tables[0].Rows[0]["DVV_Hash"].ToString();
            }
            return null;
        }

        public static int GuardarDVV(string nombreTabla, string hashVertical)
        {
            DAO dao = new DAO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@tabla", nombreTabla),
                new SqlParameter("@hash", hashVertical)
            };

            // Intentamos actualizar, si no existe el registro lo insertamos
            string comandoUpdate = "UPDATE DigitoVerificadorVertical SET DVV_Hash = @hash WHERE DVV_Tabla = @tabla";
            int filasAfectadas = dao.EjecutarNonQuery(comandoUpdate, parametros);

            if (filasAfectadas == 0)
            {
                string comandoInsert = "INSERT INTO DigitoVerificadorVertical (DVV_Tabla, DVV_Hash) VALUES (@tabla, @hash)";
                filasAfectadas = dao.EjecutarNonQuery(comandoInsert, parametros);
            }

            return filasAfectadas;
        }
    }
}
