using FluentValidation;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateWarehouseExitDocument
{
    public class CreateWarehouseExitDocumentCommandValidator : AbstractValidator<CreateWarehouseExitDocumentCommand>
    {
        public CreateWarehouseExitDocumentCommandValidator()
        {
            RuleFor(x => x.StoreReceiptId)
                .NotEmpty();

            RuleFor(x => x.PackNb)
                .GreaterThan(0);

            RuleFor(x => x.Weight)
                .GreaterThan(0);

            RuleFor(x => x.VehicleNumber)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LoadingPermitId)
                .NotEmpty();

            RuleFor(x => x.Date)
                .NotEmpty();
        }
    }
}
