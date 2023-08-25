namespace Chinook.Domain.ProblemDetails;

public class PlaylistProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? PlaylistId { get; set; }
}