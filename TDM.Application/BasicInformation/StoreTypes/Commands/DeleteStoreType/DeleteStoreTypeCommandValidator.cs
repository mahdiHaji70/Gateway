using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.Commands.DeleteCargoType;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.DeleteStoreType
{
    public class DeleteStoreTypeCommandValidator : AbstractValidator<DeleteCargoTypeCommand>
    {
        public DeleteStoreTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
