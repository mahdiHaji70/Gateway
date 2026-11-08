using MediatR;
using TDM.Application.BasicInformation.Packages.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Packages.Queries.GetPackageLookup
{
    public record GetPackageLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<PackageDto>>;
}
