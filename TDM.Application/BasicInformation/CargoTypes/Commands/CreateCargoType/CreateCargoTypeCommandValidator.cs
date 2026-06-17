using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Cities.Commands.CreateCity;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.CreateCargoType
{
    public class CreateCargoTypeCommandValidator : AbstractValidator<CreateCargoTypeCommand>
    {
        public CreateCargoTypeCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        }
    }
}
