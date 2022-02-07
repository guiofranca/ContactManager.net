namespace ContactManager.Domain.Entities;

using ContactManager.Domain.Entities.Shared;

public class Address : OwnedByContactEntity
{
    public string Nickname { get; set; }
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? PostalCode { get; set; }
    public Contact? Contact { get; set; }

    public Address(
        string nickname,
        string? street,
        string? number,
        string? neighborhood,
        string? postalCode,
        int contactId
    )
    {
        Nickname = nickname;
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        PostalCode = postalCode;
        ContactId = contactId;
    }
}