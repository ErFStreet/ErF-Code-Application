namespace Domain.Infrastructure.Base;

public class BaseViewModel<TEntityKey>
{
    public TEntityKey? Id { get; set; }
}
