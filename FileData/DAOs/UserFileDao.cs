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
        int userId = 1;
        if (_context.Users.Any())
        {
            userId = _context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        _context.Users.Add(user);
        _context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = _context.Users.FirstOrDefault(u =>
            u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }
}