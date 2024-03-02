namespace Domain.ViewModels.UserToken;

public class CreateUserTokenViewModel : object
{
    public CreateUserTokenViewModel() : base()
    {
    }

    public required string AccessToken { get; set; }
}
