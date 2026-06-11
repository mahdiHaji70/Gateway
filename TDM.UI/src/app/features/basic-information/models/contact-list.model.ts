import { ContactTypes } from "../../../shared/constants/contact-types";

export class ContactList {
    id?: string;
    contactType?: string;
    name?: string;
    nationalCode?: string;
    certificateNumber?: string;
    economicCode?: string;
    registrationDate?: Date;
    registrationPlace?: string;
    postalCode?: string;
    mobile?: string;
    phone?: string;
    address?: string;
    commerceCardCode?: string;
    email?: string;

    /**
     *
     */
    constructor(contactType: string, name: string, nationalCode: string,
        certificateNumber: string,
        economicCode: string,
        registrationDate: Date,
        registrationPlace: string,
        postalCode: string,
        mobile: string,
        phone: string,
        address: string,
        commerceCardCode: string,
        email: string,
        id?: string) {
        this.contactType = contactType;
        this.name = name;
        this.nationalCode = nationalCode;
        this.certificateNumber = certificateNumber;
        this.economicCode = economicCode;
        this.registrationDate = registrationDate;
        this.registrationPlace = registrationPlace;
        this.postalCode = postalCode;
        this.mobile = mobile;
        this.phone = phone;
        this.address = address;
        this.commerceCardCode = commerceCardCode;
        this.email = email;
        this.id = id;
    }
}