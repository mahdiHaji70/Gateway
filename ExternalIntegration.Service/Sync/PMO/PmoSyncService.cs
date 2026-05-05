using AutoMapper;
using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Repositories;
using ExternalIntegration.Service.Integrations.PMO.Client;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Sync.PMO
{
    public class PmoSyncService : IPmoSyncService
    {
        private readonly IPmoClient _client;
        private readonly IMapper _mapper;
        private readonly IRepository<GoodwayBill> _goodwayBillRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PmoSyncService(IPmoClient client
            ,IMapper mapper
            ,IUnitOfWork unitOfWork
            , IRepository<GoodwayBill> goodwayBillRepository)
        {
            _client = client;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _goodwayBillRepository = goodwayBillRepository;
        }
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBill(DateRangeDto dto)
        {            
            var clientResult = await _client.GetGoodwayBill(dto);

            var syncMappingDto = _mapper.Map<Response<IEnumerable<GoodwayBillDto>>>(clientResult);

            var newData = await _goodwayBillRepository.FilterUnpersistedAsync(
                entities: _mapper.Map<IEnumerable<GoodwayBill>>(syncMappingDto.Data),
                idSelector: t => t.Id,
                dbIdSelector: t => t.Id
            );

            await _goodwayBillRepository.InsertBulkAsync(newData);            
            await _unitOfWork.SaveChangesAsync();
           
            return syncMappingDto;
        }
    }
}
