export class User{
id?: string;
name: string;
nationalId: string;

    /**
     *
     */
    constructor(name: string, nationalId: string, id?: string) {
        this.id = id;
        this.name = name;
        this.nationalId = nationalId;
        
    }
}