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
  loading: boolean

  constructor(private contactService: ContactService){}

  ngOnInit(){ this.query() }

  requery(request: GetContactsRequest){
    this.query(request)
  }
  
  query(request?: GetContactsRequest){
    this.loading = true;
    this.contactService.getList(request).subscribe(r => {
      this.loading = false;
      this.contacts = r;
    }, console.error);
  }
}