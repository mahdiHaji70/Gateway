export class Terminal {
    id?: string;
    code: string;
    name: string;
    portCode: string;
    username: string;
    password: string;
    isActive: boolean;

    /**
     *
     */
    constructor(code: string, name: string, portCode: string, username: string, password: string, isActive: boolean, id?: string) {
        this.id = id;
        this.code = code;
        this.name = name;
        this.portCode = portCode;
        this.username = username;
        this.password = password;
        this.isActive = isActive;
    }
}