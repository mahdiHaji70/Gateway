using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Stores.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Stores.Queries.GetStores
{
    public record GetStoresQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<StoreDto>>;
}
