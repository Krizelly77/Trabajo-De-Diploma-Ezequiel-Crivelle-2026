using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public class _824_ecNotificacion : IVerificable
    {
        public int Id_824_ec { get; set; }
        public int IdRemitente_824_ec { get; set; }
        public int IdDestinatario_824_ec { get; set; }
        public string Asunto_824_ec { get; set; }
        public string Mensaje_824_ec { get; set; }
        public DateTime Fecha_824_ec { get; set; }
        public bool Leida_824_ec { get; set; }

        public string DVH_824_ec { get; set; } 

        public _824_ecNotificacion()
        {
            Fecha_824_ec = DateTime.Now;
            Leida_824_ec = false;
        }

        public _824_ecNotificacion(string asunto, string mensaje, int remitente, int destinatario, DateTime? fecha = null, bool leida = false)
        {
            Asunto_824_ec = asunto;
            Mensaje_824_ec = mensaje;
            IdRemitente_824_ec = remitente;
            IdDestinatario_824_ec = destinatario;
            Fecha_824_ec = fecha ?? DateTime.Now;
            Leida_824_ec = leida;
        }

        public List<string> ObtenerCamposParaDV()
        {
            return new List<string>
            {
                this.Id_824_ec.ToString(),
                this.IdRemitente_824_ec.ToString(),
                this.IdDestinatario_824_ec.ToString(),
                this.Asunto_824_ec ?? string.Empty,
                this.Mensaje_824_ec ?? string.Empty,
                this.Fecha_824_ec.ToString("yyyy-MM-dd HH:mm:ss"),
                this.Leida_824_ec ? "1" : "0"
            };
        }
    }
}

