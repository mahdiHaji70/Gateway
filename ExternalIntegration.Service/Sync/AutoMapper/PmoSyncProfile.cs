using AutoMapper;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Integrations.PMO.Requests;
using ExternalIntegration.Service.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;
using Newtonsoft.Json;

namespace ExternalIntegration.Service.Sync.AutoMapper
{
    public class PmoSyncProfile : Profile
    {
        public PmoSyncProfile()
        {
            CreateMap(typeof(Response<>), typeof(Response<>));        

            CreateMap<GoodwayBillDto, GoodwayBillResultDto>()
                .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
                .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => src.CargoList))
                .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<GoodwayBillResultDto, GoodwayBillDto>()
                .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => src.BulkList))
                .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => src.CargoList))
                .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => src.ContainerList));

            CreateMap<CreateStorageAgreementDto, CreateStorageAgreementRequestDto>()
                .ForMember(dest=>dest.Owner,opt=>opt.MapFrom(src=>src.Owner))
                .ForMember(dest => dest.OwnerRep, opt => opt.MapFrom(src => src.OwnerRep));

            CreateMap<CreateStorageAgreementDto, CreateStorageAgreementRequestDto>();

        }
    }
}
