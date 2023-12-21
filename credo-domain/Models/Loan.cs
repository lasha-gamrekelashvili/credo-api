using credo_domain.Models.Base;

namespace credo_domain.Models;

public class Loan : BaseModel
{
    public decimal Amount { get; set; }

    public int Period { get; set; }
    
    public string Currency { get; set; }

    public LoanStatus Status { get; set; }

    public LoanType Type { get; set; }
    
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
}

public enum LoanStatus
{
    Pending,
    Approved,
    Rejected
}

public enum LoanType
{
    Fast,
    Auto,
    Installment
}