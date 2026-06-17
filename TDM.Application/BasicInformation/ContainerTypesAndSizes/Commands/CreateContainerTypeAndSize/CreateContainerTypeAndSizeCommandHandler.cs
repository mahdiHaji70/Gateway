using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.CreateContainerTypeAndSize
{
    public class CreateContainerTypeAndSizeCommandHandler : IRequestHandler<CreateContainerTypeAndSizeCommand, Guid>
    {
        private readonly IRepository<ContainerTypeAndSize> _containerTypeAndSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateContainerTypeAndSizeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<ContainerTypeAndSize> containerTypeAndSizeRepository)
        {
            _unitOfWork = unitOfWork;
            _containerTypeAndSizeRepository = containerTypeAndSizeRepository;
        }

        public async Task<Guid> Handle(CreateContainerTypeAndSizeCommand request, CancellationToken cancellationToken)
        {
            var containerTypeAndSize = new ContainerTypeAndSize(
                request.TypeAndSize,
                request.TypeAndSizeCode);

            await _containerTypeAndSizeRepository.InsertAsync(containerTypeAndSize);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return containerTypeAndSize.Id;
        }
    }
}
