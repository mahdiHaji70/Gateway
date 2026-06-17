using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Application.Operation.TerminalDischarges.Commands.DeleteTerminalDischarge
{

    public class DeleteTerminalDischargeCommandValidator : AbstractValidator<DeleteTerminalDischargeCommand>
    {
        public DeleteTerminalDischargeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
