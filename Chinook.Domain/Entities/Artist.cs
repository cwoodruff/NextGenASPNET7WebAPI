namespace Chinook.Domain.Entities;

public partial class Artist : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
