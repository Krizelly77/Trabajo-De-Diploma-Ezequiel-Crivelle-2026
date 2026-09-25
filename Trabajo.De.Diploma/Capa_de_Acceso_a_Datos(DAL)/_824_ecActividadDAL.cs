using Capa_de_Dominio_BE_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Capa_de_Dominio_BE_._824_ecBE_Enums;

namespace Capa_de_Acceso_a_Datos_DAL_
{
    public class _824_ecActividadDAL
    {
        private static int mid_824_ec;

        private static int SiguienteId_824_ec()
        {
            if (mid_824_ec == 0)
            {
                mid_824_ec = (new DAO()).ObtenerProximoId("Actividad");
            }
            mid_824_ec += 1;
            return mid_824_ec;
        }

        public static int Guardar_824_ec(_824_ecActividad act_824_ec)
        {
            DAO dao_824_ec = new DAO();
            List<SqlParameter> parametros_824_ec = new List<SqlParameter>();
            string comando_824_ec;

            parametros_824_ec.Add(new SqlParameter("@nombre", act_824_ec.Nombre_824_ec));
            parametros_824_ec.Add(new SqlParameter("@descripcion", act_824_ec.Descripcion_824_ec ?? (object)DBNull.Value));
            parametros_824_ec.Add(new SqlParameter("@categoriaId", act_824_ec.Categoria_824_ec.Id_824_ec));
            parametros_824_ec.Add(new SqlParameter("@fechaHora", act_824_ec.FechaHora_824_ec));
            parametros_824_ec.Add(new SqlParameter("@fechaPublicacion", act_824_ec.FechaPublicacion_824_ec));
            parametros_824_ec.Add(new SqlParameter("@fechaCaducidad", act_824_ec.FechaCaducidad_824_ec));
            parametros_824_ec.Add(new SqlParameter("@ubicacion", act_824_ec.Ubicacion_824_ec));
            parametros_824_ec.Add(new SqlParameter("@cantMin", act_824_ec.CantidadMinima_824_ec));
            parametros_824_ec.Add(new SqlParameter("@cantMax", act_824_ec.CantidadMaxima_824_ec));
            parametros_824_ec.Add(new SqlParameter("@nivelRequerido", (int)act_824_ec.NivelRequerido_824_ec));
            parametros_824_ec.Add(new SqlParameter("@estado", (int)act_824_ec.Estado_824_ec));
            parametros_824_ec.Add(new SqlParameter("@organizadorId", act_824_ec.Organizador_824_ec.Id));

            if (act_824_ec.Id_824_ec == 0)
            {
                act_824_ec.Id_824_ec = SiguienteId_824_ec();
                parametros_824_ec.Add(new SqlParameter("@id", act_824_ec.Id_824_ec));
                comando_824_ec = @"INSERT INTO Actividad 
                            (Actividad_Id, Actividad_Nombre, Actividad_Descripcion, Categoria_Id, 
                             Actividad_FechaHora, Actividad_FechaPublicacion, Actividad_FechaCaducidad, Actividad_Ubicacion, 
                             Actividad_CantMinima, Actividad_CantMaxima, Actividad_NivelRequerido, Actividad_Estado, Usuario_OrganizadorId) 
                            VALUES 
                            (@id, @nombre, @descripcion, @categoriaId, 
                             @fechaHora, @fechaPublicacion, @fechaCaducidad, @ubicacion, 
                             @cantMin, @cantMax, @nivelRequerido, @estado, @organizadorId)";
            }
            else
            {
                parametros_824_ec.Add(new SqlParameter("@id", act_824_ec.Id_824_ec));
                comando_824_ec = @"UPDATE Actividad SET 
                            Actividad_Nombre = @nombre,
                            Actividad_Descripcion = @descripcion,
                            Categoria_Id = @categoriaId,
                            Actividad_FechaHora = @fechaHora,
                            Actividad_FechaPublicacion = @fechaPublicacion,
                            Actividad_FechaCaducidad = @fechaCaducidad,
                            Actividad_Ubicacion = @ubicacion,
                            Actividad_CantMinima = @cantMin,
                            Actividad_CantMaxima = @cantMax,
                            Actividad_NivelRequerido = @nivelRequerido,
                            Actividad_Estado = @estado,
                            Usuario_OrganizadorId = @organizadorId
                            WHERE Actividad_Id = @id";
            }

            return dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }

        public static int ModificarEstado_824_ec(int actividadId_824_ec, EstadoActividad_824_ec nuevoEstado_824_ec)
        {
            string comando_824_ec = "UPDATE Actividad SET Actividad_Estado = @estado WHERE Actividad_Id = @id";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter>
            {
                new SqlParameter("@estado", (int)nuevoEstado_824_ec),
                new SqlParameter("@id", actividadId_824_ec)
            };
            DAO dao = new DAO();
            return dao.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }

        public static int Eliminar_824_ec(int actividadId_824_ec)
        {
            DAO dao_824_ec = new DAO();

            string eliminarPostulaciones = @"DELETE FROM Postulacion WHERE Actividad_Id = @id";

            string eliminarActividad = @"DELETE FROM Actividad WHERE Actividad_Id = @id";

            var comandos = new List<(string comando, List<SqlParameter> parametros)>
            {
                (eliminarPostulaciones, new List<SqlParameter>{new SqlParameter("@id", actividadId_824_ec)}),

                (eliminarActividad, new List<SqlParameter>{new SqlParameter("@id", actividadId_824_ec)})
            };

            return dao_824_ec.EjecutarTransaccion(comandos);
        }

        public static _824_ecActividad ObtenerPorId_824_ec(int pid_824_ec)
        {
            string comando_824_ec = @"SELECT Actividad_Id, Actividad_Nombre, Actividad_Descripcion, Categoria_Id, 
                                       Actividad_FechaHora, Actividad_FechaPublicacion, Actividad_FechaCaducidad, Actividad_Ubicacion, 
                                       Actividad_CantMinima, Actividad_CantMaxima, Actividad_NivelRequerido, Actividad_Estado, Usuario_OrganizadorId 
                                FROM Actividad WHERE Actividad_Id = @id";

            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@id", pid_824_ec) };
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                DataRow fila_824_ec = seta_824_ec.Tables[0].Rows[0];
                _824_ecActividad act_824_ec = new _824_ecActividad { Id_824_ec = pid_824_ec };
                ValorizarEntidad_824_ec(act_824_ec, fila_824_ec);
                return act_824_ec;
            }
            return null;
        }

        public static List<_824_ecActividad> ListarTodas_824_ec()
        {
            string comando_824_ec = @"SELECT Actividad_Id, Actividad_Nombre, Actividad_Descripcion, Categoria_Id, 
                                       Actividad_FechaHora, Actividad_FechaPublicacion, Actividad_FechaCaducidad, Actividad_Ubicacion, 
                                       Actividad_CantMinima, Actividad_CantMaxima, Actividad_NivelRequerido, Actividad_Estado, Usuario_OrganizadorId 
                                FROM Actividad ORDER BY Actividad_FechaPublicacion DESC";

            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec);
            List<_824_ecActividad> lista_824_ec = new List<_824_ecActividad>();

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in seta_824_ec.Tables[0].Rows)
                {
                    _824_ecActividad act_824_ec = new _824_ecActividad { Id_824_ec = Convert.ToInt32(fila_824_ec["Actividad_Id"]) };
                    ValorizarEntidad_824_ec(act_824_ec, fila_824_ec);
                    lista_824_ec.Add(act_824_ec);
                }
            }
            return lista_824_ec;
        }

        private static void ValorizarEntidad_824_ec(_824_ecActividad act_824_ec, DataRow fila_824_ec)
        {
            act_824_ec.Nombre_824_ec = fila_824_ec["Actividad_Nombre"].ToString();
            act_824_ec.Descripcion_824_ec = fila_824_ec["Actividad_Descripcion"].ToString();
            act_824_ec.Categoria_824_ec = _824_ecCategoriaDAL.ObtenerPorId_824_ec(Convert.ToInt32(fila_824_ec["Categoria_Id"]));
            act_824_ec.FechaHora_824_ec = Convert.ToDateTime(fila_824_ec["Actividad_FechaHora"]);
            act_824_ec.FechaPublicacion_824_ec = Convert.ToDateTime(fila_824_ec["Actividad_FechaPublicacion"]);
            act_824_ec.FechaCaducidad_824_ec = Convert.ToDateTime(fila_824_ec["Actividad_FechaCaducidad"]);
            act_824_ec.Ubicacion_824_ec = fila_824_ec["Actividad_Ubicacion"].ToString();
            act_824_ec.CantidadMinima_824_ec = Convert.ToInt32(fila_824_ec["Actividad_CantMinima"]);
            act_824_ec.CantidadMaxima_824_ec = Convert.ToInt32(fila_824_ec["Actividad_CantMaxima"]);
            act_824_ec.NivelRequerido_824_ec = (NivelRequerido_824_ec)Convert.ToInt32(fila_824_ec["Actividad_NivelRequerido"]);
            act_824_ec.Estado_824_ec = (EstadoActividad_824_ec)Convert.ToInt32(fila_824_ec["Actividad_Estado"]);

            // Cargar referencia a Usuario Organizador por Id
            act_824_ec.Organizador_824_ec = UsuarioDAL.ObtenerPorId(Convert.ToInt32(fila_824_ec["Usuario_OrganizadorId"]));
        }
    }
}
