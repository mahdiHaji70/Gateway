import { StoreReceiptContainerGood } from './store-receipt-container-good.model';

export class StoreReceiptContainer {
  storeReceiptHeadId!: string;
  containerId!: string;
  containerNo!: string;
  containerTypeAndSizeCode!: string;
  sealNumber!: string;
  remark!: string;
  dangerousCode!: string;
  classification!: string;
  ignitionTemperature!: number;
  ignitionTemperatureUnit!: string;
  storeReceiptContainerGoods!: StoreReceiptContainerGood[];
}
