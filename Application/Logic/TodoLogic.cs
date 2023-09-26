using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class TodoLogic : ITodoLogic
{
    private readonly ITodoDao _todoDao;
    private readonly IUserDao _userDao;

    public TodoLogic(ITodoDao todoDao, IUserDao userDao)
    {
        _todoDao = todoDao;
        _userDao = userDao;
    }
    
    public async Task<Todo> CreateAsync(TodoCreationDto dto)
    {
        User? existing = await _userDao.getByIdAsync(dto.OwnerId);
        if (existing == null)
        {
            throw new Exception($"User with id {dto.OwnerId} was not found.");
        }

        ValidateTodo(dto);
        Todo todo = new Todo(existing, dto.Title);
        Todo created = await _todoDao.CreateAsync(todo);
        return created;
    }

    public Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchTodoParameters)
    {
        return _todoDao.GetAsync(searchTodoParameters);
    }

    private void ValidateTodo(TodoCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }
}