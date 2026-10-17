using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Declarations.Commands.CreateDeclaration
{
    public class CreateDeclarationCommandHandler : IRequestHandler<CreateDeclarationCommand, Guid>
    {
        private readonly IRepository<Declaration> _declarationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;

        public CreateDeclarationCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Declaration> declarationRepository
            , ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _declarationRepository = declarationRepository;
            _companyRepository = companyRepository;
        }

        public async Task<Guid> Handle(CreateDeclarationCommand request, CancellationToken cancellationToken)
        {
            var consignee = await _companyRepository.GetAsync(request.ConsigneeId)
                ?? throw new Exception("Consignee not found");

            var declaration = new Declaration(
                request.Number,
                request.Date,
                request.StartDate,
                request.EndDate,
                request.ConsigneeId,
                request.ConsigneerepId,
                request.TrafficId,
                request.Description,
                request.TerminalCode,
                consignee.CompanyType);

            await _declarationRepository.InsertAsync(declaration);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return declaration.Id;
        }
    }
}
