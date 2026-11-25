using FluentValidation;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public class SendVesselLoadingToIpasCommandValidator : AbstractValidator<SendVesselLoadingToIpasCommand>
    {
        public SendVesselLoadingToIpasCommandValidator()
        {
            RuleFor(x => x.StoreExitDocumentId).NotEmpty();
        }
    }
}
