using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Rutarestaurantesintermedium
    {
        public int Rutarestaurantesintermedia { get; set; }
        public int? Idrutasrestaurantes { get; set; }
        public int? Idrestaurante { get; set; }

        public virtual Restaurante IdrestauranteNavigation { get; set; }
        public virtual Rutasrestaurante IdrutasrestaurantesNavigation { get; set; }
    }
}
