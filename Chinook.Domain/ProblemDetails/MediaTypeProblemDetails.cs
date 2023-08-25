namespace Chinook.Domain.ProblemDetails;

public class MediaTypeProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? MediaTypeId { get; set; }
}