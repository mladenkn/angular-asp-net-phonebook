import { Address } from "./index";

export interface ContactDetails {
    firstName: string,
    lastName: string,
    address: Address,
    phoneNumbers: number[],
    emails: string[]
}