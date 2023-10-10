using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface ITodoLogic
{
    Task<Todo> CreateAsync(TodoCreationDto dto);
    Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchTodoParameters);
    Task UpdateAsync(TodoUpdateDto todo);
    Task DeleteAsync(int id);
}