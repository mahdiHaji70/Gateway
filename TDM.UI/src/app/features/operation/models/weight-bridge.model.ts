export class WeightBridge {
    id?: string; 
    declarationId: string; 
    gateEventId: string;
    vehicleId: string; 
    grossWeight?: number; 
    tareWeight?: number; 
    startDate?: Date; 
    endDate?: Date;

    constructor(        
        declarationId: string,
        gateEventId: string,
        vehicleId: string,
        grossWeight?: number,
        tareWeight?: number,
        startDate?: Date,
        endDate?: Date,
        id?: string
    ) {
        this.id = id;
        this.declarationId = declarationId;
        this.gateEventId = gateEventId;
        this.vehicleId = vehicleId;
        this.grossWeight = grossWeight;
        this.tareWeight = tareWeight;
        this.startDate = startDate;
        this.endDate = endDate;
        this.id = id;
    }
}