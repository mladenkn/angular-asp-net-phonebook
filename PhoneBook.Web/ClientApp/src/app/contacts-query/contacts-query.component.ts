import { Component, Output, EventEmitter } from '@angular/core';
import { GetContactsRequest } from '../models/contact';
import { MatChipInputEvent } from '@angular/material';
import { ENTER, COMMA } from '@angular/cdk/keycodes';

@Component({
  selector: 'contacts-query',
  templateUrl: './contacts-query.component.html',
  styleUrls: ['./contacts-query.component.css']
})
export class ContactsQueryComponent {
  
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  @Output() readonly wantsToRequery = new EventEmitter<GetContactsRequest>();

  model: GetContactsRequest = {
    firstNameSearchString: '',
    lastNameSearchString: '',
    contactMustContainAllTags: [],
    contactMustContainSomeTags: []
  }

  addTag1(e: MatChipInputEvent){
    const {input, value} = e;
    if ((value || '').trim())
      this.model.contactMustContainAllTags.push(value.trim());
    if (input) 
      input.value = '';
  }

  removeTag1(i: number){
      this.model.contactMustContainAllTags.splice(i, 1);
  }

  addTag2(e: MatChipInputEvent){
    const {input, value} = e;
    if ((value || '').trim())
      this.model.contactMustContainSomeTags.push(value.trim());
    if (input) 
      input.value = '';
  }

  removeTag2(i: number){
    this.model.contactMustContainSomeTags.splice(i, 1);
  }

  triggerSubmit(){
    this.wantsToRequery.emit(this.model);
  }
}
