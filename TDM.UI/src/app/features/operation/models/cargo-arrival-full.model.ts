export class CargoArrivalFull {
    id?: string;
    declarationId: string;
    declarationNumber: string;
    vehicleId: string;
    vehicleName: string;
    transportDate: Date;
    weight: number;
    packageCount: number;
    arrivalDeclarationType: string;

    constructor(
        declarationId: string,
        declarationNumber: string,
        vehicleId: string,
        vehicleName: string,
        transportDate: Date,
        weight: number,
        packageCount: number,
        arrivalDeclarationType: string,
        id?: string
    ) {
        this.id = id;
        this.declarationId = declarationId;
        this.declarationNumber = declarationNumber;
        this.vehicleId = vehicleId;
        this.vehicleName = vehicleName;
        this.transportDate = transportDate;
        this.weight = weight;
        this.packageCount = packageCount;
        this.arrivalDeclarationType = arrivalDeclarationType;
    }
}