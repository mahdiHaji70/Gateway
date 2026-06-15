import { DeclarationContainerInfoFull } from "./declaration-container-info-full.model";

export class DeclarationContainerFull {
    id?: string;
    declarationItemId: string;
    containerId: string;
    containerName: string;
    isFull: boolean;
    weight: number;
    declarationContainerInfos?: DeclarationContainerInfoFull[];
    /**
     *
     */
    constructor(declarationItemId: string, containerId: string, containerName: string, isFull: boolean, weight: number, id?: string) {
        this.declarationItemId = declarationItemId;
        this.containerId = containerId;
        this.containerName = containerName;
        this.isFull = isFull;
        this.weight = weight;
        this.id = id;
    }
}