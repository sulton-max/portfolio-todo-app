using System.ComponentModel;

namespace TodoApp.Api.Models.Common;

public enum TaskItemStatus
{
    [Description("To Do")] ToDo,
    [Description("In Progress")] InProgress,
    [Description("Pending")] Pending,
    [Description("Done")] Done,
}