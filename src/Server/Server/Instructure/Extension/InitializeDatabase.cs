namespace Server.Instructure.Extension;

public static class InitializeDatabase
{
    public static async Task Initialize(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var database =
            scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        var anyUser =
            await database.Users!
             .AnyAsync();

        if (anyUser)
            return;

        var user = new User(fullName: "Erfan Edalati")
        {
            IsActived = true,
            IsSystemic = true,
            RoleId = (int)RolesEnum.Admin,
            Email = "erfannStreet@gmail.com",
            HashedPassword = "Nayanaya48@",
        };

        await database.Users!.AddAsync(entity: user);

        await database.SaveChangesAsync();
    }
}
