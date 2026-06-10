

using System.ComponentModel.DataAnnotations;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems
{
    public class IpasDeclarationItemsCommandHandler : IRequestHandler<IpasDeclarationItemsCommand, Guid>
    {
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IDeclarationItemRepository _declarationItemRepository;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IDeclarationExternalService _declarationExternalService;
        private readonly IUnitOfWork _unitOfWork;

        public IpasDeclarationItemsCommandHandler(IUnitOfWork unitOfWork
            , IDeclarationRepository declarationRepository
            , ICommodityRepository commodityRepository
            , IPackageRepository packageRepository
            , IDeclarationItemRepository declarationItemRepository
            , IDeclarationExternalService declarationExternalService)
        {
            _unitOfWork = unitOfWork;
            _declarationRepository = declarationRepository;
            _commodityRepository = commodityRepository;
            _packageRepository = packageRepository;
            _declarationItemRepository = declarationItemRepository;
            _declarationExternalService = declarationExternalService;
        }

        public async Task<Guid> Handle(IpasDeclarationItemsCommand request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetAsync(request.DeclarationId);
            if (declaration == null)
                throw new Exception("Declaration not found");

            if (await _declarationItemRepository.ExistsByDeclarationId(declaration.Id))
                throw new Exception("Declaration items are exists");

            var ipasDeclarationItemsRequest = new IpasDeclarationItemsRequest(declaration.TerminalCode, declaration.IpasDeclarationNo!);

            var ipasDeclarationItems = await _declarationExternalService.GetIpasDeclarationItems(ipasDeclarationItemsRequest);

            if (!ipasDeclarationItems.Any())
                throw new Exception("No item found for this declaration");

            var hsCodes = ipasDeclarationItems.Select(x => x.HSCode).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();

            var packageCodes = ipasDeclarationItems.Select(x => x.PackageCode).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();

            var commodities = await _commodityRepository
                .GetByHsCodesAsync(hsCodes, cancellationToken);

            var packages = await _packageRepository
                .GetByCodesAsync(packageCodes, cancellationToken);

            var commodityDict = commodities
                .ToDictionary(x => x.HsCode, x => x.Id);

            var packageDict = packages
                .ToDictionary(x => x.Code, x => x.Id);

            var declarationItems = ipasDeclarationItems.Select(x =>
            {
                if (!commodityDict.TryGetValue(x.HSCode, out var commodityId))
                    throw new Exception($"Commodity with HSCode '{x.HSCode}' not found.");

                if (!packageDict.TryGetValue(x.PackageCode, out var packageId))
                    throw new Exception($"Package with Code '{x.PackageCode}' not found.");

                return new DeclarationItem(
                    x.Quantity,
                    x.GrossWeight,
                    x.NetWeight,
                    request.DeclarationId,
                    commodityId,
                    packageId
                    );
            });

            await _declarationItemRepository.InsertRangeAsync(declarationItems);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            return declaration.Id;
        }
    }
}
