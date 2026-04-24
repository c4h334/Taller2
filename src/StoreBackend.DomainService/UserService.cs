using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Infrastructure.Repositories;

namespace StoreBackend.DomainService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();


        var activeUsers = users
            .Where(u => !string.IsNullOrWhiteSpace(u.Email))
            .ToList();

        return activeUsers.Select(u => new UserDto
        {
            ExternalId = u.ExternalId,
            Username = u.Username,
            Email = u.Email
        }).ToList();
    }
}