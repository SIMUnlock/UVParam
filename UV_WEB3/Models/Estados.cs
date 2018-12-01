using System;
using System.Collections.Generic;

namespace UV_WEB3.Models
{
    public partial class Estados
    {
        public Estados()
        {
            Datos = new HashSet<Datos>();
            Equipos = new HashSet<Equipos>();
            Estaciones = new HashSet<Estaciones>();
            InformesUsuarios = new HashSet<InformesUsuarios>();
            Registros = new HashSet<Registros>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdEstatus { get; set; }
        public string Nombre { get; set; }

        public ICollection<Datos> Datos { get; set; }
        public ICollection<Equipos> Equipos { get; set; }
        public ICollection<Estaciones> Estaciones { get; set; }
        public ICollection<InformesUsuarios> InformesUsuarios { get; set; }
        public ICollection<Registros> Registros { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
