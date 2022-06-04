using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SpotCli.WebApi.Api.Repositories;
using System.Text.Json;

namespace SpotCli.WebApi.Api.Controllers;

[ApiController]
[Route("/")]
public class RatingController : ControllerBase
{
    private readonly IRatingRepository _ratingRepository;

    public RatingController(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var trackRatings = await _ratingRepository.GetAll();
        return Ok(JsonSerializer.Serialize(trackRatings));
    }
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        return Ok("hello world");
    }
}
