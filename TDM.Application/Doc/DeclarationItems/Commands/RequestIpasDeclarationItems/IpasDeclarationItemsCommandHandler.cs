

using System.ComponentModel.DataAnnotations;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems
{
    public class IpasDeclarationItemsCommandHandler : IRequestHandler<IpasDeclarationItemsCommand, Guid>
    {
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IDeclarationItemRepository _declarationItemRepository;
        private readonly ICommodityRepository _commodityRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IContainerRepository _containerRepository;
        private readonly IDeclarationExternalService _declarationExternalService;
        private readonly IUnitOfWork _unitOfWork;

        public IpasDeclarationItemsCommandHandler(IUnitOfWork unitOfWork
            , IDeclarationRepository declarationRepository
            , ICommodityRepository commodityRepository
            , IPackageRepository packageRepository
            , IContainerRepository containerRepository
            , IDeclarationItemRepository declarationItemRepository
            , IDeclarationExternalService declarationExternalService)
        {
            _unitOfWork = unitOfWork;
            _declarationRepository = declarationRepository;
            _commodityRepository = commodityRepository;
            _packageRepository = packageRepository;
            _containerRepository = containerRepository;
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

            var hsCodes = ipasDeclarationItems
            .Select(x => x.HSCode)
            .Concat(
             ipasDeclarationItems
            .SelectMany(x => x.Containers ?? Enumerable.Empty<IpasDeclarationContainerResponse>())
            .SelectMany(c => c.Goods ?? Enumerable.Empty<IpasDeclarationContainerGoodsResponse>())
            .Select(g => g.HSCode))
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct()
            .ToList();

            var packageCodes = ipasDeclarationItems
            .Select(x => x.PackageCode)
            .Concat(
             ipasDeclarationItems
            .SelectMany(x => x.Containers ?? Enumerable.Empty<IpasDeclarationContainerResponse>())
            .SelectMany(c => c.Goods ?? Enumerable.Empty<IpasDeclarationContainerGoodsResponse>())
            .Select(g => g.PackageCode))
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct()
            .ToList();

            var containerNoAndCodes = 
             ipasDeclarationItems
            .SelectMany(x => x.Containers ?? Enumerable.Empty<IpasDeclarationContainerResponse>())            
            .Select(g => (g.ContainerNo, g.ContainerTypeAndSizeCode))
            .Where(x => !string.IsNullOrWhiteSpace(x.ContainerNo) && !string.IsNullOrWhiteSpace(x.ContainerTypeAndSizeCode))
            .Distinct()
            .ToList();

            var commodities = await _commodityRepository
                .GetByHsCodesAsync(hsCodes, cancellationToken);

            var packages = await _packageRepository
                .GetByCodesAsync(packageCodes, cancellationToken);

            var containers = await _containerRepository
                .GetByNoAndCodesAsync(containerNoAndCodes, cancellationToken);

            var commodityDict = commodities
                .ToDictionary(x => x.HsCode, x => x.Id);

            var packageDict = packages
                .ToDictionary(x => x.Code, x => x.Id);

            var containerDict = containers
                .ToDictionary(x => x.No, x => x.Id);

            var declarationItems = ipasDeclarationItems.Select(itemDto =>
            {
                if (!commodityDict.TryGetValue(itemDto.HSCode, out var commodityId))
                    throw new Exception($"Commodity with HSCode '{itemDto.HSCode}' not found.");

                if (!packageDict.TryGetValue(itemDto.PackageCode, out var packageId))
                    throw new Exception($"Package with Code '{itemDto.PackageCode}' not found.");

                var newItem = new DeclarationItem(
                    itemDto.Quantity,
                    itemDto.GrossWeight,
                    itemDto.NetWeight,
                    request.DeclarationId,
                    commodityId,
                    packageId,
                    itemDto.CargoTypeId
                    );                

                if(itemDto.Containers != null && itemDto.Containers.Any() == true)
                {
                    foreach (var containerDto in itemDto.Containers)
                    {
                        if (!containerDict.TryGetValue(containerDto.ContainerNo, out var containerId))
                            throw new Exception($"Containers with No '{containerDto.ContainerNo}' with type code '{containerDto.ContainerTypeAndSizeCode}' not found.");

                        var container = new DeclarationContainer(
                            containerId
                            );

                        if (containerDto.Goods != null && containerDto.Goods.Any() == true)
                        {
                            foreach (var goodDto in containerDto.Goods)
                            {
                                if (!commodityDict.TryGetValue(goodDto.HSCode, out var inseideContainerCommodityId))
                                    throw new Exception($"Commodity with HSCode '{goodDto.HSCode}' not found.");

                                if (!packageDict.TryGetValue(goodDto.PackageCode, out var inseideContainerPackageId))
                                    throw new Exception($"Package with Code '{goodDto.PackageCode}' not found.");

                                container.AddGood(new DeclarationContainerGood(
                                    goodDto.Quantity,
                                    goodDto.Weight,
                                    goodDto.Description,
                                    inseideContainerCommodityId,
                                    inseideContainerPackageId
                                    ));
                            }
                        }

                        newItem.AddContainer(container);
                    }
                }

                return newItem;
            });

            await _declarationItemRepository.InsertRangeAsync(declarationItems);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            return declaration.Id;
        }
    }
}
