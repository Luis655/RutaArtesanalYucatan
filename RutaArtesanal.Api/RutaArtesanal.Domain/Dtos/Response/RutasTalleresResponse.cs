using System;
using System.Collections.Generic;


namespace QueryApi.Domain.Dtos.Response
{
    public partial class RutaTalleresResponse
    {
        public int? Idrutatalleresintermedia { get; set; }
        public string Nombretaller { get; set; }
        public string Municipio { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
