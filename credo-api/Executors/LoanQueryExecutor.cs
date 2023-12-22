using credo_api.Context;
using credo_client.Responses;
using credo_infrastructure.Persistence;

namespace credo_api.Executors;

public class LoanQueryExecutor : ILoanQueryExecutor
{
    private readonly ILoanRepository _loanRepository;


    public LoanQueryExecutor(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<IEnumerable<GetLoanResponseModel>> GetAllAsync()
    {
        var loans = await _loanRepository.GetAllAsync();

        var response = loans.Select(loan => new GetLoanResponseModel()
        {
            LoanId = loan.Id,
            UserId = loan.UserId,
            Currency = loan.Currency,
            Period = loan.Period,
            Type = loan.Type,
            Amount = loan.Amount,
            Status = loan.Status
        });

        return await Task.FromResult(response);
    }

    public async Task<IEnumerable<GetLoanResponseModel>> GetAllByUserIdAsync(Guid userId)
    {
        var loans = await _loanRepository.GetAllLoansByUserIdAsync(userId);

        var response = loans.Select(loan => new GetLoanResponseModel()
        {
            LoanId = loan.Id,
            UserId = loan.UserId,
            Currency = loan.Currency,
            Period = loan.Period,
            Type = loan.Type,
            Amount = loan.Amount,
            Status = loan.Status
        });

        return await Task.FromResult(response);
    }
}