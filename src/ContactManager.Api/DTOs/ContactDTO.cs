using ContactManager.Domain.Entities;

namespace ContactManager.Api.DTOs;

public class ContactDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Nickname { get; set; }
    public string? DateOfBirth { get; set; }

    public ContactDTO(Contact contact)
    {
        Id = contact.Id;
        Name = contact.Name;
        Nickname = contact.Nickname;
        DateOfBirth = contact.DateOfBirth?.ToString();
        //  DateOfBirth = "";
    }

    public ContactDTO(string name, string? nickname, string? dateOfBirth)
    {
        Name = name;
        Nickname = nickname;
        DateOfBirth = dateOfBirth;
    }

    public ContactDTO()
    {
        
    }
}