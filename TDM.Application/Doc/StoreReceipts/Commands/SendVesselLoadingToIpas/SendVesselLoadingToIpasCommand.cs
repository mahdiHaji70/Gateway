using MediatR;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas
{
    public record SendVesselLoadingToIpasCommand(Guid StoreExitDocumentId)
        : IRequest<SendVesselLoadingToIpasResponse>;
}
