using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public partial class ArtistApiModel : BaseApiModel, IConvertModel<Artist>
{
    public string? Name { get; set; }

    public virtual ICollection<AlbumApiModel> Albums { get; set; } = new List<AlbumApiModel>();

    public Artist Convert() =>
        new()
        {
            Id = Id,
            Name = Name ?? string.Empty
        };
}