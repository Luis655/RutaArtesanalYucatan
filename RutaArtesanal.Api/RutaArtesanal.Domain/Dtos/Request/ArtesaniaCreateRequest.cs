using System;

namespace QueryApi.Domain.Dtos.Requests
{
    public class ArtesaniaCreateRequest
    {
        
        public int Idartesania { get; set; }
        public string Nombreartesania { get; set; }
        public string Descrartesan { get; set; }
        public string Fotoartesania { get; set; }
        public string Nombrematerial { get; set; }
        public string Descripcionmat { get; set; }
    }
}