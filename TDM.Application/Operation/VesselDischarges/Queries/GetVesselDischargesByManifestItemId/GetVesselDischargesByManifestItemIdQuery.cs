using MediatR;
using TDM.Application.Operation.VesselDischarges.DTOs;

namespace TDM.Application.Operation.VesselDischarges.Queries.GetVesselDischargesByManifestItemId;

public record GetVesselDischargesByManifestItemIdQuery(Guid ManifestItemId) : IRequest<List<VesselDischargeDto>>;