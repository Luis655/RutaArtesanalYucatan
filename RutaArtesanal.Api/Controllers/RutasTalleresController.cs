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
    public class RutasTalleresController : ControllerBase
    {
        
        private readonly IArtesanoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<ArtesanoCreateRequest> _createValidator;
        private readonly IHttpContextAccessor _httpContext;

        public RutasTalleresController(IHttpContextAccessor httpContext, IArtesanoRepository repository, IMapper mapper, IValidator<ArtesanoCreateRequest> CreateValidator)
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
            var restaurantes = await _repository.GetAllRutasTalleres();
            return Ok(restaurantes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var restaurante = await _repository.GetByIdRutasTalleres(id);
            if(restaurante==null)
                return NotFound("no se encontraron valores");
            return Ok(restaurante);
        } 

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var artesano = await _repository.DeleteRutasTalleres(id);
            if(artesano==true)
                return NotFound("no se encontraron valores");
            return NoContent();
        } 


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Rutastallere rutastallere)
        {
            if (rutastallere==null)
                return NotFound("no se han insertado valores");
            var id = await _repository.CreateRutaTaller(rutastallere);
            if (id<=0)
                return Conflict("el registro no puedo ser realizado");
            var urlresult =$"https://{_httpContext.HttpContext.Request.Host.Value}/api/artesano/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> update(int id, [FromBody] Rutastallere rutastallere)
        {
            if(id <= 0)
                NotFound("el registro no fue encontrado");
            rutastallere.Idrutastalleres=id;
            var update = await _repository.UpdateRutasTalleres(id, rutastallere);
            if(!update)
                return Conflict("hubo un conflictp al realizar los cambios");
            return NoContent();
        }
}
}