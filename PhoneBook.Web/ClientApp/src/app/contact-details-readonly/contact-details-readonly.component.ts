import { Component, Input } from "@angular/core";
import { ContactDetails } from "../models/contact";

@Component({
    selector: 'contact-details-readonly',
    templateUrl: './contact-details-readonly.component.html',
    styleUrls: ['./contact-details-readonly.component.css']
  })
export class ContactDetailsReadonly {
  
  @Input() contact: ContactDetails

  edit(){
    console.log("oce editirat")
  }
}