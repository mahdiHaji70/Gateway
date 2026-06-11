import { PlaceTypes } from "../../../shared/constants/place-types";

export class PlaceFull {
    id?: string;
    placeType: string;
    placeName: string;
    capacity: number;
    area: number;
    isOwner: boolean;
    contactId: string; 
    contactName: string; 

    constructor(
        placeType: string,
        placeName: string,
        capacity: number,
        area: number,
        isOwner: boolean,
        contactId: string,
        contactName: string,
        id?: string
    ) {
        this.id = id;
        this.placeType = placeType;
        this.placeName = placeName;
        this.capacity = capacity;
        this.area = area;
        this.isOwner = isOwner;
        this.contactId = contactId;
        this.contactName = contactName;
    }
}