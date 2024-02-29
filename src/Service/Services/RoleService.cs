using Microsoft.EntityFrameworkCore;

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

    public async Task DeleteAsync(int id)
    {
        var current =
            await repository.GetByIdAsync(id: id);

        if(current is not null)
        {
            repository.Remove(current);
        }
    }

    public async Task<List<ListRoleViewModel>> GetRolesAsync()
    {
        var result =
            await repository.GetAll()
            .Select(current => new ListRoleViewModel
            {
                Id = current.Id,
                RoleName = current.RoleName,
            })
            .ToListAsync();

        return result;
    }
}
