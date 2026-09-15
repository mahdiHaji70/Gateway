import { ManifestContainerDto } from "./manifest-container.model";
import { ManifestGoodDto } from "./manifest-good.model";

export class ManifestItemDto {
  manifestItemNo?: string;
  manifestNo?: string;
  consignor?: string;
  shipLine?: string;
  manifestId!: string;

  trafficId!: string;
  trafficCode?: string;
  trafficName?: string;

  consigneeId!: string;
  consigneeName?: string;
  consigneeNationalId?: string;

  cargoTypeId!: string;
  cargoTypeName?: string;

  shipAgentId!: string;
  shipAgentName?: string;
  shipAgentNationalId?: string;

  ipasItemId!: string;

  manifestGoods?: ManifestGoodDto[];
  manifestContainers?: ManifestContainerDto[];
}
