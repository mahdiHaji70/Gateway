using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.StoreTypes.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypes
{
    public record GetStoreTypesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<StoreTypeDto>>;
}
