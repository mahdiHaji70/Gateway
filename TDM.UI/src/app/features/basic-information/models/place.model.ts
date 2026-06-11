import { PlaceTypes } from "../../../shared/constants/place-types";

export class Place {
    id?: string;
    placeType: PlaceTypes;
    placeName: string;
    capacity: number;
    area: number;
    isOwner: boolean;
    contactId: string; 

    constructor(
        placeType: PlaceTypes,
        placeName: string,
        capacity: number,
        area: number,
        isOwner: boolean,
        contactId: string,
        id?: string
    ) {
        this.id = id;
        this.placeType = placeType;
        this.placeName = placeName;
        this.capacity = capacity;
        this.area = area;
        this.isOwner = isOwner;
        this.contactId = contactId;
    }
}