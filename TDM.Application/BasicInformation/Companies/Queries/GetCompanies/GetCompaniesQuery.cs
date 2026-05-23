using MediatR;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Companies.Queries.GetCompanies
{
    public record GetCompaniesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<CompanyDto>>;
}
