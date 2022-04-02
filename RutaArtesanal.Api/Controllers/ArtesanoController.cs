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
    public class ArtesanoController : ControllerBase
    {
        
        private readonly IArtesanoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<ArtesanoCreateRequest> _createValidator;
        private readonly IHttpContextAccessor _httpContext;

        public ArtesanoController(IHttpContextAccessor httpContext, IArtesanoRepository repository, IMapper mapper, IValidator<ArtesanoCreateRequest> CreateValidator)
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
            var artesanos = await _repository.GetAll();
            var respuesta = _mapper.Map<IEnumerable<Personaartesano>,IEnumerable<ArtesanoResponse>>(artesanos);
            return Ok(respuesta);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var artesano = await _repository.GetById(id);
            if(artesano==null)
                return NotFound("no se encontraron valores");

            //var respuesta = CreateDTOFromObjects(artesano);
            var respuesta = _mapper.Map<Personaartesano, ArtesanoResponse>(artesano);
            return Ok(respuesta);
        } 


         [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var artesano = await _repository.Delete(id);
           
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
        public async Task<IActionResult> Create([FromBody] ArtesanoCreateRequest artesano)
        {
            var ValidationResult = await _createValidator.ValidateAsync(artesano);
            if(!ValidationResult.IsValid)
                return UnprocessableEntity(ValidationResult.Errors.Select(x => $"Error: {x.ErrorMessage}"));
            var entity = _mapper.Map<ArtesanoCreateRequest, Personaartesano>(artesano);
            var id = await _repository.Create(entity);
            if (id<=0)
                return Conflict("el registro no puedo ser realizado");
            var urlresult =$"https://{_httpContext.HttpContext.Request.Host.Value}/api/artesano/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> update(int id, [FromBody] ArtesanoCreateRequest artesano)
        {
            if(id <= 0)
                NotFound("el registro no fue encontrado");
            artesano.Idartesano=id;
            var validations = ArtesanoService.ValidationUpdate(artesano);
            if(!validations)
                UnprocessableEntity("no es posible realizar la modificacion");
            var entity = _mapper.Map<ArtesanoCreateRequest, Personaartesano>(artesano);
            var update = await _repository.Update(id, entity);
            if(!update)
                return Conflict("hubo un conflictp al realizar los cambios");
            return NoContent();
        }
        
       


        

    }
}