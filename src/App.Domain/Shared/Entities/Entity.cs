namespace App.Domain.Shared.Entities;

public abstract class Entity
{
    public Guid Id { get; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }
}