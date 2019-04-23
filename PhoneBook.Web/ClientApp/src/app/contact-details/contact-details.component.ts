import { Component, OnInit } from '@angular/core';
import { ContactDetails } from '../models/contact';
import { ContactService } from '../contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactDetailsEditorMode } from '../contact-details-editor/contact-details-editor.component';

@Component({
  selector: 'contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {

  contact: ContactDetails;
  loading = true
  mode: ContactDetailsEditorMode = ContactDetailsEditorMode.Readonly;

  constructor(private contactService: ContactService, private route: ActivatedRoute, private router: Router){}
  
  ngOnInit(): void {
    const contactId = +this.route.snapshot.paramMap.get("id");
    this.contactService.getDetails(contactId).subscribe(r => {
      this.loading = false;
      return this.contact = r;
    }, console.error);
  }

  wantsToFinishEditing(data: ContactDetails){
    this.contactService.update(data)
      .subscribe(r => this.router.navigateByUrl("/contacts"), console.error)    
  }

  wantsToEdit(){
    this.mode = ContactDetailsEditorMode.Edit;
  }
}