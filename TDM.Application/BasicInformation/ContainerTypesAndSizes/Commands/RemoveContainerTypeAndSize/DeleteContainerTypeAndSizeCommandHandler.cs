using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.RemoveContainerTypeAndSize
{
    public class DeleteContainerTypeAndSizeCommandHandler : IRequestHandler<DeleteContainerTypeAndSizeCommand, bool>
    {
        private readonly IRepository<ContainerTypeAndSize> _containerTypeAndSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContainerTypeAndSizeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<ContainerTypeAndSize> containerTypeAndSizeRepository)
        {
            _unitOfWork = unitOfWork;
            _containerTypeAndSizeRepository = containerTypeAndSizeRepository;
        }

        public async Task<bool> Handle(DeleteContainerTypeAndSizeCommand request, CancellationToken cancellationToken)
        {
            var containerTypeAndSize = await _containerTypeAndSizeRepository.GetAsync(request.Id);

            if (containerTypeAndSize == null)
                throw new Exception("Container Type And Size not found");

            _containerTypeAndSizeRepository.Delete(containerTypeAndSize);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
