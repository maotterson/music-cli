using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SpotCli.WebApi.Api.Controllers;

[ApiController]
[Route("rating/")]
public class RatingController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("hello world");
    }
}
