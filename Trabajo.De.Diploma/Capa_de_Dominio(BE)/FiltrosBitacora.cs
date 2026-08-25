using System;

namespace Capa_de_Dominio_BE_
{
    public class FiltrosBitacora
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Usuario { get; set; }
        public string Actividad { get; set; }
    }
}
