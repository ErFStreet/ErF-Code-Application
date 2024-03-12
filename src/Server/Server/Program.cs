namespace Server;

public class Program
{
	public static async void Main(string[] args)
	{
		//***** Builder *****\\

		var builder = WebApplication.CreateBuilder(args);

		//***** Register Services *****\\

		builder.Services.RegisterServices(
			configuration: builder.Configuration);

		builder.Services.RegisterJwt(configuration: builder.Configuration);

		//***** Build *****\\

		var app = builder.Build();

		await app.Initialize();

		//***** Register Application *****\\

		app.RegisterApplication();

		//***** APP Run *****\\

		app.Run();
	}
}
