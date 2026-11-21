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
    public class _824_ecActividadCambioDAL
    {
        public static List<_824_ecActividadCambio> Listar_824_ec( int? actividadId_824_ec = null, string nombre_824_ec = null, DateTime? fechaIni_824_ec = null, DateTime? fechaFin_824_ec = null)
        {
            string comando_824_ec = @"SELECT Id_Historico, Actividad_Id, Fecha, Hora, Actividad_Nombre, 
                                             Actividad_Descripcion, Categoria_Id, Actividad_FechaHora, 
                                             Actividad_FechaPublicacion, Actividad_FechaCaducidad, 
                                             Actividad_Ubicacion, Actividad_CantMinima, Actividad_CantMaxima, 
                                             Actividad_NivelRequerido, Actividad_Estado, Usuario_OrganizadorId, 
                                             Solicitante_Id, Actividad_Activo, Act
                                      FROM Actividad_C
                                      WHERE 1 = 1";

            List<SqlParameter> parametros_824_ec = new List<SqlParameter>();

            if (actividadId_824_ec.HasValue && actividadId_824_ec.Value > 0)
            {
                comando_824_ec += " AND Actividad_Id = @actividadId";
                parametros_824_ec.Add(new SqlParameter("@actividadId", actividadId_824_ec.Value));
            }

            if (!string.IsNullOrWhiteSpace(nombre_824_ec))
            {
                comando_824_ec += " AND Actividad_Nombre LIKE @nombre";
                parametros_824_ec.Add(new SqlParameter("@nombre", "%" + nombre_824_ec.Trim() + "%"));
            }

            if (fechaIni_824_ec.HasValue)
            {
                comando_824_ec += " AND Fecha >= @fechaIni";
                parametros_824_ec.Add(new SqlParameter("@fechaIni", fechaIni_824_ec.Value.Date));
            }

            if (fechaFin_824_ec.HasValue)
            {
                comando_824_ec += " AND Fecha <= @fechaFin";
                parametros_824_ec.Add(new SqlParameter("@fechaFin", fechaFin_824_ec.Value.Date));
            }

            comando_824_ec += " ORDER BY Fecha DESC, Hora DESC, Id_Historico DESC";

            DAO dao_824_ec = new DAO();
            DataSet ds_824_ec = dao_824_ec.ObtenerDataSet(comando_824_ec, parametros_824_ec);
            List<_824_ecActividadCambio> lista_824_ec = new List<_824_ecActividadCambio>();

            if (ds_824_ec.Tables.Count > 0 && ds_824_ec.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila_824_ec in ds_824_ec.Tables[0].Rows)
                {
                    lista_824_ec.Add(new _824_ecActividadCambio
                    {
                        IdHistorico_824_ec = Convert.ToInt32(fila_824_ec["Id_Historico"]),
                        Id_824_ec = Convert.ToInt32(fila_824_ec["Actividad_Id"]),
                        Fecha_824_ec = Convert.ToDateTime(fila_824_ec["Fecha"]),
                        Hora_824_ec = fila_824_ec["Hora"].ToString(),
                        Nombre_824_ec = fila_824_ec["Actividad_Nombre"].ToString(),
                        Descripcion_824_ec = fila_824_ec["Actividad_Descripcion"] != DBNull.Value ? fila_824_ec["Actividad_Descripcion"].ToString() : string.Empty,
                        CategoriaId_824_ec = fila_824_ec["Categoria_Id"] != DBNull.Value ? (int?)Convert.ToInt32(fila_824_ec["Categoria_Id"]) : null,
                        FechaHora_824_ec = Convert.ToDateTime(fila_824_ec["Actividad_FechaHora"]),
                        FechaPublicacion_824_ec = Convert.ToDateTime(fila_824_ec["Actividad_FechaPublicacion"]),
                        FechaCaducidad_824_ec = Convert.ToDateTime(fila_824_ec["Actividad_FechaCaducidad"]),
                        Ubicacion_824_ec = fila_824_ec["Actividad_Ubicacion"].ToString(),
                        CantidadMinima_824_ec = Convert.ToInt32(fila_824_ec["Actividad_CantMinima"]),
                        CantidadMaxima_824_ec = Convert.ToInt32(fila_824_ec["Actividad_CantMaxima"]),
                        NivelRequerido_824_ec = (NivelRequerido_824_ec)Convert.ToInt32(fila_824_ec["Actividad_NivelRequerido"]),
                        Estado_824_ec = (EstadoActividad_824_ec)Convert.ToInt32(fila_824_ec["Actividad_Estado"]),
                        OrganizadorId_824_ec = fila_824_ec["Usuario_OrganizadorId"] != DBNull.Value ? (int?)Convert.ToInt32(fila_824_ec["Usuario_OrganizadorId"]) : null,
                        SolicitanteId_824_ec = fila_824_ec["Solicitante_Id"] != DBNull.Value ? (int?)Convert.ToInt32(fila_824_ec["Solicitante_Id"]) : null,
                        ActividadActivo_824_ec = Convert.ToBoolean(fila_824_ec["Actividad_Activo"]),
                        Act_824_ec = Convert.ToBoolean(fila_824_ec["Act"])
                    });
                }
            }

            return lista_824_ec;
        }

        public static int Activar_824_ec(int idHistorico_824_ec)
        {
            // Al poner Act = 1, el trigger TR_Actividad_C_Activar desactiva los demas y sincroniza la tabla maestra de Actividad
            string comando_824_ec = "UPDATE Actividad_C SET Act = 1 WHERE Id_Historico = @idHistorico";
            List<SqlParameter> parametros_824_ec = new List<SqlParameter>
            {
                new SqlParameter("@idHistorico", idHistorico_824_ec)
            };

            DAO dao_824_ec = new DAO();
            return dao_824_ec.EjecutarNonQuery(comando_824_ec, parametros_824_ec);
        }
    }
}
