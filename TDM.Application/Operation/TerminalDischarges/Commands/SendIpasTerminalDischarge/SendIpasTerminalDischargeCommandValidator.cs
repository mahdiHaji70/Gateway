using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge
{
    public class SendIpasTerminalDischargeCommandValidator : AbstractValidator<SendIpasTerminalDischargeCommand>
    {
        public SendIpasTerminalDischargeCommandValidator()
        {
            RuleFor(x => x.DeclarationId)
           .NotEmpty();

        }
    }
}
