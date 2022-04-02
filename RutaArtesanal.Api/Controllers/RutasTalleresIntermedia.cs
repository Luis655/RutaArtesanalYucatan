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
    public class RutasTalleresIntermediaController : ControllerBase
    {
        private readonly IArtesanoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<ArtesanoCreateRequest> _createValidator;
        private readonly IHttpContextAccessor _httpContext;

        public RutasTalleresIntermediaController(IHttpContextAccessor httpContext, IArtesanoRepository repository, IMapper mapper, IValidator<ArtesanoCreateRequest> CreateValidator)
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
            var restaurantes = await _repository.GetAllRutasTalleresintermedia();
            var respuesta = _mapper.Map<IEnumerable<Rutatalleresintermedium>,IEnumerable<RutaTalleresResponse>>(restaurantes);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("{municipio}")]
        public async Task<IActionResult> GetBymunicipio(string municipio)
        {
            var restaurante = await _repository.GetByIdRutasTalleresintermedia(municipio);
            if(restaurante==null)
                return NotFound("no se encontraron valores");
            //var respuesta = CreateDTOFromObjects(artesano);
            var respuesta = _mapper.Map<IEnumerable<Rutatalleresintermedium>, IEnumerable<RutaTalleresResponse>>(restaurante);
            return Ok(respuesta);
        } 

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var artesano = await _repository.DeleteRutasTalleresintermedia(id);
            if(artesano==true)
                return NotFound("no se encontraron valores");
            return NoContent();
        } 

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Rutatalleresintermedium rutatalleresintermedium)
        {
            if (rutatalleresintermedium==null)
                return NotFound("no se han insertado valores");
            var id = await _repository.CreateRutaTallerintermedia(rutatalleresintermedium);
            if (id<=0)
                return Conflict("el registro no puedo ser realizado");
            var urlresult =$"https://{_httpContext.HttpContext.Request.Host.Value}/api/artesano/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> update(int id, [FromBody] Rutatalleresintermedium rutatalleresintermedium)
        {
            if(id <= 0)
                NotFound("el registro no fue encontrado");
            rutatalleresintermedium.Idrutatalleresintermedia=id;
            var update = await _repository.UpdateRutasTalleresintermedia(id, rutatalleresintermedium);
            if(!update)
                return Conflict("hubo un conflictp al realizar los cambios");
            return NoContent();
        }
}
}