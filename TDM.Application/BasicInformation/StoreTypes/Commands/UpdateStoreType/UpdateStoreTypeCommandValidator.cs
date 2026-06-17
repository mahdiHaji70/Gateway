using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.Commands.UpdateCargoType;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.UpdateStoreType
{
    
    public class UpdateStoreTypeCommandValidator : AbstractValidator<UpdateStoreTypeCommand>
    {
        public UpdateStoreTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        }
    }
}
