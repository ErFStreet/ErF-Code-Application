namespace Data.Repositories;

public class Repository<TEntity> where TEntity : class, IRepository<TEntity>
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

    public async Task<List<TEntity>> GetAll()
    {
        var result =
            await databaseContext.Set<TEntity>()
            .ToListAsync()
            ;

        return result;
    }
}
