import { Component } from '@angular/core';
import { ContactDetails } from '../models/contact';
import { ContactService } from '../contact.service';
import { Router } from '@angular/router';

@Component({
  selector: 'contact-create',
  templateUrl: './contact-create.component.html',
  styleUrls: ['./contact-create.component.css']
})
export class ContactCreateComponent {

  constructor(private service: ContactService, private router: Router) { }

  wantsToSave(contact: ContactDetails){
    this.service.save(contact)
      .subscribe(_ => this.router.navigateByUrl("/contacts"), console.error);
  }
}
