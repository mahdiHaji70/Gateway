using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Companies.Queries.GetCompanies
{
    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, PagedResult<CompanyDto>>
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public GetCompaniesQueryHandler(IMapper mapper, 
            IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CompanyDto>> Handle(
        GetCompaniesQuery request,
        CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetPagedAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedResult<CompanyDto>>(companies);            
        }
    }
}
