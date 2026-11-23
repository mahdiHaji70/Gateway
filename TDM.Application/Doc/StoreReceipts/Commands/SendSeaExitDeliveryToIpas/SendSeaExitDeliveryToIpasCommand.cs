using MediatR;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendSeaExitDeliveryToIpas
{
    public record SendSeaExitDeliveryToIpasCommand(Guid StoreExitDocumentId)
        : IRequest<SendSeaExitDeliveryToIpasResponse>;
}
