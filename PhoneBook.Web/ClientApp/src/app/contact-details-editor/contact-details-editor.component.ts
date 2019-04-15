import { Component, Input, Output, EventEmitter, OnInit } from "@angular/core";
import { ContactDetails } from "../models/contact";
import { FormGroup, FormBuilder, FormArray } from "@angular/forms";

@Component({
    selector: 'contact-details-editor',
    templateUrl: './contact-details-editor.component.html',
    styleUrls: ['./contact-details-editor.component.css']
  })
export class ContactDetailsEditor implements OnInit {

  @Input() contact?: ContactDetails;
  @Output() wantsToFinishEditing = new EventEmitter<ContactDetails>();

  form: FormGroup
  
  constructor(private fb: FormBuilder){}

  ngOnInit() {
    const {contact, fb} = this
    this.form = fb.group({
      firstName: contact ? contact.firstName : '',
      lastName: contact ? contact.lastName : '',
      emails: fb.array(
        contact.emails.map(e => fb.control(e))
      ),
      tags: fb.array(
        contact.tags.map(e => fb.control(e))
      ),
      phoneNumbers: fb.array(
        contact.phoneNumbers.map(e => fb.control(e))
      )
    });
  }

  extractInput(){
    const {form} = this;
    return {
      firstName: form.get("firstName").value as string,
      lastName: form.get("lastName").value as string,
      emails: (form.get("emails") as FormArray).controls.map(e => e.value as string),
      tags: (form.get("tags") as FormArray).controls.map(e => e.value as string),
      phoneNumbers: (form.get("phoneNumbers") as FormArray).controls.map(e => e.value as number)
    }
  }

  triggerWantsToFinishEditing(){
    const input = this.extractInput();
    this.wantsToFinishEditing.emit({...input, id: this.contact.id});
  }

  addArrayItem(arrayName: string){
    const array = this.form.get(arrayName) as FormArray;
    array.push(this.fb.control(''));
  }
}