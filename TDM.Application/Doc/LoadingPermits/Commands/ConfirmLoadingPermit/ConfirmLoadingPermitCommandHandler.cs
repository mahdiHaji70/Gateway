using MediatR;
using TDM.Application.Common.Interfaces;

namespace TDM.Application.Doc.LoadingPermits.Commands.ConfirmLoadingPermit
{
    public class ConfirmLoadingPermitCommandHandler
        : IRequestHandler<ConfirmLoadingPermitCommand, bool>
    {
        private readonly ILoadingPermitExternalService _externalService;

        public ConfirmLoadingPermitCommandHandler(
            ILoadingPermitExternalService externalService)
        {
            _externalService = externalService;
        }

        public Task<bool> Handle(
            ConfirmLoadingPermitCommand request,
            CancellationToken cancellationToken)
        {
            return _externalService.ConfirmLoadingPermit(
                request.PermitId,
                request.TerminalCode,
                request.IsApproved,
                request.Description,
                cancellationToken);
        }
    }
}
