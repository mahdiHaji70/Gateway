using FluentValidation;

namespace TDM.Application.BasicInformation.Services.Commands.UpdateService
{
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(10)
                .WithMessage("Code is required.");
        }
    }
}
