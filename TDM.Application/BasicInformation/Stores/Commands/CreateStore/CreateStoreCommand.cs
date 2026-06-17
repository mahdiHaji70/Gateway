using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Stores.Commands.CreateStore
{
    public record class CreateStoreCommand:IRequest<Guid>
    {
        
            public string Name { get; init; }
            public Guid StoreTypeId { get; set; }
        
    }
}
