using System.Net;

namespace Server.Instructure.Authentication;

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

        var userToken =
            await userTokenService.GetTokenByUserId(userId: int.Parse(userId!));

        var accessToken =
            context.SecurityToken as JwtSecurityToken;

        if (accessToken == null || userToken != accessToken.RawData)
        {
            context.Fail(nameof(HttpStatusCode.Unauthorized));
        }

        await Task.CompletedTask;
    }
}
