import { Component, Input } from '@angular/core';

@Component({
  selector: 'contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent {
  @Input() contact: ContactDetailsComponent
}