namespace Chinook.Domain.Exceptions;

public class TrackProblemException : ProblemDetailsException
{
    public int TrackId { get; set; }

    public TrackProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}