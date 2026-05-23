using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Commodities.Commands.UpdateCommodity
{
    public class UpdateCommodityCommandHandler : IRequestHandler<UpdateCommodityCommand, Guid>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommodityCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Commodity> commodityRepository)
        {
            _unitOfWork = unitOfWork;
            _commodityRepository = commodityRepository;
        }

        public async Task<Guid> Handle(UpdateCommodityCommand request, CancellationToken cancellationToken)
        {
            var commodity = await _commodityRepository.GetAsync(request.Id);

            if (commodity == null)
                throw new Exception("Commodity not found");

            commodity.Update(request.Name, request.HSCode);

            _commodityRepository.Update(commodity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return commodity.Id;
        }
    }
}
