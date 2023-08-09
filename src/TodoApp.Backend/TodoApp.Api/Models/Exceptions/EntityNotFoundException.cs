using TodoApp.Api.Models.Common;

namespace TodoApp.Api.Models.Exceptions;

public class EntityNotFoundException<TEntity> : Exception where TEntity : IEntity
{
    public EntityNotFoundException(Guid? id = default) : base(
        $"Entity {typeof(TEntity).FullName} {(id is not null ? $" with id {id} " : "")} not found.")
    {
    }
}