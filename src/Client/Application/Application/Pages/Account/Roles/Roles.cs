using Application.Instructure.Helpers;

namespace Application.Pages.Account.Roles;

public partial class Roles
{
	private Result<List<ListRoleViewModel>>? Response { get; set; }

	private List<string> Messages { get; set; } = new List<string>();

	protected override async Task OnInitializedAsync()
	{
		var url = $"api/Account/Roles";

		Response =
			await HttpHelper<Result<List<ListRoleViewModel>>>.Get(url: url);
	}

	private async Task Remove(int id)
	{
		var url = $"api/Account/RemoveRole?id={id}";

		var responase =
			 await HttpHelper<Response>.Delete(url: url);

		if (responase != null)
		{
			var item =
				Response!.Value!
				.Where(current => current.Id == id)
				.FirstOrDefault();

			Response!.Value!.Remove(item!);
		}

		Messages.Add(Constants.ErrorMessages.ServerError);
	}
}
