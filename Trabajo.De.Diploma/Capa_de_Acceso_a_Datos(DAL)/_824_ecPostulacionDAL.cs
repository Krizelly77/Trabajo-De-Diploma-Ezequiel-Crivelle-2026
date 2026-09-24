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
            parametros_824_ec.Add(new SqlParameter("@candidatoId", pos_824_ec.Candidato_824_ec.Id));
            parametros_824_ec.Add(new SqlParameter("@fechaPostulacion", pos_824_ec.FechaPostulacion_824_ec));
            parametros_824_ec.Add(new SqlParameter("@estado", (int)pos_824_ec.Estado_824_ec));

            if (pos_824_ec.Id_824_ec == 0)
            {
                pos_824_ec.Id_824_ec = SiguienteId_824_ec();
                parametros_824_ec.Add(new SqlParameter("@id", pos_824_ec.Id_824_ec));
                comando_824_ec = @"INSERT INTO Postulacion 
                            (Postulacion_Id, Actividad_Id, Usuario_CandidatoId, Postulacion_Fecha, Postulacion_Estado) 
                            VALUES 
                            (@id, @actividadId, @candidatoId, @fechaPostulacion, @estado)";
            }
            else
            {
                parametros_824_ec.Add(new SqlParameter("@id", pos_824_ec.Id_824_ec));
                comando_824_ec = @"UPDATE Postulacion SET 
                            Postulacion_Estado = @estado 
                            WHERE Postulacion_Id = @id";
            }

            return dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
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



        public static List<_824_ecPostulacion> ListarPorActividad_824_ec(int actividadId_824_ec)
        {
            string comando_824_ec = @"SELECT Postulacion_Id, Actividad_Id, Usuario_CandidatoId, Postulacion_Fecha, Postulacion_Estado 
                               FROM Postulacion 
                               WHERE Actividad_Id = @actividadId";

            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@actividadId", actividadId_824_ec) };
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);
            List<_824_ecPostulacion> lista_824_ec = new List<_824_ecPostulacion>();

            return buscarPor(comando_824_ec, parametros_824_ec);
        }

        public static List<_824_ecPostulacion> ListarActividadPorCandidato_824_ec(int ididid_824_ec)
        {
            string comando_824_ec = @"SELECT Postulacion_Id, Actividad_Id, Usuario_CandidatoId, Postulacion_Fecha, Postulacion_Estado 
                               FROM Postulacion 
                               WHERE Usuario_CandidatoId = @candidatoId";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@candidatoId", ididid_824_ec) };

            return buscarPor(comando_824_ec, parametros_824_ec);
        }

        private static List<_824_ecPostulacion> buscarPor(string comando_824_ec, List<SqlParameter> parametros_824_ec)
        {
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);
            List<_824_ecPostulacion> lista_824_ec = new List<_824_ecPostulacion>();

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in seta_824_ec.Tables[0].Rows)
                {
                    _824_ecPostulacion pos_824_ec = new _824_ecPostulacion
                    {
                        Id_824_ec = Convert.ToInt32(fila_824_ec["Postulacion_Id"]),
                        FechaPostulacion_824_ec = Convert.ToDateTime(fila_824_ec["Postulacion_Fecha"]),
                        Estado_824_ec = (EstadoPostulacion_824_ec)Convert.ToInt32(fila_824_ec["Postulacion_Estado"]),
                        Candidato_824_ec = UsuarioDAL.ObtenerPorId(Convert.ToInt32(fila_824_ec["Usuario_CandidatoId"]))
                    };
                    lista_824_ec.Add(pos_824_ec);
                }
            }
            return lista_824_ec;
        }
    }
}
