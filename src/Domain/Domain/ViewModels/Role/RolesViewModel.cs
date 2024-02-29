namespace Domain.ViewModels.Role;

internal class RolesViewModel:object
{
    public RolesViewModel():base()
    {
    }

    public List<ListRoleViewModel>? Roles { get; set; }
}
