import { ContactTypes } from "../../../shared/constants/contact-types";

export class ContactList {
     id?: string;
    companyType?: string;
    name?: string;
    nationalId?: string;
    registerDate?: string;
    address?: string;
    postCode?: string;
    mobile?: string;
    economicCode?: string;
    registerNumber?: string;
    registerPlace?: string;
    phone?: string;

    /**
     *
     */
     constructor(companyType: string, name: string, nationalId: string,
        registerDate: string,
        address: string,
        postCode: string,
        mobile: string,
        economicCode: string,
        registerNumber: string,
        registerPlace: string,
        phone: string,
        id?: string) {
        this.companyType = companyType;
        this.name = name;
        this.nationalId = nationalId;
        this.registerDate = registerDate;
        this.address = address;
        this.postCode = postCode;
        this.mobile = mobile;
        this.economicCode = economicCode;
        this.registerNumber = registerNumber;
        this.registerPlace = registerPlace;
        this.phone = phone;
        this.id = id;
    }
}