using AutoMapper;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
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
               .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<ContainerDto>>(src.ContainerList)));

            CreateMap<DischargePermitDto, DischargePermit>();
            CreateMap(typeof(List<>), typeof(Response<>));
    

           
    }
}
