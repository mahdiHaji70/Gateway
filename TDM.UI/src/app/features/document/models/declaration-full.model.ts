export class DeclarationFull {
    id?: string;
    number: string;
    date: Date;
    startDate: Date;
    endDate: Date;
    trafficId: string;
    trafficName: string;
    contactId: string;
    contactName: string;
    description: string;
    contactRepId?: string
    contactRepName?: string
    ipasDeclarationId?: string;
    /**
     *
     */
    constructor(id: string, number: string, date: Date, startDate: Date, endDate: Date,
        trafficId: string, trafficName: string, contactId: string, contactName: string,
        description: string, ipasDeclarationId?: string,contactRepId?: string, contactRepName?: string) {
        this.id = id;
        this.number = number;
        this.date = date;
        this.startDate = startDate;
        this.endDate = endDate;
        this.trafficId = trafficId;
        this.trafficName = trafficName;
        this.contactId = contactId;
        this.contactName = contactName;
        this.description = description;
        this.contactRepId = contactRepId;
        this.contactRepName = contactRepName;
        this.ipasDeclarationId = ipasDeclarationId;
    }
}