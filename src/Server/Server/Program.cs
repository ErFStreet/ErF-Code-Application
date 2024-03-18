namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
        //***** Builder *****\\

        var builder = WebApplication.CreateBuilder(args);

        //***** Register Services *****\\

        builder.Services.RegisterServices(
            configuration: builder.Configuration);

        builder.Services.RegisterJwt(configuration: builder.Configuration);

        //***** Build *****\\

        var app = builder.Build();

        app.Initialize();

        //***** Register Application *****\\

        app.RegisterApplication();

        //***** APP Run *****\\

        app.Run();
    }
}
