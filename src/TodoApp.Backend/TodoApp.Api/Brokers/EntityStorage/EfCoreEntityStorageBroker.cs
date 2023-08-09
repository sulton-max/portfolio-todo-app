using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Models.Common;

namespace TodoApp.Api.Brokers.EntityStorage;

/// <summary>
/// Provides entity storage operations using Entity Framework Core
/// </summary>
public sealed partial class EfCoreEntityStorageBroker : DbContext, IEntityStorageBroker
{
    /// <summary>
    /// Creates entity in database context scope
    /// </summary>
    /// <param name="entity">Entity being created</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task</returns>
    private async ValueTask InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntity
    {
        await Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    /// <summary>
    /// Gets entity set as queryable collection
    /// </summary>
    /// <param name="expression">Predicate expression</param>
    /// <returns>Queryable collection of entity</returns>
    private IQueryable<TEntity> SelectAllAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity
    {
        return Set<TEntity>().Where(expression);
    }

    /// <summary>
    /// Gets entity by Id
    /// </summary>
    /// <param name="id">Id of entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Entity if found, otherwise null</returns>
    private async ValueTask<TEntity?> SelectByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken = default) where TEntity : class, IEntity
    {
        return await Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
    }

    /// <summary>
    /// Updates entity in database context scope
    /// </summary>
    /// <param name="entity">Entity being updated</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task</returns>
    private ValueTask<TEntity> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntity
    {
        return new ValueTask<TEntity>(Task.FromResult(Set<TEntity>().Update(entity).Entity));
    }

    /// <summary>
    /// Deletes entity in database context scope
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task</returns>
    private ValueTask DeleteAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntity
    {
        return new ValueTask(Task.FromResult(Set<TEntity>().Remove(entity).Entity));
    }

    /// <summary>
    /// Saves changes to database
    /// </summary>
    /// <param name="save">Determines to actually save or not - used in inner methods</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Affected rows count</returns>
    private async ValueTask<bool> SaveAsync(bool save = true, CancellationToken cancellationToken = default)
    {
        return !save || await SaveChangesAsync(cancellationToken) > 0;
    }

    /// <summary>
    /// Saves changes to database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Affected rows count</returns>
    public ValueTask<bool> SaveAsync(CancellationToken cancellationToken = default) => SaveAsync(true, cancellationToken);
}