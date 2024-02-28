namespace Data.Configurations.Account;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //********************
        builder.Property
            (current => current.FullName)
                .HasMaxLength(maxLength: Constants.MaxLength.FullName)
                .IsRequired(true);
        //********************

        //********************
        builder.Property
            (current => current.Email)
                .HasMaxLength(maxLength: Constants.MaxLength.Email)
                .IsRequired(true);
        //********************

        //********************
        builder.Property
            (current=>current.HashedPassword)
                .HasMaxLength(maxLength:Constants.MaxLength.Password)
                .IsRequired(true);
        //********************
    }
}
