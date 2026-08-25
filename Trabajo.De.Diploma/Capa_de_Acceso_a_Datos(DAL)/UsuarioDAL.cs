using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;

namespace Capa_de_Acceso_a_Datos_DAL_
{
    public class UsuarioDAL
    {
        static int mid;
        private static int SiguienteId()
        {
            if (mid == 0)
            {
                mid = (new DAO()).ObtenerProximoId("Usuario");
            }
            mid += 1;
            return mid;
        }

        public static int Guardar(Usuario usa)
        {
            DAO dao = new DAO();
            List<SqlParameter> parametros = new List<SqlParameter>();
            string comando;

            parametros.Add(new SqlParameter("@nombre", usa.NombreUsuario));
            parametros.Add(new SqlParameter("@contra", usa.Contraseña));
            parametros.Add(new SqlParameter("@activo", usa.Activo)); 
            parametros.Add(new SqlParameter("@permiso", usa.NivelPermisos)); 
            parametros.Add(new SqlParameter("@bloqueoDV", usa.BloqueoDV));
            parametros.Add(new SqlParameter("@dvh", usa.DVH ?? (object)DBNull.Value)); // para que acepte null


            if (usa.Id == 0)
            {
                usa.Id = SiguienteId();
                parametros.Add(new SqlParameter("@id", usa.Id));
                comando = "INSERT INTO Usuario (Usuario_Id, Usuario_NombreUsuario, Usuario_Contraseña, Usuario_Activo, Usuario_Permiso, Usuario_BloqueoDV, Usuario_DVH) VALUES (@id, @nombre, @contra, @activo, @permiso, @bloqueoDV, @dvh)";
            }
            else
            {
                parametros.Add(new SqlParameter("@id", usa.Id));
                comando = "UPDATE Usuario SET Usuario_NombreUsuario = @nombre, Usuario_Contraseña = @contra, Usuario_Activo = @activo, Usuario_Permiso = @permiso, Usuario_BloqueoDV = @bloqueoDV, Usuario_DVH = @dvh WHERE Usuario_Id = @id";
            }
            int cantidadFilas = dao.EjecutarNonQuery(comando, parametros);
            if (cantidadFilas > 0)
                GuardarPermisosUsuario(usa);
            
            return cantidadFilas;
        } 
        public static int Eliminar(Usuario usa)  
        {
            string comando = "DELETE Usuario WHERE Usuario_Id = @id";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", usa.Id) };
            DAO dao = new DAO();
            return dao.EjecutarNonQuery(comando, parametros);
        }

        public static Usuario ObtenerPorId(int pid)
        {
            string comando = "SELECT Usuario_NombreUsuario, Usuario_Contraseña, Usuario_Activo, Usuario_Permiso, Usuario_BloqueoDV, Usuario_DVH FROM Usuario WHERE Usuario_Id = @id";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", pid) };
            DAO dao = new DAO();
            DataSet seta = dao.ObtenerDataSet(comando, parametros);
            if (seta.Tables.Count > 0 && seta.Tables[0].Rows.Count > 0)
            {
                Usuario usa = new Usuario(pid);
                valorizarentidad(usa, seta.Tables[0].Rows[0]);
                CargarPermisosDelUsuario(usa);
                return usa;
            }
            else { return null; }
        }
        public static List<Usuario> Listar()
        {
            string comando = "SELECT Usuario_Id, Usuario_NombreUsuario, Usuario_Contraseña, Usuario_Activo, Usuario_Permiso, Usuario_BloqueoDV, Usuario_DVH FROM Usuario ORDER BY Usuario_Id";
            DAO dao = new DAO();
            DataSet seta = dao.ObtenerDataSet(comando);
            if (seta.Tables.Count > 0 && seta.Tables[0].Rows.Count > 0)
            {
                List<Usuario> listalumno = new List<Usuario>();
                foreach (DataRow fila in seta.Tables[0].Rows)
                {
                    Usuario usa = new Usuario(int.Parse(fila["Usuario_Id"].ToString()));
                    valorizarentidad(usa, fila);
                    CargarPermisosDelUsuario(usa);
                    listalumno.Add(usa);
                }
                return listalumno;
            }
            else { return null; }
        }

        private static void valorizarentidad(Usuario usa, DataRow fila)
        {
            usa.NombreUsuario = fila["Usuario_NombreUsuario"].ToString();
            usa.Contraseña = fila["Usuario_Contraseña"].ToString();
            usa.Activo = Convert.ToBoolean(fila["Usuario_Activo"]);
            usa.NivelPermisos = Convert.ToInt32(fila["Usuario_Permiso"]);
            usa.BloqueoDV = Convert.ToBoolean(fila["Usuario_BloqueoDV"]);
            usa.DVH = fila["Usuario_DVH"].ToString();
        }

        public static Usuario ObtenerPorNombre(string username)
        {
            string comando = "SELECT Usuario_Id, Usuario_NombreUsuario, Usuario_Contraseña, Usuario_Activo, Usuario_Permiso, Usuario_BloqueoDV, Usuario_DVH FROM Usuario WHERE Usuario_NombreUsuario = @user";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@user", username) };
            DAO dao = new DAO();
            DataSet seta = dao.ObtenerDataSet(comando, parametros);

            if (seta.Tables.Count > 0 && seta.Tables[0].Rows.Count > 0)
            {
                DataRow fila = seta.Tables[0].Rows[0];
                Usuario usa = new Usuario(Convert.ToInt32(fila["Usuario_Id"]));
                valorizarentidad(usa, fila);
                CargarPermisosDelUsuario(usa);
                return usa;
            }
            return null;
        }
        public static int BloquearUsuariosPorFalla()
        {
            string comando = @"UPDATE Usuario 
                       SET Usuario_BloqueoDV = 1  
                       WHERE Usuario_Id <> 1 
                         AND Usuario_Permiso <> 1
                         AND Usuario_Id NOT IN (
                             SELECT Usuario_Id 
                             FROM Usuario_Componente 
                             WHERE Componente_Id = 1 
                         )";

            DAO dao = new DAO();
            return dao.EjecutarNonQuery(comando, new List<SqlParameter>());
        }

        private static void CargarPermisosDelUsuario(Usuario usuario)
        {
            // Buscamos los componentes asignados directamente al usuario
            string comando = @"SELECT uc.Componente_Id, c.Nombre, c.NombreInterno, c.EsFamilia 
                       FROM Usuario_Componente uc
                       INNER JOIN Componente c ON uc.Componente_Id = c.Componente_Id
                       WHERE uc.Usuario_Id = @usuarioId";

            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@usuarioId", usuario.Id) };
            DAO dao = new DAO();
            DataSet ds = dao.ObtenerDataSet(comando, parametros);

            usuario.Permisos.Clear();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    bool esFamilia = Convert.ToBoolean(fila["EsFamilia"]);
                    int idcomp = Convert.ToInt32(fila["Componente_Id"]);

                    if (esFamilia) // si es rol, tambien traemos sus hijos
                    {
                        Rol rolCompleto = PermisoDAL.ObtenerRolCompleto(idcomp);
                        usuario.Permisos.Add(rolCompleto);
                    }
                    else
                    {
                        PermisoSimple per = new PermisoSimple
                        {
                            Id = idcomp,
                            Nombre = fila["Nombre"].ToString(),
                            NombreInterno = fila["NombreInterno"].ToString()
                        };
                        usuario.Permisos.Add(per);
                    }
                }
            }
        }
        public static void GuardarPermisosUsuario(Usuario usuario)
        { //Método para guardar las relaciones del usuario en la DAL
            DAO dao = new DAO();

            string cmdDelete = "DELETE FROM Usuario_Componente WHERE Usuario_Id = @usuarioId"; // evitar duplicados
            dao.EjecutarNonQuery(cmdDelete, new List<SqlParameter> { new SqlParameter("@usuarioId", usuario.Id) });

            foreach (var componente in usuario.Permisos)
            {
                string cmdInsert = "INSERT INTO Usuario_Componente (Usuario_Id, Componente_Id) VALUES (@usuarioId, @componenteId)";
                List<SqlParameter> pars = new List<SqlParameter>
                {
                    new SqlParameter("@usuarioId", usuario.Id),
                    new SqlParameter("@componenteId", componente.Id)
                };
                dao.EjecutarNonQuery(cmdInsert, pars);
            }
        }
    }
}
