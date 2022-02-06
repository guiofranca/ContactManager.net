namespace ContactManager.Domain.Entities;

using ContactManager.Domain.Entities.Shared;

public class Phone : OwnedByContactEntity
{
    public string Name { get; set; }
    public string Number { get; set; }
    public Contact Contact { get; set; }

    public Phone(
        string name,
        string number,
        Contact contact)
    {
        Name = name;
        Number = number;
        Contact = contact;
    }
}