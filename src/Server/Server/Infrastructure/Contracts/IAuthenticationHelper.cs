namespace Server.Infrastructure.Contracts;

public interface IAuthenticationHelper
{
    Task<string?> GenerateJsonWebToken(ResponseUserViewModel response);
}
