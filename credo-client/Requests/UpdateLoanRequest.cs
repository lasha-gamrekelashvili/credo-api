using credo_domain.Models;

namespace credo_client.Requests;

public class UpdateLoanRequest
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public int Period { get; set; }
    public string Currency { get; set; }
    public LoanType Type { get; set; }
}