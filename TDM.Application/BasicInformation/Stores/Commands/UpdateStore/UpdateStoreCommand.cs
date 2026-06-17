using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Stores.Commands.UpdateStore
{
    public record class UpdateStoreCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid StoreTypeId { get; set; }

    }
}
