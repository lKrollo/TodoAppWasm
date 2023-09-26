using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class TodoFileDao : ITodoDao
{
    private readonly FileContext _context;

    public TodoFileDao(FileContext context)
    {
        _context = context;
    }

    public Task<Todo> CreateAsync(Todo todo)
    {
        int todoId = 1;
        if (_context.Todos.Any())
        {
            todoId = _context.Todos.Max(t => t.Id);
            todoId++;
        }

        todo.Id = todoId;
        
        _context.Todos.Add(todo);
        _context.SaveChanges();

        return Task.FromResult(todo);
    }

    public Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters)
    {
        IEnumerable<Todo> todos = _context.Todos.AsEnumerable();
       
        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            todos = _context.Todos.Where(t => 
                t.Owner.UserName.Equals(searchParameters.Username, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.UserId != null)
        {
            todos = todos.Where(t =>
                t.Id == searchParameters.UserId);
        }

        if (searchParameters.CompletedStatus != null)
        {
            todos = todos.Where(t =>
                t.IsCompleted == searchParameters.CompletedStatus);
        }

        if (!string.IsNullOrEmpty(searchParameters.TitleContains)){}
        {
            todos = todos.Where(t =>
                t.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }
        return Task.FromResult(todos);
    }
}