export class Declaration {
    id?: string;
    declarationTypeId: string;
    number: string;
    contactId: string;
    contactAgentId?: string
    bookingNumber: string;
    terminalId: string;
    originCityId: string;
    destinationCityId: string;
    carrierContactId?: string;
    requestStatus: boolean;
    serial?: string;
    /**
     *
     */
    constructor(declarationTypeId: string, number: string, contactId: string, bookingNumber: string, terminalId: string,
        originCityId: string, destinationCityId: string, requestStatus: boolean, contactAgentId?: string, carrierContactId?: string, id?: string, serial?: string
    ) {
        this.declarationTypeId = declarationTypeId;
        this.number = number;
        this.contactId = contactId;
        this.bookingNumber = bookingNumber;
        this.terminalId = terminalId;
        this.originCityId = originCityId;
        this.destinationCityId = destinationCityId;
        this.requestStatus = requestStatus;
        this.id = id;
        this.contactAgentId = contactAgentId;
        this.carrierContactId = carrierContactId;
        this.serial = serial;
    }
}