export class ManifestGoodDto {
  packNb!: number;
  grossWeight!: number;
  netWeight!: number;
  volume!: number;
  brandName?: string;
  description?: string;

  manifestItemId!: string;

  commodityId!: string;
  hsCode?: string;
  commodityName?: string;

  packageId!: string;
  packageCode?: string;
  packageName?: string;
}