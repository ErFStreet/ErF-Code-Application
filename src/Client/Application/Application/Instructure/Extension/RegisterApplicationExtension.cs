
namespace Application.Instructure.Extension;

public static class RegisterApplicationExtension
{
    public static void RegisterApplication(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");

        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services
            .AddScoped
            (sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44389/")
            });

        builder.Services.AddBlazoredLocalStorage();
    }
}
