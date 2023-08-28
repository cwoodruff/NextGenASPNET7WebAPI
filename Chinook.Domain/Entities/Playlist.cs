using Chinook.Domain.ApiModels;
using Chinook.Domain.Converters;

namespace Chinook.Domain.Entities;

public partial class Playlist : BaseEntity, IConvertModel<PlaylistApiModel>
{
    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public PlaylistApiModel Convert() =>
        new()
        {
            Id = Id,
            Name = Name
        };
}