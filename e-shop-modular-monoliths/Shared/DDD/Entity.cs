namespace Shared.DDD;

public abstract class Entity
{
    public Guid Id { get; init; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj == null)
        {
            return false;
        }

        if(obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return Id == entity.Id;
    }
}
