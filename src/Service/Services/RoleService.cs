namespace Service.Services;

public class RoleService : IRoleService
{
    private readonly IRepository<Role> repository;

    public RoleService(IRepository<Role> repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(CreateRoleViewModel viewModel)
    {
        var role =
            new Role(roleName: viewModel.RoleName);

        await repository.CreateAsync(role);
    }
}
