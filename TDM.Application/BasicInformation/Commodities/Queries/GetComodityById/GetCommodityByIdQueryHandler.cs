using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Commodities.DTOs;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.BasicInformation.Companies.Queries.GetCompanyById;
using TDM.Application.Common.Exceptions;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Commodities.Queries.GetComodityById
{
    public class GetCommodityByIdQueryHandler : IRequestHandler<GetCommodityByIdQuery, CommodityDto>
    {
        private readonly IRepository<Commodity> _commodityRepository;
        private readonly IMapper _mapper;

        public GetCommodityByIdQueryHandler(IMapper mapper,
            IRepository<Commodity> commodityRepository)
        {
            _commodityRepository = commodityRepository;
            _mapper = mapper;
        }

        public async Task<CommodityDto> Handle(GetCommodityByIdQuery request, CancellationToken cancellationToken)
        {
            var commodity = await _commodityRepository.GetAsync(request.Id);

            if (commodity == null)
                throw new NotFoundException("Commodity");

            return _mapper.Map<CommodityDto>(commodity);

        }
    }
}
