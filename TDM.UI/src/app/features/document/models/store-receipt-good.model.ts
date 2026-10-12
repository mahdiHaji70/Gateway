export class StoreReceiptGood {
  storeReceiptHeadId!: string;
  commodityId!: string;
  commodityName!: string;
  packageId!: string;
  packageName!: string;
  hsCode!: string;
  packageTypeCode!: string;
  brandName!: string;
  noBrandName!: boolean;
  packNB!: number;
  grossWeight!: number;
  netWeight!: number;
  volume!: number;
  remark!: string;
  isHeavy: boolean = false;
  isNonPalletized: boolean = false;
  isDamaged: boolean = false;
  isVoluminous: boolean = false;
  isDangerous: boolean = false;
  dangerousNotNoticed: boolean = false;
  dangerousCode!: string;
  classification!: string;
  ignitionTemperature!: number;
  ignitionTemperatureUnit!: string;
}
