using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Todo
{
    [Key]
    public int Id { get; set; }
    public User Owner { get; private set; }
    
    [Range(4, 15)]
    public string Title { get; private set; }

    public bool IsCompleted { get; set; }

    public Todo(User owner, string title)
    {
        Owner = owner;
        Title = title;
    }

    private Todo(){}
}