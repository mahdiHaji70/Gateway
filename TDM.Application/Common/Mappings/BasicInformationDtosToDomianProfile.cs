using AutoMapper;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.BasicInformation.Countries.DTOs;
using TDM.Application.BasicInformation.Packages.DTOs;
using TDM.Application.BasicInformation.Traffics.DTOs;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Declarations.DTOs;
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
            
            CreateMap<Package, PackageDto>();
            
            CreateMap<Country, CountryDto>();

            CreateMap<City, CityDto>();

            CreateMap<Declaration, DeclarationDto>();

        }
    }
}
