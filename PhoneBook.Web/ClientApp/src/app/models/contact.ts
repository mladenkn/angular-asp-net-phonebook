export interface ContactDetails {
    id: number
    firstName: string
    lastName: string
    tags: {id: number, value: string}[]
    phoneNumbers: {id: number, value: number}[]
    emails: {id: number, value: string}[]
}

export interface ContactListItem {
    id: number
    firstName: string
    lastName: string
    tags: string[] 
}