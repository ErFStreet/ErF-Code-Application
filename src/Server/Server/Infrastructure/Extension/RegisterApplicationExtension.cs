namespace Server.Infrastructure.Extension;

public static class RegisterAppExtension
{
    public static void RegisterApplication(this WebApplication app)
    {
        //***** Application Usings *****\\

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI();
        }

        app.UseCors("Cors");

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();
    }
}
