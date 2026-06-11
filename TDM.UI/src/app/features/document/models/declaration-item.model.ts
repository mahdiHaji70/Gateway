export class DeclarationItem{
    id?: string;
    declarationId: string;
    cargoTypeId: number;
    commodityId: string;
    packNumber: number;
    weight: number;
    volume: number;
    packageId: string;
    trafficId: string;
    shipMark: string;

    /**
     *
     */
    constructor(declarationId: string, cargoTypeId: number, commodityId: string, packNumber: number, weight: number, volume: number,
         packageId: string, trafficId: string, shipMark: string, id?: string) {

            this.declarationId = declarationId;
            this.cargoTypeId = cargoTypeId;
            this.commodityId = commodityId;
            this.packNumber = packNumber;
            this.weight = weight;
            this.volume = volume;
            this.packageId = packageId;
            this.trafficId = trafficId;
            this.shipMark = shipMark;
            this.id = id;
    }
}