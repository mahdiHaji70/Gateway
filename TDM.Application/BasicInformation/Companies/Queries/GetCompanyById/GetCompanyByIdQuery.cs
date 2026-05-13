using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Companies.DTOs;

namespace TDM.Application.BasicInformation.Companies.Queries.GetCompanyById
{
    public record GetCompanyByIdQuery(Guid Id) : IRequest<CompanyDto>;
}
