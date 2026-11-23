using FluentValidation;

namespace TDM.Application.Doc.Voyages.Commands.UpdateVoyage
{
    public class UpdateVoyageCommandValidator : AbstractValidator<UpdateVoyageCommand>
    {
        public UpdateVoyageCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

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
