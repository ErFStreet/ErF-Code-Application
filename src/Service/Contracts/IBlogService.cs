namespace Service.Contracts;

public interface IBlogService
{
    Task CreateAsync(CreateBlogViewModel viewModel);

    Task<EditBlogViewModel?> GetBlogForEditByIdAsync(int id);

    Task EditAsync(EditBlogViewModel viewModel);

    Task DeleteAsync(int id);

    Task<DetailBlogViewModel?> GetBlogById(int id);

    Task<List<ListBlogViewModel>> GetAllAsync();
}
