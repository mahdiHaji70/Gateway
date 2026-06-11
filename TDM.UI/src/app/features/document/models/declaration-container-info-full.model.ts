export class DeclarationContainerInfoFull {
    id?: string;
    declarationContainerId: string;
    commodityId: string;
    commodityName: string;
    packageId: string;
    packageName: string;    
    packNumber: number;
    weight: number;

    /**
     *
     */
    constructor(declarationContainerId: string, commodityId: string, commodityName: string,packageId: string, packageName: string, packNumber: number, weight: number, id?: string) {
        this.declarationContainerId = declarationContainerId;
        this.commodityId = commodityId;
        this.commodityName = commodityName;
        this.packageId = packageId;
        this.packageName = packageName;
        this.packNumber = packNumber;
        this.weight = weight;
        this.id = id;
    }
}