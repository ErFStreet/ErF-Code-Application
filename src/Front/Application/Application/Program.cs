namespace Application;

public class Program
{
    public static async Task Main(string[] args)
    {
        //***** Create App *****\\

        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        //***** Register App *****\\

        builder.RegisterApplication();


        //***** Run App *****\\

        await builder.Build().RunAsync();
    }
}
