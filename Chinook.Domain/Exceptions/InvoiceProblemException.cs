namespace Chinook.Domain.Exceptions;

public class InvoiceProblemException : ProblemDetailsException
{
    public int InvoiceId { get; set; }

    public InvoiceProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}