export class ManifestContainerGoodDto {
  packNb!: number;
  grossWeight!: number;
  netWeight?: number;

  manifestContainerId!: string;

  commodityId!: string;
  hsCode?: string;
  commodityName?: string;

  packageId!: string;
  packageCode?: string;
  packageName?: string;
}