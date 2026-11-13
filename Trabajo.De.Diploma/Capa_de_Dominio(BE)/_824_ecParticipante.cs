using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public class _824_ecParticipante : _824_ecCliente, IVerificable
    {
        private List<_824_ecPostulacion> postulaciones = new List<_824_ecPostulacion>();

        public List<_824_ecPostulacion> Postulaciones_824_ec
        {
            get => postulaciones;
            set => postulaciones = value ?? new List<_824_ecPostulacion>();
        }

        public _824_ecParticipante(int id)
        {
            Id_824_ec = id;
            FechaDeAlta = DateTime.Today;
            postulaciones = new List<_824_ecPostulacion>();
        }
        public _824_ecParticipante() 
        {
            FechaDeAlta = DateTime.Today;
            postulaciones = new List<_824_ecPostulacion>();
        }
        


        public string PalabraClave_824_ec { get; set; }

        public DateTime FechaDeAlta { get; set; }

        public string DVH_824_ec { get; set; } // digito verificador


        public List<string> ObtenerCamposParaDV()
        {
            return new List<string>
            {
                this.Id_824_ec.ToString(),
                this.Nombre_824_ec,
                this.Apellido_824_ec,
                this.Documento_824_ec,
                this.NumeroDeTelefono_824_ec.ToString(),
                this.CorreoElectronico ?? string.Empty,
                this.Activo_824_ec.ToString(),
                this.PalabraClave_824_ec,
                this.FechaDeAlta.ToString("yyyy-MM-dd"),
            };
        }
    }
}
