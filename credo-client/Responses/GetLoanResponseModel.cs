using credo_domain.Models;

namespace credo_client.Responses;

public class GetLoanResponseModel
{
    public Guid LoanId { get; set; }
    public Guid UserId { get; set; }
    public string Currency { get; set; }
    public LoanStatus Status { get; set; }
    public LoanType Type { get; set; }
    public int Period { get; set; }
    public decimal Amount { get; set; }
}