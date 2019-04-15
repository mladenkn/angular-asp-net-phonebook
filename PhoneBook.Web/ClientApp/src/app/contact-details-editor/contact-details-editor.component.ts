import { Component, Input, Output, EventEmitter, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, FormArray } from "@angular/forms";
import { MatChipInputEvent } from "@angular/material";
import {COMMA, ENTER} from '@angular/cdk/keycodes';

import { ContactDetails } from "../models/contact";

export enum ContactDetailsEditorMode {
  Readonly="Readonly", Edit="Edit"
}

@Component({
    selector: 'contact-details-editor',
    templateUrl: './contact-details-editor.component.html',
    styleUrls: ['./contact-details-editor.component.css']
  })
export class ContactDetailsEditorComponent implements OnInit {

  @Input() readonly contact?: ContactDetails;
  @Input() readonly mode: ContactDetailsEditorMode

  @Output() readonly wantsToFinishEditing = new EventEmitter<ContactDetails>();
  @Output() readonly wantsToEdit = new EventEmitter<void>();

  form: FormGroup
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  editedContact: ContactDetails
  
  constructor(private fb: FormBuilder){}

  ngOnInit() {
    // const {contact, fb} = this
    // this.form = fb.group({
    //   firstName: contact ? contact.firstName : '',
    //   lastName: contact ? contact.lastName : '',
    //   emails: fb.array(
    //     (contact ? contact.emails: []).map(e => fb.control(e))
    //   ),
    //   tags: fb.array(
    //     (contact ? contact.tags: []).map(e => fb.control(e))
    //   ),
    //   phoneNumbers: fb.array(
    //     (contact ? contact.phoneNumbers: []).map(e => fb.control(e.toString()))
    //   )
    // });
    this.editedContact = JSON.parse(JSON.stringify(this.contact))
  }

  // extractInput(){
  //   return {
  //     firstName: this.form.get("firstName").value as string,
  //     lastName: this.form.get("lastName").value as string,
  //     tags: this.tags.map(e => e.value as {id: number; value: string}),
  //     emails: this.emails.map(e => e.value as {id: number; value: string}),
  //     phoneNumbers: this.phoneNumbers
  //       .map(e => ({id: e.value.id as number, value: parseInt(e.value as string)}))
  //   }
  // }

  // getArray(name: string){
  //   return (this.form.get(name) as FormArray);
  // }

  // get tags(){
  //   return this.getArray("tags").controls
  // }

  // get emails(){
  //   return this.getArray("emails").controls
  // }

  // get phoneNumbers(){
  //   return this.getArray("phoneNumbers").controls
  // }

  // addEmail(value: string){
  //   this.getArray('email').push(this.fb.control({id: 0, value}))
  // }

  addTag(e: MatChipInputEvent){
    const {input, value} = e;

    if ((value || '').trim()) 
      this.editedContact.tags.push({ id: 0, value: value.trim()});

    if (input) 
      input.value = '';
  }

  removeTag(tagName: string){
    const index = this.editedContact.tags.findIndex(e => e.value == tagName);
    if (index >= 0) 
      this.editedContact.tags.splice(index, 1);
  }

  addPhoneNumber(value: number){
      
  }

  triggerWantsToFinishEditing(){   
    console.log(this.editedContact) 
    // this.wantsToFinishEditing.emit(this.editedContact);
  }

  triggerWantsToEdit(){
    this.wantsToEdit.emit()
  }
}