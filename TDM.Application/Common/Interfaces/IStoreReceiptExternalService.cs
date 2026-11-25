using TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas;
using TDM.Application.Doc.StoreReceipts.Commands.SendSeaExitDeliveryToIpas;
using TDM.Application.Doc.StoreReceipts.Commands.SendLandExitDeliveryToIpas;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.StoreReceipts.DTOs;
using TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo;
using TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation;


namespace TDM.Application.Common.Interfaces
{
    public interface IStoreReceiptExternalService
    {
       Task<List<StoreReceiptHeadDto>> GetStoreReceipts(string ipasDeclarationNo, CancellationToken cancellationToken = default);
       Task<List<StoreReceiptHeadDto>> GetStoreReceiptByBillOfLadingId(
           Guid billOfLadingId,
           CancellationToken cancellationToken = default);
       Task<SendVesselLoadingToIpasResponse> SendVesselLoadingToIpas(
           SendVesselLoadingToIpasRequest request, CancellationToken cancellationToken = default);
       Task<SendSeaExitDeliveryToIpasResponse> SendSeaExitDeliveryToIpas(
           SendSeaExitDeliveryToIpasRequest request,
           CancellationToken cancellationToken = default);
       Task<SendLandExitDeliveryToIpasResponse> SendLandExitDeliveryToIpas(
           SendLandExitDeliveryToIpasRequest request,
           CancellationToken cancellationToken = default);
       Task<SendIpasStoreAllocationResponse> SendIpasStoreAllocation(SendIpasStoreAllocationRequest request, CancellationToken cancellationToken = default);
        }
}
