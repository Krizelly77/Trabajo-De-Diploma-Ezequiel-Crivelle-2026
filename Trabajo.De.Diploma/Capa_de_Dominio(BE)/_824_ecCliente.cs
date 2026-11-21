using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Capa_de_Dominio_BE_
{
    [XmlInclude(typeof(_824_ecParticipante))]
    [XmlInclude(typeof(_824_ecSolicitante))]
    public abstract class _824_ecCliente
    {
        public int Id_824_ec { get; set; }
        public string Nombre_824_ec { get; set; }

        public bool Activo_824_ec { get; set; }


        public string Apellido_824_ec { get; set; }
        public string Documento_824_ec { get; set; }
        public string NumeroDeTelefono_824_ec { get; set; }
        public string CorreoElectronico { get; set; }

    }
}
