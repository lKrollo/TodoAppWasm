using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{

    private readonly HttpClient client;
    public Task<User> Create(UserCreationDto dto)
    {
        throw new NotImplementedException();
    }
}