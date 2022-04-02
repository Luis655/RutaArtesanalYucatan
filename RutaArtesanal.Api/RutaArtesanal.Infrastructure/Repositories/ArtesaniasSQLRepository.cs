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
    public class ArtesaniaSQLRepository : IArtesaniaRepository
    {
        

        private readonly RUTAARTESANALAPIContext _context;

        public ArtesaniaSQLRepository(RUTAARTESANALAPIContext context)
        {
        this._context = context;
        }



         public async Task<IQueryable<Artesanium>> GetAll()
        {
            var query = await _context.Artesania.Include(x => x.IdmaterialNavigation).AsQueryable<Artesanium>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }


         public async Task<Artesanium> GetById(int id)
        {
            var query = await _context.Artesania.Include(x => x.IdmaterialNavigation).FirstOrDefaultAsync(x => x.Idartesania ==id);

            return query;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            _context.Remove(entity);


            var rows =await _context.SaveChangesAsync();

            return rows >0;
        }



        public async Task<IQueryable<Artesanium>> GetByFilter(Artesanium artesania)
        {

            if (artesania == null)
                return new List<Artesanium>().AsQueryable();
            var query = _context.Artesania.Select(x=>x);
            if (!string.IsNullOrEmpty(artesania.Nombreartesania))
            {
                query = query.Where(x=>x.Nombreartesania.Contains(artesania.Nombreartesania));
            }
            if (artesania.Idartesania>0)
            {
                query = query.Where(x=>x.Idartesania==artesania.Idartesania);
            }
            if (!string.IsNullOrEmpty(artesania.IdmaterialNavigation.Nombrematerial))
            {
                query = query.Where(x=>x.IdmaterialNavigation.Nombrematerial.Contains(artesania.IdmaterialNavigation.Nombrematerial));
            }
            var result = await query.ToListAsync();
            return result.AsQueryable().AsNoTracking();

        }
        



     
        // Retornar elementos que sean de diferentes asociasiones
           public IEnumerable<string> GetAsociations(string asociation)
        {
           var  query = _context.Artesania.Select(Person=>Person.Nombreartesania).Distinct();
            return query;

        }

        //valores que contengan
        public IEnumerable<Artesanium> GetStartWith(string word)
        {
           
            var query = _context.Artesania.Where(p=>p.Nombreartesania.StartsWith(word));
            return query;
        }


        public async Task<int> Create(Artesanium artesania)
        {
           var entity = artesania;
           await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();
            
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            
            return entity.Idartesania;
        }



         public async Task<bool> Update(int id, Artesanium artesania)
        {
            if(id<= 0 || artesania==null)
                 throw new ArgumentException("falta informacion, favor de verificar tu informacion");
            var entity = await GetById(id);
            entity.Nombreartesania = artesania.Nombreartesania;
            entity.Descrartesan = artesania.Descrartesan;
            entity.Fotoartesania = artesania.Fotoartesania;
            entity.IdmaterialNavigation = new Material();
            entity.IdmaterialNavigation.Nombrematerial = artesania.IdmaterialNavigation.Nombrematerial;
            entity.IdmaterialNavigation.Descripcionmat = artesania.IdmaterialNavigation.Descripcionmat;
            _context.Update(entity);
            var rows =await _context.SaveChangesAsync();
            return rows >0;
       }

      



    }
}
