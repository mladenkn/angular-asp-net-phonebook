import { Component, Input } from '@angular/core';
import { ContactListItem } from '../models/contact';
import { ContactService } from '../contact.service';

@Component({
  selector: 'contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.css']
})
export class ContactsListComponent {
  @Input() contacts: ContactListItem[]

  constructor(private contactService: ContactService){}

  wantsToDelete(contactId: number){
    this.contactService.delete(contactId)
      .subscribe(_ => this.contacts = this.contacts.filter(c => c.id != contactId), console.error)
  }
}
