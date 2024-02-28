namespace Domain.Instructure.Account;

public class Role : BaseEntity<int>
{
    public Role(string roleName)
    {
        RoleName = roleName;
    }

    public string RoleName { get; set; }

    #region Relation
    public IList<User>? Users { get; set; }
    #endregion /Relation
}
