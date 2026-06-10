using AutoMapper;
using ExternalIntegration.Service.Application.Shared;
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

            CreateMap<CreateStorageAgreementDto, CreateStorageAgreementRequestDto>()
                .ForMember(dest=>dest.Owner,opt=>opt.MapFrom(src=>src.Owner))
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
            CreateMap<BulkResponseDto, BulkResultDto>();

        }
    }
}
