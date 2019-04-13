import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { ContactDetails } from "./models/contact";

export class ContactService {

    private baseUrl: string

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string){
        this.baseUrl = baseUrl + "Contacts/"        
    }

    getDetails(contactId: number){
        return this.http.get<ContactDetails>(this.baseUrl + "Details/" + contactId)
    }

    getList(){

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

// http.put(baseUrl + "Contacts/Put", null, {
//   params: {
//     id: '1',
//     firstName: "sdfsdf",
//     emails: ["mail1", "mail2"],
//   }
// })
// .subscribe(console.log, console.error);

// http.post<ContactListItem[]>(baseUrl + 'Contacts/List', null, {
//     params: {
      
//     }
//   })
//     .subscribe(r => this.contacts = r, console.error);