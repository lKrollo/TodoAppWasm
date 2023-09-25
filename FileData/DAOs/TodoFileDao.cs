using Application.DaoInterfaces;
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
}