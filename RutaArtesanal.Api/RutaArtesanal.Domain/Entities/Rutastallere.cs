using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Rutastallere
    {
        public Rutastallere()
        {
            Rutatalleresintermedia = new HashSet<Rutatalleresintermedium>();
        }

        public int Idrutastalleres { get; set; }
        public string Nombreruta { get; set; }
        public string Municipio { get; set; }

        public virtual ICollection<Rutatalleresintermedium> Rutatalleresintermedia { get; set; }
    }
}
