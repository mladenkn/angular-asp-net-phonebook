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
  
  constructor(private fb: FormBuilder){
    this.getArray = this.getArray.bind(this)
  }

  ngOnInit() {
    const {contact, fb} = this
    this.form = fb.group({
      firstName: contact ? contact.firstName : '',
      lastName: contact ? contact.lastName : '',
      emails: fb.array(
        (contact ? contact.emails: []).map(e => fb.control(e))
      ),
      tags: fb.array(
        (contact ? contact.tags: []).map(e => fb.control(e))
      ),
      phoneNumbers: fb.array(
        (contact ? contact.phoneNumbers: []).map(e => fb.control(e.toString()))
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
    return (this.form.get(name) as FormArray).controls;
  }

  pushToArray(arrayName: string){
    this.getArray(arrayName).push(this.fb.control(''));
  }

  removeTag(tagName: string){
    console.log(tagName)
    const tagsArray = this.getArray('tags');
    const index = tagsArray.findIndex(e => {
      console.log(e)
      return e.value == tagName;
    });
    if (index >= 0) 
      tagsArray.splice(index, 1);
  }

  addTag(e: MatChipInputEvent){
    const {input, value} = e;

    if ((value || '').trim()) 
      this.getArray('tags').push(this.fb.control(value.trim()));    

    if (input) 
      input.value = '';
  }

  triggerWantsToFinishEditing(){
    const input = this.extractInput();
    this.wantsToFinishEditing.emit({...input, id: this.contact.id});
  }

  triggerWantsToEdit(){
    this.wantsToEdit.emit()
  }
}