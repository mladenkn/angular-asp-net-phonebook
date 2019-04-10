import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contact } from '../models';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent {

  contacts: Contact[]

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string){
    http.get<Contact[]>(baseUrl + 'Contacts/Get').subscribe(result => {
      console.log(result)
      this.contacts = result;
    }, console.error);
  }
}