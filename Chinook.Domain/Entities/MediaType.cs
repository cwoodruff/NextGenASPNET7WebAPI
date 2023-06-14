namespace Chinook.Domain.Entities;

public partial class MediaType : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
