using System.Linq.Expressions;
using TodoApp.Api.Models.Entities;

namespace TodoApp.Api.Brokers.EntityStorage;

public partial interface IEntityStorageBroker
{
    ValueTask<User> InsertUserAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    IQueryable<User> SelectAllUsers(Expression<Func<User, bool>> expression);

    ValueTask<User?> SelectUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateUserAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteUserByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteUserAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}