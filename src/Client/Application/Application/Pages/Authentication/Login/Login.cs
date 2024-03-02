using Constants;
using Domain.ViewModels.User;

namespace Application.Pages.Authentication.Login;

public partial class Login
{
    private string? Email { get; set; }

    private string? Password { get; set; }

    private List<string> ErrorMessages = new List<string>();

    public async void LoginUser()
    {
        ErrorMessages = new List<string>();

        if (Email is null)
        {
            ErrorMessages.Add(item: Constants.ErrorMessages.NullEmailError);

            return;
        }

        if (!Email!.Contains("@") && Email is not null)
        {
            ErrorMessages.Add(item: Constants.ErrorMessages.InValidEmailError);

            return;
        }

        if (Password is null)
        {
            ErrorMessages.Add(item: Constants.ErrorMessages.NullPasswordError);

            return;
        }

        if (Password?.Length < 8 && Password is not null)
        {
            ErrorMessages.Add(item: Constants.ErrorMessages.PasswordLengthError);

            return;
        }

        var viewModel = new LoginUserViewModel
        {
            Email = Email,
            Password = Password,
        };

        var response =
            await httpClient.PostAsJsonAsync("api/Authentication/Login", viewModel);

        var token =
            response.Content.ReadFromJsonAsync<Result<string>>();

        if (string.IsNullOrWhiteSpace(token.Result!.Value))
        {
            ErrorMessages.Add(item: Constants.ErrorMessages.NotFoundUserError);

            return;
        }

        await localStorage.SetItemAsync("token", token.Result!.Value);
    }
}
