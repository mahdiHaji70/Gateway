export class Container {
    id?: string;
    no?: string;
    containerTypeAndSizeId?: string;

    /**
     *
     */
    constructor(no: string, containerTypeAndSizeId: string, id?: string) {
        this.id = id;
        this.no = no;
        this.containerTypeAndSizeId = containerTypeAndSizeId;
    }
}


export class ContainerDto {
    id?: string;
    containerNo?: string;
    containerTypeAndSizeId?: string;
    containerTypeAndSizeCode?: string;
    containerTypeAndSize?: string;
    containerSizeId?: string;
    containerSizeCode?: string;
    containerSizeName?: string;
    weight?: number;

    /**
     *
     */
    constructor(containerNo: string, containerTypeAndSizeId: string, containerTypeAndSizeCode: string,containerTypeAndSize: string, id?: string) {
        this.id = id;
        this.containerNo = containerNo;
        this.containerTypeAndSizeId = containerTypeAndSizeId;
        this.containerTypeAndSizeCode = containerTypeAndSizeCode;        
        this.containerTypeAndSize = containerTypeAndSize;        
    }
}