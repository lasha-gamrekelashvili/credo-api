using credo_api.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace credo_api.Controllers;

[ApiController]
[Route("/api/health-check")]
public class HealthcheckController : ControllerBase
{
    [HttpGet]
    public string Healthcheck()
    {
        return "ok";
    }
    
    [HttpGet("/authorized")]
    [Authorize]
    public Guid AuthorizedHealthCheck([FromServices] IUserContextService userContextService)
    {
        return userContextService.GetCurrentUserId();
    }
}