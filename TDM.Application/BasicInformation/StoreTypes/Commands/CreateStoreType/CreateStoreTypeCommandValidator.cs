using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.Commands.CreateCargoType;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.CreateStoreType
{
    
    public class CreateStoreTypeCommandValidator : AbstractValidator<CreateStoreTypeCommand>
    {
        public CreateStoreTypeCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        }
    }
}
