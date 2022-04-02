using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Rutasrestaurante
    {
        public Rutasrestaurante()
        {
            Rutarestaurantesintermedia = new HashSet<Rutarestaurantesintermedium>();
        }

        public int Idrutasrestaurantes { get; set; }
        public string Nombreruta { get; set; }
        public string Municipio { get; set; }


        public virtual ICollection<Rutarestaurantesintermedium> Rutarestaurantesintermedia { get; set; }
    }
}
