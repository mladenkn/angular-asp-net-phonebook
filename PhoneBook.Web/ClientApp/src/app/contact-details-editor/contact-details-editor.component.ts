import { Component, Input, Output, EventEmitter, OnInit } from "@angular/core";
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

  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  phoneNumbersInput: string[]
  editedContact: ContactDetails

  ngOnInit() {
    this.editedContact = JSON.parse(JSON.stringify(this.contact))
    this.phoneNumbersInput = this.editedContact.phoneNumbers.map(e => e.toString())
  }

  addTag(e: MatChipInputEvent){
    const {input, value} = e;
    if ((value || '').trim()) 
      this.editedContact.tags.push(value.trim());

    if (input) 
      input.value = '';
  }

  removeTag(i: number){
      this.editedContact.tags.splice(i, 1);
  }

  addEmail(){
    this.editedContact.emails.push('');
  }

  setEmail(index: number, value: string){
    this.editedContact.emails[index] = value
  }

  removeEmail(i: number){
    this.editedContact.emails.splice(i, 1)
  }

  addPhoneNumber(){
    this.phoneNumbersInput.push('')      
  }

  setPhoneNumber(index: number, value: string){
    this.phoneNumbersInput[index] = value
  }

  removePhoneNumber(i: number){
    this.phoneNumbersInput.splice(i, 1)      
  }

  triggerWantsToFinishEditing(){
    this.editedContact.phoneNumbers = this.phoneNumbersInput.map(e => parseInt(e));
    console.log(this.editedContact);
    this.wantsToFinishEditing.emit(this.editedContact);
  }

  triggerWantsToEdit(){
    this.wantsToEdit.emit()
  }
}