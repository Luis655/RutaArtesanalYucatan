using System;
namespace QueryApi.Domain.Dtos.Response
{
    public class ArtesanoResponse
    {
        
        public int Idartesano { get; set; }
        public string Nombrecompleto { get; set; }
        public string Nombreasociacion { get; set; }
        public string Statu { get; set; }
        public string Nombretaller { get; set; }
        public string Telefonocontacto { get; set; }
        public string Emailcontacto { get; set; }
        public string Redessociales { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int Tipotaller { get; set; }

       
        
    }
}