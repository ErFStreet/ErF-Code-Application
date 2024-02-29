namespace Application.Pages.Account.Roles;

public partial class Roles
{
    private Result<List<ListRoleViewModel>>? Response { get; set; }

    private List<string>? Messages { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Response =
            await httpClient.GetFromJsonAsync<Result<List<ListRoleViewModel>>>("api/Account/Roles");
    }

    private async Task Remove(int id)
    {
        var responase =
             await httpClient.GetFromJsonAsync<Response>("api/Account/RemoveRole?id=" + id);

        var item =
            Response!.Value!
            .Where(current => current.Id == id)
            .FirstOrDefault();

        Response!.Value!.Remove(item!);
    }
}
