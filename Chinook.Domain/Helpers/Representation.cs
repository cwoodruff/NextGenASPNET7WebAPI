namespace Chinook.Domain.Helpers;

public abstract class Representation : IRepresentation
{
    public List<Link> Links { get; set; } = new List<Link>();

    public Representation AddLink(Link link)
    {
        var exists = Links.FirstOrDefault(x => x.Id == link.Id);
        if (exists != null)
        {
            Links.Remove(exists);
        } 
        
        Links.Add(link);
        return this;
    }
}