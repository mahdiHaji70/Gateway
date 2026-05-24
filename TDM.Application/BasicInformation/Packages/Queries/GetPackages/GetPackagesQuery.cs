using MediatR;
using TDM.Application.BasicInformation.Packages.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Packages.Queries.GetPackages
{
    public record GetPackagesQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<PackageDto>>;

}
