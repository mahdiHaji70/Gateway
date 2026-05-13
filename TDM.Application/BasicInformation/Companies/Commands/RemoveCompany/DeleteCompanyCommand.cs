using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.BasicInformation.Companies.Commands.RemoveCompany
{
    public class DeleteCompanyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCompanyCommand(Guid id)
        {
            Id = id;
        }
    }
}
