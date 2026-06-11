export class CargoArrival {
    id?: string;
    declarationId: string;
    vehicleId: string;
    transportDate: Date;
    weight: number;
    packageCount: number;
    arrivalDeclarationTypes: string;

    constructor(
        declarationId: string,
        vehicleId: string,
        transportDate: Date,
        weight: number,
        packageCount: number,
        arrivalDeclarationTypes: string,
        id?: string
    ) {
        this.id = id;
        this.declarationId = declarationId;
        this.vehicleId = vehicleId;
        this.transportDate = transportDate;
        this.weight = weight;
        this.packageCount = packageCount;
        this.arrivalDeclarationTypes = arrivalDeclarationTypes;
    }
}