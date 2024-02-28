namespace Data.Contracts.Base;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
}
