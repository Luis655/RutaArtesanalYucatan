using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Direccion
    {
        public Direccion()
        {
            Restaurantes = new HashSet<Restaurante>();
            Tallers = new HashSet<Taller>();
        }

        public int Iddireccion { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public string Cruzamientos { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<Restaurante> Restaurantes { get; set; }
        public virtual ICollection<Taller> Tallers { get; set; }
    }
}
