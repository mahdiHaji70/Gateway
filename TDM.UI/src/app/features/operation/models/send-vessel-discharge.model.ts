export interface SendVesselDischarge {
  id: string;
  manifestItemNo: string;
  manifestNo: string;
  containerNo?: string;
  storeName: string;
  dischargeDate: Date;
  packNB: number;
  weight: number;
  isDangerous: boolean;
  isSend: boolean;
  sendError?: string;
}