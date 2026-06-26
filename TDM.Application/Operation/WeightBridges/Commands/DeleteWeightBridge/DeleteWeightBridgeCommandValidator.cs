using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Operation.WeightBridges.Commands.DeleteWeightBridge;

namespace TDM.Application.Operation.WeightBridges.Commands.DeleteWeightBridge
{
    public class DeleteWeightBridgeCommandValidator : AbstractValidator<DeleteWeightBridgeCommand>
    {
        public DeleteWeightBridgeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
