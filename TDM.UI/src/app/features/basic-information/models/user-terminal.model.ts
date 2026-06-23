export class UserTerminal{
id?: string;
userNationalId: string;
terminalId: string;

    /**
     *
     */
    constructor(userNationalId: string, terminalId: string, id?: string) {
        this.id = id;
        this.userNationalId = userNationalId;
        this.terminalId = terminalId;
        
    }
}