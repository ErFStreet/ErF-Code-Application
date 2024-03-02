namespace Service.Services;

public class UserTokenService : IUserTokenService
{
    private readonly IRepository<UserToken> repository;

    public UserTokenService(IRepository<UserToken> repository)
    {
        this.repository = repository;
    }

    public async Task CreateAsync(CreateUserTokenViewModel viewModel)
    {
        if (viewModel == null)
            throw new ArgumentNullException(nameof(viewModel));

        var userToken =
            new UserToken
            {
                AccessTokenHash = viewModel.AccessToken,
            };

        await repository.CreateAsync(entity: userToken);
    }

    public async Task<string?> GetTokenByUserId(int userId)
    {
        var result =
            await repository.GetQueryable()
            .Where(current => current.UserId == userId)
            .Select(current => current.AccessTokenHash)
            .FirstOrDefaultAsync();

        return result;
    }
}
