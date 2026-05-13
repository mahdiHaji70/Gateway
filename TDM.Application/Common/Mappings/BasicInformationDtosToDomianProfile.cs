using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Companies.DTOs;
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
        }
    }
}
