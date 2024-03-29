﻿namespace Service.Contracts;

public interface IRoleService
{
    Task CreateAsync(CreateRoleViewModel viewModel);

    Task DeleteAsync(int id);

    Task<List<ListRoleViewModel>> GetRolesAsync();
}
