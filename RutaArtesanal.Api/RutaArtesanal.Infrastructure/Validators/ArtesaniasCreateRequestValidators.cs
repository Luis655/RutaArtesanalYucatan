using System;
using FluentValidation;
using QueryApi.Domain.Dtos.Requests;
using QueryApi.Domain.Interfaces;

namespace QueryApi.Infrastructure.Validators
{
    public class ArtesaniaCreateRequestValidator : AbstractValidator<ArtesaniaCreateRequest>
    {
        private readonly IArtesaniaRepository _repository;

        public ArtesaniaCreateRequestValidator(IArtesaniaRepository repository)
        {
           this._repository = repository;

            RuleFor(x => x.Nombreartesania).NotNull().NotEmpty().Length(3,20);
            RuleFor(x => x.Descrartesan).NotEmpty().Length(2, 200);
            RuleFor(x => x.Fotoartesania).NotEmpty().NotNull().Length(5, 30);
            RuleFor(x => x.Nombrematerial).NotEmpty().NotNull().Length(5, 15);
            RuleFor(x => x.Descripcionmat).NotEmpty().NotNull().Length(5, 300);
            
        }

        
    }
}