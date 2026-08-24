using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Operation.VesselDischarges.Commands.DeleteVesselDischarge
{
   
    public class DeleteVesselDischargeCommandHandler : IRequestHandler<DeleteVesselDischargeCommand, bool>
    {
        private readonly IRepository<VesselDischarge> _vesselDischargeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVesselDischargeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<VesselDischarge> vesselDischargeRepository)
        {
            _unitOfWork = unitOfWork;
            _vesselDischargeRepository = vesselDischargeRepository;
        }

        public async Task<bool> Handle(DeleteVesselDischargeCommand request, CancellationToken cancellationToken)
        {
            var vesselDischarge = await _vesselDischargeRepository.GetAsync(request.Id);

            if (vesselDischarge == null)
                throw new Exception("VesselDischarge not found");

            _vesselDischargeRepository.Delete(vesselDischarge);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
