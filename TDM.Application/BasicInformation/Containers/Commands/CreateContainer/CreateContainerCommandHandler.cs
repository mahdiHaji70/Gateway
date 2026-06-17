using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Containers.Commands.CreateContainer
{
    public class CreateContainerCommandHandler : IRequestHandler<CreateContainerCommand, Guid>
    {
        private readonly IRepository<Container> _containerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateContainerCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Container> containerRepository)
        {
            _unitOfWork = unitOfWork;
            _containerRepository = containerRepository;
        }

        public async Task<Guid> Handle(CreateContainerCommand request, CancellationToken cancellationToken)
        {
            var container = new Container(
                request.No,                
                request.ContainerTypeAndSizeId);

            await _containerRepository.InsertAsync(container);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return container.Id;
        }
    }
}
