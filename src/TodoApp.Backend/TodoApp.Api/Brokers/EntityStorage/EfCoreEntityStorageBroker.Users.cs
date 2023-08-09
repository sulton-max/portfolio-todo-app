using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Models.Entities;
using TodoApp.Api.Models.Exceptions;

namespace TodoApp.Api.Brokers.EntityStorage;

/// <summary>
/// Provides entity storage operations using Entity Framework Core
/// </summary>
public sealed partial class EfCoreEntityStorageBroker
{
    public DbSet<User> Users => Set<User>();

    public async ValueTask<User> InsertUserAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await AddAsync(user, cancellationToken);
        await SaveChangesAsync(saveChanges, cancellationToken);

        return user;
    }

    public IQueryable<User> SelectAllUsers(Expression<Func<User, bool>> expression)
    {
        return Users.Where(expression);
    }

    public ValueTask<User?> SelectUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return SelectByIdAsync<User>(id, cancellationToken);
    }

    public async ValueTask<User> UpdateUserAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await UpdateAsync(user, cancellationToken);
        await SaveChangesAsync(saveChanges, cancellationToken);

        return user;
    }

    public async ValueTask<User> DeleteUserByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await SelectUserByIdAsync(id, cancellationToken) ?? throw new EntityNotFoundException<User>(id);
        await DeleteAsync(foundUser, cancellationToken);
        await SaveChangesAsync(saveChanges, cancellationToken);

        return foundUser;
    }

    public async ValueTask<User> DeleteUserAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await DeleteAsync(user, cancellationToken);
        await SaveChangesAsync(saveChanges, cancellationToken);

        return user;
    }
}