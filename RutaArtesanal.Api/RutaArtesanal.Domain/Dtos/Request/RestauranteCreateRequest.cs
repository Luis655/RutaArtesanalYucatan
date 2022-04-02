using System;
using System.Collections.Generic;

#nullable disable

namespace QueryApi.Domain.Dtos.Requests
{
    public partial class RestauranteCreateRequest
    {
        public int Idrestaurante { get; set; }
        public string Nombrerest { get; set; }
        public string Telfonocomercio { get; set; }
        public string Descripcionmenu { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Tiporestaurante { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public string Cruzamientos { get; set; }
        public string Numero { get; set; }
        public string Fotorest { get; set; }
    }
}
