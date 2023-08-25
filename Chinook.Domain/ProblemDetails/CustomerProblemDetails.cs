namespace Chinook.Domain.ProblemDetails;

public class CustomerProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? CustomerId { get; set; }
}