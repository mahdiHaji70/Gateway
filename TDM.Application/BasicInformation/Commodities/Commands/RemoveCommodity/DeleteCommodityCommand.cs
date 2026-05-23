using MediatR;

namespace TDM.Application.BasicInformation.Commodities.Commands.RemoveCommodity
{
    public class DeleteCommodityCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCommodityCommand(Guid id)
        {
            Id = id;
        }
    }
}
