using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Containers.Commands.UpdateContainer
{
    public class UpdateContainerCommandHandler : IRequestHandler<UpdateContainerCommand, Guid>
    {
        private readonly IRepository<Container> _containerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContainerCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Container> containerRepository)
        {
            _unitOfWork = unitOfWork;
            _containerRepository = containerRepository;
        }

        public async Task<Guid> Handle(UpdateContainerCommand request, CancellationToken cancellationToken)
        {
            var container = await _containerRepository.GetAsync(request.Id);

            if (container == null)
                throw new Exception("Container not found");

            container.Update(request.No, request.ContainerTypeAndSizeId);

            _containerRepository.Update(container);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return container.Id;
        }
    }
}
