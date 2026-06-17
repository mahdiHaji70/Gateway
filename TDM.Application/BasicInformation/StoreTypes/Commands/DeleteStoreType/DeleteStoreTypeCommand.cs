using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.StoreTypes.Commands.DeleteStoreType
{
    public class DeleteStoreTypeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStoreTypeCommand(Guid id)
        {
            Id = id;
        }
    }
}
