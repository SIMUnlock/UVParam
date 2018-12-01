using System;
using System.Collections.Generic;

namespace UV_WEB3.Models
{
    public partial class Estaciones
    {
        public Estaciones()
        {
            Registros = new HashSet<Registros>();
        }

        public int IdEstacion { get; set; }
        public string Nombre { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public int Estatus { get; set; }
        public string Observacion { get; set; }

        public Estados EstatusNavigation { get; set; }
        public ICollection<Registros> Registros { get; set; }
    }
}
