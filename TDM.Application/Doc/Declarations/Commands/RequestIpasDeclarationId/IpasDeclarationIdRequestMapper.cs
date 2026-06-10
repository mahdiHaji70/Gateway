using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId
{
    public static class IpasDeclarationIdRequestMapper
    {
        public static IpasDeclarationIdRequest Map(Declaration declaration)
        {
            return new IpasDeclarationIdRequest 
            { 
                TerminalCode = declaration.TerminalCode,
                Date = declaration.Date,
                StartDate = declaration.StartDate,
                EndDate = declaration.EndDate,
                Traffic = declaration.Traffic.Code,
                Description = declaration.Description,
                ConsigneeName = declaration.Consignee.Name,
                ConsigneeNationalId = declaration.Consignee.NationalId,
                ConsigneeRegisterDate = declaration.Consignee.RegisterDate,
                ConsigneeMobile = declaration.Consignee.Mobile,
                ConsigneePostCode = declaration.Consignee.PostCode,
                ConsigneeAddress = declaration.Consignee.Address,
                ConsigneeIsCompany = declaration.Consignee.CompanyType == CompanyType.Company ? true : false,
                ConsigneeRepName = declaration.ConsigneeRep.Name,
                ConsigneeRepNationalId = declaration.ConsigneeRep.NationalId,
                ConsigneeRepBirthDate = declaration.ConsigneeRep.RegisterDate,
                ConsigneeRepMobile = declaration.ConsigneeRep.Mobile,
                ConsigneeRepPostCode = declaration.ConsigneeRep.PostCode,
                ConsigneeRepAddress = declaration.ConsigneeRep.Address,
                ConsigneeRepIsCompany = declaration.ConsigneeRep.CompanyType == CompanyType.Company ? true : false,
            };
        }

    }
}
