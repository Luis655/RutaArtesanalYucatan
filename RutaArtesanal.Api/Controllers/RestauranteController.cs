using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using QueryApi.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using QueryApi.Application.Services;
using QueryApi.Domain.Dtos.Response;
using QueryApi.Domain.Dtos.Requests;
using AutoMapper;
using FluentValidation;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;

namespace RutaArtesanal.Api.Controllers
{

        
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        
        private readonly IArtesanoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<ArtesanoCreateRequest> _createValidator;
        private readonly IHttpContextAccessor _httpContext;

        public RestauranteController(IHttpContextAccessor httpContext, IArtesanoRepository repository, IMapper mapper, IValidator<ArtesanoCreateRequest> CreateValidator)
        {
           _repository = repository;
            this._mapper = mapper;
            _createValidator = CreateValidator;
            this._httpContext = httpContext;
        }

        [HttpGet]
        [Route("")] 
        public async Task<IActionResult> GetAll()
        {
            var restaurantes = await _repository.GetAllRestaurantes();
            var respuesta = _mapper.Map<IEnumerable<Restaurante>,IEnumerable<RestauranteResponse>>(restaurantes);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var restaurante = await _repository.GetByIdRestaurantes(id);
            if(restaurante==null)
                return NotFound("no se encontraron valores");
            //var respuesta = CreateDTOFromObjects(artesano);
            var respuesta = _mapper.Map<Restaurante, RestauranteResponse>(restaurante);
            return Ok(respuesta);
        } 

         [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var artesano = await _repository.DeleteRestaurantes(id);
            if(artesano==true)
                return NotFound("no se encontraron valores");
            return NoContent();
        } 

        [HttpGet]
        [Route("Find")]
        public async Task<IActionResult> GetBuFilter(Personaartesano artesano)
        {
            //var artesan = CreateObjctFromDTO(artesano);
            var artesanos = await _repository.GetByFilter(artesano);
            //var respuesta = artesanos.Select(x =>CreateDTOFromObjects(x)
            var respuesta = _mapper.Map<IEnumerable<Personaartesano>, IEnumerable<ArtesanoResponse>>(artesanos);
            
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] RestauranteCreateRequest restauranteCreateRequest)
        {
            if (restauranteCreateRequest==null)
                return NotFound("no se han insertado valores");

            var entity = _mapper.Map<RestauranteCreateRequest, Restaurante>(restauranteCreateRequest);
            var id = await _repository.CreateRestaurante(entity);
           
            if (id<=0)
                return Conflict("el registro no puedo ser realizado");
            var urlresult =$"https://{_httpContext.HttpContext.Request.Host.Value}/api/artesano/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> update(int id, [FromBody] RestauranteCreateRequest restaurante)
        {
            if(id <= 0)
                NotFound("el registro no fue encontrado");
            restaurante.Idrestaurante=id;
            //var entity = _mapper.Map<RestauranteCreateRequest, Restaurante>(restaurante);
            var entity = CreateObjctFromDTO(restaurante);
            var update = await _repository.UpdateRestaurantes(id, entity);
            if(!update)
                return Conflict("hubo un conflictp al realizar los cambios");
            return NoContent();
        }


        private Restaurante CreateObjctFromDTO(RestauranteCreateRequest dto)
        {
            var restaurante = new Restaurante{
                Idrestaurante = dto.Idrestaurante,
                Nombrerest = dto.Nombrerest,
                Telfonocomercio = dto.Telfonocomercio,
                Descripcionmenu = dto.Descripcionmenu,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                Tiporestaurante = dto.Tiporestaurante,
                IddireccionNavigation = new Direccion{
                    Municipio = dto.Municipio,
                    Colonia = dto.Colonia,
                    Cruzamientos= dto.Cruzamientos,
                    Numero = dto.Numero,
                    },
                IdfotomenuNavigation = new Fotoplatillo{
                    Fotorest = dto.Fotorest
                }
            };
            return restaurante;
    }
}
}