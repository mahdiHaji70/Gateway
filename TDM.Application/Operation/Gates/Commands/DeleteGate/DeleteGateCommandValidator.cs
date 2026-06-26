using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.Gates.Commands.DeleteGate;

namespace TDM.Application.Operation.Gates.Commands.DeleteGate
{
   
    public class DeleteGateCommandValidator : AbstractValidator<DeleteGateCommand>
    {
        public DeleteGateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
