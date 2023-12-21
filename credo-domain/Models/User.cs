using Microsoft.AspNetCore.Identity;

namespace credo_domain.Models;

public class User : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PersonalId { get; set; }
    public DateTime BirthDate { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
}