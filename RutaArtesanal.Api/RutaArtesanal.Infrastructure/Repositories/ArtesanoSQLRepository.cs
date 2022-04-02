using System.Collections;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using QueryApi.Domain.Interfaces;
using System.Threading.Tasks;
using System.Linq.Expressions;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;
using RutaArtesanal.Domain.Context;

#nullable disable

namespace RutaArtesanal.Infrastructure.Repositories
{
    public class ArtesanosSQLRepository : IArtesanoRepository
    {
        

        private readonly RUTAARTESANALAPIContext _context;

        public ArtesanosSQLRepository(RUTAARTESANALAPIContext context)
        {
        this._context = context;
        }



         public async Task<IQueryable<Personaartesano>> GetAll()
        {
            var query = await _context.Personaartesanos.Include(x => x.IdasociacionNavigation).Include(x => x.IdloginNavigation).Include(x=> x.IdtallerNavigation).AsQueryable<Personaartesano>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IQueryable<Rutastallere>> GetAllRutasTalleres()
        {
            var query = await _context.Rutastalleres.AsQueryable<Rutastallere>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

          public async Task<IQueryable<Rutatalleresintermedium>> GetAllRutasTalleresintermedia()
        {
            var query = await _context.Rutatalleresintermedia.Include(x => x.IdartesanoNavigation).Include(x=>x.IdrutastalleresNavigation).AsQueryable<Rutatalleresintermedium>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }


           public async Task<IEnumerable<Rutarestaurantesintermedium>> GetAllRutasRestaurantes()
        {
            var query = await _context.Rutarestaurantesintermedia.Include(x => x.IdrestauranteNavigation).Include(x => x.IdrutasrestaurantesNavigation).Include(x => x.IdrestauranteNavigation.IddireccionNavigation).AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        public async Task<IEnumerable<Rutasrestaurante>> GetAllRutasRestaurantes2()
        {
            var query = await _context.Rutasrestaurantes.AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }


          public async Task<IQueryable<Restaurante>> GetAllRestaurantes()
        {
            var query = await _context.Restaurantes.Include(x => x.IddireccionNavigation).Include(x=>x.IdfotomenuNavigation).AsQueryable<Restaurante>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }


         public async Task<Personaartesano> GetById(int id)
        {
            var query = await _context.Personaartesanos.Include(x => x.IdasociacionNavigation).Include(x => x.IdloginNavigation).Include(x=> x.IdtallerNavigation).FirstOrDefaultAsync(x => x.Idartesano ==id);
            return query;
        }



         public async Task<Personaartesano> GetById2(int id)
        {
            var query = await _context.Personaartesanos.FirstOrDefaultAsync(x => x.Idartesano ==id);
            return query;
        }


        public async Task<Rutastallere> GetByIdRutasTalleres(int id)
        {
            var query = await _context.Rutastalleres.FirstOrDefaultAsync(x => x.Idrutastalleres ==id);
            return query;
        }

        public async Task<IQueryable<Rutatalleresintermedium>> GetByIdRutasTalleresintermedia(string municipio)
        {
            var query = await _context.Rutatalleresintermedia.Where(x => x.IdrutastalleresNavigation.Municipio == municipio).Include(x => x.IdartesanoNavigation).Include(x => x.IdrutastalleresNavigation).ToListAsync();
            return query.AsQueryable();
        }
        public async Task<Rutatalleresintermedium> GetByIdRutasTalleresintermedia2(int id)
        {
            var query = await _context.Rutatalleresintermedia.Include(x => x.IdartesanoNavigation).Include(x => x.IdrutastalleresNavigation).FirstOrDefaultAsync(x => x.Idrutatalleresintermedia ==id);
            return query;
        }


        public async Task<Rutarestaurantesintermedium> GetByIdRutasRestaurantes3(int id)
        {
            var query = await _context.Rutarestaurantesintermedia.Include(x => x.IdrestauranteNavigation).Include(x => x.IdrutasrestaurantesNavigation).FirstOrDefaultAsync(x => x.Rutarestaurantesintermedia ==id);
            return query;
        }

        public async Task<IQueryable<Rutarestaurantesintermedium>> GetByIdRutasRestaurantes(string municipio)
        {
            var query = await _context.Rutarestaurantesintermedia.Where(x => x.IdrestauranteNavigation.IddireccionNavigation.Municipio == municipio).Include(x => x.IdrestauranteNavigation).Include(x => x.IdrutasrestaurantesNavigation).ToListAsync();
            return query.AsQueryable();
        }


        public async Task<Rutasrestaurante> GetByIdRutasRestaurantes2(int id)
        {
            var query = await _context.Rutasrestaurantes.FirstOrDefaultAsync(x => x.Idrutasrestaurantes ==id);
            return query;
        }


            public async Task<Restaurante> GetByIdRestaurantes(int id)
        {
            var query = await _context.Restaurantes.Include(x => x.IddireccionNavigation).Include(x => x.IdfotomenuNavigation).FirstOrDefaultAsync(x => x.Idrestaurante ==id);

            return query;
        }

        public Restaurante GetByIdRestaurantes2(int id)
        {
            var query =  _context.Restaurantes.FirstOrDefault(x => x.Idrestaurante == id);
            return query;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            _context.Remove(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
        }


        public async Task<bool> DeleteRutasTalleres(int id)
        {
            var entity = await GetByIdRutasTalleres(id);
            _context.Remove(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
        }

        public async Task<bool> DeleteRutasTalleresintermedia(int id)
        {
            var entity = await GetByIdRutasTalleresintermedia2(id);
            _context.Remove(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
        }


           public async Task<bool> DeleteRutasRestaurantes(int id)
        {
            var entity = await GetByIdRutasRestaurantes3(id);
            _context.Remove(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
        }



        public async Task<bool> DeleteRutasRestaurantes2(int id)
        {
            var entity = await GetByIdRutasRestaurantes2(id);
            _context.Remove(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
        }


        public async Task<bool> DeleteRestaurantes(int id)
        {
            var entity = await GetByIdRestaurantes(id);
            _context.Remove(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
        }


        public async Task<IQueryable<Personaartesano>> GetByFilter(Personaartesano artesano)
        {
            if (artesano == null)
                return new List<Personaartesano>().AsQueryable();
            var query = _context.Personaartesanos.Select(x=>x);
            if (!string.IsNullOrEmpty(artesano.Nombre))
            {
                query = query.Where(x=>x.Nombre.Contains(artesano.Nombre));
            }
            if (artesano.Idartesano>0)
            {
                query = query.Where(x=>x.Idartesano==artesano.Idartesano);
            }
            if (!string.IsNullOrEmpty(artesano.IdasociacionNavigation.Nombreasociacion))
            {
                query = query.Where(x=>x.IdasociacionNavigation.Nombreasociacion.Contains(artesano.IdasociacionNavigation.Nombreasociacion));
            }
            if (artesano.IdloginNavigation.Correo !=null)
            {
                query = query.Where(x=>x.IdloginNavigation.Correo ==artesano.IdloginNavigation.Correo);
            }
            var result = await query.ToListAsync();
            return result.AsQueryable().AsNoTracking();
        }
        



     
        // Retornar elementos que sean de diferentes asociasiones
           public IEnumerable<string> GetAsociations(string asociation)
        {
           var  query = _context.Personaartesanos.Select(Person=>Person.IdasociacionNavigation.Nombreasociacion).Distinct();
            return query;

        }

        //valores que contengan
        public IEnumerable<Personaartesano> GetStartWith(string word)
        {
            var query = _context.Personaartesanos.Where(p=>p.IdasociacionNavigation.Nombreasociacion.StartsWith(word));
            return query;
        }


        public async Task<int> Create(Personaartesano personaartesano)
        {
           var entity = personaartesano;
           await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();
            
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            
            return entity.Idartesano;
        }


        public async Task<int> CreateRutaTaller(Rutastallere rutastallere)
        {
           var entity = rutastallere;
           await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            return entity.Idrutastalleres;
        }


        public async Task<int> CreateRutaTallerintermedia(Rutatalleresintermedium rutatalleresintermedium)
        {
           var entity = rutatalleresintermedium;
           await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            return entity.Idrutatalleresintermedia;
        }


        public async Task<int> CreateRutaRestaurante(Rutarestaurantesintermedium rutarestaurantesintermedium)
        {
           var entity = rutarestaurantesintermedium;
           await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            return entity.Rutarestaurantesintermedia;
        }



        public async Task<int> CreateRutaRestaurante2(Rutasrestaurante rutasrestaurante)
        {
           var entity = rutasrestaurante;
           await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            return entity.Idrutasrestaurantes;
        }



         public async Task<int> CreateRestaurante(Restaurante restaurante)
        {
           var entity = restaurante;
           await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            return entity.Idrestaurante;
        }



         public async Task<bool> Update(int id, Personaartesano personaartesano)
        {
            if(id<= 0 || personaartesano==null)
                 throw new ArgumentException("falta informacion, favor de verificar tu informacion");
            var entity = await GetById2(id);
            entity.Nombre = personaartesano.Nombre;
            entity.Apellidop = personaartesano.Apellidop;
            entity.Apellidom = personaartesano.Apellidom;
            entity.IdasociacionNavigation = new Asociacion();
            entity.IdasociacionNavigation.Nombreasociacion = personaartesano.IdasociacionNavigation.Nombreasociacion;
            entity.IdloginNavigation = new Usuario();
            entity.IdloginNavigation.Correo = personaartesano.IdloginNavigation.Correo;
            entity.IdloginNavigation.Contraseña = personaartesano.IdloginNavigation.Contraseña;
            entity.IdloginNavigation.Statu = personaartesano.IdloginNavigation.Statu;
            entity.IdtallerNavigation = new Taller();
            entity.IdtallerNavigation.Nombretaller = personaartesano.IdtallerNavigation.Nombretaller;
            entity.IdtallerNavigation.Logodeltaller = personaartesano.IdtallerNavigation.Logodeltaller;
            entity.IdtallerNavigation.Telefonocontacto = personaartesano.IdtallerNavigation.Telefonocontacto;
            entity.IdtallerNavigation.Emailcontacto = personaartesano.IdtallerNavigation.Emailcontacto;
            entity.IdtallerNavigation.Redessociales = personaartesano.IdtallerNavigation.Redessociales;
            entity.IdtallerNavigation.Latitud = personaartesano.IdtallerNavigation.Latitud;
            entity.IdtallerNavigation.Longitud = personaartesano.IdtallerNavigation.Longitud;
            entity.IdtallerNavigation.Tipotaller = personaartesano.IdtallerNavigation.Tipotaller;
            
            _context.Update(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
       }


       public async Task<bool> UpdateRutasTalleres(int id, Rutastallere rutastallere)
        {
            if(id<= 0 || rutastallere==null)
                 throw new ArgumentException("falta informacion, favor de verificar tu informacion");
            var entity = await GetByIdRutasTalleres(id);
            entity.Nombreruta = rutastallere.Nombreruta;
            entity.Municipio = rutastallere.Municipio;
            _context.Update(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
       }


       public async Task<bool> UpdateRutasTalleresintermedia(int id, Rutatalleresintermedium rutatalleresintermedium)
        {
            if(id<= 0 || rutatalleresintermedium==null)
                 throw new ArgumentException("falta informacion, favor de verificar tu informacion");
            var entity = await GetByIdRutasTalleresintermedia2(id);
            entity.Idrutastalleres = rutatalleresintermedium.Idrutastalleres;
            entity.Idartesano = rutatalleresintermedium.Idartesano;
            _context.Update(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
       }


       public async Task<bool> UpdateRutasRestaurantes(int id, Rutarestaurantesintermedium rutarestaurantesintermedium)
        {
            if(id<= 0 || rutarestaurantesintermedium==null)
                 throw new ArgumentException("falta informacion, favor de verificar tu informacion");
            var entity = await GetByIdRutasRestaurantes3(id);
            entity.Idrutasrestaurantes = rutarestaurantesintermedium.Idrutasrestaurantes;
            entity.Idrestaurante = rutarestaurantesintermedium.Idrestaurante;
            _context.Update(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
       }


       public async Task<bool> UpdateRutasRestaurantes2(int id, Rutasrestaurante rutasrestaurante)
        {
            if(id<= 0 || rutasrestaurante==null)
                 throw new ArgumentException("falta informacion, favor de verificar tu informacion");
            var entity = await GetByIdRutasRestaurantes2(id);
            entity.Nombreruta = rutasrestaurante.Nombreruta;
            entity.Municipio = rutasrestaurante.Municipio;
            _context.Update(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
       }


       public async Task<bool> UpdateRestaurantes(int id, Restaurante restaurante)
        {
             
            if(id<= 0 || restaurante==null)
                 throw new ArgumentException("falta informacion, favor de verificar tu informacion");
            
            var entity = GetByIdRestaurantes2(id);
            entity.Nombrerest = restaurante.Nombrerest;
            entity.Telfonocomercio = restaurante.Telfonocomercio;
            entity.Descripcionmenu = restaurante.Descripcionmenu;
            entity.Latitud = restaurante.Latitud;
            entity.Longitud = restaurante.Longitud;
            entity.Tiporestaurante = restaurante.Tiporestaurante;
            entity.IddireccionNavigation = new Direccion();
            entity.IddireccionNavigation.Municipio = restaurante.IddireccionNavigation.Municipio;
            entity.IddireccionNavigation.Colonia = restaurante.IddireccionNavigation.Colonia;
            entity.IddireccionNavigation.Cruzamientos = restaurante.IddireccionNavigation.Cruzamientos;
            entity.IddireccionNavigation.Numero = restaurante.IddireccionNavigation.Numero;
            entity.IdfotomenuNavigation = new Fotoplatillo();
            entity.IdfotomenuNavigation.Fotorest = restaurante.IdfotomenuNavigation.Fotorest;

            

            _context.Update(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
       }

         public bool Exist(Expression<Func<Personaartesano, bool>> expression)
        {
            return _context.Personaartesanos.Any(expression);
        }



    }
}

