using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Dominio_BE_
{
    public class _824_ecSolicitante: _824_ecCliente, IVerificable
    {
        private List<_824_ecActividad> actividades = new List<_824_ecActividad>();

        public List<_824_ecActividad> Actividades_824_ec
        {
            get => actividades;
            set => actividades = value ?? new List<_824_ecActividad>();
        }

        public _824_ecSolicitante(int id)
        {
            Id_824_ec = id;
            FechaDeAlta = DateTime.Today;
            actividades = new List<_824_ecActividad>();
        }
        public _824_ecSolicitante() 
        {
            FechaDeAlta = DateTime.Today;
            actividades = new List<_824_ecActividad>();
        }


        public DateTime FechaDeAlta { get; set; }
        public string DVH_824_ec { get ; set ; }

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
                this.FechaDeAlta.ToString("yyyy-MM-dd"),
            };
        }
    }
}
