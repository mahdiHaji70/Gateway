using AutoMapper;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Operation.VesselDischarges.DTOs;

namespace TDM.Application.Operation.VesselDischarges.Queries.GetVesselDischargesByManifestItemId;

public class GetVesselDischargesByManifestItemIdQueryHandler : IRequestHandler<GetVesselDischargesByManifestItemIdQuery, List<VesselDischargeDto>>
{
    private readonly IVesselDischargeRepository _repository;
    private readonly IMapper _mapper;

    public GetVesselDischargesByManifestItemIdQueryHandler(IVesselDischargeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<VesselDischargeDto>> Handle(GetVesselDischargesByManifestItemIdQuery request, CancellationToken cancellationToken)
    {
        var discharges = await _repository.GetByManifestItemIdAsync(request.ManifestItemId, cancellationToken);
        return _mapper.Map<List<VesselDischargeDto>>(discharges);
    }
}