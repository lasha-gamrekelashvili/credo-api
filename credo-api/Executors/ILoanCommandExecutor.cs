using credo_client.Requests;
using credo_client.Responses;
using credo_domain.Models;

namespace credo_api.Executors;

public interface ILoanCommandExecutor
{
    Task<Loan> AddLoan(CreateLoanRequest createLoanRequest);

    Task<IEnumerable<GetLoanResponseModel>> GetAll();
}