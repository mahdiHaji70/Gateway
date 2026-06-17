using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.DTOs;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.CargoTypes.Queries.GetCargoTypes
{
    public record GetCargoTypesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<CargoTypeDto>>;
}
