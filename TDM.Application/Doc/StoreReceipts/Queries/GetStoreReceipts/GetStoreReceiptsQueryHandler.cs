using AutoMapper;
using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Doc.StoreReceipts.DTOs;

namespace TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceipts
{
    public class GetStoreReceiptsQueryHandler
        : IRequestHandler<GetStoreReceiptsQuery, PagedResult<StoreReceiptHeadDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStoreReceiptHeadRepository _repository;

        public GetStoreReceiptsQueryHandler(IMapper mapper, IStoreReceiptHeadRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResult<StoreReceiptHeadDto>> Handle(
            GetStoreReceiptsQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _repository.GetPagedFilteredAsync(
                request.PageNumber, request.PageSize, request.Search, request.DateFrom, request.DateTo,
                request.ConsigneeId, request.ConsigneeRepId, request.TrafficId, request.CargoTypeId,
                request.ArrivalTypeCode);
            return _mapper.Map<PagedResult<StoreReceiptHeadDto>>(result);
        }
    }
}
