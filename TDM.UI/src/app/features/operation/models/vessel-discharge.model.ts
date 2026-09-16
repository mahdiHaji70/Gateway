export class VesselDischarge {
  id?: string;
  terminalCode!: string;
  storeId!: string;
  manifestItemId!: string;
  manifestContainerId?: string;
  dischargeDate!: Date;
  packNB!: number;
  weight!: number;
  volume!: number;
  isNonPalletized: boolean = false;
  isDamaged: boolean = false;
  isVoluminous: boolean = false;
  isDangerous: boolean = false;
  dangerousCode?: string;
  classification?: string;
  ignitionTemperature: number = 0;
  ignitionTemperatureUnit?: string;
  unitWeight: number = 0;
}
