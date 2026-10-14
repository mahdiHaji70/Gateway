using MediatR;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.OperationTypes.Commands.RemoveOperationType
{
    public class DeleteOperationTypeCommandHandler : IRequestHandler<DeleteOperationTypeCommand, bool>
    {
        private readonly IRepository<OperationType> _operationtypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOperationTypeCommandHandler(IUnitOfWork unitOfWork
            , IRepository<OperationType> operationtypeRepository)
        {
            _unitOfWork = unitOfWork;
            _operationtypeRepository = operationtypeRepository;
        }

        public async Task<bool> Handle(DeleteOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationtype = await _operationtypeRepository.GetAsync(request.Id);

            if (operationtype == null)
                throw new Exception("OperationType not found");

            _operationtypeRepository.Delete(operationtype);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
