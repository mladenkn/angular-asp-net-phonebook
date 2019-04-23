import { Component, OnInit } from '@angular/core';
import { ContactListItem, GetContactsRequest } from '../models/contact';
import { ContactService } from '../contact.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  contacts: ContactListItem[]

  constructor(private contactService: ContactService){}

  ngOnInit(){
    this.contactService.getList().subscribe(r => this.contacts = r);
  }

  requery(request: GetContactsRequest){
    this.contacts = null
    this.contactService.getList(request).subscribe(r => this.contacts = r);
  }
}