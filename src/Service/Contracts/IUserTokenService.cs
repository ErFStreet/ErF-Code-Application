namespace Service.Contracts;

public interface IUserTokenService
{
    Task CreateAsync(CreateUserTokenViewModel viewModel);

	bool GetTokenByUserId(int userId, string token);
}
