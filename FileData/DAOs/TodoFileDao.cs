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

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            todos = todos.Where(t =>
                t.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }
        return Task.FromResult(todos);
    }

    public Task UpdateAsync(Todo toUpdate)
    {
        Todo? existing = _context.Todos.FirstOrDefault(todo => todo.Id == toUpdate.Id);
        if (existing == null)
        {
            throw new Exception($"Todo with id {toUpdate.Id} does not exist!");
        }

        _context.Todos.Remove(existing);
        _context.Todos.Add(toUpdate);
    
        _context.SaveChanges();
    
        return Task.CompletedTask;
    }

    public Task<Todo> GetByIdAsync(int id)
    {
        Todo? existing = _context.Todos.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(existing);
    }

    public Task DeleteAsync(int id)
    {
        Todo? existing = _context.Todos.FirstOrDefault(todo => todo.Id == id);
        if (existing == null)
        {
            throw new Exception($"Todo with id {id} does not exist!");
        }

        _context.Todos.Remove(existing); 
        _context.SaveChanges();
    
        return Task.CompletedTask;
    }
}