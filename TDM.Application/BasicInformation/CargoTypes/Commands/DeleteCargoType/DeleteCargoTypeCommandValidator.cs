using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Cities.Commands.RemoveCity;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.DeleteCargoType
{
    public class DeleteCargoTypeCommandValidator : AbstractValidator<DeleteCargoTypeCommand>
    {
        public DeleteCargoTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
