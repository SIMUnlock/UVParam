using System;
using System.Collections.Generic;

namespace UV_WEB3.Models
{
    public partial class Registros
    {
        public int IdRegistro { get; set; }
        public int NoLance { get; set; }
        public float Valor { get; set; }
        public int IdDato { get; set; }
        public float Profundidad { get; set; }
        public string FechaLance { get; set; }
        public string Hora { get; set; }
        public int IdEstacion { get; set; }
        public int IdEquipo { get; set; }
        public int Estatus { get; set; }
        public string Observacion { get; set; }

        public Estados EstatusNavigation { get; set; }
        public Datos IdDatoNavigation { get; set; }
        public Equipos IdEquipoNavigation { get; set; }
        public Estaciones IdEstacionNavigation { get; set; }
    }
}
