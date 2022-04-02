using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Material
    {
        public Material()
        {
            Artesania = new HashSet<Artesanium>();
        }

        public int Idmaterial { get; set; }
        public string Nombrematerial { get; set; }
        public string Descripcionmat { get; set; }

        public virtual ICollection<Artesanium> Artesania { get; set; }
    }
}
