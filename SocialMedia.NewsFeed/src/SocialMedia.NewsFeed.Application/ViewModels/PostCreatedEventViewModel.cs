namespace SocialMedia.NewsFeed.Application.ViewModels;

public class PostCreatedEventViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishedAt { get; set; }
    public UserViewModel User { get; set; }
}
