using credo_client.Requests;
using credo_client.Responses;
using credo_domain.Models;

namespace credo_api.Executors;

public interface ILoanCommandExecutor
{
    Task<Loan> CreateAsync(CreateLoanRequest createLoanRequest);
    Task<Loan> UpdateAsync(UpdateLoanRequest updateLoanRequest);
    Task<Loan> ApproveAsync(Guid id);
    Task<Loan> RejectAsync(Guid id);

}