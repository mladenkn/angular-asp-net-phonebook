export interface ContactDetails {
    id: number
    firstName: string
    lastName: string
    tags: string[]
    phoneNumbers: number[]
    emails: string[]
}

export interface ContactListItem {
    id: number
    firstName: string
    lastName: string
    tags: string[] 
}

export interface GetContactsRequest {
    firstNameSearchString: string
    lastNameSearchString: string
    contactMustContainAllTags: string[]
    contactMustContainSomeTags: string[]
}