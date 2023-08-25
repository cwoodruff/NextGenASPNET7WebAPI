namespace Chinook.Domain.Exceptions;

public class CustomerProblemException : ProblemDetailsException
{
    public int CustomerId { get; set; }

    public CustomerProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}