namespace Server.Infrastructure.Contracts;

public interface IValidateTokenHelper
{
    Task ExecuteAsync(TokenValidatedContext context);
}
