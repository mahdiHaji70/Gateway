using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.UpdateStoreType
{
    public record class UpdateStoreTypeCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


    }
}
