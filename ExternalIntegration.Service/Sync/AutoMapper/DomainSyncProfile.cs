using AutoMapper;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;
using Newtonsoft.Json;

namespace ExternalIntegration.Service.Sync.AutoMapper
{
    public class DomainSyncProfile : Profile
    {
        public DomainSyncProfile()
        {
            CreateMap(typeof(Response<>), typeof(Response<>));
            CreateMap<GoodwayBill, GoodwayBillDto>()
               .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<BulkDto>>(src.BulkList)))
               .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<GeneralCargoDto>>(src.CargoList)))
               .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<ContainerDto>>(src.ContainerList)))
               .ReverseMap()
               .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.BulkList)))
               .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.CargoList)))
               .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.ContainerList)));


            CreateMap<DischargePermitDto, DischargePermit>();
            CreateMap(typeof(List<>), typeof(Response<>));

            CreateMap<IssueRequest, IssueRequestDto>()
                         .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<BulkDto>>(src.BulkList)))
                         .ForMember(dest => dest.GeneralCargoList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<GeneralCargoDto>>(src.GeneralCargoList)))
                         .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<ContainerDto>>(src.ContainerList)));

            CreateMap<Voyage, VoyageDto>()
 .ForMember(dest => dest.VesselData, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<ContainerResultDto>>(src.VesselData)));

            CreateMap<StoreReceipt, StoreReceiptDto>()
                        .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<BulkDto>>(src.BulkList)))
                        .ForMember(dest => dest.GeneralCargoList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<GeneralCargoDto>>(src.GeneralCargoList)))
                        .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<ContainerDto>>(src.ContainerList)));

        }
    }
}
