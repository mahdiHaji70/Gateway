using AutoMapper;
using MediatR;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;

namespace TDM.Application.BasicInformation.Companies.Queries.GetCompanyLookup
{
    public class GetCompanyLookupQueryHandler : IRequestHandler<GetCompanyLookupQuery, PagedResult<CompanyLookupDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyLookupQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CompanyLookupDto>> Handle(
            GetCompanyLookupQuery request,
            CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Search);

            return _mapper.Map<PagedResult<CompanyLookupDto>>(companies);
        }
    }
}
