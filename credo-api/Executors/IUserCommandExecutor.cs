using credo_client.Requests;
using credo_domain.Models;

namespace credo_api.Executors;

public interface IUserCommandExecutor
{
    Task<(User user, string token)> AddUser(CreateUserRequest createUserRequest);
}