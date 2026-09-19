using TDM.Application.Doc.VesselLoadingPermits.DTOs;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public static class VesselLoadingPermitMapper
    {
        public static VesselLoadingPermitDto Map(VesselLoadingPermitResponseDto source)
        {
            if (source == null)
                return null;

            return new VesselLoadingPermitDto
            {
                Id = source.Id,
                PortId = source.PortId,
                Port = source.Port,
                TerminalId = source.TerminalId,
                Terminal = source.Terminal,
                Date = source.Date,
                SerialNo = source.SerialNo,
                CreatedById = source.CreatedById,
                CreatedBy = source.CreatedBy,
                Remark = source.Remark,
                PartyId = source.PartyId,
                Party = source.Party,
                PartyIdNumber = source.PartyIdNumber,
                CreationDate = source.CreationDate,
                State = source.State,
                StateName = source.StateName,
                GoodClassification = source.GoodClassification,
                GoodClassificationName = source.GoodClassificationName,
                CargoUnitizeTypeName = source.CargoUnitizeTypeName,
                OwnerName = source.OwnerName,
                OwnerIdNumber = source.OwnerIdNumber,
                OwnerType = source.OwnerType,
                OwnerRepName = source.OwnerRepName,
                OwnerRepIdNumber = source.OwnerRepIdNumber,
                OwnerRepType = source.OwnerRepType,
                WarehouseReceiptId = source.WarehouseReceiptId,
                WarehouseReceiptNo = source.WarehouseReceiptNo,
                TaskId = source.TaskId,
                TaskOwnerRoleName = source.TaskOwnerRoleName,
                TaskStage = source.TaskStage,
                TaskStageName = source.TaskStageName,
                TaskOwnerRoleNames = source.TaskOwnerRoleNames,
                TaskIsRead = source.TaskIsRead,
                TaskRemark = source.TaskRemark,
                Workflow = source.Workflow,
                TaskRegisterDate = source.TaskRegisterDate,
                TerminalCode = source.TerminalCode,
                ExpirationDate = source.ExpirationDate,
                BulkList = source.BulkList,
                GeneralCargoList = source.GeneralCargoList,
                ContainerList = source.ContainerList
            };
        }
    }
}
