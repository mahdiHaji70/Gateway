using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Commodities.Commands.CreateCommodity
{
    public class CreateCommodityCommandHandler : IRequestHandler<CreateCommodityCommand, Guid>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommodityCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Commodity> commodityRepository)
        {
            _unitOfWork = unitOfWork;
            _commodityRepository = commodityRepository;
        }

        public async Task<Guid> Handle(CreateCommodityCommand request, CancellationToken cancellationToken)
        {
            var commodity = new Commodity(
                request.Name,
                request.HSCode);

            await _commodityRepository.InsertAsync(commodity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return commodity.Id;
        }
    }
}
