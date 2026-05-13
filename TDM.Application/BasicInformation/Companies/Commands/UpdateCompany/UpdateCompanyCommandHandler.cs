using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Companies.Commands.CreateCompany;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Application.BasicInformation.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Guid>
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork
            , IRepository<Company> companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public async Task<Guid> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync(request.Id);

            if (company == null)
                throw new Exception("Company not found");

            company.Update(
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

            _companyRepository.Update(company);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return company.Id;
        }
    }
}
