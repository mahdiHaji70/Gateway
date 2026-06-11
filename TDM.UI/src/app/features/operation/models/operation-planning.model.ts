export class OperationPlanning {
    id?: string;
    declarationId: string;    
    staffId: string;
    equipmentId: string;
    shiftId: string;
    placeId: string;
    date: Date;

    constructor(
        declarationId: string,
        staffId: string,
        equipmentId: string,        
        shiftId: string,
        placeId: string,
        date: Date,
        id?: string
    ) {
        this.id = id;
        this.declarationId = declarationId;
        this.staffId = staffId;
        this.equipmentId = equipmentId;
        this.shiftId = shiftId;
        this.placeId = placeId;
        this.date = date;
    }
}