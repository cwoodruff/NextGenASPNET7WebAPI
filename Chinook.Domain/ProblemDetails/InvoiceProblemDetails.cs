namespace Chinook.Domain.ProblemDetails;

public class InvoiceProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public int? InvoiceId { get; set; }
}