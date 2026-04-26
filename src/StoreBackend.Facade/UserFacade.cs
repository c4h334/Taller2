using StoreBackend.DomainService;
using StoreBackend.Dto;

namespace StoreBackend.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userService;

        public UserFacade(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            return users.Select(user => new UserDto
            {
                ExternalId = user.ExternalId,
                Username = user.Username,
                Email = user.Email
            });
        }
    }
}