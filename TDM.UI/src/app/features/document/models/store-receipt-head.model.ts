import { StoreReceiptContainer } from './store-receipt-container.model';
import { StoreReceiptGood } from './store-receipt-good.model';

export class StoreReceiptHead {
  ipasStoreReceiptId!: string;
  terminalCode!: string;
  ipasStoreReceiptNo!: string;
  issueDate!: Date;
  consigneeId!: string;
  consigneeName!: string;
  consigneeNationalId!: string;
  consigneeRepId!: string;
  consigneeRepName!: string;
  consigneeRepNationalId!: string;
  cargoTypeId!: string;
  cargoTypeName!: string;
  firstDischargeDate?: Date;
  creatorName!: string;
  trafficId!: string;
  trafficCode!: string;
  trafficName!: string;
  storeReceiptStateId!: string;
  storeReceiptStateCode!: string;
  storeReceiptStateName!: string;
  requestId?: string;
  voyageNoticeNo!: string;
  arrivalTypeId!: string;
  arrivalTypeName!: string;
  declarationId?: string;
  ipasDeclarationNo?: string;
  billOfLadingId?: string;
  storeReceiptGoods!: StoreReceiptGood[];
  storeReceiptContainers!: StoreReceiptContainer[];
}
