import { ManifestContainerGoodDto } from "./manifest-container-good.model";

export class ManifestContainerDto {
  containerId!: string;
  containerNo?: string;
  containerTypeAndSizeCode?: string;
  manifestItemId!: string;
  billOfLadingId?: string;
  sealNumber?: string;
  dangerousCode?: string;
  classification?: string;
  ignitionTemperature?: number;
  ignitionTemperatureUnit?: string;

  manifestContainerGoods?: ManifestContainerGoodDto[];
}