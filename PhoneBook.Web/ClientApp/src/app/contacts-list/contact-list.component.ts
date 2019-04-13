import { Component } from '@angular/core';
import { ContactListItem } from '../models/contact';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent {

  contacts: ContactListItem[]

  constructor(contactService: ContactService){
    
  }

  showContactDetails(){
    
  }
}