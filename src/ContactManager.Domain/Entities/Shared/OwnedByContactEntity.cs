namespace ContactManager.Domain.Entities.Shared;

public abstract class OwnedByContactEntity : BaseEntity
{
    public int ContactId { get; set; }
}