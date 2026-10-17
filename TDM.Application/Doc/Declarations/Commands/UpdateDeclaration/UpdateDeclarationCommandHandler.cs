using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.Doc.Declarations.Commands.UpdateDeclaration
{
    public class UpdateDeclarationCommandHandler : IRequestHandler<UpdateDeclarationCommand, Guid>
    {
        private readonly IRepository<Declaration> _declarationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;

        public UpdateDeclarationCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Declaration> declarationRepository
            , ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _declarationRepository = declarationRepository;
            _companyRepository = companyRepository;
        }

        public async Task<Guid> Handle(UpdateDeclarationCommand request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetAsync(request.Id);

            if (declaration == null)
                throw new Exception("Declaration not found");

            var consignee = await _companyRepository.GetAsync(request.ConsigneeId)
                ?? throw new Exception("Consignee not found");

            declaration.Update(
                request.Number,
                request.Date,
                request.StartDate,
                request.EndDate,
                request.ConsigneeId,
                request.ConsigneeRepId,
                request.TrafficId,
                request.Description,
                request.TerminalCode,
                consignee.CompanyType);

            _declarationRepository.Update(declaration);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return declaration.Id;
        }
    }
}
