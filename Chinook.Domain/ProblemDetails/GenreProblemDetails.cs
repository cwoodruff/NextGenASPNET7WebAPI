namespace Chinook.Domain.ProblemDetails;

public class GenreProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? GenreId { get; set; }
}