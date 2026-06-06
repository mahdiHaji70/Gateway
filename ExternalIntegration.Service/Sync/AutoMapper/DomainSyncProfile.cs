using AutoMapper;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Newtonsoft.Json;

namespace ExternalIntegration.Service.Sync.AutoMapper
{
    public class DomainSyncProfile : Profile
    {
        public DomainSyncProfile()
        {
            CreateMap<GoodwayBillDto, GoodwayBill>()
           .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.BulkList)))
           .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.CargoList)))
           .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.ContainerList)));
            CreateMap<DischargePermitDto, DischargePermit>();
        }
    }
}
