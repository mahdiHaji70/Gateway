export class City {
    id?: string;
    countryId: string;
    code?: string;
    name?: string;

    /**
     *
     */
    constructor(countryId: string, code: string, name: string, id?: string) {
        this.id = id;
        this.countryId = countryId;
        this.code = code;
        this.name = name;
    }
}

export class CityDto {
    id?: string;
    countryId: string;
    code?: string;
    name?: string;
    countryCode?: string;
    countryName?: string;
    /**
     *
     */
    constructor(code: string, name: string, countryCode: string, countryName: string, countryId: string, id?: string) {
        this.id = id;
        this.code = code;
        this.name = name;
        this.countryCode = countryCode;
        this.countryName = countryName;
        this.countryId = countryId;
    }
}

