export class DeclarationItemFull {
    id?: string;
    declarationId: string;
    declarationNumber: string;
    commodityId: string;
    commodityName: string;
    packNumber: number;
    grossWeight: number;
    netWeight: number;
    packageId: string;
    packageName: string;

    /**
     *
     */
    constructor(id: string, declarationId: string, declarationNumber: string, commodityId: string,
         commodityName: string, packNumber: number, grossWeight: number,netWeight: number, 
         packageId: string, packageName: string) {
        this.id = id;
        this.declarationId = declarationId;
        this.declarationNumber = declarationNumber;
        this.commodityId = commodityId;
        this.commodityName = commodityName;
        this.packNumber = packNumber;
        this.grossWeight = grossWeight;
        this.netWeight = netWeight;
        this.packageId = packageId;
        this.packageName = packageName;
    }
}