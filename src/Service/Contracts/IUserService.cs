namespace Service.Contracts;

public interface IUserService
{
    Task RegisterAsync(RegisterUserViewModel viewModel);

    Task<ResponseUserViewModel?> LoginAsync(LoginUserViewModel viewModel);
}
