using AutoMapper;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;
using Newtonsoft.Json;

namespace ExternalIntegration.Service.Sync.AutoMapper
{
    public class PmoSyncProfile : Profile
    {
        public PmoSyncProfile()
        {
            CreateMap(typeof(Response<>), typeof(Response<>));

            CreateMap<GoodwayBillDto, GoodwayBillResponseDto>()
                .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
                .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => src.CargoList))
                .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<GoodwayBillResponseDto, GoodwayBillDto>()
                .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
                .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => src.CargoList))
                .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<GeneralCargoResponseDto, GeneralCargoDto>();
            CreateMap<BulkResponseDto, BulkDto>();
            CreateMap<ContainerResponseDto, ContainerDto>()
                .ForMember(dest => dest.Goods, opt => opt.MapFrom(src => src.Goods));

            CreateMap<ContainersGoodResponseDto, ContainerGoodDto>();

            CreateMap<CreateStorageAgreementDto, CreateStorageAgreementRequestDto>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner))
                .ForMember(dest => dest.OwnerRep, opt => opt.MapFrom(src => src.OwnerRep));

            CreateMap<OwnerRequestDto, OwnerDto>();
            CreateMap<OwnerDto, OwnerRequestDto>();

            CreateMap<OwnerRepRequestDto, OwnerRepDto>();
            CreateMap<OwnerRepDto, OwnerRepRequestDto>();

            CreateMap<CreateStorageAgreementRequestDto, CreateStorageAgreementDto>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner))
                .ForMember(dest => dest.OwnerRep, opt => opt.MapFrom(src => src.OwnerRep));

            CreateMap<CreateStorageAgreementDto, CreateStorageAgreementRequestDto>();

            CreateMap<CreateStorageAgreementResultDto, CreateStorageAgreementResponseDto>();
            CreateMap<CreateStorageAgreementResponseDto, CreateStorageAgreementResultDto>();                                 

            CreateMap<StorageAgreementResponseDto, StorageAgreementResultDto>()
               .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
               .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => src.CargoList))
               .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<GeneralCargoResponseDto, GeneralCargoResultDto>();
            CreateMap<ContainerResponseDto, ContainerResultDto>();
            CreateMap<ContainersGoodResponseDto, ContainerGoodResultDto>();
            CreateMap<BulkResponseDto, BulkResultDto>();
            
            CreateMap<DischargePermitDto, DischargePermitResponseDto>();
            
            CreateMap<TruckTerminalDischargeDto, TruckTerminalDischargeRequestDto>();
            CreateMap<TruckTerminalDischargeRequestDto,TruckTerminalDischargeDto>();
            CreateMap<GeneralCargoTruckTerminalDischargeDto, GeneralCargoTruckTerminalDischargeRequestDto>();
            CreateMap<GeneralCargoTruckTerminalDischargeRequestDto,GeneralCargoTruckTerminalDischargeDto>();
            CreateMap<BulkTruckTerminalDischargeDto, BulkTruckTerminalDischargeRequestDto>();
            CreateMap<ContainerTruckTerminalDischargeDto, ContainerTruckTerminalDischargeRequestDto>();
            CreateMap<DangerousSpecificationDto, DangerousSpecificationRequestDto>();
          
            CreateMap<IssueRequestDto, IssueRequestResponseDto>()
                .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
                .ForMember(dest => dest.GeneralCargoList, opt => opt.MapFrom(src => src.GeneralCargoList))
                .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<IssueRequestResponseDto, IssueRequestDto>()
                .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
                .ForMember(dest => dest.GeneralCargoList, opt => opt.MapFrom(src => src.GeneralCargoList))
                .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<VoyageDto, Voyage>()
                      .ForMember(dest => dest.VesselData, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.VesselData)));

            CreateMap<IssueRequestConfirmationDto, IssueRequestConfirmationRequestDto>();
            CreateMap<StoreReceiptDto, StoreReceiptResponseDto>()
               .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
               .ForMember(dest => dest.GeneralCargoList, opt => opt.MapFrom(src => src.GeneralCargoList))
               .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<StoreReceiptResponseDto, StoreReceiptDto>()
                .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
                .ForMember(dest => dest.GeneralCargoList, opt => opt.MapFrom(src => src.GeneralCargoList))
                .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<SendStoreReceiptAllocationDto, SendStoreReceiptAllocationRequestDto>();


        }
    }
}
