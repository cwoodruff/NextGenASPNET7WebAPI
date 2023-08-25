using System.Net;
using System.Text.Json;
using Chinook.Domain.ApiModels;
using Chinook.Domain.Exceptions;
using Chinook.Domain.Extensions;
using Chinook.Domain.ProblemDetails;
using Chinook.Domain.Supervisor;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors("CorsPolicy")]
[ApiVersion("1.0")]
public class ArtistController : ControllerBase
{
    private readonly IChinookSupervisor _chinookSupervisor;
    private readonly ILogger<ArtistController> _logger;

    public ArtistController(IChinookSupervisor chinookSupervisor, ILogger<ArtistController> logger)
    {
        _chinookSupervisor = chinookSupervisor;
        _logger = logger;
    }

    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<PagedList<ArtistApiModel>>> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        try
        {
            var artists = await _chinookSupervisor.GetAllArtist(pageNumber, pageSize);

            if (artists.Any())
            {
                var metadata = new
                {
                    artists.TotalCount,
                    artists.PageSize,
                    artists.CurrentPage,
                    artists.TotalPages,
                    artists.HasNext,
                    artists.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
                return Ok(artists);
            }

            return StatusCode((int)HttpStatusCode.NotFound, "No Artists Could Be Found");
        }
        catch (ArtistProblemException ex)
        {
            var problemDetails = new ArtistProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/api/Artist/not-found",
                Title = "Could not find any artists",
                Detail = "Something went wrong inside the ArtistController Get All action",
                ArtistId = null,
                Instance = HttpContext.Request.Path
            };
            _logger.LogError($"{problemDetails.Detail}: {ex}");
            return new ObjectResult(problemDetails)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = 403,
            };
        }
    }

    [HttpGet("{id}", Name = "GetArtistById")]
    [Produces("application/json")]
    public async Task<ActionResult<ArtistApiModel>> Get(int id)
    {
        try
        {
            var artist = await _chinookSupervisor.GetArtistById(id);

            if (artist != null)
            {
                return Ok(artist);
            }

            return StatusCode((int)HttpStatusCode.NotFound, "Artist Not Found");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ArtistController GetById action: {ex}");
            return StatusCode((int)HttpStatusCode.InternalServerError,
                "Error occurred while executing Get Artist By Id");
        }
    }

    [HttpPost]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<ActionResult<ArtistApiModel>> Post([FromBody] ArtistApiModel input)
    {
        try
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Artist is null");
            }

            return Ok(await _chinookSupervisor.AddArtist(input));
        }
        catch (ValidationException ex)
        {
            _logger.LogError($"Something went wrong inside the ArtistController Add Artist action: {ex}");
            return StatusCode((int)HttpStatusCode.InternalServerError,
                "Error occurred while executing Add Artists");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ArtistController Add Artist action: {ex}");
            return StatusCode((int)HttpStatusCode.InternalServerError,
                "Error occurred while executing Add Artists");
        }
    }

    [HttpPut("{id}")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<ActionResult<ArtistApiModel>> Put(int id, [FromBody] ArtistApiModel input)
    {
        try
        {
            if (input == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Given Artist is null");
            }

            return Ok(await _chinookSupervisor.UpdateArtist(input));
        }
        catch (ValidationException ex)
        {
            _logger.LogError($"Something went wrong inside the ArtistController Update Artist action: {ex}");
            return StatusCode((int)HttpStatusCode.InternalServerError,
                "Error occurred while executing Update Artists");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ArtistController Update Artist action: {ex}");
            return StatusCode((int)HttpStatusCode.InternalServerError,
                "Error occurred while executing Update Artists");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            return Ok(await _chinookSupervisor.DeleteArtist(id));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside the ArtistController Delete action: {ex}");
            return StatusCode((int)HttpStatusCode.InternalServerError,
                "Error occurred while executing Delete Artist");
        }
    }
}