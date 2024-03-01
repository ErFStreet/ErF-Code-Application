namespace Domain.Instructure.Base;

public class BaseViewModel<TEntityKey>
{
    public TEntityKey? Id { get; set; }
}
