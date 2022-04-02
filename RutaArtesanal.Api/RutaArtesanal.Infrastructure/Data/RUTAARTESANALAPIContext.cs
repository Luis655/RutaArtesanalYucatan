using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;

#nullable disable

namespace RutaArtesanal.Domain.Context
{
    public partial class RUTAARTESANALAPIContext : DbContext
    {
        public RUTAARTESANALAPIContext()
        {
        }

        public RUTAARTESANALAPIContext(DbContextOptions<RUTAARTESANALAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artesanium> Artesania { get; set; }
        public virtual DbSet<Asociacion> Asociacions { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Fotoplatillo> Fotoplatillos { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Personaartesano> Personaartesanos { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<Rutarestaurantesintermedium> Rutarestaurantesintermedia { get; set; }
        public virtual DbSet<Rutasrestaurante> Rutasrestaurantes { get; set; }
        public virtual DbSet<Rutastallere> Rutastalleres { get; set; }
        public virtual DbSet<Rutatalleresintermedium> Rutatalleresintermedia { get; set; }
        public virtual DbSet<Secretarium> Secretaria { get; set; }
        public virtual DbSet<Taller> Tallers { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Viajero> Viajeros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=RutaArtesanal");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Artesanium>(entity =>
            {
                entity.HasKey(e => e.Idartesania)
                    .HasName("PK_IDARTESANIA");

                entity.ToTable("ARTESANIA");

                entity.Property(e => e.Idartesania).HasColumnName("IDARTESANIA");

                entity.Property(e => e.Descrartesan)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("DESCRARTESAN");

                entity.Property(e => e.Fotoartesania)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("FOTOARTESANIA");

                entity.Property(e => e.Idmaterial).HasColumnName("IDMATERIAL");

                entity.Property(e => e.Nombreartesania)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREARTESANIA");

                entity.HasOne(d => d.IdmaterialNavigation)
                    .WithMany(p => p.Artesania)
                    .HasForeignKey(d => d.Idmaterial)
                    .HasConstraintName("FK_IDMATERIAL");
            });

            modelBuilder.Entity<Asociacion>(entity =>
            {
                entity.HasKey(e => e.Idasociacion)
                    .HasName("PK_IDASOCIACION");

                entity.ToTable("ASOCIACION");

                entity.Property(e => e.Idasociacion).HasColumnName("IDASOCIACION");

                entity.Property(e => e.Nombreasociacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREASOCIACION");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.Idcargo)
                    .HasName("PK_IDCARGO");

                entity.ToTable("CARGO");

                entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");

                entity.Property(e => e.Cargo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARGO");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.Iddireccion)
                    .HasName("PK_IDDIRECCION");

                entity.ToTable("DIRECCION");

                entity.Property(e => e.Iddireccion).HasColumnName("IDDIRECCION");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COLONIA");

                entity.Property(e => e.Cruzamientos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRUZAMIENTOS");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MUNICIPIO");

                entity.Property(e => e.Numero)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO");
            });

            modelBuilder.Entity<Fotoplatillo>(entity =>
            {
                entity.HasKey(e => e.Idfotomenu)
                    .HasName("PK_IDFOTOMENU");

                entity.ToTable("FOTOPLATILLO");

                entity.Property(e => e.Idfotomenu).HasColumnName("IDFOTOMENU");

                entity.Property(e => e.Fotorest)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("FOTOREST");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.Idmaterial)
                    .HasName("PK_IDMATERIAL");

                entity.ToTable("MATERIAL");

                entity.Property(e => e.Idmaterial).HasColumnName("IDMATERIAL");

                entity.Property(e => e.Descripcionmat)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCIONMAT");

                entity.Property(e => e.Nombrematerial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREMATERIAL");
            });

            modelBuilder.Entity<Personaartesano>(entity =>
            {
                entity.HasKey(e => e.Idartesano)
                    .HasName("PK_IDARTESANO");

                entity.ToTable("PERSONAARTESANO");

                entity.Property(e => e.Idartesano).HasColumnName("IDARTESANO");

                entity.Property(e => e.Apellidom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOM");

                entity.Property(e => e.Apellidop)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOP");

                entity.Property(e => e.Idasociacion).HasColumnName("IDASOCIACION");

                entity.Property(e => e.Idlogin).HasColumnName("IDLOGIN");

                entity.Property(e => e.Idtaller).HasColumnName("IDTALLER");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdasociacionNavigation)
                    .WithMany(p => p.Personaartesanos)
                    .HasForeignKey(d => d.Idasociacion)
                    .HasConstraintName("FK_IDASOCIACION");

                entity.HasOne(d => d.IdloginNavigation)
                    .WithMany(p => p.Personaartesanos)
                    .HasForeignKey(d => d.Idlogin)
                    .HasConstraintName("FK_IDLOGIN");

                entity.HasOne(d => d.IdtallerNavigation)
                    .WithMany(p => p.Personaartesanos)
                    .HasForeignKey(d => d.Idtaller)
                    .HasConstraintName("FK_IDTALLER");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.Idrestaurante)
                    .HasName("PK_IDRESTAURANTE");

                entity.ToTable("RESTAURANTE");

                entity.Property(e => e.Idrestaurante).HasColumnName("IDRESTAURANTE");

                entity.Property(e => e.Descripcionmenu)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCIONMENU");

                entity.Property(e => e.Iddireccion).HasColumnName("IDDIRECCION");

                entity.Property(e => e.Idfotomenu).HasColumnName("IDFOTOMENU");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LATITUD");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUD");

                entity.Property(e => e.Nombrerest)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREREST");

                entity.Property(e => e.Telfonocomercio)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TELFONOCOMERCIO");

                entity.Property(e => e.Tiporestaurante).HasColumnName("TIPORESTAURANTE");

                entity.HasOne(d => d.IddireccionNavigation)
                    .WithMany(p => p.Restaurantes)
                    .HasForeignKey(d => d.Iddireccion)
                    .HasConstraintName("FK_IDDIRECCIONRESTAURANTE");

                entity.HasOne(d => d.IdfotomenuNavigation)
                    .WithMany(p => p.Restaurantes)
                    .HasForeignKey(d => d.Idfotomenu)
                    .HasConstraintName("FK_FOTOMENU");
            });

            modelBuilder.Entity<Rutarestaurantesintermedium>(entity =>
            {
                entity.HasKey(e => e.Rutarestaurantesintermedia);

                entity.ToTable("RUTARESTAURANTESINTERMEDIA");

                entity.Property(e => e.Rutarestaurantesintermedia).HasColumnName("RUTARESTAURANTESINTERMEDIA");

                entity.Property(e => e.Idrestaurante).HasColumnName("IDRESTAURANTE");

                entity.Property(e => e.Idrutasrestaurantes).HasColumnName("IDRUTASRESTAURANTES");

                entity.HasOne(d => d.IdrestauranteNavigation)
                    .WithMany(p => p.Rutarestaurantesintermedia)
                    .HasForeignKey(d => d.Idrestaurante)
                    .HasConstraintName("FK_IDRESTAURANTETABLAINTERMEDIA");

                entity.HasOne(d => d.IdrutasrestaurantesNavigation)
                    .WithMany(p => p.Rutarestaurantesintermedia)
                    .HasForeignKey(d => d.Idrutasrestaurantes)
                    .HasConstraintName("FK_IDRUTASRESTAURANTES");
            });

            modelBuilder.Entity<Rutasrestaurante>(entity =>
            {
                entity.HasKey(e => e.Idrutasrestaurantes)
                    .HasName("PK_IDRUTASARTESANALES");

                entity.ToTable("RUTASRESTAURANTES");

                entity.Property(e => e.Idrutasrestaurantes).HasColumnName("IDRUTASRESTAURANTES");

                entity.Property(e => e.Nombreruta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRERUTA");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MUNICIPIO");
            });

            modelBuilder.Entity<Rutastallere>(entity =>
            {
                entity.HasKey(e => e.Idrutastalleres)
                    .HasName("PK_IDRUTASTALLERES");

                entity.ToTable("RUTASTALLERES");

                entity.Property(e => e.Idrutastalleres).HasColumnName("IDRUTASTALLERES");

                entity.Property(e => e.Nombreruta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRERUTA");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MUNICIPIO");
            });

            modelBuilder.Entity<Rutatalleresintermedium>(entity =>
            {
                entity.HasKey(e => e.Idrutatalleresintermedia)
                    .HasName("PK_IDRUTATALLERESINTERMEDIA");

                entity.ToTable("RUTATALLERESINTERMEDIA");

                entity.Property(e => e.Idrutatalleresintermedia).HasColumnName("IDRUTATALLERESINTERMEDIA");

                entity.Property(e => e.Idartesano).HasColumnName("IDARTESANO");

                entity.Property(e => e.Idrutastalleres).HasColumnName("IDRUTASTALLERES");

                entity.HasOne(d => d.IdartesanoNavigation)
                    .WithMany(p => p.Rutatalleresintermedia)
                    .HasForeignKey(d => d.Idartesano)
                    .HasConstraintName("FK_IDARTESANORUTATALLERESINTERMEDIA");

                entity.HasOne(d => d.IdrutastalleresNavigation)
                    .WithMany(p => p.Rutatalleresintermedia)
                    .HasForeignKey(d => d.Idrutastalleres)
                    .HasConstraintName("FK_IDRUTASTALLERES");
            });

            modelBuilder.Entity<Secretarium>(entity =>
            {
                entity.HasKey(e => e.Idsecretaria)
                    .HasName("PK_IDSECRETARIA");

                entity.ToTable("SECRETARIA");

                entity.Property(e => e.Idsecretaria).HasColumnName("IDSECRETARIA");

                entity.Property(e => e.Idlogin).HasColumnName("IDLOGIN");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.IdloginNavigation)
                    .WithMany(p => p.Secretaria)
                    .HasForeignKey(d => d.Idlogin)
                    .HasConstraintName("FK_IDLOGINSECRETARIA");
            });

            modelBuilder.Entity<Taller>(entity =>
            {
                entity.HasKey(e => e.Idtaller)
                    .HasName("PK_IDTALLER");

                entity.ToTable("TALLER");

                entity.Property(e => e.Idtaller).HasColumnName("IDTALLER");

                entity.Property(e => e.Emailcontacto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAILCONTACTO");

                entity.Property(e => e.Iddireccion).HasColumnName("IDDIRECCION");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LATITUD");

                entity.Property(e => e.Logodeltaller)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("LOGODELTALLER");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUD");

                entity.Property(e => e.Nombretaller)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRETALLER");

                entity.Property(e => e.Redessociales)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REDESSOCIALES");

                entity.Property(e => e.Telefonocontacto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONOCONTACTO");

                entity.Property(e => e.Tipotaller).HasColumnName("TIPOTALLER");

                entity.HasOne(d => d.IddireccionNavigation)
                    .WithMany(p => p.Tallers)
                    .HasForeignKey(d => d.Iddireccion)
                    .HasConstraintName("FK_IDDIRECCIONTALLER");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idlogin)
                    .HasName("PK_IDLOGIN");

                entity.ToTable("USUARIO");

                entity.Property(e => e.Idlogin).HasColumnName("IDLOGIN");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASEÑA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");

                entity.Property(e => e.Statu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATU")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdcargoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idcargo)
                    .HasConstraintName("FK_CARGO");
            });

            modelBuilder.Entity<Viajero>(entity =>
            {
                entity.HasKey(e => e.Idviajero)
                    .HasName("PK_IDVIAJERO");

                entity.ToTable("VIAJERO");

                entity.Property(e => e.Idviajero).HasColumnName("IDVIAJERO");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LATITUD");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUD");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
