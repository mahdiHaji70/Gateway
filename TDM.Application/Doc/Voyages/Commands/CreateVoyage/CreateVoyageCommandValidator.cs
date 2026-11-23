using FluentValidation;

namespace TDM.Application.Doc.Voyages.Commands.CreateVoyage
{
    public class CreateVoyageCommandValidator : AbstractValidator<CreateVoyageCommand>
    {
        public CreateVoyageCommandValidator()
        {
            RuleFor(x => x.VoyageNo).NotEmpty().MaximumLength(50);
            RuleFor(x => x.NoticeNo).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ETA).NotEmpty();
            RuleFor(x => x.ETD).NotEmpty();
            RuleFor(x => x.ShipLine).NotEmpty().MaximumLength(200);
            RuleFor(x => x.ShipAgent).NotEmpty().MaximumLength(200);
            RuleFor(x => x.VesselName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Imo).NotEmpty().MaximumLength(20);
        }
    }
}
