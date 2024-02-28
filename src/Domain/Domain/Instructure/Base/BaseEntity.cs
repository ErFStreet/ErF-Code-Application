namespace Domain.Instructure.Base;

public class BaseEntity<TEntityKey>
{
    [Key]
    public TEntityKey? Id { get; set; }
}


