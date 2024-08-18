namespace SocialMedia.NewsFeed.Domain.SeedWork;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        IsDeleted = false;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
