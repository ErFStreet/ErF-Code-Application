using Data.Instructure;
using Domain.Instructure.Account;
using Microsoft.EntityFrameworkCore;

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

        //***** Add Cors *****\\

        services.AddCors(options =>
        {
            options.AddPolicy("Cors",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        //***** Add Database *****\\

        services.AddDbContext<DatabaseContext>
            (option => option.UseSqlServer(
                connectionString: configuration.GetSection("DatabaseSettings")["ConnectionString"]));
    }
}
