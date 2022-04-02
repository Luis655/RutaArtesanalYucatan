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
    public class ArtesaniaController : ControllerBase
    {
        
        private readonly IArtesaniaRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<ArtesaniaCreateRequest> _createValidator;
        private readonly IHttpContextAccessor _httpContext;

        public ArtesaniaController(IHttpContextAccessor httpContext, IArtesaniaRepository repository, IMapper mapper, IValidator<ArtesaniaCreateRequest> CreateValidator)
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
            var artesania = await _repository.GetAll();
            var respuesta = _mapper.Map<IEnumerable<Artesanium>,IEnumerable<ArtesaniaResponse>>(artesania);
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
            var respuesta = _mapper.Map<Artesanium, ArtesaniaResponse>(artesano);
            return Ok(respuesta);
        } 


         [HttpGet]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var artesania = await _repository.Delete(id);
           
            if(artesania==true)
                return NotFound("no se encontraron valores");
            
            return NoContent();
        } 

        [HttpGet]
        [Route("Find")]
        public async Task<IActionResult> GetBuFilter(Artesanium artesania)
        {
        
            var artesanias = await _repository.GetByFilter(artesania);
            var respuesta = _mapper.Map<IEnumerable<Artesanium>, IEnumerable<ArtesaniaResponse>>(artesanias);
            
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ArtesaniaCreateRequest artesania)
        {
            var ValidationResult = await _createValidator.ValidateAsync(artesania);
            if(!ValidationResult.IsValid)
                return UnprocessableEntity(ValidationResult.Errors.Select(x => $"Error: {x.ErrorMessage}"));
            var entity = _mapper.Map<ArtesaniaCreateRequest, Artesanium>(artesania);
            var id = await _repository.Create(entity);
            if (id<=0)
                return Conflict("el registro no puedo ser realizado");
            var urlresult =$"https://{_httpContext.HttpContext.Request.Host.Value}/api/artesania/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> update(int id, [FromBody] ArtesaniaCreateRequest artesania)
        {
            if(id <= 0)
                NotFound("el registro no fue encontrado");
            artesania.Idartesania = id;
            var validations = ArtesaniaService.ValidationUpdate(artesania);
            if(!validations)
                UnprocessableEntity("no es posible realizar la modificacion");
           var entity = _mapper.Map<ArtesaniaCreateRequest, Artesanium>(artesania);
            var update = await _repository.Update(id, entity);
            if(!update)
                return Conflict("hubo un conflictp al realizar los cambios");
            return NoContent();
        }
    }
}