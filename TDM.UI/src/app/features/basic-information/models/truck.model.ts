export class Truck{
id?: string;
leftSide: string;
charecter: string;
rightSide: string;
serial: string;
    /**
     *
     */
    constructor(leftSide: string, charecter: string, rightSide: string, serial: string, id?: string) {
        this.id = id;
        this.leftSide = leftSide;
        this.charecter = charecter;
        this.rightSide = rightSide;
        this.serial = serial;
    }
}