using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Stores.DTOs;

namespace TDM.Application.BasicInformation.Stores.Queries.GetStoreById
{
    public record GetStoreByIdQuery(Guid Id) : IRequest<StoreDto>;
}
