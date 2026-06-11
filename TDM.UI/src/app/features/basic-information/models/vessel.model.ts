export class Vessel {
    id?: string;
    name: string;
    imoNumber: string;
    storeCount: number;
    grt: number;

    /**
     *
     */
    constructor(name: string, imoNumber: string, storeCount: number, grt: number, id?: string) {
        this.id = id;
        this.name = name;
        this.imoNumber = imoNumber;
        this.storeCount = storeCount;
        this.grt = grt;
    }
}