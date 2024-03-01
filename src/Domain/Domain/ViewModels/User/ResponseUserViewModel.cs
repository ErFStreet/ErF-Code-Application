namespace Domain.ViewModels.User;

public class ResponseUserViewModel : BaseViewModel<int>
{
    public ResponseUserViewModel() : base()
    {
    }


    public string? FullName { get; set; }

    public string? Email { get; set; }

    public int RoleId { get; set; }
}
