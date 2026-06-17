export class ContainerTypeAndSize{
    id?: string;
    typeAndSizeCode?: string;
    typeAndSize?: string;

    /**
     *
     */
    constructor(typeAndSizeCode: string, typeAndSize: string, id?: string) {
        this.id = id;
        this.typeAndSizeCode = typeAndSizeCode;
        this.typeAndSize = typeAndSize;
    }
}