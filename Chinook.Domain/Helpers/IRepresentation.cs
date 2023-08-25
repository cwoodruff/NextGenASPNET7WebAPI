namespace Chinook.Domain.Helpers;

public interface IRepresentation
{
    List<Link> Links { get; set; }
    Representation AddLink(Link link);
}