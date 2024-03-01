namespace Domain.ViewModels.User;

public class LoginUserViewModel:object
{
    public LoginUserViewModel():base()
    {
    }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
