using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Companies.Commands.RemoveCommodity
{
    public class DeleteCommodityCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCommodityCommand(Guid id)
        {
            Id = id;
        }
    }
}
