using credo_client.Requests;
using credo_client.Responses;
using credo_domain.Models;
using credo_infrastructure.Persistence;

namespace credo_api.Executors;

public class LoanCommandExecutor : ILoanCommandExecutor
{
    private readonly ILoanRepository _loanRepository;
    private readonly IUserRepository _userRepository;
    
    public LoanCommandExecutor(ILoanRepository loanRepository, IUserRepository userRepository)
    {
        _loanRepository = loanRepository;
        _userRepository = userRepository;
    }

    public async Task<Loan> AddLoan(CreateLoanRequest createLoanRequest)
    {
        var user = await _userRepository.GetById(createLoanRequest.UserId);
        
        var loan = new Loan()
        {
            Amount = createLoanRequest.Amount,
            Period = createLoanRequest.Period,
            Status = LoanStatus.Pending,
            UserId = createLoanRequest.UserId,
            Type = createLoanRequest.Type,
            Currency = createLoanRequest.Currency,
            User = user
        };

        await _loanRepository.AddAsync(loan);
        
        return await Task.FromResult(loan);
    }
    
    public async Task<IEnumerable<GetLoanResponseModel>> GetAll()
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
            })
            .ToList();

        return await Task.FromResult(response);
    }
}