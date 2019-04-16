import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { MatGridListModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ContactListComponent } from './contacts-list/contact-list.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { ContactDetailsEditorComponent } from './contact-details-editor/contact-details-editor.component';
import { ContactsQueryComponent } from './contacts-query/contacts-query.component';
import { ContactCreateComponent } from './contact-create/contact-create.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ContactListComponent,
    ContactDetailsComponent,
    ContactDetailsEditorComponent,
    ContactsQueryComponent,
    ContactCreateComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatGridListModule,
    MatChipsModule,
    MatIconModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: ContactListComponent, pathMatch: 'full' },
      { path: 'contacts', component: ContactListComponent },
      { path: 'contact/:id', component: ContactDetailsComponent },
      { path: 'contacts/create', component: ContactCreateComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
