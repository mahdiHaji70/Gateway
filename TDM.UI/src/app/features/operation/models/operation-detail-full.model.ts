export class OperationDetailFull {
    id?: string;
    declarationId: string;
    declarationNumber: string;
    vehicleId: string;
    vehicleName: string;
    placeId: string;
    placeName: string;
    packNumber: number;
    weight: number;
    volume?: number; 
    containerId?: string; 
    containerNumber?: string; 
    operationDate: Date;
    operationTypeId: string;
    operationTypeName: string;
    storeReceiptId?: string; 
    storeReceiptSerial?: string; 
    travelId?: string; 
    travelNumber?: string; 

    constructor(        
        declarationId: string,
        declarationNumber: string,
        vehicleId: string,
        vehicleName: string,
        placeId: string,
        placeName: string,
        packNumber: number,
        weight: number,
        operationDate: Date,
        operationTypeId: string,
        operationTypeName: string,
        volume?: number,
        containerId?: string,
        containerNumber?: string,
        storeReceiptId?: string,
        storeReceiptSerial?: string,
        travelId?: string,
        travelNumber?: string,
        id?: string
    ) {
        this.id = id;
        this.declarationId = declarationId;
        this.declarationNumber = declarationNumber;
        this.vehicleId = vehicleId;
        this.vehicleName = vehicleName;
        this.placeId = placeId;
        this.placeName = placeName;
        this.packNumber = packNumber;
        this.weight = weight;
        this.volume = volume;
        this.containerId = containerId;
        this.containerNumber = containerNumber;
        this.operationDate = operationDate;
        this.operationTypeId = operationTypeId;
        this.operationTypeName = operationTypeName;
        this.storeReceiptId = storeReceiptId;
        this.storeReceiptSerial = storeReceiptSerial;
        this.travelId = travelId;
        this.travelNumber = travelNumber;
    }
}