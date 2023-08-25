namespace Chinook.Domain.Exceptions;

public class InvoiceLineProblemException : ProblemDetailsException
{
    public int InvoiceLineId { get; set; }

    public InvoiceLineProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}