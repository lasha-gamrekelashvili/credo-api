using credo_domain.Models;
using credo_infrastructure.Persistence.Base;

namespace credo_infrastructure.Persistence;

public interface ILoanRepository : IRepository<Loan>
{
    Task<List<Loan>> GetAllWithUsersAsync();
    Task<List<Loan>> GetAllLoansByUserIdAsync(Guid userId);
}