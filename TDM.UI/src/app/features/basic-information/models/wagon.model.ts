export class Wagon{
    id?: string;
    code: string;

    /**
     *
     */
    constructor(code: string, id?: string) {
        this.id = id;
        this.code = code;
    }
}