using FluentValidation;

namespace TDM.Application.BasicInformation.Commodities.Commands.RemoveCommodity
{
    public class DeleteCommodityCommandValidator : AbstractValidator<DeleteCommodityCommand>
    {
        public DeleteCommodityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
