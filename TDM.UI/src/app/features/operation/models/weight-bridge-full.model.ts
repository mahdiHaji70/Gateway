export class WeightBridgeFull {
    id?: string; 
    declarationId: string; 
    declarationNumber: string;
    gateEventId: string;
    vehicleId: string; 
    vehicleName: string;
    grossWeight?: number; 
    tareWeight?: number; 
    startDate?: Date; 
    endDate?: Date;

    constructor(
        declarationId: string,
        declarationNumber: string,
        gateEventId: string,
        vehicleId: string,
        vehicleName: string,
        grossWeight?: number,
        tareWeight?: number,
        startDate?: Date,
        endDate?: Date,
        id?: string
    ) {
        this.id = id;
        this.declarationId = declarationId;
        this.declarationNumber = declarationNumber;
        this.gateEventId = gateEventId;
        this.vehicleId = vehicleId;
        this.vehicleName = vehicleName;
        this.grossWeight = grossWeight;
        this.tareWeight = tareWeight;
        this.startDate = startDate;
        this.endDate = endDate;
    }
}