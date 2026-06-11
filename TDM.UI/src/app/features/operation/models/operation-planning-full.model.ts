export class OperationPlanningFull {
    id?: string;
    declarationId: string;
    declarationNumber: string;
    staffId: string;
    staffName: string;
    equipmentId: string;
    equipmentName: string;
    equipmentTypeId: string;
    equipmentTypeName: string;
    shiftId: string;
    shiftName: string;
    placeId: string;
    placeName: string;
    date: Date;

    constructor(
        declarationId: string,
        declarationNumber: string,
        staffId: string,
        staffName: string,
        equipmentId: string,
        equipmentName: string,
        equipmentTypeId: string,
        equipmentTypeName: string,
        shiftId: string,
        shiftName: string,
        placeId: string,
        placeName: string,
        date: Date,
        id?: string
    ) {
        this.id = id;
        this.declarationId = declarationId;
        this.declarationNumber = declarationNumber;
        this.staffId = staffId;
        this.staffName = staffName;
        this.equipmentId = equipmentId;
        this.equipmentName = equipmentName;
        this.equipmentTypeId = equipmentTypeId;
        this.equipmentTypeName = equipmentTypeName;
        this.shiftId = shiftId;
        this.shiftName = shiftName;
        this.placeId = placeId;
        this.placeName = placeName;
        this.date = date;
    }
}