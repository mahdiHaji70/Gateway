using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Application.Operation.TerminalDischarges.Commands.CreateTerminalDischarge
{
   
    public class CreateTerminalDischargeCommandValidator : AbstractValidator<CreateTerminalDischargeCommand>
    {
        public CreateTerminalDischargeCommandValidator()
        {
            RuleFor(x => x.TerminalCode)
           .GreaterThan(0);

            RuleFor(x => x.CargoTypeId)
                .NotEmpty();

            RuleFor(x => x.StoreId)
                .NotEmpty();

            RuleFor(x => x.DeclarationItemId)
                .NotEmpty();

            RuleFor(x => x.WayBillNo)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.WayBillId)
                .NotEmpty();

            RuleFor(x => x.DischargeDate)
                .NotEmpty();

            RuleFor(x => x.VehicleNumber)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.PackNB)
                .GreaterThan(0);

            RuleFor(x => x.Weight)
                .GreaterThan(0);
            
            RuleFor(x => x.DangerousCode)
                .NotEmpty()
                .MaximumLength(50)
                .When(x => x.IsDangerous);

            RuleFor(x => x.Classification)
                .NotEmpty()
                .MaximumLength(100)
                .When(x => x.IsDangerous);

            RuleFor(x => x.IgnitionTemperature)
                .GreaterThan(0)
                .When(x => x.IsDangerous);

            RuleFor(x => x.IgnitionTemperatureUnit)
                .NotEmpty()
                .MaximumLength(10)
                .When(x => x.IsDangerous);

        }
    }
}
