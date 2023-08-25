namespace Chinook.Domain.ProblemDetails;

public class InvoiceLineProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? InvoiceLineId { get; set; }
}