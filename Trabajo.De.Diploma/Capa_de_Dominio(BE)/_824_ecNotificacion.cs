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
        public _824_ecParticipante Participante_824_ec { get; set; }
        public List<_824_ecParticipante> ParticipantesAgrupados { get; set; } = new List<_824_ecParticipante>();
        public string Asunto_824_ec { get; set; }
        public string Mensaje_824_ec { get; set; }
        public DateTime Fecha_824_ec { get; set; }
        public bool Leida_824_ec { get; set; }

        public string DVH_824_ec { get; set; } 

        public _824_ecNotificacion()
        {
            Fecha_824_ec = DateTime.Now;
            Leida_824_ec = false;
            ParticipantesAgrupados = new List<_824_ecParticipante>();
        }

        public _824_ecNotificacion(string asunto, string mensaje, int remitente, int destinatario, DateTime? fecha = null, bool leida = false,
            _824_ecParticipante participante = null, List<_824_ecParticipante> participantesAgrupados = null)
        {
            Asunto_824_ec = asunto;
            Mensaje_824_ec = mensaje;
            IdRemitente_824_ec = remitente;
            IdDestinatario_824_ec = destinatario;
            Fecha_824_ec = fecha ?? DateTime.Now;
            Leida_824_ec = leida;
            Participante_824_ec = participante;
            ParticipantesAgrupados = participantesAgrupados ?? new List<_824_ecParticipante>();
        }

        public List<string> ObtenerCamposParaDV()
        {
            string agrupados = (ParticipantesAgrupados != null && ParticipantesAgrupados.Count > 0)
                ? string.Join("-", ParticipantesAgrupados.OrderBy(p => p.Id_824_ec).Select(p => p.Id_824_ec.ToString())): string.Empty;

            return new List<string>
            {
                this.Id_824_ec.ToString(),
                this.IdRemitente_824_ec.ToString(),
                this.IdDestinatario_824_ec.ToString(),
                (this.Participante_824_ec?.Id_824_ec ?? 0).ToString(),
                agrupados,
                this.Asunto_824_ec ?? string.Empty,
                this.Mensaje_824_ec ?? string.Empty,
                this.Fecha_824_ec.ToString("yyyy-MM-dd HH:mm:ss"),
                this.Leida_824_ec ? "1" : "0"
            };
        }
    }
}

