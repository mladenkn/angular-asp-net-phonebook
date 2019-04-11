import { Component, Input } from '@angular/core';
import { ContactDetails } from '../models/contact';

@Component({
  selector: 'app-contact',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactComponent {
  @Input() contact: ContactDetails
}