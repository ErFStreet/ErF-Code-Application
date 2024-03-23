namespace Domain.Infrastructure.SeedWork;

public interface IEntityHasIsDeleted
{
    bool IsDeleted { get; set; }
}
