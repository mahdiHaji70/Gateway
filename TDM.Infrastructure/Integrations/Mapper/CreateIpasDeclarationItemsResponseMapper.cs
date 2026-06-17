using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Infrastructure.Integrations.Requests;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public static class CreateIpasDeclarationItemsResponseMapper
    {
        public static List<IpasDeclarationItemResponse> Map(StorageAgreementResponseDto storageAgreementResponseDto)
        {
            var items = new List<IpasDeclarationItemResponse>();

            if (storageAgreementResponseDto.CargoList != null &&
            storageAgreementResponseDto.CargoList.Count() > 0)
            {
                items.AddRange(storageAgreementResponseDto.CargoList.Select(x =>
                new IpasDeclarationItemResponse
                {
                    Quantity = Convert.ToInt64(x.PackageQuantity),
                    GrossWeight = Convert.ToDecimal(x.GrossWeight),
                    NetWeight = Convert.ToDecimal(x.NetWeight),
                    HSCode = x.HSCode!,
                    PackageCode = x.PackageTypeCode!
                }));
            }

            if (storageAgreementResponseDto.BulkList != null &&
            storageAgreementResponseDto.BulkList.Count() > 0)
            {
                items.AddRange(storageAgreementResponseDto.BulkList.Select(x =>
                new IpasDeclarationItemResponse
                {
                    Quantity = 0,
                    GrossWeight = Convert.ToDecimal(x.Weight),
                    NetWeight = Convert.ToDecimal(x.Weight),
                    HSCode = x.HsCode!,
                    PackageCode = string.Empty
                }));
            }

            if (storageAgreementResponseDto.ContainerList != null &&
            storageAgreementResponseDto.ContainerList.Count() > 0)
            {
                items.AddRange(storageAgreementResponseDto.ContainerList.Select(container =>
                    new IpasDeclarationItemResponse
                    {
                        Quantity = storageAgreementResponseDto.ContainerList.Count(),
                        GrossWeight = 1,
                        NetWeight = 1,
                        HSCode = "86090000",
                        PackageCode = "SX",

                        Containers = new List<IpasDeclarationContainerResponse>
                        {
                new IpasDeclarationContainerResponse
                {
                    ContainerNo = container.ContainerNo!,
                    ContainerTypeAndSize = container.ContainerTypeAndSize!,
                    ContainerTypeAndSizeCode = container.ContainerTypeAndSizeCode!,

                    Goods = container.Goods?
                        .Select(g => new IpasDeclarationContainerGoodsResponse
                        {
                            HSCode = g.HSCode!,
                            PackageCode = g.PackageTypeCode!,
                            Quantity = Convert.ToInt64(g.PackageQuantity),
                            Weight = Convert.ToInt64(g.PackageQuantity) * Convert.ToDecimal(g.weight)
                        })
                        .ToList()
                }
                        }
                    }));
            }

            return items;
        }
    }
}
