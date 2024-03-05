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
				UserId = viewModel.UserId,
			};

		await repository.CreateAsync(entity: userToken);
	}

	public bool GetTokenByUserId(int userId, string token)
	{
		var result =
			 repository.GetQueryable()
			.Where(current => current.UserId == userId)
			.Where(current => current.AccessTokenHash == token)
			.Any();

		return result;
	}
}
