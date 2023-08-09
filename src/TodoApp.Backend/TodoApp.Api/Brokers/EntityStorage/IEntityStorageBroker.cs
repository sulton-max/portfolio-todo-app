namespace TodoApp.Api.Brokers.EntityStorage;

public partial interface IEntityStorageBroker
{
    /// <summary>
    /// Saves changes to database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Affected rows count</returns>
    ValueTask<bool> SaveAsync(CancellationToken cancellationToken = default);
}