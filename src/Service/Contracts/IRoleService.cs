namespace Service.Contracts;

public interface IRoleService
{
    Task CreateAsync(CreateRoleViewModel viewModel);

    Task<List<ListRoleViewModel>> GetRolesAsync();
}
