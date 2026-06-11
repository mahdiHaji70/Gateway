export class Container {
    id?: string;
    containerNumber?: string;
    containerTypeId?: string;
    containerSizeId?: string;
    weight?: number;

    /**
     *
     */
    constructor(containerNumber: string, containerTypeId: string, containerSizeId: string, weight: number, id?: string) {
        this.id = id;
        this.containerNumber = containerNumber;
        this.containerTypeId = containerTypeId;
        this.containerSizeId = containerSizeId;
        this.weight = weight;
    }
}


export class ContainerDto {
    id?: string;
    containerNumber?: string;
    containerTypeId?: string;
    containerTypeCode?: string;
    containerTypeName?: string;
    containerSizeId?: string;
    containerSizeCode?: string;
    containerSizeName?: string;
    weight?: number;

    /**
     *
     */
    constructor(containerNumber: string, containerTypeId: string, containerTypeCode: string,containerTypeName: string, containerSizeId: string, 
        containerSizeCode: string,containerSizeName: string, weight: number, id?: string) {
        this.id = id;
        this.containerNumber = containerNumber;
        this.containerTypeId = containerTypeId;
        this.containerTypeCode = containerTypeCode;        
        this.containerTypeName = containerTypeName;        
        this.containerSizeId = containerSizeId;
        this.containerSizeCode = containerSizeCode; 
        this.containerSizeName = containerSizeName; 
        this.weight = weight;
    }
}