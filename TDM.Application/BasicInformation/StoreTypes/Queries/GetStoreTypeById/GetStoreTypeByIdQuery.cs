using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.StoreTypes.DTOs;

namespace TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypeById
{
      public record GetStoreTypeByIdQuery(Guid Id) : IRequest<StoreTypeDto>;
}
