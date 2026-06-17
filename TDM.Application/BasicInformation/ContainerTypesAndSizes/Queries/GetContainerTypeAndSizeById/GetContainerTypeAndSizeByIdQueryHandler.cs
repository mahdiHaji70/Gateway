using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.DTOs;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypeAndSizeById
{
    public class GetContainerTypeAndSizeByIdQueryHandler : IRequestHandler<GetContainerTypeAndSizeByIdQuery, ContainerTypeAndSizeDto>
    {
        private readonly IRepository<ContainerTypeAndSize> _containerTypeAndSizeRepository;
        private readonly IMapper _mapper;

        public GetContainerTypeAndSizeByIdQueryHandler(IMapper mapper,
            IRepository<ContainerTypeAndSize> containerTypeAndSizeRepository)
        {
            _containerTypeAndSizeRepository = containerTypeAndSizeRepository;
            _mapper = mapper;
        }

        public async Task<ContainerTypeAndSizeDto> Handle(GetContainerTypeAndSizeByIdQuery request, CancellationToken cancellationToken)
        {
            var containerTypeAndSize = await _containerTypeAndSizeRepository.GetAsync(request.Id);

            if (containerTypeAndSize == null)
                throw new NotFoundException("Container Type And Size");

            return _mapper.Map<ContainerTypeAndSizeDto>(containerTypeAndSize);

        }
    }
}
