using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.CargoTypes.Queries.GetCargoTypeById
{
    public record GetCargoTypeByIdQuery(Guid Id) : IRequest<CargoTypeDto>;
}
