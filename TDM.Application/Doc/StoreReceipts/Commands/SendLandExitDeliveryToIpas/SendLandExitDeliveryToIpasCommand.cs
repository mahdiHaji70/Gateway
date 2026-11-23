using MediatR;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendLandExitDeliveryToIpas
{
    public record SendLandExitDeliveryToIpasCommand(Guid StoreExitDocumentId)
        : IRequest<SendLandExitDeliveryToIpasResponse>;
}
