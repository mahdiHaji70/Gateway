export class ExitGate {
    id?: string;
    exitDate: Date;

    /**
     *
     */
    constructor(exitDate: Date, id?: string) {
        this.id = id;
        this.exitDate = exitDate;
    }
}