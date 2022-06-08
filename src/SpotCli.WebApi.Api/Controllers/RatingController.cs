using Microsoft.AspNetCore.Mvc;
using SpotCli.Core.Exceptions;
using SpotCli.WebApi.Api.Common;
using SpotCli.WebApi.Api.Data.Requests;
using SpotCli.WebApi.Api.Repositories;
using SpotCli.WebApi.Api.Services;
using System.Text.Json;

namespace SpotCli.WebApi.Api.Controllers;

[ApiController]
[Route("/")]
public class RatingController : ControllerBase
{
    private readonly IRatingService _ratingService;

    public RatingController(IRatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var trackRatings = await _ratingService.GetAll();
        var response = trackRatings.Select(rating =>
        {
            return rating.AsTrackRatingResponse();
        });
        return Ok(JsonSerializer.Serialize(response));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            var trackRating = await _ratingService.GetById(id);
            return Ok(JsonSerializer.Serialize(trackRating.AsTrackRatingResponse()));
        }
        catch (TrackNotFoundException ex)
        {
            return NotFound(JsonSerializer.Serialize(ex.Message));
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, ModifyTrackRatingRequest request)
    {
        try
        {
            await _ratingService.Modify(request, id);
            return Ok();
        }
        catch (TrackNotFoundException ex)
        {
            return NotFound(JsonSerializer.Serialize(ex.Message));
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _ratingService.Delete(id);
            return Ok();
        }
        catch(TrackNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch
        {
            return BadRequest();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateTrackRatingRequest request)
    {
        try
        {
            await _ratingService.Create(request);
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}
