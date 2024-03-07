namespace ClientApplication.Instructure.Extension;

public static class RegisterApplicationExtension
{
    public static void RegisterApplication(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");

        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped<HttpClient>();

        builder.Services.AddBlazoredLocalStorage();
    }
}
