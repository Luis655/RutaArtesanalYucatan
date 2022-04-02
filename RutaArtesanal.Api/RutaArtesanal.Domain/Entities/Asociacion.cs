using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Asociacion
    {
        public Asociacion()
        {
            Personaartesanos = new HashSet<Personaartesano>();
        }

        public int Idasociacion { get; set; }
        public string Nombreasociacion { get; set; }

        public virtual ICollection<Personaartesano> Personaartesanos { get; set; }
    }
}
