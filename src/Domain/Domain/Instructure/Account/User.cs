namespace Domain.Instructure.Account;

public class User : BaseEntity<int>, IEntityHasIsSystemic, IEntityHasIsActived
{
    public User(string fullName)
    {
        FullName = fullName;
    }

    public string FullName { get; set; }

    public required string Email { get; set; }

    [ForeignKey("Role")]
    public required int RoleId { get; set; }

    public bool IsSystemic { get; set; }

    public bool IsActived { get; set; }

    public required string HashedPassword { get; set; }

    #region Relation
    public Role? Role { get; set; }

    public IList<UserToken>? UserTokens { get; set; }
    #endregion /Relation
}
