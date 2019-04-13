import { Component, Input} from '@angular/core';
import { ContactDetails } from '../models/contact';
import { ContactService } from '../contact.service';

@Component({
  selector: 'contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent {

  @Input() contactId: number
  contact: ContactDetails

  constructor(contactService: ContactService){
    contactService.getDetails(this.contactId).subscribe(r => this.contact = r, console.error)
  }
}