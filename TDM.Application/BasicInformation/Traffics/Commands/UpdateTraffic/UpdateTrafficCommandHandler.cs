using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Traffics.Commands.UpdateTraffic
{
    public class UpdateTrafficCommandHandler : IRequestHandler<UpdateTrafficCommand, Guid>
    {
        private readonly IRepository<Traffic> _trafficRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTrafficCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Traffic> trafficRepository)
        {
            _unitOfWork = unitOfWork;
            _trafficRepository = trafficRepository;
        }

        public async Task<Guid> Handle(UpdateTrafficCommand request, CancellationToken cancellationToken)
        {
            var traffic = await _trafficRepository.GetAsync(request.Id);

            if (traffic == null)
                throw new Exception("Traffic not found");

            traffic.Update(request.Name, request.Code);

            _trafficRepository.Update(traffic);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return traffic.Id;
        }
    }
}
