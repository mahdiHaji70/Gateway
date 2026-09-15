export class ManifestFull {
    id?: string;
    manifestRegistrationNumber: string;
    voyageNo: string;
    noticeNo: string;
    shipAgent: string;
    vesselName: string;
    imo: string;
    manifestNo: string;
    trafficName: string;
    consigneeName: string;
    cargoTypeName: string;
    hsCode: string;
    commodityName: string;
    packageName: string;
    packNb: number;
    grossWeight: number;
    container: string;

    constructor(
        id: string,
        manifestRegistrationNumber: string,
        voyageNo: string,
        noticeNo: string,
        shipAgent: string,
        vesselName: string,
        imo: string,
        manifestNo: string,
        trafficName: string,
        consigneeName: string,
        cargoTypeName: string,
        hsCode: string,
        commodityName: string,
        packageName: string,
        packNb: number,
        grossWeight: number,
        container: string
    ) {
        this.id = id;
        this.manifestRegistrationNumber = manifestRegistrationNumber;
        this.voyageNo = voyageNo;
        this.noticeNo = noticeNo;
        this.shipAgent = shipAgent;
        this.vesselName = vesselName;
        this.imo = imo;
        this.manifestNo = manifestNo;
        this.trafficName = trafficName;
        this.consigneeName = consigneeName;
        this.cargoTypeName = cargoTypeName;
        this.hsCode = hsCode;
        this.commodityName = commodityName;
        this.packageName = packageName;
        this.packNb = packNb;
        this.grossWeight = grossWeight;
        this.container = container;
    }
}
