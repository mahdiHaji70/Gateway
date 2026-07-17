export class RequestConfirmation {
    terminalCode: string;
    requestId: string;
    isApproved: boolean;
    description: string;

    constructor(
        terminalCode: string,
        requestId: string,
        isApproved: boolean,
        description: string
    ) {
        this.terminalCode = terminalCode;
        this.requestId = requestId;
        this.isApproved = isApproved;
        this.description = description;
    }
}
