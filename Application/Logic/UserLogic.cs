using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserLogic userDao;
    
    public Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }
}