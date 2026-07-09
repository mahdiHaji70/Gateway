export class Discharge {

    id?: string;
    declarationItemId: string;
    cargoTypeId: string;
    storeId: string;
    wayBillNo: string;
    wayBillId: string;
    dischargeDate: Date;
    vehicleNumber: string;
    packNb: number;
    weight: number;
    volume?: number;

    isNonPalletized: boolean;
    isDamaged: boolean;
    isVoluminous: boolean;
    isDangerous: boolean;

    dangerousCode?: string;
    classification?: string;
    ignitionTemperature?: number;
    ignitionTemperatureUnit?: string;

    terminalCode: string;

    constructor(
        declarationItemId: string,
        cargoTypeId: string,
        storeId: string,
        wayBillNo: string,
        wayBillId: string,
        dischargeDate: Date,
        vehicleNumber: string,
        packNb: number,
        weight: number,
        terminalCode: string,
        volume?: number,
        isNonPalletized: boolean = false,
        isDamaged: boolean = false,
        isVoluminous: boolean = false,
        isDangerous: boolean = false,
        dangerousCode?: string,
        classification?: string,
        ignitionTemperature?: number,
        ignitionTemperatureUnit?: string,
        id?: string
    ) {
        this.id = id;
        this.declarationItemId = declarationItemId;
        this.cargoTypeId = cargoTypeId;
        this.storeId = storeId;
        this.wayBillNo = wayBillNo;
        this.wayBillId = wayBillId;
        this.dischargeDate = dischargeDate;
        this.vehicleNumber = vehicleNumber;
        this.packNb = packNb;
        this.weight = weight;
        this.volume = volume;
        this.terminalCode = terminalCode;

        this.isNonPalletized = isNonPalletized;
        this.isDamaged = isDamaged;
        this.isVoluminous = isVoluminous;
        this.isDangerous = isDangerous;

        this.dangerousCode = dangerousCode;
        this.classification = classification;
        this.ignitionTemperature = ignitionTemperature;
        this.ignitionTemperatureUnit = ignitionTemperatureUnit;
    }
}
