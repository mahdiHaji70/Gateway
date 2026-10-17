using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public static class CreateStorageAgreementMapper
    {
        public static CreateStorageAgreementDto Map(IpasDeclarationIdRequest ipasDeclarationIdRequest)
        {
            var ownerDto = new OwnerDto 
            {
                Name = ipasDeclarationIdRequest.ConsigneeName,
                NationalID = ipasDeclarationIdRequest.ConsigneeNationalId,
                Email = "test@gmail.com",
                Date = ipasDeclarationIdRequest.ConsigneeRegisterDate,
                CellPhone = ipasDeclarationIdRequest.ConsigneeMobile,
                PostalCode = ipasDeclarationIdRequest.ConsigneePostCode,
                Address = ipasDeclarationIdRequest.ConsigneeAddress,
                IsCompany = ipasDeclarationIdRequest.ConsigneeIsCompany
            };

            var ownerRepDto = ipasDeclarationIdRequest.ConsigneeRepBirthDate is DateTime birthDate ? new OwnerRepDto
            {
                Name = ipasDeclarationIdRequest.ConsigneeRepName!,
                NationalID = ipasDeclarationIdRequest.ConsigneeRepNationalId!,
                Email = "test@gmail.com",
                BirthDate = birthDate,
                CellPhone = ipasDeclarationIdRequest.ConsigneeRepMobile!,
                PostalCode = ipasDeclarationIdRequest.ConsigneeRepPostCode!,
                Address = ipasDeclarationIdRequest.ConsigneeRepAddress!,
            } : null;

            return new CreateStorageAgreementDto 
            { 
                TerminalCode = ipasDeclarationIdRequest.TerminalCode,
                AgreementDate = ipasDeclarationIdRequest.Date,
                StartDate = ipasDeclarationIdRequest.StartDate,
                FinishDate = ipasDeclarationIdRequest.EndDate,
                CustomsProcedureCode = ipasDeclarationIdRequest.Traffic,
                Owner = ownerDto,
                OwnerRep = ownerRepDto,
                WorkflowRemark = ipasDeclarationIdRequest.Description
            };
        }


    }
}
