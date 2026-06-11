export class Commodity {
    id?: string;
    name?: string;
    hsCode?: string;

    /**
     *
     */
    constructor(name: string, hsCode: string, id?: string) {
        this.id = id;
        this.name = name;
        this.hsCode = hsCode;
    }
}