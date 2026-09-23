using MediatR;

namespace TDM.Application.Doc.LoadingPermits.Commands.ConfirmLoadingPermit
{
    public record ConfirmLoadingPermitCommand(
        Guid PermitId,
        string TerminalCode,
        bool IsApproved,
        string Description) : IRequest<bool>;
}
