using MediatR;

namespace TDM.Application.Doc.VesselLoadingPermits.Commands.ConfirmVesselLoadingPermit
{
    public record ConfirmVesselLoadingPermitCommand(
        Guid Id,
        string TerminalCode,
        bool IsApproved,
        string Remark) : IRequest<bool>;
}
