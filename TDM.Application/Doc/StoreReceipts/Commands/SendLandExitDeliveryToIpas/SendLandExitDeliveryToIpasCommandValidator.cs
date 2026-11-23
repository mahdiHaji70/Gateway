using FluentValidation;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendLandExitDeliveryToIpas
{
    public class SendLandExitDeliveryToIpasCommandValidator : AbstractValidator<SendLandExitDeliveryToIpasCommand>
    {
        public SendLandExitDeliveryToIpasCommandValidator()
        {
            RuleFor(x => x.StoreExitDocumentId).NotEmpty();
        }
    }
}
