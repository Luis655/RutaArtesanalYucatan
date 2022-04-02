using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Fotoplatillo
    {
        public Fotoplatillo()
        {
            Restaurantes = new HashSet<Restaurante>();
        }

        public int Idfotomenu { get; set; }
        public string Fotorest { get; set; }

        public virtual ICollection<Restaurante> Restaurantes { get; set; }
    }
}
