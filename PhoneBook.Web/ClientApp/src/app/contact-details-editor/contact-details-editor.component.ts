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
  
  constructor(private fb: FormBuilder){
    this.getArray = this.getArray.bind(this)
  }

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
        contact.phoneNumbers.map(e => fb.control(e.toString()))
      )
    });
  }

  extractInput(){
    const {form, getArray} = this;
    return {
      firstName: form.get("firstName").value as string,
      lastName: form.get("lastName").value as string,
      emails: getArray("emails").map(e => e.value as string),
      tags: getArray("tags").map(e => e.value as string),
      phoneNumbers: getArray("phoneNumbers").map(e => parseInt(e.value as string))
    }
  }

  getArray(name: string){
    return (this.form.get(name) as FormArray).controls
  }

  pushToArray(arrayName: string){
    this.getArray(arrayName).push(this.fb.control(''))    
  }

  triggerWantsToFinishEditing(){
    const input = this.extractInput();
    this.wantsToFinishEditing.emit({...input, id: this.contact.id});
  }
}