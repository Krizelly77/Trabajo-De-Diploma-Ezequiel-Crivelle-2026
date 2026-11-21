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

        public static int Eliminar_824_ec(_824_ecCategoria cat_824_ec)
        {
            if (cat_824_ec == null || cat_824_ec.Id_824_ec <= 0)
                return 0;

            if (!VerificarQueNoSeUsoEnActividad(cat_824_ec))
                throw new Exception("No se puede eliminar la categoría porque se encuentra asignada a una o más actividades.");

            DAO dao_824_ec = new DAO();
            string comando_824_ec = "DELETE FROM Categoria WHERE Categoria_Id = @id";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter>
            {
                new SqlParameter("@id", cat_824_ec.Id_824_ec)
            };

            return dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }

        // solo lectura
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

        public static bool VerificarQueNoSeUsoEnActividad(_824_ecCategoria cat_824_ec)
        {
            if (cat_824_ec == null || cat_824_ec.Id_824_ec <= 0)
                return false;

            DAO dao_824_ec = new DAO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id", cat_824_ec.Id_824_ec)
            };

            // Se comprueba si existe alguna actividad que haga referencia a esta categoría
            // Soporta tanto 'categoriaId' como 'Categoria_Id' según la definición de la tabla Actividad
            string comando = "SELECT COUNT(1) FROM Actividad WHERE categoriaId = @id";
            try
            {
                DataSet ds = dao_824_ec.ObtenerDataSet(comando, parametros);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    int cantidad = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    return cantidad == 0; // True si NO se usó en ninguna actividad
                }
            }
            catch
            {
                // Fallback por si en la base de datos la columna es Categoria_Id
                try
                {
                    List<SqlParameter> parametrosAlt = new List<SqlParameter>
                    {
                        new SqlParameter("@id", cat_824_ec.Id_824_ec)
                    };
                    string comandoAlt = "SELECT COUNT(1) FROM Actividad WHERE Categoria_Id = @id";
                    DataSet dsAlt = dao_824_ec.ObtenerDataSet(comandoAlt, parametrosAlt);
                    if (dsAlt.Tables.Count > 0 && dsAlt.Tables[0].Rows.Count > 0)
                    {
                        int cantidad = Convert.ToInt32(dsAlt.Tables[0].Rows[0][0]);
                        return cantidad == 0;
                    }
                }
                catch
                {
                    // En caso de cualquier error imprevisto al consultar, por seguridad no permitimos eliminar
                    return false;
                }
            }

            return true;
        }
    }
}
