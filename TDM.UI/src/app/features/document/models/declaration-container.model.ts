export class DeclarationContainer {
    id?: string;
    declarationItemId: string;
    containerId: string;
    isFull: boolean;
    weight: number;

    /**
     *
     */
    constructor(declarationItemId: string, containerId: string, isFull: boolean, weight: number, id?: string) {
        this.declarationItemId = declarationItemId;
        this.containerId = containerId;
        this.isFull = isFull;
        this.weight = weight;
    }
}