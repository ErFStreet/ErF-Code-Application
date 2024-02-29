namespace Application.Pages.Account.Roles;

public partial class Roles
{
    public List<ListRoleViewModel>? RoleList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        RoleList =
            await httpClient.GetFromJsonAsync<List<ListRoleViewModel>>("api/Account/Roles");
    }
}
