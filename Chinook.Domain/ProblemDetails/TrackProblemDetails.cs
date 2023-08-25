namespace Chinook.Domain.ProblemDetails;

public class TrackProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? TrackId { get; set; }
}