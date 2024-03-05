using Application.Instructure.Helpers;
using System.Net;

namespace Application.Pages.Account.CreateRole;

public partial class CreateRole
{
	private string? roleName;

	private List<string> Messages { get; set; } = new List<string>();

	private async Task CreateRoleAsync()
	{
		var viewModel = new CreateRoleViewModel
		{
			RoleName = roleName!
		};

		var url = $"api/Account/CreateRole";

		var response =
			 await HttpHelper<Response>.Post(url, viewModel);

		var statusCode = response.StatusCode;

		if (statusCode == 200)
		{
			navigationManager.NavigateTo("/Roles");
		}
	}
}
