namespace Chinook.Domain.Exceptions;

public class MediaTypeProblemException : ProblemDetailsException
{
    public int MediaTypeId { get; set; }

    public MediaTypeProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}