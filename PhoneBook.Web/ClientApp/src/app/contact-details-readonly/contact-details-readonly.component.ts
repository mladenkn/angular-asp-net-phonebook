import { Component, Input, EventEmitter, Output } from "@angular/core";
import { ContactDetails } from "../models/contact";

@Component({
    selector: 'contact-details-readonly',
    templateUrl: './contact-details-readonly.component.html',
    styleUrls: ['./contact-details-readonly.component.css']
  })
export class ContactDetailsReadonly {
  
  @Input() contact: ContactDetails
  @Output() wantsToEdit = new EventEmitter<void>();

  triggerWantsToEdit(){
    this.wantsToEdit.emit()
  }
}