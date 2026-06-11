export class OperationDetail {

    id?: string; 
    declarationId: string;
    vehicleId: string;
    placeId: string;
    packNumber: number;
    weight: number;
    volume?: number; 
    containerId?: string; 
    operationDate: Date;
    operationTypeId: string;
    storeReceiptId?: string; 
    travelId?: string; 

    /**
     *
     */
    constructor(declarationId: string,
        vehicleId: string,
        placeId: string,
        packNumber: number,
        weight: number,
        operationDate: Date,
        operationTypeId: string,
        volume?: number,
        containerId?: string,
        storeReceiptId?: string,
        travelId?: string,
        id?: string) {
        this.id = id;
        this.declarationId = declarationId;
        this.vehicleId = vehicleId;
        this.placeId = placeId;
        this.packNumber = packNumber;
        this.weight = weight;
        this.volume = volume;
        this.containerId = containerId;
        this.operationDate = operationDate;
        this.operationTypeId = operationTypeId;
        this.storeReceiptId = storeReceiptId;
        this.travelId = travelId;
    }
}