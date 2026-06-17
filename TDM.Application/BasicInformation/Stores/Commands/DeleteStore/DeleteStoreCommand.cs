using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStoreCommand(Guid id)
        {
            Id = id;
        }
    }
}
