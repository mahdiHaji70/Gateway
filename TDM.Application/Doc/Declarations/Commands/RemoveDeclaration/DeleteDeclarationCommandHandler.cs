using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Declarations.Commands.RemoveDeclaration
{
    public class DeleteDeclarationCommandHandler : IRequestHandler<DeleteDeclarationCommand, bool>
    {
        private readonly IRepository<Declaration> _declarationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeclarationCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Declaration> declarationRepository)
        {
            _unitOfWork = unitOfWork;
            _declarationRepository = declarationRepository;
        }

        public async Task<bool> Handle(DeleteDeclarationCommand request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetAsync(request.Id);

            if (declaration == null)
                throw new Exception("Declaration not found");

            _declarationRepository.Delete(declaration);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
