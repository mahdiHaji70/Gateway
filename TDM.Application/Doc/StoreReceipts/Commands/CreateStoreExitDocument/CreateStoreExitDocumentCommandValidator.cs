using FluentValidation;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateStoreExitDocument
{
    public class CreateStoreExitDocumentCommandValidator : AbstractValidator<CreateStoreExitDocumentCommand>
    {
        public CreateStoreExitDocumentCommandValidator()
        {
            RuleFor(x => x.StoreReceiptId)
                .NotEmpty();

            RuleFor(x => x.PackNb)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Weight)
                .GreaterThan(0);

            RuleFor(x => x.VehicleNumber)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LoadingPermitId)
                .NotEmpty();

            RuleFor(x => x.VoyageId)
                .NotEmpty().When(x => x.VoyageId.HasValue);

            RuleFor(x => x.Date)
                .NotEmpty();
        }
    }
}
