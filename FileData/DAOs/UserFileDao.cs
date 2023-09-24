using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext _context;

    public UserFileDao(FileContext context)
    {
        _context = context;
    }


    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUsernameAsync(string Username)
    {
        throw new NotImplementedException();
    }
}