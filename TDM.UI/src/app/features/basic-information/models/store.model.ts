import { StoreTypes } from "../../../shared/constants/store-types";

export class Store {
    id?: string;
    storeTypeId: string;
    name: string;
    // capacity: number;
    // area: number;
    // isOwner: boolean;
    // contactId: string; 

    constructor(
        storeTypeId: string,
        name: string,
        // capacity: number,
        // area: number,
        // isOwner: boolean,
        // contactId: string,
        id?: string
    ) {
        this.id = id;
        this.storeTypeId = storeTypeId;
        this.name = name;
        // this.capacity = capacity;
        // this.area = area;
        // this.isOwner = isOwner;
        // this.contactId = contactId;
    }
}