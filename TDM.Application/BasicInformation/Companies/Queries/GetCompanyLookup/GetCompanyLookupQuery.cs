using MediatR;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Companies.Queries.GetCompanyLookup
{
    public record GetCompanyLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<CompanyLookupDto>>;
}
