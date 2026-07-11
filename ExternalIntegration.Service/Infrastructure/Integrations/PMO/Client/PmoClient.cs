using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Config;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TOS.Services.Gateway.Infrastructure.Integrations.PMO.Requests;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client
{
    public class PmoClient : IPmoClient
    {
        private readonly IPmoRequestExecutor _requestExecutor;
        private readonly PmoServiceNames _serviceNames;
        private readonly string _userName;
        private readonly string _password;

        public PmoClient(IPmoRequestExecutor requestExecutor,
            IOptions<PmoServiceNames> serviceNames,
            IConfiguration configuration)
        {
            _requestExecutor = requestExecutor;
            _serviceNames = serviceNames.Value;
            _userName = configuration["ServiceProviderConfig:PMO:Username"]!;
            _password = configuration["ServiceProviderConfig:PMO:Password"]!;
        }
        public async Task<Response<IEnumerable<GoodwayBillResponseDto>>> GetGoodwayBill(PmoDateRangeDto dto)
        {
            var request = new PmoRequestBuilder()
            .WithCredential(_userName, _password)
            .WithService(_serviceNames.GoodwayBills)
            .WithParameters(new List<Parameter>
            {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode},
                new Parameter{ ParameterName = nameof(dto.FromDate), ParameterValue = dto.FromDate },
                new Parameter{ ParameterName = nameof(dto.ToDate), ParameterValue = dto.ToDate },

            }).Build();

            var response = await _requestExecutor.PostAsync<IEnumerable<GoodwayBillResponseDto>>(request, dto.TerminalCode);

            return response;
        }

        public async Task<Response<CreateStorageAgreementResponseDto>> CreateStorageAgreement(CreateStorageAgreementRequestDto dto)
        {
            var request = new PmoRequestBuilder()
            .WithCredential(_userName, _password)
            .WithService(_serviceNames.CreateStorageAgreement)
            .WithParameters(new List<Parameter>
            {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode },
                new Parameter{ ParameterName = nameof(dto.AgreementDate), ParameterValue = dto.AgreementDate.ToString("yyyy-MM-ddTHH:mm:ss")  },
                new Parameter{ ParameterName = nameof(dto.StartDate ), ParameterValue = dto.StartDate.ToString("yyyy-MM-ddTHH:mm:ss")  },
                new Parameter{ParameterName = nameof(dto.FinishDate), ParameterValue = dto.FinishDate.ToString("yyyy-MM-ddTHH:mm:ss") },
                new Parameter{ParameterName = nameof(dto.CustomsProcedureCode), ParameterValue = dto.CustomsProcedureCode},
                new Parameter{ParameterName = nameof(dto.WorkflowRemark), ParameterValue = dto.WorkflowRemark},
                new Parameter{ParameterName =nameof(dto.Owner),ParameterValue = JsonConvert.SerializeObject(dto.Owner)},
                new Parameter { ParameterName =nameof(dto.OwnerRep),ParameterValue = JsonConvert.SerializeObject(dto.OwnerRep)}

            }).Build();

            var response = await _requestExecutor.PostAsync<CreateStorageAgreementResponseDto>(request, dto.TerminalCode);
            return response;
        }

        public async Task<Response<StorageAgreementResponseDto>> GetStorageAgreement(GetStorageAgreementDto dto)
        {
            var request = new PmoRequestBuilder()
           .WithCredential(_userName, _password)
           .WithService(_serviceNames.StorageAgreement)
           .WithParameters(new List<Parameter>
           {
                new Parameter{ ParameterName = nameof(dto.AgreementNo), ParameterValue = dto.AgreementNo },
           }).Build();

            var response = await _requestExecutor.PostAsync<StorageAgreementResponseDto>(request, dto.TerminalCode);
            return response;
        }

        public async Task<Response<bool>> DeleteStorageAgreement(DeleteStorageAgreementDto dto)
        {
            var request = new PmoRequestBuilder()
          .WithCredential(_userName, _password)
          .WithService(_serviceNames.DeleteStorageAgreement)
          .WithParameters(new List<Parameter>
          {
                new Parameter{ ParameterName = nameof(dto.No), ParameterValue = dto.No },
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode }
          }).Build();

            var response = await _requestExecutor.PostAsync<bool>(request);
            return response;
        }
        public async Task<Response<IEnumerable<DischargePermitResponseDto>>> GetDischargePermit(PmoDateRangeDto dto)
        {
            var request = new PmoRequestBuilder()
                .WithCredential(_userName, _password)
                .WithService(_serviceNames.DischargPermit)
                .WithParameters(new List<Parameter>
                {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode},
                new Parameter{ ParameterName = nameof(dto.FromDate), ParameterValue = dto.FromDate },
                new Parameter{ ParameterName = nameof(dto.ToDate), ParameterValue = dto.ToDate },

                }).Build();


            var response = await _requestExecutor.PostAsync<IEnumerable<DischargePermitResponseDto>>(request, dto.TerminalCode);
            
            return response;

        }
        public async Task<Response<Guid>> TruckTerminalDischarge(TruckTerminalDischargeRequestDto model)
        {
            var request = new PmoRequestBuilder()
                .WithCredential(_userName, _password)
                .WithService(_serviceNames.TruckTerminalDis)
                .WithParameters(new List<Parameter>
                {
                new Parameter{ParameterName = nameof(model.TerminalCode), ParameterValue = model.TerminalCode },
                new Parameter{ParameterName = nameof(model.AgreementNo), ParameterValue = model.AgreementNo  },
                new Parameter{ParameterName = nameof(model.WaybillNo ), ParameterValue = model.WaybillNo  },
                new Parameter{ParameterName = nameof(model.WaybillId), ParameterValue = model.WaybillId},
                new Parameter{ParameterName = nameof(model.DischargeDate), ParameterValue = model.DischargeDate.ToString("yyyy-MM-ddTHH:mm:ss")},
                new Parameter{ParameterName = nameof(model.TruckPlateNumber), ParameterValue = model.TruckPlateNumber},
                new Parameter{ParameterName = nameof(model.TruckEmptyWeight), ParameterValue = model.TruckEmptyWeight},
                new Parameter{ParameterName = nameof(model.TruckFullWeight), ParameterValue = model.TruckFullWeight},
                new Parameter{ParameterName = nameof(model.Tallyman), ParameterValue = model.Tallyman},
                new Parameter{ParameterName =nameof(model.GateInDateTime),ParameterValue = model.GateInDateTime.ToString("yyyy-MM-ddTHH:mm:ss")},
                new Parameter{ParameterName =nameof(model.GateOutDateTime),ParameterValue = model.GateOutDateTime.ToString("yyyy-MM-ddTHH:mm:ss")},
                new Parameter{ParameterName =nameof(model.GeneralCargoList),
                    ParameterValue = JsonConvert.SerializeObject(model.GeneralCargoList.Select( s=>
                                new {
                s.HSCode,
                s.Description,
                s.BrandName,
                s.PackageTypeCode ,
                s.PackageType,
                s.PackageQuantity ,
                s.GrossWeight  ,
                s.NetWeight,
                s.IsNonPalletized ,
                s.IsDamaged,
                s.IsDangerous,
                s.Width,
                s.Height,
                s.Length,
                s.IsVoluminous,
                s.Remark,
                s.DangerousSpecification
                                }
                                ))},
                new Parameter { ParameterName =nameof(model.BulkList),
                    ParameterValue = JsonConvert.SerializeObject( model.BulkList.Select( s=>
                                new {
                s.HSCode,
                s.Description,
                s.Weight,
                s.Volume,
                s.ISDangerous,
                s.DangerousNotNoticed,
                s.DangerousSpecification,
                s.Remark,
                                }
                                ))},
                new Parameter { ParameterName =nameof(model.ContainerList),
                    ParameterValue = JsonConvert.SerializeObject(model.ContainerList.Select( s=>
                               new {
                s.ContainerNo,
                s.ContainerTypeAndSizeCode,
                s.SealNumber,
                s.Remark,
                s.DangerousSpecification

                                }
                                ))}
                }).Build();

            var response = await _requestExecutor.PostAsync<Guid>(request, model.TerminalCode);
           
            return response;
        }

        public async Task<Response<IEnumerable<IssueRequestResponseDto>>> GetIssueRequest(PmoDateRangeDto dto)
        {
            var request = new PmoRequestBuilder()
            .WithCredential(_userName, _password)
            .WithService(_serviceNames.Issuerequests)
            .WithParameters(new List<Parameter>
            {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode},
                new Parameter{ ParameterName = nameof(dto.FromDate), ParameterValue = dto.FromDate },
                new Parameter{ ParameterName = nameof(dto.ToDate), ParameterValue = dto.ToDate },

            }).Build();

            var response = await _requestExecutor.PostAsync<IEnumerable<IssueRequestResponseDto>>(request, dto.TerminalCode);

            return response;
        }

        public async Task<Response<GetDataWithPagingDto<VoyageResponseDto>>> GetVoyages(PmoDateRangeWithPagingDto dto)
        {
            var request = new PmoRequestBuilder()
              .WithCredential(_userName, _password)
              .WithService(_serviceNames.GetVoyages)
              .WithParameters(new List<Parameter>
              {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode},
                new Parameter{ ParameterName = nameof(dto.FromDate), ParameterValue = dto.FromDate },
                new Parameter{ ParameterName = nameof(dto.ToDate), ParameterValue = dto.ToDate },
                new Parameter{ ParameterName = nameof(dto.PageIndex), ParameterValue = dto.PageIndex },
                new Parameter{ ParameterName = nameof(dto.PageSize), ParameterValue = dto.PageSize },
              }).Build();

            var response = await _requestExecutor.PostAsync<GetDataWithPagingDto<VoyageResponseDto>>(request, dto.TerminalCode);
           
            return response;
        }
        public async Task<Response<VoyageResponseDto>> GetVoyageByNoticeNo(VoyageByNoticeNoRequestDto dto)
        {
            var request = new PmoRequestBuilder()
               .WithCredential(_userName, _password)
               .WithService(_serviceNames.GetVoyagesByNoticeN)
               .WithParameters(new List<Parameter>
               {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode},
                new Parameter{ ParameterName = nameof(dto.NoticeNo), ParameterValue = dto.NoticeNo }
               }).Build();

            var response = await _requestExecutor.PostAsync<VoyageResponseDto>(request);
           
            return response;
        }

        public async Task<Response<string>> IssueRequestConfirmation(IssueRequestConfirmationRequestDto dto)
        {
            var request = new PmoRequestBuilder()
          .WithCredential(_userName, _password)
          .WithService(_serviceNames.Confirmation)
          .WithParameters(new List<Parameter>
          {
                new Parameter {ParameterName = nameof(dto.TerminalCode),ParameterValue = dto.TerminalCode},
                new Parameter {ParameterName = nameof(dto.RequestId),ParameterValue= dto.RequestId},
                new Parameter {ParameterName = nameof(dto.IsApproved),ParameterValue= dto.IsApproved},
                new Parameter {ParameterName = nameof(dto.Description),ParameterValue= dto.Description}
              }).Build();
            var response = await _requestExecutor.PostAsync<string>(request);
            return response;
        }

        public async Task<Response<GetDataWithPagingDto<StoreReceiptDto>>> GetStoreReceipts(PmoDateRangeWithPagingDto dto)
        {
            var request = new PmoRequestBuilder()
          .WithCredential(_userName, _password)
          .WithService(_serviceNames.WRinquiry)
          .WithParameters(new List<Parameter>
          {
                new Parameter{ ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode},
                new Parameter{ ParameterName = nameof(dto.FromDate), ParameterValue = dto.FromDate },
                new Parameter{ ParameterName = nameof(dto.ToDate), ParameterValue = dto.ToDate },
                new Parameter{ ParameterName = nameof(dto.PageIndex), ParameterValue = dto.PageIndex },
                new Parameter{ ParameterName = nameof(dto.PageSize), ParameterValue = dto.PageSize },

          }).Build();

            var response = await _requestExecutor.PostAsync<GetDataWithPagingDto<StoreReceiptDto>>(request, dto.TerminalCode);
            return response;
        }

        public async Task<Response<bool>> SendStoreReceiptAllocation(SendStoreReceiptAllocationRequestDto dto)
        {
            var request = new PmoRequestBuilder()
      .WithCredential(_userName, _password)
      .WithService(_serviceNames.WReceiptsAllocation)
      .WithParameters(new List<Parameter>
      {
              new Parameter{ParameterName = nameof(dto.WarehouseReceiptId), ParameterValue = dto.WarehouseReceiptId},
              new Parameter{ParameterName = nameof(dto.TerminalCode), ParameterValue = dto.TerminalCode },
               new Parameter { ParameterName =nameof(dto.ContainerList),
                  ParameterValue = JsonConvert.SerializeObject( dto.ContainerList.Select( s=>
                              new {
              s.OperationDate,
              s.StorageAreaCode,
              s.ContainerNo,
              s.Quantity
                              }
                              ))},
              new Parameter { ParameterName =nameof(dto.GeneralCargoList),
                  ParameterValue = JsonConvert.SerializeObject(dto.GeneralCargoList.Select( s=>
                             new {
              s.OperationDate,
              s.StorageAreaCode,
              s.GeneralCargo

                              }
                              ))},
              new Parameter { ParameterName =nameof(dto.BulkList),
                  ParameterValue = JsonConvert.SerializeObject(dto.BulkList.Select( s=>
                             new {
              s.OperationDate,
              s.StorageAreaCode,
              s.Bulk

                              }
                              ))}
      }).Build();
            var response = await _requestExecutor.PostAsync<bool>(request);
            return response;
        }
    }
}
