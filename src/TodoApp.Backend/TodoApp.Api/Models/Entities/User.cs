using TodoApp.Api.Models.Common;

namespace TodoApp.Api.Models.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public ICollection<Task> Tasks { get; set; }

    public User(string firstName, string lastName, string username, string emailAddress, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        EmailAddress = emailAddress;
        Password = password;
    }
}