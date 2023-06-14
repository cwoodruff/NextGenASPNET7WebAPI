namespace Chinook.Domain.Entities;

public partial class Playlist : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
