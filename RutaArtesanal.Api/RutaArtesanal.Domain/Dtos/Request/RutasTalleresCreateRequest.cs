using System;
using System.Collections.Generic;


namespace QueryApi.Domain.Dtos.Requests
{
    public partial class RutasTalleresCreateRequest
    {
        public int Idrutatalleresintermedia { get; set; }
        public int? Idrutastalleres { get; set; }
        public int? Idartesano { get; set; }

    }
}
