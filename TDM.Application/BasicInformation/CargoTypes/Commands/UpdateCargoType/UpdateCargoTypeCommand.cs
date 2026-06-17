using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.UpdateCargoType
{
    public record class UpdateCargoTypeCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

      
    }
}
