using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Restaurante
    {
        public Restaurante()
        {
            Rutarestaurantesintermedia = new HashSet<Rutarestaurantesintermedium>();
        }

        public int Idrestaurante { get; set; }
        public string Nombrerest { get; set; }
        public string Telfonocomercio { get; set; }
        public string Descripcionmenu { get; set; }
        public int? Iddireccion { get; set; }
        public int? Idfotomenu { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Tiporestaurante { get; set; }

        public virtual Direccion IddireccionNavigation { get; set; }
        public virtual Fotoplatillo IdfotomenuNavigation { get; set; }
        public virtual ICollection<Rutarestaurantesintermedium> Rutarestaurantesintermedia { get; set; }
    }
}
