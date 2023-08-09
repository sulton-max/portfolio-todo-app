using TodoApp.Api.Models.Common;

namespace TodoApp.Api.Models.Entities;

public class TaskItem : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskItemStatus Status { get; set; }
    public string Tags { get; set; }
    public Guid UserId { get; set; }

    public TaskItem(string name, string description, DateTime dueDate)
    {
        Name = name;
        Description = description;
        DueDate = dueDate;

        Status = TaskItemStatus.ToDo;
        Tags = string.Empty;
    }
}