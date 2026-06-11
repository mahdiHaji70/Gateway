export class GateFull {
    id?: string;
    declarationId: string;
    declarationNumber: string;
    vehicleId: string;
    vehicleName: string;
    containerId?: string;
    containerNumber?: string;
    enterDate: Date;
    exitDate?: Date;

    /**
     *
     */
    constructor(declarationId: string, declarationNumber: string, vehicleId: string, vehicleName: string, enterDate: Date,
        exitDate?: Date, containerId?: string, containerNumber?: string, id?: string) {
        this.id = id;
        this.declarationId = declarationId;
        this.declarationNumber = declarationNumber;
        this.vehicleId = vehicleId;
        this.vehicleName = vehicleName;
        this.containerId = containerId;
        this.containerNumber = containerNumber;
        this.enterDate = enterDate;
        this.exitDate = exitDate;
    }
}