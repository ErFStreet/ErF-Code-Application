namespace Data.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext databaseContext;

    public UnitOfWork(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public async Task<bool> SaveChangesAsync()
    {
        var result =
            await databaseContext.SaveChangesAsync();

        if (result > 0)
        {
            return true;
        }

        return false;
    }
}
