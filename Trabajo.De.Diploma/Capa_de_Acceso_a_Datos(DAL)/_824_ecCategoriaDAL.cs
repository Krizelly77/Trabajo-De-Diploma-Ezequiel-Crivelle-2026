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
    public class _824_ecCategoriaDAL
    {
        private static int mid_824_ec;

        private static int SiguienteId_824_ec()
        {
            if (mid_824_ec == 0)
            {
                mid_824_ec = (new DAO()).ObtenerProximoId("Categoria");
            }
            mid_824_ec += 1;
            return mid_824_ec;
        }

        public static int Guardar_824_ec(_824_ecCategoria cat_824_ec)
        {
            DAO dao_824_ec = new DAO();
            List<SqlParameter> parametros_824_ec = new List<SqlParameter>();
            string comando_824_ec;

            parametros_824_ec.Add(new SqlParameter("@nombre", cat_824_ec.Nombre_824_ec));
            parametros_824_ec.Add(new SqlParameter("@descripcion", cat_824_ec.Descripcion_824_ec ?? (object)DBNull.Value));

            if (cat_824_ec.Id_824_ec == 0)
            {
                cat_824_ec.Id_824_ec = SiguienteId_824_ec();
                parametros_824_ec.Add(new SqlParameter("@id", cat_824_ec.Id_824_ec));
                comando_824_ec = @"INSERT INTO Categoria (Categoria_Id, Categoria_Nombre, Categoria_Descripcion) 
                                   VALUES (@id, @nombre, @descripcion)";
            }
            else
            {
                parametros_824_ec.Add(new SqlParameter("@id", cat_824_ec.Id_824_ec));
                comando_824_ec = @"UPDATE Categoria SET 
                                   Categoria_Nombre = @nombre, 
                                   Categoria_Descripcion = @descripcion 
                                   WHERE Categoria_Id = @id";
            }

            return dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }

        public static _824_ecCategoria ObtenerPorId_824_ec(int id_824_ec)
        {
            string comando_824_ec = "SELECT Categoria_Id, Categoria_Nombre, Categoria_Descripcion FROM Categoria WHERE Categoria_Id = @id";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@id", id_824_ec) };
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                DataRow fila_824_ec = seta_824_ec.Tables[0].Rows[0];
                return new _824_ecCategoria
                {
                    Id_824_ec = Convert.ToInt32(fila_824_ec["Categoria_Id"]),
                    Nombre_824_ec = fila_824_ec["Categoria_Nombre"].ToString(),
                    Descripcion_824_ec = fila_824_ec["Categoria_Descripcion"].ToString()
                };
            }
            return null;
        }

        public static List<_824_ecCategoria> Listar_824_ec()
        {
            string comando_824_ec = "SELECT Categoria_Id, Categoria_Nombre, Categoria_Descripcion, Categoria_DVH FROM Categoria ORDER BY Categoria_Nombre";
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec);
            List<_824_ecCategoria> lista_824_ec = new List<_824_ecCategoria>();

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in seta_824_ec.Tables[0].Rows)
                {
                    lista_824_ec.Add(new _824_ecCategoria
                    {
                        Id_824_ec = Convert.ToInt32(fila_824_ec["Categoria_Id"]),
                        Nombre_824_ec = fila_824_ec["Categoria_Nombre"].ToString(),
                        Descripcion_824_ec = fila_824_ec["Categoria_Descripcion"] != DBNull.Value ? fila_824_ec["Categoria_Descripcion"].ToString() : null,
                        DVH_824_ec = fila_824_ec["Categoria_DVH"] != DBNull.Value ? fila_824_ec["Categoria_DVH"].ToString() : null
                    });
                }
            }
            return lista_824_ec;
        }
    }
}
