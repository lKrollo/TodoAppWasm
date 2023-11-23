using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class TodoEfcDao : ITodoDao
{
    private readonly TodoContext _context;

    public TodoEfcDao(TodoContext context)
    {
        _context = context;
    }

    public async Task<Todo> CreateAsync(Todo todo)
    {
        EntityEntry<Todo> added = await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        return added.Entity;
    }

    public Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task<Todo?> GetByIdAsync(int todoId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}