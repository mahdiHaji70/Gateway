using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Guid>
    {
        private readonly IRepository<Service> _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceCommandHandler(IUnitOfWork unitOfWork, IRepository<Service> serviceRepository)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
        }

        public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service(request.Name, request.Code);

            await _serviceRepository.InsertAsync(service);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return service.Id;
        }
    }
}
