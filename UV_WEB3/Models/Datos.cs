using System;
using System.Collections.Generic;

namespace UV_WEB3.Models
{
    public partial class Datos
    {
        public Datos()
        {
            Registros = new HashSet<Registros>();
        }

        public int IdDato { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public int Estatus { get; set; }
        public string Observacion { get; set; }

        public Estados EstatusNavigation { get; set; }
        public ICollection<Registros> Registros { get; set; }
    }
}
