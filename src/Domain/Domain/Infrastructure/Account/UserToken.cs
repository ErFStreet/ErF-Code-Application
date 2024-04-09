namespace Domain.Infrastructure.Account;

public class UserToken : BaseEntity<int>
{
    public UserToken():base()
    {
    }

    public required string AccessTokenHash { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    #region Relation
    public User? User { get; set; }
    #endregion
}
