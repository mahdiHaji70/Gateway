import { DeclarationContainerInfoFull } from "./declaration-container-info-full.model";

export class DeclarationContainerFull {
    declarationContainerId: string;
    declarationItemId: string;
    containerId: string;
    containerNo: string;
    containerTypeAndSize: string
    declarationContainerInfos?: DeclarationContainerInfoFull[];
    /**
     *
     */
    constructor(declarationContainerId: string, declarationItemId: string, containerId: string, containerNo: string, containerTypeAndSize: string) {
        this.declarationContainerId = declarationContainerId;
        this.declarationItemId = declarationItemId;
        this.containerId = containerId;
        this.containerNo = containerNo;
        this.containerTypeAndSize = containerTypeAndSize;

    }
}