using System;
using System.Collections.Generic;


namespace QueryApi.Domain.Dtos.Requests
{
    public partial class RutaRestauranteCreateRequest
    {
        public int Rutarestaurantesintermedia { get; set; }
        public int? Idrutasrestaurantes { get; set; }
        public int? Idrestaurante { get; set; }

    }
}
