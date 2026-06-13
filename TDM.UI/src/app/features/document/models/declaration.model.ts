export class Declaration {
    id?: string;
    number: string;
    date: string;
    startDate: string;
    endDate: string;
    consigneeId: string;
    consigneeRepId?: string
    trafficId: string;
    terminalCode: string;
    description: string;

    /**
     *
     */
    constructor(number: string,date: string,startDate: string,endDate: string, consigneeId: string, 
         trafficId: string ,terminalCode: string, description: string,consigneeRepId?: string, id?: string) {
        this.number = number;
        this.date = date;
        this.startDate = startDate;
        this.endDate = endDate;
        this.consigneeId = consigneeId;
        this.consigneeRepId = consigneeRepId;
        this.trafficId = trafficId;
        this.terminalCode = terminalCode;
        this.description = description;
        this.id = id;
    }
}