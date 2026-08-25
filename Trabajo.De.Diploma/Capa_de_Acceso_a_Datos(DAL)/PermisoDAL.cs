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
    public class PermisoDAL
    {
        private static int _mid;

        private static int SiguienteId()
        {
            if (_mid == 0)
            {
                _mid = (new DAO()).ObtenerProximoId("Componente");
            }
            _mid += 1;
            return _mid;
        }

        public static int GuardarComponente(ComponentePermiso componente)
        {
            //Guardar un Componente Base (Alta o Modificación)
            DAO dao = new DAO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombre", componente.Nombre),
                new SqlParameter("@nombreInterno", componente.NombreInterno ?? (object)DBNull.Value), // para permitir nulos
                new SqlParameter("@esFamilia", componente is Rol) // para saber si es permiso simple o rol 
            };

            string comando;
            if (componente.Id == 0) // si todavia no existe
            {
                componente.Id = SiguienteId();
                parametros.Add(new SqlParameter("@id", componente.Id));
                comando = "INSERT INTO Componente (Componente_Id, Nombre, NombreInterno, EsFamilia) VALUES (@id, @nombre, @nombreInterno, @esFamilia)";

                return dao.EjecutarNonQuery(comando, parametros);
            }
            else //si ya existe
            {
                parametros.Add(new SqlParameter("@id", componente.Id));
                comando = "UPDATE Componente SET Nombre = @nombre, NombreInterno = @nombreInterno, EsFamilia = @esFamilia WHERE Componente_Id = @id";
                return dao.EjecutarNonQuery(comando, parametros);
            }
        }
        public static int EliminarRol(int id)
        {
            DAO dao = new DAO();

            // Primero se borran las relaciones
            string sql1 = @"DELETE FROM Componente_Hijo WHERE Padre_Id = @id OR Hijo_Id = @id";

            List<SqlParameter> p = new List<SqlParameter>()
            {
                new SqlParameter("@id", id)
            };

            dao.EjecutarNonQuery(sql1, p);

            // Ahora se borra el componente
            string sql2 = @"DELETE FROM Componente WHERE Componente_Id = @id";

            return dao.EjecutarNonQuery(sql2, p);
        }



        public static int AgregarHijo(int padreId, int hijoId)
        {
            // vincular hijo a un padre de la tabla intermedia
            string comando = "INSERT INTO Componente_Hijo (Padre_Id, Hijo_Id) VALUES (@padreId, @hijoId)";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@padreId", padreId),
                new SqlParameter("@hijoId", hijoId)
            };

            DAO dao = new DAO();
            return dao.EjecutarNonQuery(comando, parametros);
        }

        public static int QuitarHijo(int padreId, int hijoId)
        {
            // desvincular hijo en la tabla intermedia
            string comando = "DELETE FROM Componente_Hijo WHERE Padre_Id = @padreId AND Hijo_Id = @hijoId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@padreId", padreId),
                new SqlParameter("@hijoId", hijoId)
            };

            DAO dao = new DAO();
            return dao.EjecutarNonQuery(comando, parametros);
        }

        public static List<ComponentePermiso> ListarComponentesRaiz()
        {
            // buscar todos los componentes 
            string comando = "SELECT Componente_Id, Nombre, NombreInterno, EsFamilia FROM Componente";
            DAO dao = new DAO();
            DataSet ds = dao.ObtenerDataSet(comando);
            List<ComponentePermiso> lista = new List<ComponentePermiso>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    bool esFamilia = Convert.ToBoolean(fila["EsFamilia"]);
                    ComponentePermiso comp = esFamilia ? (ComponentePermiso)new Rol() : new PermisoSimple();

                    comp.Id = Convert.ToInt32(fila["Componente_Id"]);
                    comp.Nombre = fila["Nombre"].ToString();
                    comp.NombreInterno = fila["NombreInterno"] != DBNull.Value ? fila["NombreInterno"].ToString() : null;

                    lista.Add(comp);
                }
            }
            return lista;
        }

        public static Rol ObtenerRolCompleto(int rolId)
        {
            // obteer un rol con sus hijos 
            string comando = "SELECT Componente_Id, Nombre, NombreInterno, EsFamilia FROM Componente WHERE Componente_Id = @id AND EsFamilia = 1";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", rolId) };
            DAO dao = new DAO();
            DataSet ds = dao.ObtenerDataSet(comando, parametros);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                Rol padre = new Rol
                {
                    Id = Convert.ToInt32(fila["Componente_Id"]),
                    Nombre = fila["Nombre"].ToString(),
                    NombreInterno = fila["NombreInterno"] != DBNull.Value ? fila["NombreInterno"].ToString() : null
                };

                LlenarHijosRecursivo(padre);
                return padre;
            }
            return null;
        }

        private static void LlenarHijosRecursivo(ComponentePermiso padre)
        {
            // llenar hijos de forma recursiva 
            string comando = @"SELECT c.Componente_Id, c.Nombre, c.NombreInterno, c.EsFamilia 
                               FROM Componente_Hijo ch 
                               INNER JOIN Componente c ON ch.Hijo_Id = c.Componente_Id 
                               WHERE ch.Padre_Id = @padreId";

            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@padreId", padre.Id) };
            DAO dao = new DAO();
            DataSet ds = dao.ObtenerDataSet(comando, parametros);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    bool esFamilia = Convert.ToBoolean(fila["EsFamilia"]);
                    ComponentePermiso hijo;

                    if (esFamilia)
                    {
                        hijo = new Rol();
                        hijo.Id = Convert.ToInt32(fila["Componente_Id"]);
                        hijo.Nombre = fila["Nombre"].ToString();
                        hijo.NombreInterno = fila["NombreInterno"] != DBNull.Value ? fila["NombreInterno"].ToString() : null;

                        LlenarHijosRecursivo(hijo);
                    }
                    else
                    {
                        hijo = new PermisoSimple();
                        hijo.Id = Convert.ToInt32(fila["Componente_Id"]);
                        hijo.Nombre = fila["Nombre"].ToString();
                        hijo.NombreInterno = fila["NombreInterno"].ToString();
                    }

                    padre.AgregarHijo(hijo);
                }
            }
        }

    }
}
