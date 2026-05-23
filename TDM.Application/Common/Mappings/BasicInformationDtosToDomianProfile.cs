using AutoMapper;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.BasicInformation.Traffics.DTOs;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Mappings
{
    public class BasicInformationDtosToDomianProfile : Profile
    {
        public BasicInformationDtosToDomianProfile()
        {
            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));

            CreateMap<Company, CompanyDto>();

            CreateMap<Commodity, CommodityDto>();

            CreateMap<Traffic, TrafficDto>();

        }
    }
}
