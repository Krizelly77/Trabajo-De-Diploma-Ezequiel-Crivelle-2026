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
    public class _824_ecParticipanteDAL
    {
        private static int mid;

        private static int SiguienteId()
        {
            if (mid == 0)
            {
                mid = (new DAO()).ObtenerProximoId("Participante");
            }
            mid += 1;
            return mid;
        }

        public static int Guardar_824_ec(_824_ecParticipante parti)
        {
            if (parti == null) return 0;

            DAO dao = new DAO();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@nombre", (object)parti.Nombre_824_ec ?? DBNull.Value),
                new SqlParameter("@apellido", (object)parti.Apellido_824_ec ?? DBNull.Value),
                new SqlParameter("@activo", parti.Activo_824_ec),
                new SqlParameter("@documento", (object)parti.Documento_824_ec ?? DBNull.Value),
                new SqlParameter("@telefono", parti.NumeroDeTelefono_824_ec),
                new SqlParameter("@correo", (object)parti.CorreoElectronico ?? DBNull.Value),
                new SqlParameter("@clave", (object)parti.PalabraClave_824_ec ?? DBNull.Value),
                new SqlParameter("@alta", parti.FechaDeAlta == default(DateTime) ? DateTime.Today : parti.FechaDeAlta),
                new SqlParameter("@dvh", (object)parti.DVH_824_ec ?? DBNull.Value),
            };

            string comando;
            if (parti.Id_824_ec == 0)
            {
                parti.Id_824_ec = SiguienteId();
                parametros.Add(new SqlParameter("@id", parti.Id_824_ec));
                comando = @"INSERT INTO Participante 
                            (Participante_Id, Participante_Nombre, Participante_Apellido, Participante_Activo, 
                             Participante_Documento, Participante_Telefono, Participante_Correo, Participante_Clave, 
                             Participante_FechaAlta, Participante_DVH) 
                            VALUES (@id, @nombre, @apellido, @activo, @documento, @telefono, @correo, @clave, @alta, @dvh)";
            }
            else
            {
                parametros.Add(new SqlParameter("@id", parti.Id_824_ec));
                comando = @"UPDATE Participante 
                            SET Participante_Nombre = @nombre, 
                                Participante_Apellido = @apellido,
                                Participante_Activo = @activo,
                                Participante_Documento = @documento,
                                Participante_Telefono = @telefono,
                                Participante_Correo = @correo,
                                Participante_Clave = @clave,
                                Participante_DVH = @dvh
                            WHERE Participante_Id = @id";
            }

            return dao.EjecutarNonQuery(comando, parametros);
        }

        public static int Eliminar_824_ec(_824_ecParticipante parti)
        {
            if (parti == null || parti.Id_824_ec <= 0) return 0;

            DAO dao_824_ec = new DAO();
            string comando = @"DELETE FROM Participante WHERE Participante_Id = @id";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", parti.Id_824_ec) };

            return dao_824_ec.EjecutarNonQuery(comando, parametros);
        }

        public static _824_ecParticipante ObtenerPorId_824_ec(int id_824_ec)
        {
            string comando_824_ec = @"SELECT Participante_Id, Participante_Nombre, Participante_Apellido, Participante_Activo, 
                                             Participante_Documento, Participante_Telefono, Participante_Correo, Participante_Clave, 
                                             Participante_FechaAlta, Participante_DVH 
                                      FROM Participante 
                                      WHERE Participante_Id = @id";

            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@id", id_824_ec) };
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                return ValorizarEntidad(seta_824_ec.Tables[0].Rows[0]);
            }
            return null;
        }

        public static List<_824_ecParticipante> ListarTodos_824_ec()
        {
            string comando_824_ec = @"SELECT Participante_Id, Participante_Nombre, Participante_Apellido, Participante_Activo, 
                                             Participante_Documento, Participante_Telefono, Participante_Correo, Participante_Clave, 
                                             Participante_FechaAlta, Participante_DVH 
                                      FROM Participante 
                                      ORDER BY Participante_Apellido, Participante_Nombre";

            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec);
            List<_824_ecParticipante> lista_824_ec = new List<_824_ecParticipante>();

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in seta_824_ec.Tables[0].Rows)
                {
                    lista_824_ec.Add(ValorizarEntidad(fila_824_ec));
                }
            }
            return lista_824_ec;
        }

        // Carga diferida / explícita de postulaciones a pedido mediante un método
        public static void CargarPostulaciones_824_ec(_824_ecParticipante parti)
        {
            if (parti == null || parti.Id_824_ec <= 0) return;
            parti.Postulaciones_824_ec = ListarPostulacionesPorParticipante_824_ec(parti.Id_824_ec);
        }

        public static List<_824_ecPostulacion> ListarPostulacionesPorParticipante_824_ec(int idParticipante)
        {
            return _824_ecPostulacionDAL.ListarPorParticipante_824_ec(idParticipante);
        }

        private static _824_ecParticipante ValorizarEntidad(DataRow fila)
        {
            _824_ecParticipante parti = new _824_ecParticipante();

            if (fila.Table.Columns.Contains("Participante_Id"))
                parti.Id_824_ec = Convert.ToInt32(fila["Participante_Id"]);

            if (fila.Table.Columns.Contains("Participante_Nombre"))
                parti.Nombre_824_ec = fila["Participante_Nombre"] != DBNull.Value ? fila["Participante_Nombre"].ToString() : null;

            if (fila.Table.Columns.Contains("Participante_Apellido"))
                parti.Apellido_824_ec = fila["Participante_Apellido"] != DBNull.Value ? fila["Participante_Apellido"].ToString() : null;

            if (fila.Table.Columns.Contains("Participante_Activo"))
                parti.Activo_824_ec = fila["Participante_Activo"] != DBNull.Value && Convert.ToBoolean(fila["Participante_Activo"]);

            if (fila.Table.Columns.Contains("Participante_Documento"))
                parti.Documento_824_ec = fila["Participante_Documento"] != DBNull.Value ? fila["Participante_Documento"].ToString() : null;

            if (fila.Table.Columns.Contains("Participante_Telefono"))
                parti.NumeroDeTelefono_824_ec = (string)(fila["Participante_Telefono"] != DBNull.Value ? fila["Participante_Telefono"] : null);

            if (fila.Table.Columns.Contains("Participante_Correo"))
                parti.CorreoElectronico = fila["Participante_Correo"] != DBNull.Value ? fila["Participante_Correo"].ToString() : null;

            if (fila.Table.Columns.Contains("Participante_Clave"))
                parti.PalabraClave_824_ec = fila["Participante_Clave"] != DBNull.Value ? fila["Participante_Clave"].ToString() : null;

            if (fila.Table.Columns.Contains("Participante_FechaAlta"))
                parti.FechaDeAlta = fila["Participante_FechaAlta"] != DBNull.Value ? Convert.ToDateTime(fila["Participante_FechaAlta"]) : DateTime.Today;

            if (fila.Table.Columns.Contains("Participante_DVH"))
                parti.DVH_824_ec = fila["Participante_DVH"] != DBNull.Value ? fila["Participante_DVH"].ToString() : null;

            return parti;
        }
    }
}
