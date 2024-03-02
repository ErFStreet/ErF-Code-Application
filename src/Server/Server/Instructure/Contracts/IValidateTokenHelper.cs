namespace Server.Instructure.Contracts;

public interface IValidateTokenHelper
{
    Task ExecuteAsync(TokenValidatedContext context);
}
