import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { ContactDetails, ContactListItem, GetContactsRequest } from "./models/contact";

@Injectable({providedIn: "root"})
export class ContactService {

    private baseUrl: string

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string){
        this.baseUrl = baseUrl + "Contacts/"        
    }

    getDetails(contactId: number){
        return this.http.get<ContactDetails>(this.baseUrl + "Details/" + contactId)
    }

    getList(request?: GetContactsRequest){
        return this.http.post<ContactListItem[]>(this.baseUrl + 'List', null, {
            params: request || {} as any
        })
    }

    update(contact: ContactDetails){
        return this.http.put(this.baseUrl + "Put", null, {params: contact as any})
    }

    save(contact: ContactDetails){
        return this.http.post(this.baseUrl + "Post", null, {params: contact as any}) 
    }
}
    
// http.delete(baseUrl + 'Contacts/Delete/1')
//   .subscribe(console.log, console.error);     

