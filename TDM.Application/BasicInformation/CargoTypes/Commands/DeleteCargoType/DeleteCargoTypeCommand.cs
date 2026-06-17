using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.CargoTypes.Commands.DeleteCargoType
{
    public class DeleteCargoTypeCommand:IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCargoTypeCommand(Guid id)
        {
            Id = id;
        }
    }
}
