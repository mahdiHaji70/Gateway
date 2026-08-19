using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.CreateDeclarationItem
{
    public class CreateDeclarationItemCommandHandler : IRequestHandler<CreateDeclarationItemCommand, Guid>
    {
        private readonly IRepository<DeclarationItem> _declarationItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeclarationItemCommandHandler(IUnitOfWork unitOfWork
            , IRepository<DeclarationItem> declarationItemRepository)
        {
            _unitOfWork = unitOfWork;
            _declarationItemRepository = declarationItemRepository;
        }

        public async Task<Guid> Handle(CreateDeclarationItemCommand request, CancellationToken cancellationToken)
        {
            var declarationItem = new DeclarationItem(
                request.Quantity,
                request.GrossWeight,
                request.NetWeight,
                request.DeclarationId,
                request.CommodityId,
                request.PackageId,
                request.CargoTypeId);

            await _declarationItemRepository.InsertAsync(declarationItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return declarationItem.Id;
        }
    }
}
