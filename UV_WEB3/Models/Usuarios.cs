using System;
using System.Collections.Generic;

namespace UV_WEB3.Models
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Estatus { get; set; }
        public string Observacion { get; set; }
        public int Tipo { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellitoMat { get; set; }
        public string Usuario { get; set; }

        public Estados EstatusNavigation { get; set; }
    }
}
