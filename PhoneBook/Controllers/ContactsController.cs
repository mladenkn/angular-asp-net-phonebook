using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class ContactsController 
{
    [HttpGet("[action]")]
    public IEnumerable<Contact> Get()
    {
        return new [] 
        {
            new Contact 
            {
                FirstName = "Mladen",
                LastName = "Knezović",
                Address = new Address { Street = "Mornarska", HouseNumber = 15 },
                PhoneNumbers = new [] { 022342340, 546745, 2346 },
                Emails = new [] { "mladen.knezovic.1993@gmail.com", "email2@hotmail.com" }
            },
            new Contact 
            {
                FirstName = "Mate",
                LastName = "Jurić",
                Address = new Address { Street = "Ulica", HouseNumber = 23 },
                PhoneNumbers = new [] { 022342340, 546745, 2346 },
                Emails = new [] { "email1@gmail.com", "email2@hotmail.com" }
            }
        };
    }
}

public class Contact 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public IEnumerable<int> PhoneNumbers { get; set; }
    public IEnumerable<string> Emails { get; set; }
}

public class Address
{
    public string Street { get; set; }    
    public int HouseNumber { get; set; }
}