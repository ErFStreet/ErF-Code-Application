﻿namespace Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        :base(options:options)
    {
    }

    #region Properties
    public DbSet<User>? Users { get; set; }

    public DbSet<Role>? Roles { get; set; }

    public DbSet<Blog>? Blogs { get; set; }

    public DbSet<Music>? Musics { get; set; }


    public DbSet<UserToken>? UserTokens { get; set; }
    #endregion /Properties

    #region Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
    #endregion
}
