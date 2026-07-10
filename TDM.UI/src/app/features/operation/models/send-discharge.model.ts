export class SendDischarge {
  id?: string;

  declarationId!: string;
  declarationNumber!: string;
  dischargeDate!: Date;

  vehicleNumber!: string;
  wayBillNo!: string;

  storeId!: string;
  storeName!: string;

  packNumber!: number;
  weight!: number;
  volume?: number;

  isSend: boolean;
  ipasTerminalDischargeId?: string;

  sendError?: string;

  constructor(
    declarationId: string,
    declarationNumber: string,
    dischargeDate: Date,
    vehicleNumber: string,
    wayBillNo: string,
    storeId: string,
    storeName: string,
    packNumber: number,
    weight: number,
    isSend: boolean,
    volume?: number,
    ipasTerminalDischargeId?: string,
    id?: string
  ) {
    this.id = id;
    this.declarationId = declarationId;
    this.declarationNumber = declarationNumber;
    this.dischargeDate = dischargeDate;
    this.vehicleNumber = vehicleNumber;
    this.wayBillNo = wayBillNo;
    this.storeId = storeId;
    this.storeName = storeName;
    this.packNumber = packNumber;
    this.weight = weight;
    this.volume = volume;
    this.isSend = isSend;
    this.ipasTerminalDischargeId = ipasTerminalDischargeId;
  }
}
