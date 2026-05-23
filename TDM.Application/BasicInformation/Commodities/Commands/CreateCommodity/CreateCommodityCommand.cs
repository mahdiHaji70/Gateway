using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Commodities.Commands.CreateCommodity
{
    public record CreateCommodityCommand : IRequest<Guid>
    {
        public string Name { get; init; } = default!;
        public string HSCode { get; init; } = default!;
    }
}
