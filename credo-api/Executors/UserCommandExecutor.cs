using credo_api.Auth;
using credo_client.Requests;
using credo_domain.Models;
using credo_infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace credo_api.Executors;

public class UserCommandExecutor : IUserCommandExecutor
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;

    public UserCommandExecutor(IUserRepository userRepository, ITokenService tokenService, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<(User user, string token)> AddUser(CreateUserRequest createUserRequest)
    {
        var user = new User
        {
            UserName = createUserRequest.Username,
            Name = createUserRequest.Name,
            Surname = createUserRequest.Surname,
            PersonalId = createUserRequest.PersonalId,
            BirthDate = createUserRequest.BirthDate,
        };

        var createUserResult = await _userManager.CreateAsync(user, createUserRequest.Password);

        if (!createUserResult.Succeeded)
        {
            var errors = createUserResult.Errors.Select(e => e.Description).ToList();
            throw new InvalidOperationException("User creation failed: " + string.Join(", ", errors));
        }
        
        var token = _tokenService.GenerateJwtToken(user);

        return (user, token);
    }

}