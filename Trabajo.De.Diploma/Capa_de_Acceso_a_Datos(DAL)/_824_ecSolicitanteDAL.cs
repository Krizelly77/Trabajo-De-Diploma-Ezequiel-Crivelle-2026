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
    public class _824_ecSolicitanteDAL
    {
        private static int mid;

        private static int SiguienteId()
        {
            if (mid == 0)
            {
                mid = (new DAO()).ObtenerProximoId("Solicitante");
            }
            mid += 1;
            return mid;
        }

        public static int Guardar_824_ec(_824_ecSolicitante sol)
        {
            if (sol == null) return 0;

            DAO dao = new DAO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombre", (object)sol.Nombre_824_ec ?? DBNull.Value),
                new SqlParameter("@apellido", (object)sol.Apellido_824_ec ?? DBNull.Value),
                new SqlParameter("@activo", sol.Activo_824_ec),
                new SqlParameter("@documento", (object)sol.Documento_824_ec ?? DBNull.Value),
                new SqlParameter("@telefono", sol.NumeroDeTelefono_824_ec),
                new SqlParameter("@correo", (object)sol.CorreoElectronico ?? DBNull.Value),
                new SqlParameter("@alta", sol.FechaDeAlta == default(DateTime) ? DateTime.Today : sol.FechaDeAlta),
                new SqlParameter("@dvh", (object)sol.DVH_824_ec ?? DBNull.Value),
            };

            string comando;
            if (sol.Id_824_ec == 0)
            {
                sol.Id_824_ec = SiguienteId();
                parametros.Add(new SqlParameter("@id", sol.Id_824_ec));
                comando = @"INSERT INTO Solicitante 
                            (Solicitante_Id, Solicitante_Nombre, Solicitante_Apellido, Solicitante_Activo, 
                             Solicitante_Documento, Solicitante_Telefono, Solicitante_Correo, 
                             Solicitante_FechaAlta, Solicitante_DVH) 
                            VALUES (@id, @nombre, @apellido, @activo, @documento, @telefono, @correo, @alta, @dvh)";
            }
            else
            {
                parametros.Add(new SqlParameter("@id", sol.Id_824_ec));
                comando = @"UPDATE Solicitante 
                            SET Solicitante_Nombre = @nombre, 
                                Solicitante_Apellido = @apellido,
                                Solicitante_Activo = @activo,
                                Solicitante_Documento = @documento,
                                Solicitante_Telefono = @telefono,
                                Solicitante_Correo = @correo,
                                Solicitante_DVH = @dvh
                            WHERE Solicitante_Id = @id";
            }

            return dao.EjecutarNonQuery(comando, parametros);
        }

        public static int Eliminar_824_ec(_824_ecSolicitante sol)
        {
            if (sol == null || sol.Id_824_ec <= 0) return 0;

            DAO dao_824_ec = new DAO();
            string comando = @"DELETE FROM Solicitante WHERE Solicitante_Id = @id";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", sol.Id_824_ec) };

            return dao_824_ec.EjecutarNonQuery(comando, parametros);
        }

        public static _824_ecSolicitante ObtenerPorId_824_ec(int id_824_ec)
        {
            string comando_824_ec = @"SELECT Solicitante_Id, Solicitante_Nombre, Solicitante_Apellido, Solicitante_Activo, 
                                             Solicitante_Documento, Solicitante_Telefono, Solicitante_Correo, 
                                             Solicitante_FechaAlta, Solicitante_DVH 
                                      FROM Solicitante 
                                      WHERE Solicitante_Id = @id";

            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@id", id_824_ec) };
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                return ValorizarEntidad(seta_824_ec.Tables[0].Rows[0]);
            }
            return null;
        }

        public static List<_824_ecSolicitante> ListarTodos_824_ec()
        {
            string comando_824_ec = @"SELECT Solicitante_Id, Solicitante_Nombre, Solicitante_Apellido, Solicitante_Activo, 
                                             Solicitante_Documento, Solicitante_Telefono, Solicitante_Correo, 
                                             Solicitante_FechaAlta, Solicitante_DVH 
                                      FROM Solicitante 
                                      ORDER BY Solicitante_Apellido, Solicitante_Nombre";

            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec);
            List<_824_ecSolicitante> lista_824_ec = new List<_824_ecSolicitante>();

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in seta_824_ec.Tables[0].Rows)
                {
                    lista_824_ec.Add(ValorizarEntidad(fila_824_ec));
                }
            }
            return lista_824_ec;
        }

        // Carga diferida / explícita de actividades a pedido mediante un método
        public static void CargarActividades_824_ec(_824_ecSolicitante sol)
        {
            if (sol == null || sol.Id_824_ec <= 0) return;
            sol.Actividades_824_ec = ListarActividadesPorSolicitante_824_ec(sol.Id_824_ec);
        }

        public static List<_824_ecActividad> ListarActividadesPorSolicitante_824_ec(int idSolicitante)
        {
            return _824_ecActividadDAL.ListarPorSolicitante_824_ec(idSolicitante);
        }

        private static _824_ecSolicitante ValorizarEntidad(DataRow fila)
        {
            _824_ecSolicitante sol = new _824_ecSolicitante();

            if (fila.Table.Columns.Contains("Solicitante_Id"))
                sol.Id_824_ec = Convert.ToInt32(fila["Solicitante_Id"]);

            if (fila.Table.Columns.Contains("Solicitante_Nombre"))
                sol.Nombre_824_ec = fila["Solicitante_Nombre"] != DBNull.Value ? fila["Solicitante_Nombre"].ToString() : null;

            if (fila.Table.Columns.Contains("Solicitante_Apellido"))
                sol.Apellido_824_ec = fila["Solicitante_Apellido"] != DBNull.Value ? fila["Solicitante_Apellido"].ToString() : null;

            if (fila.Table.Columns.Contains("Solicitante_Activo"))
                sol.Activo_824_ec = fila["Solicitante_Activo"] != DBNull.Value && Convert.ToBoolean(fila["Solicitante_Activo"]);

            if (fila.Table.Columns.Contains("Solicitante_Documento"))
                sol.Documento_824_ec = fila["Solicitante_Documento"] != DBNull.Value ? fila["Solicitante_Documento"].ToString() : null;

            if (fila.Table.Columns.Contains("Solicitante_Telefono"))
                sol.NumeroDeTelefono_824_ec = (string)(fila["Solicitante_Telefono"] != DBNull.Value ? fila["Solicitante_Telefono"] : null);

            if (fila.Table.Columns.Contains("Solicitante_Correo"))
                sol.CorreoElectronico = fila["Solicitante_Correo"] != DBNull.Value ? fila["Solicitante_Correo"].ToString() : null;

            if (fila.Table.Columns.Contains("Solicitante_FechaAlta"))
                sol.FechaDeAlta = fila["Solicitante_FechaAlta"] != DBNull.Value ? Convert.ToDateTime(fila["Solicitante_FechaAlta"]) : DateTime.Today;

            if (fila.Table.Columns.Contains("Solicitante_DVH"))
                sol.DVH_824_ec = fila["Solicitante_DVH"] != DBNull.Value ? fila["Solicitante_DVH"].ToString() : null;

            return sol;
        }
    }
}
