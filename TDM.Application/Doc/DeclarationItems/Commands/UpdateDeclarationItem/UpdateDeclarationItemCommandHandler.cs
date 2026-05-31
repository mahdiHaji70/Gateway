using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.UpdateDeclarationItem
{
    public class UpdateDeclarationItemCommandHandler : IRequestHandler<UpdateDeclarationItemCommand, Guid>
    {
        private readonly IRepository<DeclarationItem> _declarationItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeclarationItemCommandHandler(IUnitOfWork unitOfWork
            , IRepository<DeclarationItem> declarationItemRepository)
        {
            _unitOfWork = unitOfWork;
            _declarationItemRepository = declarationItemRepository;
        }

        public async Task<Guid> Handle(UpdateDeclarationItemCommand request, CancellationToken cancellationToken)
        {
            var declarationItem = await _declarationItemRepository.GetAsync(request.Id);

            if (declarationItem == null)
                throw new Exception("DeclarationItem not found");

            declarationItem.Update(
                request.Quantity,
                request.GrossWeight,
                request.NetWeight,
                request.DeclarationId,
                request.CommodityId,
                request.PackageId);

            _declarationItemRepository.Update(declarationItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return declarationItem.Id;
        }
    }
}
