import { Component, OnInit } from '@angular/core';
import { ContactDetails } from '../models/contact';
import { ContactService } from '../contact.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {

  contact: ContactDetails
  mode: "readonly" | "edit" = "readonly"

  constructor(private contactService: ContactService, private route: ActivatedRoute){}
  
  ngOnInit(): void {
    const contactId = +this.route.snapshot.paramMap.get("id");
    this.contactService.getDetails(contactId).subscribe(r => this.contact = r, console.error);
  }

  wantsToEdit(){
    this.mode = "edit"
  }

  wantsToFinishEditing(){
    console.log("završava editiranje")
    this.mode = "readonly"
  }
}