using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Taller
    {
        public Taller()
        {
            Personaartesanos = new HashSet<Personaartesano>();
        }

        public int Idtaller { get; set; }
        public string Nombretaller { get; set; }
        public string Logodeltaller { get; set; }
        public string Telefonocontacto { get; set; }
        public string Emailcontacto { get; set; }
        public string Redessociales { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Iddireccion { get; set; }
        public int? Tipotaller { get; set; }

        public virtual Direccion IddireccionNavigation { get; set; }
        public virtual ICollection<Personaartesano> Personaartesanos { get; set; }
    }
}
