using System;
using System.Collections.Generic;

#nullable disable

namespace RutaArtesanal.Api.RutaArtesanal.Domain.Entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Idcargo { get; set; }
        public string Cargo1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
