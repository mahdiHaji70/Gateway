using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Domain.Entities;
using TDM.Domain.Exceptions;

namespace TDM.Application.BasicInformation.Declarations.Commands.RequestIpasDeclarationId
{
    public class IpasDeclarationIdCommandHandler : IRequestHandler<IpasDeclarationIdCommand, string>
    {
        private readonly IDeclarationRepository _declarationRepository;
        private readonly IDeclarationExternalService _declarationExternalService;
        private readonly IUnitOfWork _unitOfWork;

        public IpasDeclarationIdCommandHandler(IUnitOfWork unitOfWork
            , IDeclarationRepository declarationRepository
            , IDeclarationExternalService declarationExternalService)
        {
            _unitOfWork = unitOfWork;
            _declarationRepository = declarationRepository;
            _declarationExternalService = declarationExternalService;
        }

        public async Task<string> Handle(IpasDeclarationIdCommand request, CancellationToken cancellationToken)
        {
            var declaration = await _declarationRepository.GetAsync(request.DeclarationId);
            if (declaration == null)
                throw new Exception("Declaration not found");

            if (!string.IsNullOrWhiteSpace(declaration.IpasDeclarationId))
                throw new Exception("Ipas declarationId id has already been assigned for this declaration.");

            var ipasDeclarationIdRequest = IpasDeclarationIdRequestMapper.Map(declaration);

            var ipasDeclarationId = await _declarationExternalService.GetIpasDeclarationId(ipasDeclarationIdRequest);

            declaration.SetIpasDeclarationId(ipasDeclarationId);

            _declarationRepository.Update(declaration);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            return ipasDeclarationId;
        }
    }
}
