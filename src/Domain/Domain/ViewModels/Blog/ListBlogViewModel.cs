namespace Domain.ViewModels.Blog;

public class ListBlogViewModel
{
    public ListBlogViewModel()
    {
    }

    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string ShortDescription { get; set; }

    public required string ImageUrl { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public bool IsDeleted { get; set; }
}
