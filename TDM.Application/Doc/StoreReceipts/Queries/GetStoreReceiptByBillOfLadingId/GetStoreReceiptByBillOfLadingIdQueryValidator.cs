using FluentValidation;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByBillOfLadingId
{
    public class GetStoreReceiptByBillOfLadingIdQueryValidator
        : AbstractValidator<GetStoreReceiptByBillOfLadingIdQuery>
    {
        public GetStoreReceiptByBillOfLadingIdQueryValidator()
        {
            RuleFor(x => x.BillOfLadingId)
                .NotEmpty()
                .WithMessage("BillOfLadingId is required.");
        }
    }
}
