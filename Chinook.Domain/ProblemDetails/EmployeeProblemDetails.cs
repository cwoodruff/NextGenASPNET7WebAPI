namespace Chinook.Domain.ProblemDetails;

public class EmployeeProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? EmployeeId { get; set; }
}