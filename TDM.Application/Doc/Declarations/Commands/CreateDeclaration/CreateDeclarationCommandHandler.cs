using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Declarations.Commands.CreateDeclaration
{
    public class CreateDeclarationCommandHandler : IRequestHandler<CreateDeclarationCommand, Guid>
    {
        private readonly IRepository<Declaration> _declarationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeclarationCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Declaration> declarationRepository)
        {
            _unitOfWork = unitOfWork;
            _declarationRepository = declarationRepository;
        }

        public async Task<Guid> Handle(CreateDeclarationCommand request, CancellationToken cancellationToken)
        {
            var declaration = new Declaration(
                request.Number,
                request.StartDate,
                request.EndDate,
                request.ConsigneeId,
                request.ConsigneerepId,
                request.TrafficId,
                request.Description,
                request.TerminalCode);

            await _declarationRepository.InsertAsync(declaration);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return declaration.Id;
        }
    }
}
