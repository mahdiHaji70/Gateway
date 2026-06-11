export class DeclarationItemFull{
    id?: string;
    declarationId: string;
    cargoType: number;
    cargoTypeName: string;
    commodityId: string;
    commodityName: string;
    packNumber: number;
    weight: number;
    volume: number;
    packageId: string;
    packageName: string;
    trafficId: string;
    trafficName: string;
    shipMark: string;

    /**
     *
     */
    constructor(declarationId: string, cargoType: number, cargoTypeName: string, commodityId: string, commodityName: string, packNumber: number, weight: number,
         volume: number, packageId: string, packageName: string, trafficId: string, trafficName: string, shipMark: string, id?: string) {

            this.declarationId = declarationId;
            this.cargoType = cargoType;
            this.cargoTypeName = cargoTypeName;
            this.commodityId = commodityId;
            this.commodityName = commodityName;
            this.packNumber = packNumber;
            this.weight = weight;
            this.volume = volume;
            this.packageId = packageId;
            this.packageName = packageName;
            this.trafficId = trafficId;
            this.trafficName = trafficName;
            this.shipMark = shipMark;
            this.id = id;
    }
}