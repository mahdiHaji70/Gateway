using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Enums;

namespace TDM.Application.BasicInformation.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public CompanyType CompanyType { get; init; }
        public string Name { get; init; } = default!;
        public string NationalId { get; init; } = default!;
        public DateTime RegisterDate { get; init; }
        public string Address { get; init; } = default!;
        public string PostCode { get; init; } = default!;
        public string Mobile { get; init; } = default!;
        public string? EconomicCode { get; init; }
        public string? RegisterNumber { get; init; }
        public string? RegisterPlace { get; init; }
        public string? Phone { get; init; }
    }
}
