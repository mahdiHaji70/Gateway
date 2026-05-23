using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Commodities.Commands.RemoveCommodity
{
    public class DeleteCommodityCommandHandler : IRequestHandler<DeleteCommodityCommand, bool>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommodityCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Commodity> commodityRepository)
        {
            _unitOfWork = unitOfWork;
            _commodityRepository = commodityRepository;
        }

        public async Task<bool> Handle(DeleteCommodityCommand request, CancellationToken cancellationToken)
        {
            var commodity = await _commodityRepository.GetAsync(request.Id);

            if (commodity == null)
                throw new Exception("Commodity not found");

            _commodityRepository.Delete(commodity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
