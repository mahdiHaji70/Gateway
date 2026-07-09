using AutoMapper;
using TDM.Application.BasicInformation.CargoTypes.DTOs;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.BasicInformation.Containers.DTOs;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs;
using TDM.Application.BasicInformation.Countries.DTOs;
using TDM.Application.BasicInformation.Packages.DTOs;
using TDM.Application.BasicInformation.Stores.DTOs;
using TDM.Application.BasicInformation.StoreTypes.DTOs;
using TDM.Application.BasicInformation.Terminals.DTOs;
using TDM.Application.BasicInformation.Traffics.DTOs;
using TDM.Application.BasicInformation.UsersTerminal.DTOs;
using TDM.Application.Common.Models;
using TDM.Application.Doc.DeclarationItems.DTOs;
using TDM.Application.Doc.Declarations.DTOs;
using TDM.Application.Operation.TerminalDischarges.DTOs;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo;
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

            CreateMap<Terminal, TerminalDto>();

            CreateMap<UserTerminal, UserTerminalDto>();

            CreateMap<Declaration, DeclarationDto>();

            CreateMap<DeclarationItem, DeclarationItemDto>()
                .ForMember(dest => dest.IpasDeclarationNo, opt => opt.MapFrom(src => src.Declaration.IpasDeclarationNo));


            CreateMap<ContainerTypeAndSize, ContainerTypeAndSizeDto>();
            CreateMap<CargoType, CargoTypeDto>();

            CreateMap<StoreType, StoreTypeDto>();

            CreateMap<Store, StoreDto>();

            CreateMap<TerminalDischarge, TerminalDischargeDto>()
                .ForMember(dest => dest.IpasDeclarationNo, opt => opt.MapFrom(src => src.DeclarationItem.Declaration.IpasDeclarationNo))
                .ForMember(dest => dest.DeclarationId, opt => opt.MapFrom(src => src.DeclarationItem.Declaration.Id))
                .ForMember(dest => dest.IsSend, opt => opt.MapFrom(src => src.IpasTerminalDischargeId != null));


            CreateMap<DeclarationContainer, DeclarationContainerDto>()
                .ForMember(dest => dest.ContainerNo, opt => opt.MapFrom(src => src.Container.No))
                .ForMember(dest => dest.ContainerTypeAndSize, opt => opt.MapFrom(src => src.Container.ContainerTypeAndSize.TypeAndSize));


            CreateMap<DeclarationContainerGood, DeclarationContainerGoodDto>()
                .ForMember(dest => dest.CommodityName, opt => opt.MapFrom(src => src.Commodity.Name))
                .ForMember(dest => dest.PackageName, opt => opt.MapFrom(src => src.Package.Name));

            CreateMap<Container, ContainerDto>()
                .ForMember(dest => dest.ContainerTypeAndSize, opt => opt.MapFrom(src => src.ContainerTypeAndSize.TypeAndSize))
                .ForMember(dest => dest.ContainerTypeAndSizeCode, opt => opt.MapFrom(src => src.ContainerTypeAndSize.TypeAndSizeCode));
            CreateMap<IpasGoodwayBillsResponse, IpasGoodwayBillsRequest>();
        }
    }
}
