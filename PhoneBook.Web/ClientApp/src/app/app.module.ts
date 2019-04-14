import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ContactListComponent } from './contacts-list/contact-list.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { ContactDetailsEditor as ContactDetailsEditorComponent } from './contact-details-editor/contact-details-editor.component';
import { ContactDetailsReadonly } from './contact-details-readonly/contact-details-readonly.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ContactListComponent,
    ContactDetailsComponent,
    ContactDetailsEditorComponent,
    ContactDetailsReadonly,    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ContactListComponent, pathMatch: 'full' },
      { path: 'contacts', component: ContactListComponent },
      { path: 'contact/:id', component: ContactDetailsComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
