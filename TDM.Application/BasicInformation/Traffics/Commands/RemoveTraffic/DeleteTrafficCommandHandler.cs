using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Traffics.Commands.RemoveTraffic
{
    public class DeleteTrafficCommandHandler : IRequestHandler<DeleteTrafficCommand, bool>
    {
        private readonly IRepository<Traffic> _trafficRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTrafficCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Traffic> trafficRepository)
        {
            _unitOfWork = unitOfWork;
            _trafficRepository = trafficRepository;
        }

        public async Task<bool> Handle(DeleteTrafficCommand request, CancellationToken cancellationToken)
        {
            var traffic = await _trafficRepository.GetAsync(request.Id);

            if (traffic == null)
                throw new Exception("Traffic not found");

            _trafficRepository.Delete(traffic);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
