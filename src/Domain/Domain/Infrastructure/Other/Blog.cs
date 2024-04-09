namespace Domain.Infrastructure.Other;

public class Blog : BaseEntity<int>, IEntityHasIsDeleted
{
    public Blog(string title)
    {
        Title = title;
    }

    public string Title { get; set; }

    public required string Description { get; set; }

    public required string ShortDescription { get; set; }

    public required string ImageUrl { get; set; }

    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    public bool IsDeleted { get; set; } = false;
}
