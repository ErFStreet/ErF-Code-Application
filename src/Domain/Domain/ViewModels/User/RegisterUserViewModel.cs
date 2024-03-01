namespace Domain.ViewModels.User;

public class RegisterUserViewModel
{
    public required string FullName { get; set; }

    public required string Email { get; set; }

    public required int RoleId { get; set; }

    public bool IsActived { get; set; }

    public required string Password { get; set; }
}
