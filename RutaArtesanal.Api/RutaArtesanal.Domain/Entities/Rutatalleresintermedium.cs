using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Rutatalleresintermedium
    {
        public int Idrutatalleresintermedia { get; set; }
        public int? Idrutastalleres { get; set; }
        public int? Idartesano { get; set; }

        public virtual Personaartesano IdartesanoNavigation { get; set; }
        public virtual Rutastallere IdrutastalleresNavigation { get; set; }
    }
}
