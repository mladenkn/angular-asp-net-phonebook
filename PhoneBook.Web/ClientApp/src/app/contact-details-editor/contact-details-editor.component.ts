import { Component, Input, Output, EventEmitter, OnInit } from "@angular/core";
import { ContactDetails } from "../models/contact";
import { FormGroup, FormBuilder, FormArray } from "@angular/forms";

@Component({
    selector: 'contact-details-editor',
    templateUrl: './contact-details-editor.component.html',
    styleUrls: ['./contact-details-editor.component.css']
  })
export class ContactDetailsEditor implements OnInit {

  @Input() contact: ContactDetails;
  @Output() wantsToFinishEditing = new EventEmitter<ContactDetails>();

  form: FormGroup
  
  constructor(private fb: FormBuilder){}

  ngOnInit() {
    const {contact, fb} = this
    this.form = fb.group({
      firstName: contact.firstName,
      lastName: contact.lastName,
      emails: contact.emails.join(',\n')
    });
  }

  triggerWantsToFinishEditing(){
    const emailsString = this.form.get('emails').value as string
    const emailsArray = emailsString.split(",\n")
    console.log(emailsArray)
  }
}