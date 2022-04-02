using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;
using QueryApi.Domain.Dtos.Requests;

namespace QueryApi.Domain.Interfaces
{
    public interface IArtesanoRepository
    {
        Task<IQueryable<Personaartesano>> GetAll();
        Task<IQueryable<Rutastallere>> GetAllRutasTalleres();
        Task<IQueryable<Rutatalleresintermedium>> GetAllRutasTalleresintermedia();
        Task<IEnumerable<Rutarestaurantesintermedium>> GetAllRutasRestaurantes();
        Task<IEnumerable<Rutasrestaurante>> GetAllRutasRestaurantes2();
        Task<IQueryable<Restaurante>> GetAllRestaurantes();
        Task<Personaartesano> GetById(int id);
        Task<Rutastallere> GetByIdRutasTalleres(int id);
        Task<IQueryable<Rutatalleresintermedium>> GetByIdRutasTalleresintermedia(string municipio);
        Task<IQueryable<Rutarestaurantesintermedium>> GetByIdRutasRestaurantes(string municipio);
        Task<Rutasrestaurante> GetByIdRutasRestaurantes2(int id);
        Task<Restaurante> GetByIdRestaurantes(int id);
        Task<bool> Delete(int id);
        Task<bool> DeleteRutasTalleres(int id);
        Task<bool> DeleteRutasTalleresintermedia(int id);
        Task<bool> DeleteRutasRestaurantes2(int id);
        Task<bool> DeleteRutasRestaurantes(int id);
        Task<bool> DeleteRestaurantes(int id);
        Task<IQueryable<Personaartesano>> GetByFilter(Personaartesano artesano);
        bool Exist(Expression<Func<Personaartesano, bool>> expression);
        Task<int> Create(Personaartesano artesano);
        Task<int> CreateRutaTaller(Rutastallere rutastallere);
        Task<int> CreateRutaTallerintermedia(Rutatalleresintermedium rutatalleresintermedium);
        Task<int> CreateRutaRestaurante2(Rutasrestaurante rutasrestaurante);
        Task<int> CreateRutaRestaurante(Rutarestaurantesintermedium rutarestaurantesintermedium);
        Task<int> CreateRestaurante(Restaurante restaurante);
        Task<bool> Update(int id, Personaartesano artesano);
        Task<bool> UpdateRutasTalleres(int id, Rutastallere rutastallere);
        Task<bool> UpdateRutasTalleresintermedia(int id, Rutatalleresintermedium rutatalleresintermedium);
        Task<bool> UpdateRutasRestaurantes2(int id, Rutasrestaurante rutasrestaurante);
        Task<bool> UpdateRutasRestaurantes(int id, Rutarestaurantesintermedium rutarestaurantesintermedium);
        Task<bool> UpdateRestaurantes(int id, Restaurante restaurante);

    }
}