namespace Chinook.Domain.Exceptions;

public class ArtistProblemException : ProblemDetailsException
{
    public int ArtistId { get; set; }

    public ArtistProblemException(int status, string type, string title, string detail, string instance)
    {
        Status = status;
        Type = type;
        Title = title;
        Detail = detail;
        Instance = instance;
    }
}