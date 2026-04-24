using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsersAsync();
}

