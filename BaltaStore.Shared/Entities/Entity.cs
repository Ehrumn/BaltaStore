using Flunt.Notifications;

namespace BaltaStore.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid();
    }
}