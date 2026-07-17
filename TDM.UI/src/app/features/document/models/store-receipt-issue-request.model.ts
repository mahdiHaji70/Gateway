export class StoreReceiptIssueRequest {
    requestId: string;
    date: Date;
    ownerName: string;
    ownerNationalId: string;
    ownerRepName: string;
    ownerRepNationalId: string;
    hsCode: string;
    hsDescription: string;
    PackNb: number;
    weight: number;

    constructor(
        requestId: string,
        date: Date,
        ownerName: string,
        ownerNationalId: string,
        ownerRepName: string,
        ownerRepNationalId: string,
        hsCode: string,
        hsDescription: string,
        packNb: number,
        weight: number
    ) {
        this.requestId = requestId;
        this.date = date;
        this.ownerName = ownerName;
        this.ownerNationalId = ownerNationalId;
        this.ownerRepName = ownerRepName;
        this.ownerRepNationalId = ownerRepNationalId;
        this.hsCode = hsCode;
        this.hsDescription = hsDescription;
        this.PackNb = packNb;
        this.weight = weight;
    }
}
