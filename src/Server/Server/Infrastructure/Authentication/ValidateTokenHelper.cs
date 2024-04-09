
namespace Server.Infrastructure.Authentication;

public class ValidateTokenHelper : IValidateTokenHelper
{
	private readonly IUserTokenService userTokenService;

	public ValidateTokenHelper(IUserTokenService userTokenService)
	{
		this.userTokenService = userTokenService;
	}

	public async Task ExecuteAsync(TokenValidatedContext context)
	{
		var userId =
			context.Principal?.Claims.FirstOrDefault
			(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


		if (string.IsNullOrWhiteSpace(userId))
		{
			context.Fail(nameof(HttpStatusCode.Unauthorized));
		}

		var accessToken =
			context.SecurityToken as JwtSecurityToken;

		var anyUserToken =
			userTokenService.GetTokenByUserId(userId: int.Parse(userId!), token: accessToken!.RawData);

		if (!anyUserToken)
		{
			context.Fail(nameof(HttpStatusCode.Unauthorized));
		}

		await Task.CompletedTask;
	}
}
