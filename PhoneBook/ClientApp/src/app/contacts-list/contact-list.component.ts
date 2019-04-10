import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContactDetails } from '../models/contact';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent {

  contacts: ContactDetails[]

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string){
    http.get<ContactDetails[]>(baseUrl + 'Contacts/Get').subscribe(
      result => this.contacts = result, console.error);
  }
}