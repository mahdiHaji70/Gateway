using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Application.Operation.VesselDischarges.Commands.DeleteVesselDischarge
{

    public class DeleteVesselDischargeCommandValidator : AbstractValidator<DeleteVesselDischargeCommand>
    {
        public DeleteVesselDischargeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
