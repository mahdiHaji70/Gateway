using FluentValidation;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendSeaExitDeliveryToIpas
{
    public class SendSeaExitDeliveryToIpasCommandValidator : AbstractValidator<SendSeaExitDeliveryToIpasCommand>
    {
        public SendSeaExitDeliveryToIpasCommandValidator()
        {
            RuleFor(x => x.StoreExitDocumentId).NotEmpty();
        }
    }
}
