namespace Data.Configurations.Account;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        //********************
        builder.Property
            (current => current.RoleName)
                .HasMaxLength(maxLength: Constants.MaxLength.RoleName)
                .IsRequired(true);
        //********************
    }
}
