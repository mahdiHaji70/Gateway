export class OperationAggregationList{
    declarationId: string;
    number: string;
    lastDate: string

    /**
     *
     */
    constructor(declarationId: string, number: string, lastDate: string) {
        this.declarationId = declarationId;
        this.number = number;
        this.lastDate = lastDate;
    }
}