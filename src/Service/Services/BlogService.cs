namespace Service.Services;

public class BlogService : IBlogService
{
    private readonly IRepository<Blog> repository;

    public BlogService(IRepository<Blog> repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(CreateBlogViewModel viewModel)
    {
        if (viewModel is null)
            throw new ArgumentNullException(nameof(viewModel));

        var blog = new Blog(title: viewModel.Title)
        {
            ShortDescription = viewModel.ShortDescription,
            Description = viewModel.Description,
            ImageUrl = viewModel.ImageUrl,
        };

        await repository.CreateAsync(entity: blog);
    }

    public async Task<EditBlogViewModel?> GetBlogForEditByIdAsync(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var result =
            await repository.GetQueryable()
            .Where(current => current.Id == id)
            .Select(current => new EditBlogViewModel
            {
                Id = current.Id,
                Title = current.Title,
                ShortDescription = current.ShortDescription,
                Description = current.Description,
                IsDeleted = current.IsDeleted,
                ImageUrl = current.ImageUrl,
            })
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task EditAsync(EditBlogViewModel viewModel)
    {
        if (viewModel is null)
            throw new ArgumentNullException(nameof(viewModel));

        var blog =
            await repository.GetByIdAsync(id: viewModel.Id);

        blog!.Title = viewModel.Title;

        blog!.ShortDescription = viewModel.ShortDescription;

        blog!.Description = viewModel.Description;

        blog!.IsDeleted = viewModel.IsDeleted;

        blog!.ImageUrl = viewModel.ImageUrl;

        repository.Update(entity: blog);
    }

    public async Task DeleteAsync(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var blog =
            await repository.GetByIdAsync(id: id);

        if (blog is null)
            throw new ArgumentNullException(nameof(blog));

        repository.Remove(entity: blog);
    }

    public async Task<DetailBlogViewModel?> GetBlogById(int id)
    {
        if (id == 0)
            throw new ArgumentNullException(nameof(id));

        var result =
            await repository.GetQueryable()
            .Where(current => current.Id == id)
            .Select(current => new DetailBlogViewModel
            {
                Title = current.Title,
                Description = current.Description,
                ImageUrl = current.ImageUrl,
            })
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<List<ListBlogViewModel>> GetAllAsync()
    {
        var result =
            await repository.GetQueryable()
            .AsNoTracking()
            .Where(current => !current.IsDeleted)
            .Select(current => new ListBlogViewModel
            {
                Id = current.Id,
                Title = current.Title,
                ShortDescription = current.ShortDescription,
                Description = current.Description,
                CreatedDateTime = current.CreatedDateTime,
                ImageUrl = current.ImageUrl,
            })
            .ToListAsync();

        return result;
    }
}
