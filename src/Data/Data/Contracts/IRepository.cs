﻿namespace Data.Contracts;

public interface IRepository<TEntity>
{
    Task CreateAsync(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    IQueryable<TEntity> GetAll();
}
