namespace Domain.Infrastructure.Base;

public class BaseEntity<TEntityKey>
{
    [Key]
    public TEntityKey? Id { get; set; }
}


