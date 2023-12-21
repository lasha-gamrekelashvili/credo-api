using credo_domain.Models;
using credo_infrastructure.Persistence.Base;
using credo_infrastructure.Persistence.Context;

namespace credo_infrastructure.Persistence;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}