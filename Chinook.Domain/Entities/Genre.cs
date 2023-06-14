namespace Chinook.Domain.Entities;

public partial class Genre : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
