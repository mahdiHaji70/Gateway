export class DeclarationContainerInfo {
    id?: string;
    declarationContainerId: string;
    CommodityId: string;    
    PackageId: string;        
    packNumber: number;
    weight: number;

    /**
     *
     */
    constructor(declarationContainerId: string, CommodityId: string,PackageId: string, packNumber: number, weight: number, id?: string) {
        this.declarationContainerId = declarationContainerId;
        this.CommodityId = CommodityId;        
        this.PackageId = PackageId;        
        this.packNumber = packNumber;
        this.weight = weight;
        this.id = id;
    }
}