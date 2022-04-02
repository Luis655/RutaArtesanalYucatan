using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Personaartesanos = new HashSet<Personaartesano>();
            Secretaria = new HashSet<Secretarium>();
        }

        public int Idlogin { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Statu { get; set; }
        public int? Idcargo { get; set; }

        public virtual Cargo IdcargoNavigation { get; set; }
        public virtual ICollection<Personaartesano> Personaartesanos { get; set; }
        public virtual ICollection<Secretarium> Secretaria { get; set; }
    }
}
