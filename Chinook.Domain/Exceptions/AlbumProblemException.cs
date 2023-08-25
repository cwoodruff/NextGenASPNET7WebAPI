namespace Chinook.Domain.Exceptions;

public class AlbumProblemException : ProblemDetailsException
{
    public int AlbumId { get; set; }

    public AlbumProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}