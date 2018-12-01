using System;
using System.Collections.Generic;

namespace UV_WEB3.Models
{
    public partial class Equipos
    {
        public Equipos()
        {
            Registros = new HashSet<Registros>();
        }

        public int IdEquipo { get; set; }
        public string Modelo { get; set; }
        public string NoSerial { get; set; }
        public string Rango { get; set; }
        public string Presicion { get; set; }
        public string Resolucion { get; set; }
        public string Estabilidad { get; set; }
        public int Estatus { get; set; }
        public string Observacion { get; set; }

        public Estados EstatusNavigation { get; set; }
        public ICollection<Registros> Registros { get; set; }
    }
}
