using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.RemoveDeclarationItem
{
    public class DeleteDeclarationItemCommandHandler : IRequestHandler<DeleteDeclarationItemCommand, bool>
    {
        private readonly IRepository<DeclarationItem> _declarationItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeclarationItemCommandHandler(IUnitOfWork unitOfWork
            , IRepository<DeclarationItem> declarationItemRepository)
        {
            _unitOfWork = unitOfWork;
            _declarationItemRepository = declarationItemRepository;
        }

        public async Task<bool> Handle(DeleteDeclarationItemCommand request, CancellationToken cancellationToken)
        {
            var declarationItem = await _declarationItemRepository.GetAsync(request.Id);

            if (declarationItem == null)
                throw new Exception("Declaration sItem not found");

            _declarationItemRepository.Delete(declarationItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
