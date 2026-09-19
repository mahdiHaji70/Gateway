using MediatR;
using TDM.Application.Common.Interfaces;

namespace TDM.Application.Doc.VesselLoadingPermits.Commands.ConfirmVesselLoadingPermit
{
    public class ConfirmVesselLoadingPermitCommandHandler
        : IRequestHandler<ConfirmVesselLoadingPermitCommand, bool>
    {
        private readonly IVesselLoadingPermitExternalService _externalService;

        public ConfirmVesselLoadingPermitCommandHandler(
            IVesselLoadingPermitExternalService externalService)
        {
            _externalService = externalService;
        }

        public Task<bool> Handle(
            ConfirmVesselLoadingPermitCommand request,
            CancellationToken cancellationToken)
        {
            return _externalService.ConfirmVesselLoadingPermit(
                request.Id,
                request.TerminalCode,
                request.IsApproved,
                request.Remark,
                cancellationToken);
        }
    }
}
