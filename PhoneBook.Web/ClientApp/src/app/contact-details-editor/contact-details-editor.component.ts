import { Component, Input, Output, EventEmitter } from "@angular/core";
import { ContactDetails } from "../models/contact";

@Component({
    selector: 'contact-details-editor',
    templateUrl: './contact-details-editor.component.html',
    styleUrls: ['./contact-details-editor.component.css']
  })
export class ContactDetailsEditor {

  @Input() contact: ContactDetails
  @Output() wantsToFinishEditing = new EventEmitter<void>();

  triggerWantsoFinishEditing(){
    this.wantsToFinishEditing.emit()
  }
}