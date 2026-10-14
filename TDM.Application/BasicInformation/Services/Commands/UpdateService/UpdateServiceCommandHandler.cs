using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Services.Commands.UpdateService
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Guid>
    {
        private readonly IRepository<Service> _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork, IRepository<Service> serviceRepository)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = serviceRepository;
        }

        public async Task<Guid> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetAsync(request.Id);

            if (service == null)
                throw new Exception("Service not found");

            service.Update(request.Name, request.Code);
            _serviceRepository.Update(service);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return service.Id;
        }
    }
}
