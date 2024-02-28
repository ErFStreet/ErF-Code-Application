namespace Server.Instructure.Extension;

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

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
