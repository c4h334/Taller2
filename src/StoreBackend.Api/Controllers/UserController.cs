using Microsoft.AspNetCore.Mvc;
using StoreBackend.Api.Mappers;
using StoreBackend.Facade;

namespace StoreBackend.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserFacade _userFacade;

    public UserController(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var usersDto = await _userFacade.GetAllUsersAsync();
        var response = UserMapper.ToModel(usersDto.ToList());
        return Ok(response);
    }
}