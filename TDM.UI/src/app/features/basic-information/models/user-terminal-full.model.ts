export class UserTerminalFull {
    id?: string;
    userNationalId: string;
    terminalId: string;
    terminalName: string;
    terminalCode: string;
    /**
     *
     */
    constructor(userNationalId: string, terminalId: string, terminalName: string, terminalCode: string, id?: string) {
        this.id = id;
        this.userNationalId = userNationalId;
        this.terminalId = terminalId;
        this.terminalName = terminalName;
        this.terminalCode = terminalCode;

    }
}