namespace Service.Contracts;

public interface IUserTokenService
{
    Task CreateAsync(CreateUserTokenViewModel viewModel);

    Task<string?> GetTokenByUserId(int userId);
}
