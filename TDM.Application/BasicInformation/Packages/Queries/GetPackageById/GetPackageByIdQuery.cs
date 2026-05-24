using MediatR;
using TDM.Application.BasicInformation.Packages.DTOs;

namespace TDM.Application.BasicInformation.Packages.Queries.GetPackageById
{
    public record GetPackageByIdQuery(Guid Id) : IRequest<PackageDto>;

}
