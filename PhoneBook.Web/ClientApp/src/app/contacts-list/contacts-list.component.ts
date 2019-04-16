import { Component, Input } from '@angular/core';
import { ContactListItem } from '../models/contact';

@Component({
  selector: 'contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.css']
})
export class ContactsListComponent {
  @Input() contacts: ContactListItem[]
}
