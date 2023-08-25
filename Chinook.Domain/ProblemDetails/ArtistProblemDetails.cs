namespace Chinook.Domain.ProblemDetails;

public class ArtistProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? ArtistId { get; set; }
}