namespace Server.Instructure.Extension;

public static class InitializeDatabase
{
    public static void Initialize(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var database =
            scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        var anyRole =
            database.Roles!
            .Any();

        if (!anyRole)
        {
            var roles = new List<string>()
            {
                RoleNames.Admin,
                RoleNames.User,
                RoleNames.Vip,
            };

            foreach(var item in roles)
            {
                var role = 
                    new Role(roleName: item);

                database.Add(entity: role);
            }

            database.SaveChanges();
        }

        var anyUser =
             database.Users!
             .Any();

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

        database.Users!.Add(entity: user);

        database.SaveChanges();
    }
}
