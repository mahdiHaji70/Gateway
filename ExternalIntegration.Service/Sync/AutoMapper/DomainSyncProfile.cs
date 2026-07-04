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
            CreateMap<GoodwayBill, GoodwayBillDto>()
               .ForMember(dest => dest.BulkList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<BulkResultDto>>(src.BulkList)))
               .ForMember(dest => dest.CargoList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<GeneralCargoResultDto>>(src.CargoList)))
               .ForMember(dest => dest.ContainerList, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<ContainerResultDto>>(src.ContainerList)));

            CreateMap<DischargePermitDto, DischargePermit>();


            //CreateMap<GoodwayBill, GoodwayBillDto>()
            //        .ForMember(dest => dest.BulkList,
            //            opt => opt.MapFrom(src => ParseJsonSafe<List<BulkDto>>(src.BulkList)))
            //        .ForMember(dest => dest.CargoList,
            //            opt => opt.MapFrom(src => ParseJsonSafe<List<GeneralCargoDto>>(src.CargoList)));


        }
        private T ParseJsonSafe<T>(string json) where T : new()
        {
            if (string.IsNullOrWhiteSpace(json) || json == "[]")
                return new T();

            try
            {
                return JsonConvert.DeserializeObject<T>(json) ?? new T();
            }
            catch (Exception ex)
            {
                // لاگ برای دیباگ
                // Debug.WriteLine($"JSON Parse Error: {ex.Message}");
                return new T();
            }
        }
    }
}
