using credo_api.Context;
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
    public async Task<ActionResult<Loan>> CreateAsync([FromServices] ILoanCommandExecutor loanCommandExecutor,CreateLoanRequest request)
    {
        return Ok(await loanCommandExecutor.CreateAsync(request));
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<GetLoanResponseModel>>> GetAllAsync([FromServices] ILoanQueryExecutor loanQueryExecutor)
    {
        return Ok(await loanQueryExecutor.GetAllAsync());
    }
    
    [HttpGet("all/me")]
    public async Task<ActionResult<IEnumerable<GetLoanResponseModel>>> GetAllLoanForCurrentUserAsync(
        [FromServices] ILoanQueryExecutor loanQueryExecutor, [FromServices] IUserContextService ctx)
    {
        return Ok(await loanQueryExecutor.GetAllByUserIdAsync(ctx.GetCurrentUserId()));
    }
    
    [HttpPut]
    public async Task<ActionResult<IEnumerable<GetLoanResponseModel>>> UpdateAsync(
        [FromServices] ILoanCommandExecutor loanCommandExecutor, UpdateLoanRequest updateLoanRequest)
    {
        return Ok(await loanCommandExecutor.UpdateAsync(updateLoanRequest));
    }
    
    [HttpPost("approve")]
    public async Task<ActionResult<IEnumerable<GetLoanResponseModel>>> ApproveAsync(
        [FromServices] ILoanCommandExecutor loanCommandExecutor, Guid id)
    {
        return Ok(await loanCommandExecutor.ApproveAsync(id));
    }
    
    [HttpPost("reject")]
    public async Task<ActionResult<IEnumerable<GetLoanResponseModel>>> RejectAsync(
        [FromServices] ILoanCommandExecutor loanCommandExecutor, Guid id)
    {
        return Ok(await loanCommandExecutor.RejectAsync(id));
    }
}