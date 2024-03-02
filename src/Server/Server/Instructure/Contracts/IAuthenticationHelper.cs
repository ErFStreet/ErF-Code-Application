namespace Server.Instructure.Contracts;

public interface IAuthenticationHelper
{
    Task<string?> GenerateJsonWebToken(ResponseUserViewModel response);
}
