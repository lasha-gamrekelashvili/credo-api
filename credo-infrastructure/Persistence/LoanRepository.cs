using credo_domain.Models;
using credo_infrastructure.Persistence.Base;
using credo_infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace credo_infrastructure.Persistence;

public class LoanRepository : Repository<Loan>, ILoanRepository
{
    private readonly ApplicationDbContext _context;

    public LoanRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<Loan>> GetAllWithUsersAsync()
    {
        return await DbSet.Include(entity => entity.User).ToListAsync();
    }
    
}