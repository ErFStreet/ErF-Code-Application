namespace Server.Instructure.Contracts;

public interface IAuthenticationHelper
{
    string GenerateJsonWebToken(ResponseUserViewModel loginResult);
}
