namespace Domain.ViewModels.Blog;

public class CreateBlogViewModel
{
    public CreateBlogViewModel()
    {
    }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string ShortDescription { get; set; }

    public required string ImagePath { get; set; }

    public bool IsDeleted { get; set; }
}
