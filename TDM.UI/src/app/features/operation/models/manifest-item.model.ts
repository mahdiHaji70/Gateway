export interface ManifestGood {
  id: string;
  packNb: number;
  grossWeight: number;
  netWeight: number;
  description?: string;
  commodityName?: string;
  packageName?: string;
}

export interface ManifestContainerGood {
  packNb: number;
  grossWeight: number;
  netWeight: number;
  commodityName?: string;
  packageName?: string;
}

export interface ManifestContainer {
  id: string;
  containerId: string;
  containerNo: string;
  containerTypeAndSizeCode?: string;
  sealNumber?: string;
  dangerousCode?: string;
  classification?: string;
  ignitionTemperature?: number;
  ignitionTemperatureUnit?: string;
  manifestContainerGoods: ManifestContainerGood[];
}

export interface ManifestItem {
  id?: string;
  manifestItemNo: string;
  manifestNo: string;
  manifestGoods: ManifestGood[];
  manifestContainers: ManifestContainer[];
}
