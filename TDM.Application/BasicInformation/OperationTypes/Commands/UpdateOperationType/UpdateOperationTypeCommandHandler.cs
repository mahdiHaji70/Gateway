using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.OperationTypes.Commands.UpdateOperationType
{
    public class UpdateOperationTypeCommandHandler : IRequestHandler<UpdateOperationTypeCommand, Guid>
    {
        private readonly IRepository<OperationType> _operationtypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOperationTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<OperationType> operationtypeRepository)
        {
            _unitOfWork = unitOfWork;
            _operationtypeRepository = operationtypeRepository;
        }

        public async Task<Guid> Handle(UpdateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationtype = await _operationtypeRepository.GetAsync(request.Id);

            if (operationtype == null)
                throw new Exception("OperationType not found");

            operationtype.Update(request.Name, request.Code);

            _operationtypeRepository.Update(operationtype);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return operationtype.Id;
        }
    }
}
