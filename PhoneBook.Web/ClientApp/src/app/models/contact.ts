import { Address } from "./index";

export interface ContactDetails {
    id: number
    firstName: string
    lastName: string
    address: Address
    phoneNumbers: number[]
    emails: string[]
}

export interface ContactListItem {
    id: number
    firstName: string
    lastName: string    
}