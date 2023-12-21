using credo_api.Executors;
using credo_client.Requests;
using credo_client.Responses;
using credo_domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace credo_api.Controllers;

[ApiController]
[Route("/api/loan")]
[Authorize]
public class LoanController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Loan>> CreateLoan([FromServices] ILoanCommandExecutor loanCommandExecutor,CreateLoanRequest request)
    {
        return Ok(await loanCommandExecutor.AddLoan(request));
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetLoanResponseModel>>> GetAll([FromServices] ILoanCommandExecutor loanCommandExecutor)
    {
        return Ok(await loanCommandExecutor.GetAll());
    }
}