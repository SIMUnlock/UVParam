using System;
using System.Collections.Generic;

namespace UV_WEB3.Models
{
    public partial class InformesUsuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int EstatusAnterior { get; set; }
        public string Observacion { get; set; }
        public int Estatus { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public int IdInformesUser { get; set; }

        public Estados EstatusNavigation { get; set; }
    }
}
