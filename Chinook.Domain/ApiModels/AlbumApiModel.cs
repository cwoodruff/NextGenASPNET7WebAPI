using Chinook.Domain.Converters;
using Chinook.Domain.Entities;

namespace Chinook.Domain.ApiModels;

public partial class AlbumApiModel : BaseApiModel, IConvertModel<Album>
{
    public string Title { get; set; } = null!;
    public string? ArtistName { get; set; }
    public int? ArtistId { get; set; }
    public virtual ArtistApiModel Artist { get; set; } = null!;
    public virtual ICollection<TrackApiModel> Tracks { get; set; } = new List<TrackApiModel>();

    public Album Convert() =>
        new()
        {
            Id = Id,
            ArtistId = ArtistId,
            Title = Title ?? string.Empty
        };
}