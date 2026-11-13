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
    public class _824_ecPostulacionDAL
    {
        private static int mid_824_ec;

        private static int SiguienteId_824_ec()
        {
            if (mid_824_ec == 0)
            {
                mid_824_ec = (new DAO()).ObtenerProximoId("Postulacion");
            }
            mid_824_ec += 1;
            return mid_824_ec;
        }

        public static int Guardar_824_ec(_824_ecPostulacion pos_824_ec)
        {
            DAO dao_824_ec = new DAO();
            List<SqlParameter> parametros_824_ec = new List<SqlParameter>();
            string comando_824_ec;

            parametros_824_ec.Add(new SqlParameter("@actividadId", pos_824_ec.Actividad_824_ec.Id_824_ec));
            parametros_824_ec.Add(new SqlParameter("@candidatoId", pos_824_ec.GestorResponsable_824_ec.Id));
            parametros_824_ec.Add(new SqlParameter("@participanteId", (object)pos_824_ec.Participante_824_ec?.Id_824_ec ?? DBNull.Value));
            parametros_824_ec.Add(new SqlParameter("@fechaPostulacion", pos_824_ec.FechaPostulacion_824_ec));
            parametros_824_ec.Add(new SqlParameter("@estado", (int)pos_824_ec.Estado_824_ec));

            if (pos_824_ec.Id_824_ec == 0)
            {
                pos_824_ec.Id_824_ec = SiguienteId_824_ec();
                parametros_824_ec.Add(new SqlParameter("@id", pos_824_ec.Id_824_ec));
                comando_824_ec = @"INSERT INTO Postulacion 
                            (Postulacion_Id, Actividad_Id, Usuario_CandidatoId, Participante_Id, Postulacion_Fecha, Postulacion_Estado) 
                            VALUES 
                            (@id, @actividadId, @candidatoId, @participanteId, @fechaPostulacion, @estado)";
            }
            else
            {
                parametros_824_ec.Add(new SqlParameter("@id", pos_824_ec.Id_824_ec));
                comando_824_ec = @"UPDATE Postulacion SET 
                            Postulacion_Estado = @estado,
                            Participante_Id = @participanteId
                            WHERE Postulacion_Id = @id";
            }

            int filasAfectadas = dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);

            // Sincronizar integrantes si es una postulación grupal
            if (filasAfectadas > 0)
            {
                GuardarParticipantesAgrupados_824_ec(pos_824_ec);
            }

            return filasAfectadas;
        }

        public static int ModificarEstado_824_ec(int postulacionId_824_ec, EstadoPostulacion_824_ec nuevoEstado_824_ec)
        {
            string comando_824_ec = "UPDATE Postulacion SET Postulacion_Estado = @estado WHERE Postulacion_Id = @id";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter>
            {
                new SqlParameter("@estado", (int)nuevoEstado_824_ec),
                new SqlParameter("@id", postulacionId_824_ec)
            };
            DAO dao = new DAO();
            return dao.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }

        public static int Eliminar_824_ec(int idpostulacion)
        {
            if (idpostulacion == 0 || idpostulacion <= 0) return 0;

            DAO dao_824_ec = new DAO();
            string comando = @"DELETE FROM Participante WHERE Postulacion_Id = @id";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@id", idpostulacion) };

            return dao_824_ec.EjecutarNonQuery(comando, parametros);
        }

        private static void GuardarParticipantesAgrupados_824_ec(_824_ecPostulacion pos)
        {
            DAO dao = new DAO();
            // limiar relaciones previas por si es una modificación
            string cmdDelete = "DELETE FROM Postulacion_Participante WHERE Postulacion_Id = @posId";
            dao.EjecutarNonQuery(cmdDelete, new List<SqlParameter> { new SqlParameter("@posId", pos.Id_824_ec) });

            if (pos.ParticipantesAgrupados != null && pos.ParticipantesAgrupados.Count > 0)
            {
                foreach (var part in pos.ParticipantesAgrupados)
                {
                    string cmdInsert = @"INSERT INTO Postulacion_Participante (Postulacion_Id, Participante_Id) 
                                         VALUES (@posId, @partId)";
                    List<SqlParameter> pars = new List<SqlParameter>
                    {
                        new SqlParameter("@posId", pos.Id_824_ec),
                        new SqlParameter("@partId", part.Id_824_ec)
                    };
                    dao.EjecutarNonQuery(cmdInsert, pars);
                }
            }
        }

        // metodos de solo lectura
        public static List<_824_ecPostulacion> ListarPorActividad_824_ec(int actividadId_824_ec)
        {
            string comando_824_ec = @"SELECT Postulacion_Id, Actividad_Id, Usuario_CandidatoId, Participante_Id, Postulacion_Fecha, Postulacion_Estado, Postulacion_DVH
                               FROM Postulacion 
                               WHERE Actividad_Id = @actividadId";

            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@actividadId", actividadId_824_ec) };
            return buscarPor(comando_824_ec, parametros_824_ec);
        }

        public static List<_824_ecPostulacion> ListarActividadPorCandidato_824_ec(int idGestor)
        {
            string comando_824_ec = @"SELECT Postulacion_Id, Actividad_Id, Usuario_CandidatoId, Participante_Id, Postulacion_Fecha, Postulacion_Estado, Postulacion_DVH
                               FROM Postulacion 
                               WHERE Usuario_CandidatoId = @candidatoId";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@candidatoId", idGestor) };
            return buscarPor(comando_824_ec, parametros_824_ec);
        }

        // Busca tanto postulaciones individuales como grupales donde participe el idparti
        public static List<_824_ecPostulacion> ListarPorParticipante_824_ec(int idparti)
        {
            string comando_824_ec = @"SELECT DISTINCT p.Postulacion_Id, p.Actividad_Id, p.Usuario_CandidatoId, p.Participante_Id, p.Postulacion_Fecha, p.Postulacion_Estado, p.Postulacion_DVH
                               FROM Postulacion p
                               LEFT JOIN Postulacion_Participante pp ON p.Postulacion_Id = pp.Postulacion_Id
                               WHERE p.Participante_Id = @participanteId OR pp.Participante_Id = @participanteId";

            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@participanteId", idparti) };
            return buscarPor(comando_824_ec, parametros_824_ec);
        }

        private static List<_824_ecPostulacion> buscarPor(string comando_824_ec, List<SqlParameter> parametros_824_ec = null)
        {
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);
            List<_824_ecPostulacion> lista_824_ec = new List<_824_ecPostulacion>();

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in seta_824_ec.Tables[0].Rows)
                {
                    int postulacionId = Convert.ToInt32(fila_824_ec["Postulacion_Id"]);
                    int? participanteId = fila_824_ec["Participante_Id"] != DBNull.Value
                        ? (int?)Convert.ToInt32(fila_824_ec["Participante_Id"])
                        : null;

                    _824_ecPostulacion pos_824_ec = new _824_ecPostulacion
                    {
                        Id_824_ec = postulacionId,
                        FechaPostulacion_824_ec = Convert.ToDateTime(fila_824_ec["Postulacion_Fecha"]),
                        Estado_824_ec = (EstadoPostulacion_824_ec)Convert.ToInt32(fila_824_ec["Postulacion_Estado"]),
                        GestorResponsable_824_ec = UsuarioDAL.ObtenerPorId(Convert.ToInt32(fila_824_ec["Usuario_CandidatoId"])),
                        Actividad_824_ec = _824_ecActividadDAL.ObtenerPorId_824_ec(Convert.ToInt32(fila_824_ec["Actividad_Id"])),
                        Participante_824_ec = participanteId.HasValue ? _824_ecParticipanteDAL.ObtenerPorId_824_ec(participanteId.Value) : null,
                        ParticipantesAgrupados = ObtenerParticipantesAgrupados_824_ec(postulacionId),
                        DVH_824_ec = fila_824_ec["Postulacion_DVH"] != DBNull.Value ? fila_824_ec["Postulacion_DVH"].ToString() : null
                    };
                    lista_824_ec.Add(pos_824_ec);
                }
            }
            return lista_824_ec;
        }

        private static List<_824_ecParticipante> ObtenerParticipantesAgrupados_824_ec(int postulacionId)
        {
            string comando = "SELECT Participante_Id FROM Postulacion_Participante WHERE Postulacion_Id = @posId";
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@posId", postulacionId) };
            DAO dao = new DAO();
            DataSet ds = dao.ObtenerDataSet(comando, parametros);
            List<_824_ecParticipante> lista = new List<_824_ecParticipante>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int partId = Convert.ToInt32(row["Participante_Id"]);
                    var part = _824_ecParticipanteDAL.ObtenerPorId_824_ec(partId);
                    if (part != null) lista.Add(part);
                }
            }
            return lista;
        }

        public static List<_824_ecPostulacion> ListarTodas_824_ec()
        {
            string comando_824_ec = @"SELECT Postulacion_Id, Actividad_Id, Usuario_CandidatoId, Participante_Id, Postulacion_Fecha, Postulacion_Estado, Postulacion_DVH
                               FROM Postulacion";
            return buscarPor(comando_824_ec);
        }

        public static _824_ecPostulacion BuscarPorID_824_ec(int id_824_ec)
        {
            string comando_824_ec = @"SELECT Postulacion_Id, Actividad_Id, Usuario_CandidatoId, Participante_Id, Postulacion_Fecha, Postulacion_Estado, Postulacion_DVH
                                FROM Postulacion 
                                WHERE Postulacion_Id = @id";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@id", id_824_ec) };
            return buscarPor(comando_824_ec, parametros_824_ec).FirstOrDefault();
        }

    }
}
