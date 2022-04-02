using System;
using System.Collections.Generic;


namespace QueryApi.Domain.Dtos.Response
{
    public partial class RutaRestauranteResponse
    {
        public int Rutarestaurantesintermedia { get; set; }
        public string Nombreruta { get; set; }
        public string Municipio { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Tiporestaurante { get; set; }
    }
}
