using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}