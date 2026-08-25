using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Acceso_a_Datos_DAL_
{
    public class HistorialCambiosDAL
    {
        private DAO dao = new DAO();

        public void GuardarCambios(List<RegistroCambio> cambios)
        {
            foreach (RegistroCambio cambio in cambios)
            {
                string sql = @"INSERT INTO HistorialCambios 
                    (HC_EntidadNombre, HC_EntidadId, HC_NombreCampo,
                     HC_ValorAnterior, HC_ValorNuevo, HC_Operador, HC_FechaHora)
                    VALUES (@entidad, @id, @campo, @anterior, @nuevo, @operador, @fecha)";

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@entidad", cambio.EntidadNombre));
                parametros.Add(new SqlParameter("@id", cambio.EntidadId));
                parametros.Add(new SqlParameter("@campo", cambio.NombreCampo));
                parametros.Add(new SqlParameter("@anterior", cambio.ValorAnterior ?? (object)DBNull.Value));
                parametros.Add(new SqlParameter("@nuevo", cambio.ValorNuevo ?? (object)DBNull.Value));
                parametros.Add(new SqlParameter("@operador", cambio.Operador));
                parametros.Add(new SqlParameter("@fecha", cambio.FechaHora));

                dao.EjecutarNonQuery(sql, parametros);
            }
        }

        public List<RegistroCambio> ObtenerHistorialDeUsuario(int usuarioId)
        {
            string sql = @"SELECT HC_Id, HC_EntidadNombre, HC_EntidadId, HC_NombreCampo,
                                  HC_ValorAnterior, HC_ValorNuevo, HC_Operador, HC_FechaHora
                           FROM HistorialCambios
                           WHERE HC_EntidadNombre = 'Usuario' AND HC_EntidadId = @id
                           ORDER BY HC_FechaHora DESC";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", usuarioId));

            DataSet ds = dao.ObtenerDataSet(sql, parametros);
            List<RegistroCambio> lista = new List<RegistroCambio>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lista.Add(new RegistroCambio
                {
                    Id = (int)row["HC_Id"],
                    EntidadNombre = row["HC_EntidadNombre"].ToString(),
                    EntidadId = (int)row["HC_EntidadId"],
                    NombreCampo = row["HC_NombreCampo"].ToString(),
                    ValorAnterior = row["HC_ValorAnterior"] as string,
                    ValorNuevo = row["HC_ValorNuevo"] as string,
                    Operador = row["HC_Operador"].ToString(),
                    FechaHora = (DateTime)row["HC_FechaHora"]
                });
            }

            return lista;
        }
    }
}
