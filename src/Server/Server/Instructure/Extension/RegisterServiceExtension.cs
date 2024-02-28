using Data.Instructure;
using Domain.Instructure.Account;

namespace Server.Instructure.Extension;

public static class RegisterServiceExtension
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        //***** Add *****\\

        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        //***** Add Scoped *****\\

        services.AddTransient<IRoleService, RoleService>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

        //***** Add Database *****\\

        services.AddDbContext<DatabaseContext>
            (option => option.UseSqlServer(
                "Data Source=.;Initial Catalog=ErF-APP;Integrated Security=true; TrustServerCertificate=True"));
    }
}
