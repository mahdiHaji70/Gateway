using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.StoreReceipt.Command.CreateStoreReceipt;

namespace TDM.Application.Doc.StoreReceipt.Command.UpdateStoreReceipt
{
    
    public class UpdateStoreReceiptHeadCommandValidator : AbstractValidator<UpdateStoreReceiptHeadCommand>
    {
        public UpdateStoreReceiptHeadCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty();

            RuleFor(x => x.TerminalCode)
             .NotEmpty()
             .MaximumLength(50)
             .WithMessage("Terminal code is required.");

            RuleFor(x => x.IPASStoreReceiptNo)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("IPAS Store Receipt No is required.");

            RuleFor(x => x.IssueDate)
                .NotEmpty()
                .WithMessage("Issue date is required.");

            RuleFor(x => x.ConsigneeId)
                .NotEmpty()
                .WithMessage("Consignee Id is required.");

            RuleFor(x => x.ConsigneeRepId)
                .NotEmpty()
                .WithMessage("Consignee representative Id is required.");

            RuleFor(x => x.CargoTypeId)
                .NotEmpty()
                .WithMessage("Cargo type Id is required.");

            RuleFor(x => x.CreatorId)
                .NotEmpty()
                .WithMessage("Creator Id is required.");

            RuleFor(x => x.TrafficId)
                .NotEmpty()
                .WithMessage("Traffic Id is required.");

            RuleFor(x => x.StoreReceiptStateId)
                .NotEmpty()
                .WithMessage("Store receipt state Id is required.");

            RuleFor(x => x.ArrivalTypeId)
                .NotEmpty()
                .WithMessage("Arrival type Id is required.");

            RuleFor(x => x.FirstDischargeDate)
                .NotNull()
                .WithMessage("First discharge date is required.");

            RuleFor(x => x)
            .Must(x => x.DeclarationId.HasValue || x.BillOfLadingId.HasValue)
            .WithMessage("Either DeclarationId or BillOfLadingId must be provided.");

            RuleFor(x => x)
                .Must(x =>
                    x.DeclarationId.HasValue ^ x.BillOfLadingId.HasValue)
                .WithMessage("Provide either DeclarationId or BillOfLadingId, but not both.");
        }
    }

}
