namespace Chinook.Domain.Exceptions;

public class PlaylistProblemException : ProblemDetailsException
{
    public int PlaylistId { get; set; }

    public PlaylistProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}