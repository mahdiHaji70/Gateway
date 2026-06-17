using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.UpdateContainerTypeAndSize
{
    public class UpdateContainerTypeAndSizeCommandHandler : IRequestHandler<UpdateContainerTypeAndSizeCommand, Guid>
    {
        private readonly IRepository<ContainerTypeAndSize> _containerTypeAndSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContainerTypeAndSizeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<ContainerTypeAndSize> containerTypeAndSizeRepository)
        {
            _unitOfWork = unitOfWork;
            _containerTypeAndSizeRepository = containerTypeAndSizeRepository;
        }

        public async Task<Guid> Handle(UpdateContainerTypeAndSizeCommand request, CancellationToken cancellationToken)
        {
            var containerTypeAndSize = await _containerTypeAndSizeRepository.GetAsync(request.Id);

            if (containerTypeAndSize == null)
                throw new Exception("Package not found");

            containerTypeAndSize.Update(request.TypeAndSize, request.TypeAndSizeCode);

            _containerTypeAndSizeRepository.Update(containerTypeAndSize);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return containerTypeAndSize.Id;
        }
    }
}
