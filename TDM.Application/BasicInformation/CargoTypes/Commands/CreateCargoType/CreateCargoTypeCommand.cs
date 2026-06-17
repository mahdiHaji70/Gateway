using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.CreateCargoType
{
    public record class CreateCargoTypeCommand : IRequest<Guid>
    {
        public string Name { get; init; }
    }
}
