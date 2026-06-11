export class DeclarationFull {
    id?: string;
    declarationTypeId: string;
    declarationTypeName: string;
    number: string;
    contactId: string;
    contactName: string;
    contactAgentId?: string
    contactAgentName?: string
    bookingNumber: string;
    terminalId: string;
    terminalName: string;
    originCityId: string;
    originCityName: string;
    destinationCityId: string;
    destinationCityName: string;
    carrierContactId?: string;
    carrierContactName?: string;
    requestStatus: boolean;
    serial: string;
    /**
     *
     */
    constructor(declarationTypeId: string, declarationTypeName: string, number: string, contactId: string, contactName: string, bookingNumber: string, terminalId: string,
        terminalName: string, originCityId: string, originCityName: string, destinationCityId: string, destinationCityName: string, requestStatus: boolean, serial: string,
        contactAgentId?: string, contactAgentName?: string, carrierContactId?: string, carrierContactName?: string, id?: string
    ) {
        this.declarationTypeId = declarationTypeId;
        this.declarationTypeName = declarationTypeName;
        this.number = number;
        this.contactId = contactId;
        this.contactName = contactName;
        this.bookingNumber = bookingNumber;
        this.terminalId = terminalId;
        this.terminalName = terminalName;
        this.originCityId = originCityId;
        this.originCityName = originCityName;
        this.destinationCityId = destinationCityId;
        this.destinationCityName = destinationCityName;
        this.requestStatus = requestStatus;
        this.serial = serial;
        this.id = id;
        this.contactAgentId = contactAgentId;
        this.contactAgentName = contactAgentName;
        this.carrierContactId = carrierContactId;
        this.carrierContactName = carrierContactName;
    }
}