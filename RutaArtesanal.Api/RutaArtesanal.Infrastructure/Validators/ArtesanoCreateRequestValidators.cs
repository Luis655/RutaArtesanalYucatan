using System;
using FluentValidation;
using QueryApi.Domain.Dtos.Requests;
using QueryApi.Domain.Interfaces;

namespace QueryApi.Infrastructure.Validators
{
    public class ArtesanoCreateRequestValidator : AbstractValidator<ArtesanoCreateRequest>
    {
        private readonly IArtesanoRepository _repository;
        

        public ArtesanoCreateRequestValidator(IArtesanoRepository repository)
        {
           this._repository = repository;
           

            RuleFor(x => x.Nombre).NotNull().NotEmpty().Length(2,20);
            RuleFor(x => x.Apellidop).NotEmpty().Length(2, 20);
            RuleFor(x => x.Correo).NotEmpty().EmailAddress();
            RuleFor(x => x.Correo).Must(NotExistEmail).WithMessage("El correo electrónico debe ser único...");

   
        }

        public bool NotExistEmail(string email) 
        {
            return !_repository.Exist(p => p.IdloginNavigation.Correo == email);
        }


     
    }
}