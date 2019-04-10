import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contact } from '../models';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactsComponent {

  contacts: Contact[]

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string){
    http.get<Contact[]>(baseUrl + 'Contacts/Get').subscribe(result => {
      this.contacts = result;
    }, console.error);
  }
}