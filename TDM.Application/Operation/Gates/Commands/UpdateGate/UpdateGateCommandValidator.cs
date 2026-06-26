using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.Gates.Commands.CreateGate;

namespace TDM.Application.Operation.Gates.Commands.UpdateGate
{

    public class UpdateGateCommandValidator : AbstractValidator<UpdateGateCommand>
    {
        public UpdateGateCommandValidator()
        {
            RuleFor(x => x.Vehicle)
            .NotEmpty();

        }
    }
}
