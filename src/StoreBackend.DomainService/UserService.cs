using StoreBackend.Domain.Entities;
using StoreBackend.Infrastructure;

namespace StoreBackend.DomainService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();

            // Aquí va la regla de negocio si el profe la pide

            return users;
        }
    }
}