export interface Contact {
    firstName: string,
    lastName: string,
    address: Address,
    phoneNumbers: number[],
    emails: string[]
}

export interface Address {
    street: string,
    houseNumber: number
}