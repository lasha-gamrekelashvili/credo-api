using credo_api.Context;
using credo_client.Requests;
using credo_client.Responses;
using credo_domain.Models;
using credo_infrastructure.Persistence;

namespace credo_api.Executors;

public class LoanCommandExecutor : ILoanCommandExecutor
{
    private readonly ILoanRepository _loanRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserContextService _context;
    
    public LoanCommandExecutor(ILoanRepository loanRepository, IUserRepository userRepository, IUserContextService context)
    {
        _loanRepository = loanRepository;
        _userRepository = userRepository;
        _context = context;
    }

    public async Task<Loan> CreateAsync(CreateLoanRequest createLoanRequest)
    {
        var user = await _userRepository.GetById(_context.GetCurrentUserId());
        
        var loan = new Loan()
        {
            Amount = createLoanRequest.Amount,
            Period = createLoanRequest.Period,
            Status = LoanStatus.Pending,
            UserId = user.Id,
            Type = createLoanRequest.Type,
            Currency = createLoanRequest.Currency,
            User = user
        };

        await _loanRepository.AddAsync(loan);
        
        return await Task.FromResult(loan);
    }

    
    public async Task<Loan> UpdateAsync(UpdateLoanRequest updateLoanRequest)
    {
        var loan = await _loanRepository.GetById(updateLoanRequest.Id);

        if (loan.Status != LoanStatus.Pending)
        {
            throw new InvalidOperationException("Can't update approved/rejected loans.");
        }
        
        loan.Amount = updateLoanRequest.Amount;
        loan.Currency = updateLoanRequest.Currency;
        loan.Period = updateLoanRequest.Period;
        loan.Type = updateLoanRequest.Type;

        await _loanRepository.UpdateAsync(loan);

        return await Task.FromResult(loan);
    }

    public async Task<Loan> ApproveAsync(Guid id)
    {
        var loan = await _loanRepository.GetById(id);
        
        if (loan.Status != LoanStatus.Pending)
        {
            throw new BadHttpRequestException("Loan is already approved.");
        }
        
        loan.Status = LoanStatus.Approved;

        await _loanRepository.UpdateAsync(loan);

        return await Task.FromResult(loan);
    }

    public async Task<Loan> RejectAsync(Guid id)
    {
        var loan = await _loanRepository.GetById(id);
        
        if (loan.Status != LoanStatus.Pending)
        {
            throw new InvalidOperationException("Can't update approved/rejected loans.");
        }
        
        loan.Status = LoanStatus.Rejected;

        await _loanRepository.UpdateAsync(loan);

        return await Task.FromResult(loan);
    }
    
}