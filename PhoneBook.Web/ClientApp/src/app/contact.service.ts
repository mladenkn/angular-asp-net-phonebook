import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { ContactDetails, ContactListItem } from "./models/contact";

@Injectable({providedIn: "root"})
export class ContactService {

    private baseUrl: string

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string){
        this.baseUrl = baseUrl + "Contacts/"        
    }

    getDetails(contactId: number){
        return this.http.get<ContactDetails>(this.baseUrl + "Details/" + contactId)
    }

    getList(){
        return this.http.post<ContactListItem[]>(this.baseUrl + 'List', null, {
            params: {
                firstNameSearchString: "mla",
                lastNameSearchString: "knez",
                contactMustContainAllTags: ["tag1", "tag2"],
                contactMustContainSomeTags: ["tag1", "tag3"],
            }
        })
    }

    update(contact: ContactDetails){
        return this.http.put(this.baseUrl + "Put", null, {params: contact as any})
    }
}
    
// http.get<ContactDetails>(baseUrl + "Contacts/Details/1")
//   .subscribe(console.log, console.error)

// http.post<ContactListItem[]>(baseUrl + 'Contacts/List', null, {
//   params: {
//     firstNameSearchString: "mla",
//     lastNameSearchString: "knez",
//     contactMustContainAllTags: ["tag1", "tag2"],
//     contactMustContainSomeTags: ["tag1", "tag3"],
//   }
// })
//   .subscribe(console.log, console.error);
    
// http.delete(baseUrl + 'Contacts/Delete/1')
//   .subscribe(console.log, console.error);     

// http.post(baseUrl + "Contacts/Post", null, {
//   params: {
//     firstName: "sdfsdf",
//     emails: ["mail1", "mail2"]
//   }
// }) 
// .subscribe(console.log, console.error);

// http.post<ContactListItem[]>(baseUrl + 'Contacts/List', null, {
//     params: {
      
//     }
//   })
//     .subscribe(r => this.contacts = r, console.error);