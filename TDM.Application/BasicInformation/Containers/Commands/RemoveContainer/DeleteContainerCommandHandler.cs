using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Containers.Commands.RemoveContainer
{
    public class DeleteContainerCommandHandler : IRequestHandler<DeleteContainerCommand, bool>
    {
        private readonly IRepository<Container> _containerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContainerCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Container> containerRepository)
        {
            _unitOfWork = unitOfWork;
            _containerRepository = containerRepository;
        }

        public async Task<bool> Handle(DeleteContainerCommand request, CancellationToken cancellationToken)
        {
            var container = await _containerRepository.GetAsync(request.Id);

            if (container == null)
                throw new Exception("Container not found");

            _containerRepository.Delete(container);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
