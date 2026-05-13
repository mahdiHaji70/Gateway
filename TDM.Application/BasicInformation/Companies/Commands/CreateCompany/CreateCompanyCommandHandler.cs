using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Company> companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company(
                request.CompanyType,
                request.Name,
                request.NationalId,
                request.RegisterDate,
                request.Address,
                request.PostCode, 
                request.Mobile,
                request.EconomicCode,
                request.RegisterNumber,
                request.RegisterPlace,
                request.Phone);

            await _companyRepository.InsertAsync(company);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return company.Id;
        }
    }
}
