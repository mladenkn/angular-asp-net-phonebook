import { Component, OnInit } from '@angular/core';
import { ContactDetails } from '../models/contact';
import { ContactService } from '../contact.service';
import { ActivatedRoute } from '@angular/router';
import { ContactDetailsEditorMode } from '../contact-details-editor/contact-details-editor.component';

@Component({
  selector: 'contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {

  contact: ContactDetails;
  mode: ContactDetailsEditorMode = ContactDetailsEditorMode.Readonly;

  constructor(private contactService: ContactService, private route: ActivatedRoute){}
  
  ngOnInit(): void {
    const contactId = +this.route.snapshot.paramMap.get("id");
    this.contactService.getDetails(contactId).subscribe(r => this.contact = r, console.error);
  }

  wantsToFinishEditing(data: ContactDetails){
    console.log(data)
    this.contactService.update(data)
      .subscribe(r => console.log('Contact updated'), console.error)
  }

  wantsToEdit(){
    this.mode = ContactDetailsEditorMode.Edit
  }
}