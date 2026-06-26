using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.Commands.CreateCargoType;

namespace TDM.Application.Operation.Gates.Commands.CreateGate
{
    public class CreateGateCommandValidator : AbstractValidator<CreateGateCommand>
    {
        public CreateGateCommandValidator()
        {
            RuleFor(x => x.Vehicle)
            .NotEmpty();

        }
    }
}
