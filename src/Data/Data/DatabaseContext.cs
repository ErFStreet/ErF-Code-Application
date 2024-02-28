namespace Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        :base(options:options)
    {
    }

    #region Properties
    public DbSet<User>? Users { get; set; }

    public DbSet<Role>? Roles { get; set; }

    #endregion /Properties

    #region Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
    #endregion
}
