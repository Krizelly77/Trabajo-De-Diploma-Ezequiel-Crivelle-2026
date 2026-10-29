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
    public class _824_ecNotificacionDAL
    {
        private static int mid_824_ec;

        private static int SiguienteId_824_ec()
        {
            if (mid_824_ec == 0)
            {
                mid_824_ec = (new DAO()).ObtenerProximoId("Notificacion");
            }
            mid_824_ec += 1;
            return mid_824_ec;
        }

        public static int Guardar_824_ec(_824_ecNotificacion notif_824_ec)
        {
            DAO dao_824_ec = new DAO();
            List<SqlParameter> parametros_824_ec = new List<SqlParameter>();
            string comando_824_ec;

            parametros_824_ec.Add(new SqlParameter("@remitenteId", notif_824_ec.IdRemitente_824_ec));
            parametros_824_ec.Add(new SqlParameter("@destinatarioId", notif_824_ec.IdDestinatario_824_ec));
            parametros_824_ec.Add(new SqlParameter("@asunto", notif_824_ec.Asunto_824_ec));
            parametros_824_ec.Add(new SqlParameter("@mensaje", notif_824_ec.Mensaje_824_ec));
            parametros_824_ec.Add(new SqlParameter("@fecha", notif_824_ec.Fecha_824_ec));
            parametros_824_ec.Add(new SqlParameter("@leida", notif_824_ec.Leida_824_ec));
            parametros_824_ec.Add(new SqlParameter("@dvh", notif_824_ec.DVH_824_ec ?? (object)DBNull.Value));

            if (notif_824_ec.Id_824_ec == 0)
            {
                notif_824_ec.Id_824_ec = SiguienteId_824_ec();
                parametros_824_ec.Add(new SqlParameter("@id", notif_824_ec.Id_824_ec));
                comando_824_ec = @"INSERT INTO Notificacion 
                        (Notificacion_Id, Notificacion_RemitenteId, Notificaciono_DestinatarioId, Notificacion_Asunto, Notificacion_Mensaje, Notificacion_Fecha, Notificacion_Leida, Notificacion_DVH) 
                        VALUES 
                        (@id, @remitenteId, @destinatarioId, @asunto, @mensaje, @fecha, @leida, @dvh)";
            }
            else
            {
                parametros_824_ec.Add(new SqlParameter("@id", notif_824_ec.Id_824_ec));
                comando_824_ec = @"UPDATE Notificacion SET 
                        Notificacion_RemitenteId = @remitenteId, 
                        Notificaciono_DestinatarioId = @destinatarioId, 
                        Notificacion_Asunto = @asunto, 
                        Notificacion_Mensaje = @mensaje, 
                        Notificacion_Fecha = @fecha, 
                        Notificacion_Leida = @leida, 
                        Notificacion_DVH = @dvh 
                        WHERE Notificacion_Id = @id";
            }

            return dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }

        public static _824_ecNotificacion ObtenerPorId_824_ec(int id_824_ec)
        {
            string comando_824_ec = "SELECT Notificacion_Id, Notificacion_RemitenteId, Notificaciono_DestinatarioId, Notificacion_Asunto, Notificacion_Mensaje, Notificacion_Fecha, Notificacion_Leida, Notificacion_DVH FROM Notificacion WHERE Notificacion_Id = @id";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@id", id_824_ec) };
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                DataRow fila_824_ec = seta_824_ec.Tables[0].Rows[0];
                return MapearFila_824_ec(fila_824_ec);
            }
            return null;
        }

        public static List<_824_ecNotificacion> Listar_824_ec()
        {
            string comando_824_ec = "SELECT Notificacion_Id, Notificacion_RemitenteId, Notificaciono_DestinatarioId, Notificacion_Asunto, Notificacion_Mensaje, Notificacion_Fecha, Notificacion_Leida, Notificacion_DVH FROM Notificacion ORDER BY Notificacion_Fecha DESC, Notificacion_Id DESC";
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec);
            List<_824_ecNotificacion> lista_824_ec = new List<_824_ecNotificacion>();

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in seta_824_ec.Tables[0].Rows)
                {
                    lista_824_ec.Add(MapearFila_824_ec(fila_824_ec));
                }
            }
            return lista_824_ec;
        }

        public static List<_824_ecNotificacion> ListarPorDestinatario_824_ec(int idDestinatario_824_ec)
        {
            string comando_824_ec = "SELECT Notificacion_Id, Notificacion_RemitenteId, Notificaciono_DestinatarioId, Notificacion_Asunto, Notificacion_Mensaje, Notificacion_Fecha, Notificacion_Leida, Notificacion_DVH FROM Notificacion WHERE Notificaciono_DestinatarioId = @destinatarioId ORDER BY Notificacion_Fecha DESC";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@destinatarioId", idDestinatario_824_ec) };
            DAO dao_824_ec = new DAO();
            DataSet seta_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);
            List<_824_ecNotificacion> lista_824_ec = new List<_824_ecNotificacion>();

            if (seta_824_ec.Tables.Count > 0 && seta_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in seta_824_ec.Tables[0].Rows)
                {
                    lista_824_ec.Add(MapearFila_824_ec(fila_824_ec));
                }
            }
            return lista_824_ec;
        }

        public static int MarcarComoLeida_824_ec(int idNotificacion_824_ec)
        {
            string comando_824_ec = "UPDATE Notificacion SET Notificacion_Leida = 1 WHERE Notificacion_Id = @id";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@id", idNotificacion_824_ec) };
            DAO dao_824_ec = new DAO();
            return dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }

        public static int Eliminar_824_ec(int idNotificacion_824_ec)
        {
            string comando_824_ec = "DELETE FROM Notificacion WHERE Notificacion_Id = @id";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter> { new SqlParameter("@id", idNotificacion_824_ec) };
            DAO dao_824_ec = new DAO();
            return dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }

        private static _824_ecNotificacion MapearFila_824_ec(DataRow fila_824_ec)
        {
            return new _824_ecNotificacion
            {
                Id_824_ec = Convert.ToInt32(fila_824_ec["Notificacion_Id"]),
                IdRemitente_824_ec = Convert.ToInt32(fila_824_ec["Notificacion_RemitenteId"]),
                IdDestinatario_824_ec = Convert.ToInt32(fila_824_ec["Notificaciono_DestinatarioId"]),
                Asunto_824_ec = fila_824_ec["Notificacion_Asunto"].ToString(),
                Mensaje_824_ec = fila_824_ec["Notificacion_Mensaje"].ToString(),
                Fecha_824_ec = Convert.ToDateTime(fila_824_ec["Notificacion_Fecha"]),
                Leida_824_ec = Convert.ToBoolean(fila_824_ec["Notificacion_Leida"]),
                DVH_824_ec = fila_824_ec["Notificacion_DVH"] != DBNull.Value ? fila_824_ec["Notificacion_DVH"].ToString() : null
            };
        }

    }
}
