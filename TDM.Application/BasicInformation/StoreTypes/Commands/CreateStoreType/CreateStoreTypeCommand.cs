using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.CreateStoreType
{
    public record class CreateStoreTypeCommand:IRequest<Guid>
    {
        public string Name { get; init; }
    }
}
