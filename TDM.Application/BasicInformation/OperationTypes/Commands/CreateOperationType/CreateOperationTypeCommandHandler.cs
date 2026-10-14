using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.OperationTypes.Commands.CreateOperationType
{
    public class CreateOperationTypeCommandHandler : IRequestHandler<CreateOperationTypeCommand, Guid>
    {
        private readonly IRepository<OperationType> _operationtypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOperationTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<OperationType> operationtypeRepository)
        {
            _unitOfWork = unitOfWork;
            _operationtypeRepository = operationtypeRepository;
        }

        public async Task<Guid> Handle(CreateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationtype = new OperationType(
                request.Name,
                request.Code);

            await _operationtypeRepository.InsertAsync(operationtype);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return operationtype.Id;
        }
    }
}
