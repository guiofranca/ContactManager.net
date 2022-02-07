namespace ContactManager.Domain.Entities;

using ContactManager.Domain.Entities.Shared;
using System.Collections.Generic;

public class Contact : BaseEntity {
    public string Name { get; set; }
    public string? Nickname { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public IEnumerable<Address>? Addresses { get; set; }
    public IEnumerable<Email>? Emails { get; set; }
    public IEnumerable<Phone>? Phones { get; set; }

    public Contact(
        string name,
        string? nickname,
        DateOnly? dateOfBirth//,
        //IEnumerable<Address> addresses,
        //IEnumerable<Email> emails,
        //IEnumerable<Phone> phones
    )
    {
        Name = name;
        Nickname = nickname;
        DateOfBirth = dateOfBirth;
        //Addresses = addresses;
        //Emails = emails;
        //Phones = phones;
    }
}