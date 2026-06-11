import { CreateStuff } from "./create-stuff.model";

export class StuffAggregation {
    declarationId?: string;
    newPackNb?: number;
    newWeight?: number;
    packageId?: string;
    stuffDto: CreateStuff;

    /**
     *
     */
    constructor() {
        this.stuffDto = new CreateStuff();        
    }
}
