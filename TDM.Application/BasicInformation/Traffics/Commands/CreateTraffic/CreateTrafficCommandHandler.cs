using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Traffics.Commands.CreateTraffic
{
    public class CreateTrafficCommandHandler : IRequestHandler<CreateTrafficCommand, Guid>
    {
        private readonly IRepository<Traffic> _trafficRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTrafficCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Traffic> trafficRepository)
        {
            _unitOfWork = unitOfWork;
            _trafficRepository = trafficRepository;
        }

        public async Task<Guid> Handle(CreateTrafficCommand request, CancellationToken cancellationToken)
        {
            var traffic = new Traffic(
                request.Name,
                request.Code);

            await _trafficRepository.InsertAsync(traffic);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return traffic.Id;
        }
    }
}
