using FluentValidation;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetManifestIssuedStoreReceipts
{
    public class GetManifestIssuedStoreReceiptsQueryValidator
        : AbstractValidator<GetManifestIssuedStoreReceiptsQuery>
    {
        public GetManifestIssuedStoreReceiptsQueryValidator()
        {
            RuleFor(x => x.IpasItemId)
                .NotEmpty()
                .WithMessage("IpasItemId is required.");
        }
    }
}
