export class StoreFull {
    id?: string;
    storeType: string;
    storeName: string;
    // capacity: number;
    // area: number;
    // isOwner: boolean;
    // contactId: string; 
    // contactName: string; 

    constructor(
        storeType: string,
        storeName: string,
        // capacity: number,
        // area: number,
        // isOwner: boolean,
        // contactId: string,
        // contactName: string,
        id?: string
    ) {
        this.id = id;
        this.storeType = storeType;
        this.storeName = storeName;
        // this.capacity = capacity;
        // this.area = area;
        // this.isOwner = isOwner;
        // this.contactId = contactId;
        // this.contactName = contactName;
    }
}