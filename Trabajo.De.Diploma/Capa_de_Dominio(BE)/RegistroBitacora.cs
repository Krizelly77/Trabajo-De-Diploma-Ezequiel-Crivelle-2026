using System;

namespace Capa_de_Dominio_BE_
{
    public class RegistroBitacora
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Actividad { get; set; }
        public DateTime FechaHora { get; set; }

        public RegistroBitacora(string usuario, string actividad)
        {
            Usuario = usuario;
            Actividad = actividad;
            FechaHora = DateTime.Now;
        }
    }
}
