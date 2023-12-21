using credo_domain.Models;
using credo_infrastructure.Persistence.Base;

namespace credo_infrastructure.Persistence;

public interface IUserRepository : IRepository<User>
{
    
}