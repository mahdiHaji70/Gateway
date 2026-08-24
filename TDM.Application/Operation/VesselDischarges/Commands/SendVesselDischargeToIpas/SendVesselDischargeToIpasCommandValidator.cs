using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas
{
    public class SendVesselDischargeToIpasCommandValidator : AbstractValidator<SendVesselDischargeToIpasCommand>
    {
        public SendVesselDischargeToIpasCommandValidator()
        {
            RuleFor(x => x.ManifestItemId)
           .NotEmpty();

        }
    }
}
