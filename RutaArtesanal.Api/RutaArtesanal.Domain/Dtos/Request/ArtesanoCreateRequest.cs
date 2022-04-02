using System;

namespace QueryApi.Domain.Dtos.Requests
{
    public class ArtesanoCreateRequest
    {
        public int Idartesano { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }        
        public string Nombreasociacion { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Statu { get; set; }
        public string Nombretaller { get; set; }
        public string Logodeltaller { get; set; }
        public string Telefonocontacto { get; set; }
        public string Emailcontacto { get; set; }
        public string Redessociales { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Tipotaller { get; set; }
    }
}