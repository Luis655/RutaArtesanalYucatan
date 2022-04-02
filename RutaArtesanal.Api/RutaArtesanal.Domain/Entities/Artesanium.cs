using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Artesanium
    {
        public int Idartesania { get; set; }
        public string Nombreartesania { get; set; }
        public string Descrartesan { get; set; }
        public int? Idmaterial { get; set; }
        public string Fotoartesania { get; set; }
        public virtual Material IdmaterialNavigation { get; set; }
    }
}
