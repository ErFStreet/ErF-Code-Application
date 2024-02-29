namespace Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DatabaseContext databaseContext;

    public Repository(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await databaseContext.Set<TEntity>()
            .AddAsync(entity)
            ;
    }

    public void Update(TEntity entity)
    {
        databaseContext.Set<TEntity>()
            .Update(entity)
            ;
    }

    public void Remove(TEntity entity)
    {
        databaseContext.Set<TEntity>()
            .Remove(entity)
            ;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        var result =
            await databaseContext.Set<TEntity>()
            .FindAsync(keyValues: id);

        return result;
    }

    public IQueryable<TEntity> GetAll()
    {
        var result =
             databaseContext.Set<TEntity>()
            .AsQueryable()
            ;

        return result;
    }
}
