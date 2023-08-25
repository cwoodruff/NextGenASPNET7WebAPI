namespace Chinook.Domain.ProblemDetails;

public class AlbumProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? AlbumId { get; set; }
}