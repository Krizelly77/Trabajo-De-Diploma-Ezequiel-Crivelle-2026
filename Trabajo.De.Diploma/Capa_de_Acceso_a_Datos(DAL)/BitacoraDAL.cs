using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_Acceso_a_Datos_DAL_
{
    public class BitacoraDAL
    {
        public static int Guardar(RegistroBitacora registro)
        {
            DAO dao = new DAO();
            string comando = "INSERT INTO Bitacora (Bitacora_Usuario, Bitacora_Actividad, Bitacora_FechaHora) VALUES (@usuario, @actividad, @fechahora)";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@usuario",   registro.Usuario),
                new SqlParameter("@actividad", registro.Actividad),
                new SqlParameter("@fechahora", registro.FechaHora)
            };
            return dao.EjecutarNonQuery(comando, parametros);
        }

        public static List<RegistroBitacora> ObtenerRegistros(FiltrosBitacora filtros)
        {
            DAO dao = new DAO();
            string comando = @"SELECT Bitacora_Id, Bitacora_Usuario, Bitacora_Actividad, Bitacora_FechaHora
                               FROM Bitacora
                               WHERE Bitacora_FechaHora BETWEEN @desde AND @hasta
                                 AND (@usuario  IS NULL OR Bitacora_Usuario  LIKE '%' + @usuario  + '%')
                                 AND (@actividad IS NULL OR Bitacora_Actividad LIKE '%' + @actividad + '%')
                               ORDER BY Bitacora_FechaHora DESC";

            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@desde",     filtros.FechaDesde),
                new SqlParameter("@hasta",     filtros.FechaHasta.Date.AddDays(1).AddSeconds(-1)),
                new SqlParameter("@usuario",   string.IsNullOrEmpty(filtros.Usuario)   ? (object)DBNull.Value : filtros.Usuario),
                new SqlParameter("@actividad", string.IsNullOrEmpty(filtros.Actividad) ? (object)DBNull.Value : filtros.Actividad)
            };

            DataSet seta = dao.ObtenerDataSet(comando, parametros);
            List<RegistroBitacora> lista = new List<RegistroBitacora>();

            if (seta.Tables.Count > 0)
            {
                foreach (DataRow fila in seta.Tables[0].Rows)
                {
                    RegistroBitacora r = new RegistroBitacora(
                        fila["Bitacora_Usuario"].ToString(),
                        fila["Bitacora_Actividad"].ToString()
                    );
                    r.Id = Convert.ToInt32(fila["Bitacora_Id"]);
                    r.FechaHora = Convert.ToDateTime(fila["Bitacora_FechaHora"]);
                    lista.Add(r);
                }
            }
            return lista;
        }
    }
}
