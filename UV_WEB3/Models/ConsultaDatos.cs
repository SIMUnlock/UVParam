using System;
using System.Collections.Generic;

namespace UV_WEB3.Models
{
    public partial class ConsultaDatos
    {
        public ConsultaDatos()
        {

        }

        public int idEst { get; set; }
        public int idDato { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }

    }
}
