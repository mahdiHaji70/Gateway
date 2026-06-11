export class Gate {
    id?: string;
    declarationId: string;
    vehicleId: string;
    containerId?: string;
    enterDate: Date;

    /**
     *
     */
    constructor(declarationId: string, vehicleId: string, enterDate: Date,
        containerId?: string, id?: string) {
        this.id = id;
        this.declarationId = declarationId;
        this.vehicleId = vehicleId;
        this.containerId = containerId;
        this.enterDate = enterDate
    }
}