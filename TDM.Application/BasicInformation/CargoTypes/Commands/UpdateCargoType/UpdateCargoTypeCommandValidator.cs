using FluentValidation;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.UpdateCargoType
{
    public class UpdateCargoTypeCommandValidator: AbstractValidator<UpdateCargoTypeCommand>
    {
        public UpdateCargoTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
           
        }
    }
}
