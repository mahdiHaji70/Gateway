using MediatR;
using TDM.Application.BasicInformation.Companies.DTOs;

namespace TDM.Application.BasicInformation.Companies.Queries.GetCompanyById
{
    public record GetCompanyByIdQuery(Guid Id) : IRequest<CompanyDto>;
}
