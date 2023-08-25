namespace Chinook.Domain.Exceptions;

public class EmployeeProblemException : ProblemDetailsException
{
    public int EmployeeId { get; set; }

    public EmployeeProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}