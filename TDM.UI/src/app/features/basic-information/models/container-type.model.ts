export class ContainerType{
    id?: string;
    code?: string;
    name?: string;

    /**
     *
     */
    constructor(code: string, name: string, id?: string) {
        this.id = id;
        this.code = code;
        this.name = name;
    }
}