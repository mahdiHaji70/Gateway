using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Declarations.Commands.UpdateDeclaration
{
    public class UpdateDeclarationCommandHandler : IRequestHandler<UpdateDeclarationCommand, Guid>
    {
        private readonly IRepository<Declaration> _declarationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeclarationCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Declaration> declarationRepository)
        {
            _unitOfWork = unitOfWork;
            _declarationRepository = declarationRepository;
        }

        public async Task<Guid> Handle(UpdateDeclarationCommand request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetAsync(request.Id);

            if (declaration == null)
                throw new Exception("Declaration not found");

            declaration.Update(
                request.Number,
                request.StartDate,
                request.EndDate,
                request.ConsigneeId,
                request.ConsigneeRepId,
                request.TrafficId,
                request.Description,
                request.TerminalCode);

            _declarationRepository.Update(declaration);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return declaration.Id;
        }
    }
}
