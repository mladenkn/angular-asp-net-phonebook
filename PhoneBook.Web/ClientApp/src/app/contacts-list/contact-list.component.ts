import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContactListItem, ContactDetails } from '../models/contact';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent {

  contacts: ContactListItem[]
  contactDetails: ContactDetails

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){
    
    http.get<ContactDetails>(baseUrl + "Contacts/Details/1")
      .subscribe(console.log, console.error)

    http.post<ContactListItem[]>(baseUrl + 'Contacts/List', null, {
      params: {
        firstNameSearchString: "mla",
        lastNameSearchString: "knez",
        contactMustContainAllTags: ["tag1", "tag2"],
        contactMustContainSomeTags: ["tag1", "tag3"],
      }
    })
      .subscribe(console.log, console.error);
      
    http.delete(baseUrl + 'Contacts/Delete/1')
      .subscribe(console.log, console.error);     

    http.post(baseUrl + "Contacts/Post", null, {
      params: {
        firstName: "sdfsdf",
        emails: ["mail1", "mail2"]
      }
    }) 
    .subscribe(console.log, console.error);

    http.put(baseUrl + "Contacts/Put", null, {
      params: {
        id: '1',
        firstName: "sdfsdf",
        emails: ["mail1", "mail2"],
      }
    })
    .subscribe(console.log, console.error);

    // http.get<ContactListItem[]>(baseUrl + 'Contacts/List')
    //   .subscribe(r => this.contacts = r, console.error);
  }

  showContactDetails(){
    console.log("adsfsdf")
    this.http.get<ContactDetails>(this.baseUrl + "Contacts/Details/" + 1)
      .subscribe(r => this.contactDetails = r)
  }
}