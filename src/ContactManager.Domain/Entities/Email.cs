namespace ContactManager.Domain.Entities;

using ContactManager.Domain.Entities.Shared;

public class Email : OwnedByContactEntity 
{
    public string Address { get; set; }
    public Contact Contact { get; set; }

    public Email(
        string address,
        Contact contact
    )
    {
        Address = address;
        Contact = contact;
    }
}