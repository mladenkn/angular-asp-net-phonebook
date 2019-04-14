import { Component, OnInit } from '@angular/core';
import { ContactListItem } from '../models/contact';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {

  contacts: ContactListItem[]

  constructor(private contactService: ContactService){}

  ngOnInit(){
    this.contactService.getList().subscribe(r => this.contacts = r)
  }
}