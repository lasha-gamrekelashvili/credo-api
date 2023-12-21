using credo_api.Executors;
using credo_client.Requests;
using Microsoft.AspNetCore.Mvc;

namespace credo_api.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController : ControllerBase
{
    
    [HttpPost("register")]
    public async Task<ActionResult> CreateUser([FromServices] IUserCommandExecutor userCommandExecutor,CreateUserRequest request)
    {
        var (user, token) = await userCommandExecutor.AddUser(request);

        var result = new
        {
            User = user, 
            Token = token 
        };
        
        return Ok(result);
    }
}