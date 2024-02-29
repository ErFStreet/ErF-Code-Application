namespace Application.Pages.Account.CreateRole;

public partial class CreateRole
{
    private string? roleName;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./user/js/jquery-3.1.1.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./user/js/bootstrap.min.js");

            await _jsRunTime.InvokeAsync<IJSObjectReference>("import", "./user/js/scripts.js");
        }
    }

    private async Task CreateRoleAsync()
    {
        var viewModel = new CreateRoleViewModel
        {
            RoleName = roleName!
        };


        var response =
             await httpClient.PostAsJsonAsync("api/Account/CreateRole", viewModel);

        var result = response.StatusCode;
    }
}
